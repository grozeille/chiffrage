using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Events
{
    public class HardwareCreatedEvent : ICatalogEvent
    {
        private readonly int catalogId;
        private readonly int hardwareId;

        public HardwareCreatedEvent(int catalogId, int hardwareId)
        {
            this.catalogId = catalogId;
            this.hardwareId = hardwareId;
        }

        public int HardwareId
        {
            get { return this.hardwareId; }
        }

        public int CatalogId
        {
            get { return this.catalogId; }
        }
    }
}
