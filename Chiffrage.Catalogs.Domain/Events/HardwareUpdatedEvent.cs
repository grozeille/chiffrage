using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Events
{
    public class HardwareUpdatedEvent : IEvent
    {
        private readonly int catalogId;
        private readonly Hardware hardware;

        public HardwareUpdatedEvent(int catalogId, Hardware hardware)
        {
            this.catalogId = catalogId;
            this.hardware = hardware;
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
