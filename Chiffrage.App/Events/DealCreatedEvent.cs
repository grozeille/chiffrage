using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Projects.Domain;
using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
{
    public class DealCreatedEvent : IEvent
    {
        private readonly Deal newDeal;

        public DealCreatedEvent(Deal newDeal)
        {
            this.newDeal = newDeal;
        }

        public Deal NewDeal
        {
            get { return this.newDeal; }
        }
    }
}
