using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
{
    public class NewProjectEvent : IEvent
    {
        public int DealId { get; private set; }

        public NewProjectEvent(int dealId)
        {
            this.DealId = dealId;
        }
    }
}
