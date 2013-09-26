using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Events
{
    public class HardwareSupplyCreatedEvent : ICatalogEvent
    {
        private readonly int catalogId;
        private readonly int hardwareId;
        private readonly int componentId;

        public HardwareSupplyCreatedEvent(int catalogId, int hardwareId, int componentId)
        {
            this.catalogId = catalogId;
            this.hardwareId = hardwareId;
            this.componentId = componentId;
        }

        public int ComponentId
        {
            get { return this.componentId; }
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
