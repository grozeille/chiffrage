using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Sample.Commands;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Sample.Events;

namespace Chiffrage.Mvc.Sample.Services
{
    public class Service :
        IEventHandler<MessageCommand>
    {
        public EventBroker EventBroker { get; set; }

        public void  ProcessAction(MessageCommand eventObject)
        {
            EventBroker.Publish(new MessageReceivedEvent
               {
                   Value = eventObject.Value,
                   Date = DateTime.Now
               });
        }
    }
}
