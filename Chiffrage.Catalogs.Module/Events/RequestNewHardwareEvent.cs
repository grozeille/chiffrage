using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
{
    public class RequestNewHardwareEvent : IEvent
    {
        private readonly int catalogId;

        public RequestNewHardwareEvent(int catalogId)
        {
            this.catalogId = catalogId;
        }

        public int CatalogId
        {
            get { return this.catalogId; }
        }
    }
}
