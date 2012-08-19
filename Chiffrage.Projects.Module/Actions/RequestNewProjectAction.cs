using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Module.Actions
{
    public class RequestNewProjectAction : IEvent
    {
        public int DealId { get; private set; }

        public RequestNewProjectAction(int dealId)
        {
            this.DealId = dealId;
        }
    }
}
