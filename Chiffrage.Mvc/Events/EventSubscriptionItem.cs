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
        public EventSubscriptionItem(Type eventType, object eventHandler, MethodInfo method, bool threadUI)
        {
            this.EventHandler = eventHandler;
            this.Method = method;
            this.ThreadUI = threadUI;
            this.EventType = eventType;
        }

        public object EventHandler { get; private set; }

        public MethodInfo Method { get; private set; }

        public Type EventType { get; private set; }

        public bool ThreadUI { get; private set; }
    }
}
