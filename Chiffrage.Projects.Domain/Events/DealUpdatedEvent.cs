using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using Chiffrage.Projects.Domain;

namespace Chiffrage.Projects.Domain.Events
{
    public class DealUpdatedEvent : IDealEvent
    {
        private readonly int dealId;

        public DealUpdatedEvent(int dealId)
        {
            this.dealId = dealId;
        }

        public int DealId
        {
            get { return this.dealId; }
        }
    }
}
