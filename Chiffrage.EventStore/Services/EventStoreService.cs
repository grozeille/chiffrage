using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using Chiffrage.EventStore.Repositories;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Services;
using Newtonsoft.Json;

namespace Chiffrage.EventStore.Services
{
    public class EventStoreService : IService
    {
        private readonly JsonSerializer serializer;

        private readonly IEventRepository eventRepository;

        public EventStoreService(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
            serializer = JsonSerializer.Create(new JsonSerializerSettings
            {
                Formatting = Formatting.None
            });    
        }

        [Subscribe(Topic = "topic://events")]
        public void ProcessAction(Object eventObject)
        {
            var memoryStream = new MemoryStream();
            var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress);
            var writer = new StreamWriter(gzipStream);

            serializer.Serialize(writer, eventObject);

            var obj = new EventObject {MessageType = eventObject.GetType().FullName, MessageBody = memoryStream.ToArray()};

            eventRepository.Save(obj);
        }
    }
}
