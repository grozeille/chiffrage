using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Mvc.Events
{
    [AttributeUsage(AttributeTargets.Event)]
    public class PublishAttribute : Attribute
    {
        public string Topic { get; set; }

        public PublishAttribute()
        {
            this.Topic = "topic://default";
        }
    }
}
