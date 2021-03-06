﻿using System;
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
        public EventSubscriptionItem(Type eventType, object eventHandler, Action<object, object> method, SubscriptionMode subscriptionMode, String topic)
        {
            this.EventHandler = eventHandler;
            this.Method = method;
            this.SubscriptionMode = subscriptionMode;
            this.EventType = eventType;
            this.Topic = topic;
        }

        public object EventHandler { get; private set; }

        public Action<object, object> Method { get; private set; }

        public Type EventType { get; private set; }

        public SubscriptionMode SubscriptionMode { get; private set; }

        public string Topic { get; private set; }
    }
}
