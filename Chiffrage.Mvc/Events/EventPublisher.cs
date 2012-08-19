using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Mvc.Events
{
    public class EventPublisher<T>
    {
        private IEventBroker eventBroker;

        public EventPublisher(IEventBroker eventBroker)
        {
            this.eventBroker = eventBroker;
        }

        public void Publish(T message)
        {
            this.eventBroker.Publish(message);
        }
    }
}
