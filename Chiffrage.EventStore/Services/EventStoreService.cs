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

namespace Chiffrage.EventStore.Services
{
    public class EventStoreService : IService
    {
        private readonly JsonSerializer serializer;

        private readonly IEventRepository eventRepository;

        private readonly string sessionId;

        private readonly object mylock = new object();

        private readonly IList<object> blacklist = new List<object>();

        [Publish(Topic = "topic://events")]
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
            //thread.Start();
        }

        private void Start()
        {
            int maxId = 0;

            var typeCache = new Dictionary<string, Type>();

            while(true)
            {
                Thread.Sleep(3*1000);

                var items = this.eventRepository.FindFromOtherSession(sessionId, maxId);
                if (items.Count > 0)
                {
                    maxId = items.Last().Id;
                    lock (mylock)
                    {
                        foreach (var item in items)
                        {
                            var memoryStream = new MemoryStream(item.MessageBody);
                            var gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress);
                            var reader = new StreamReader(gzipStream);

                            Type type = null;
                            if(!typeCache.TryGetValue(item.MessageType, out type))
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

        //[Subscribe(Topic = "topic://events")]
        public void ProcessAction(Object eventObject)
        {
            lock (mylock)
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
