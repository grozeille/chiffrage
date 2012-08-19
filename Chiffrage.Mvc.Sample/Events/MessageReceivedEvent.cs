using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Mvc.Sample.Events
{
    public class MessageReceivedEvent : IEvent
    {
        public DateTime Date { get; set; }

        public string Value { get; set; }
    }
}
