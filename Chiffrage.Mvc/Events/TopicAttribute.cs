using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Mvc.Events
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class TopicAttribute : Attribute
    {
        public string Topic { get; set; }

        public TopicAttribute(string topic)
        {
            this.Topic = topic;
        }
    }
}
