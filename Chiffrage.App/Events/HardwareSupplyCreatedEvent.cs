using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
{
    public class HardwareSupplyCreatedEvent : IEvent
    {
        private readonly int catalogId;
        private readonly int hardwareId;
        private readonly HardwareSupply component;

        public HardwareSupplyCreatedEvent(int catalogId, int hardwareId, HardwareSupply component)
        {
            this.catalogId = catalogId;
            this.hardwareId = hardwareId;
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

        public int HardwareId
        {
            get { return this.hardwareId; }
        }
    }
}
