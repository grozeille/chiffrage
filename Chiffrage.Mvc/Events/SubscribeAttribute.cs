using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Mvc.Events
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SubscribeAttribute : Attribute
    {
        public string Topic { get; set; }

        public SubscriptionMode SubscriptionMode { get; set; }

        public SubscribeAttribute()
        {
            this.Topic = "topic://default";
            this.SubscriptionMode = SubscriptionMode.Default;
        }
    }
}
