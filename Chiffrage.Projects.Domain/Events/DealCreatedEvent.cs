using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Projects.Domain;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Events
{
    public class DealCreatedEvent : IDealEvent
    {
        private readonly int dealId;

        public DealCreatedEvent(int dealId)
        {
            this.dealId = dealId;
        }

        public int DealId
        {
            get { return this.dealId; }
        }
    }
}
