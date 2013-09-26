using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Mvc.Events
{
    public class EventPublisher<T>
    {
        private IEventBroker eventBroker;

        private string topic;

        public EventPublisher(IEventBroker eventBroker, string topic)
        {
            this.eventBroker = eventBroker;
            this.topic = topic;
        }

        public void Publish(T message)
        {
            this.eventBroker.Publish(message, topic);
        }
    }
}
