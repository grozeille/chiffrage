using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Module.Events
{
    public class RequestNewHardwareSupplyEvent : IEvent
    {
        private readonly int catalogId;

        private readonly int hardwareId;

        public RequestNewHardwareSupplyEvent(int catalogId, int hardwareId)
        {
            this.catalogId = catalogId;
            this.hardwareId = hardwareId;
        }

        public int CatalogId
        {
            get { return this.catalogId; }
        }

        public int HardwareId
        {
            get { return this.hardwareId; }
        }
    }
}
