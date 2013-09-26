using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Domain.Events
{
    public class DealDeletedEvent : IDealEvent
    {
        private readonly int dealId;

        public DealDeletedEvent(int dealId)
        {
            this.dealId = dealId;
        }

        public int DealId
        {
            get { return this.dealId; }
        }
    }
}
