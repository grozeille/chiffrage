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

        public bool ThreadUI { get; set; }

        public SubscribeAttribute()
        {
            this.Topic = "topic://default";
        }
    }
}
