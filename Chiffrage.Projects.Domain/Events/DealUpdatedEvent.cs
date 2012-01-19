using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using Chiffrage.Projects.Domain;

namespace Chiffrage.Projects.Domain.Events
{
    public class DealUpdatedEvent : IEvent
    {
        public Deal NewDeal { get; private set; }

        public DealUpdatedEvent(Deal newDeal)
        {
            this.NewDeal = newDeal;
        }
    }
}
