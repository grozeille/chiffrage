using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;
using Common.Logging;

namespace Chiffrage.Mvc.Events
{
    public class EventSubscriptionItem
    {
        private readonly BlockingQueue<IEvent> eventQueue = new BlockingQueue<IEvent>(Int32.MaxValue);

        public EventSubscriptionItem(IEventHandler eventHandler, MethodInfo method)
        {
            this.EventHandler = eventHandler;
            this.Method = method;
        }

        public IEventHandler EventHandler { get; private set; }

        public MethodInfo Method { get; private set; }
    }
}
