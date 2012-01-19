using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Events
{
    public class HardwareSupplyCreatedEvent : IEvent
    {
        private readonly int catalogId;
        private readonly Hardware hardware;
        private readonly HardwareSupply component;

        public HardwareSupplyCreatedEvent(int catalogId, Hardware hardware, HardwareSupply component)
        {
            this.catalogId = catalogId;
            this.hardware = hardware;
            this.component = component;
        }

        public HardwareSupply Component
        {
            get { return this.component; }
        }

        public int CatalogId
        {
            get { return this.catalogId; }
        }

        public Hardware Hardware
        {
            get { return this.hardware; }
        }
    }
}
