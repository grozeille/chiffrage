using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using Chiffrage.EventStore.Repositories;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Services;
using Newtonsoft.Json;
using System.Threading;
using System.Diagnostics;

namespace Chiffrage.EventStore.Services
{
    public class EventStoreService : IService
    {
        private readonly JsonSerializer serializer;

        private readonly IEventRepository eventRepository;

        private readonly string sessionId;

        private readonly object blacklistLock = new object();

        private readonly object repositoryLock = new object();

        private readonly IList<object> blacklist = new List<object>();

        [Publish(Topic = Topics.EVENTS)]
        public event Action<Object> OnEvent;

        public EventStoreService(IEventRepository eventRepository)
        {
            this.sessionId = Guid.NewGuid().ToString();
            this.eventRepository = eventRepository;
            serializer = JsonSerializer.Create(new JsonSerializerSettings
            {
                Formatting = Formatting.None
            });

            var thread = new Thread(Start);
            thread.Name = "EventStoreServicePolling";
            thread.IsBackground = true;
            thread.Start();

            thread = new Thread(Clean);
            thread.Name = "EventStoreServiceCleaning";
            thread.IsBackground = true;
            thread.Start();
        }

        private void Start()
        {
            long maxId = 0;

            var typeCache = new Dictionary<string, Type>();

            IList<EventObject> items;

            // start reading messages from the last one
            lock (repositoryLock)
            {
                items = this.eventRepository.FindFromOtherSession(sessionId, maxId);
                maxId = items.Count > 0 ? items.Last().Id : 0;
            }

            while(true)
            {
                Thread.Sleep(3*1000);

                lock (repositoryLock)
                {
                    items = this.eventRepository.FindFromOtherSession(sessionId, maxId);
                    if (items.Count > 0)
                    {
                        maxId = items.Last().Id;
                        lock (blacklistLock)
                        {
                            foreach (var item in items)
                            {
                                var memoryStream = new MemoryStream(item.MessageBody);
                                var gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress);
                                var reader = new StreamReader(gzipStream);

                                Type type = null;
                                if (!typeCache.TryGetValue(item.MessageType, out type))
                                {
                                    type = Type.GetType(item.MessageType);
                                    typeCache.Add(item.MessageType, type);
                                }

                                //var json = reader.ReadToEnd();
                                //var obj = serializer.Deserialize(new StringReader(json), type);
                                var obj = serializer.Deserialize(reader, type);

                                blacklist.Add(obj);

                                OnEvent(obj);
                            }
                        }
                    }
                }
            }
        }

        private void Clean()
        {
            var rand = new Random(Process.GetCurrentProcess().Id);
            while (true)
            {
                Thread.Sleep(60 * (5 + rand.Next(3)) * 1000);

                lock (repositoryLock)
                {
                    eventRepository.CleanOldEvents(100);   
                }
            }
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(Object eventObject)
        {
            lock (blacklistLock)
            {
                if(blacklist.Contains(eventObject))
                {
                    blacklist.Remove(eventObject);
                    return;
                }
            }

            var memoryStream = new MemoryStream();
            var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress);
            var writer = new StreamWriter(gzipStream);

            serializer.Serialize(writer, eventObject);

            writer.Flush();
            gzipStream.Flush();
            memoryStream.Flush();

            writer.Close();
            gzipStream.Close();
            memoryStream.Close();

            var obj = new EventObject { MessageType = eventObject.GetType().AssemblyQualifiedName, MessageBody = memoryStream.ToArray(), SessionId = sessionId };

            eventRepository.Save(obj);
        }


    }
}
