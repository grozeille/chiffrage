using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Module.Events
{
    public class RequestNewProjectEvent : IEvent
    {
        public int DealId { get; private set; }

        public RequestNewProjectEvent(int dealId)
        {
            this.DealId = dealId;
        }
    }
}
