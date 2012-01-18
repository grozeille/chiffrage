using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.Catalogs.Domain.Events
{
    public class HardwareDeletedEvent  : IEvent
    {
        private readonly int catalogId;
        private readonly Hardware hardware;

        public HardwareDeletedEvent(int catalogId, Hardware hardware)
        {
            this.catalogId = catalogId;
            this.hardware = hardware;
        }

        public Hardware Hardware
        {
            get { return this.hardware; }
        }

        public int CatalogId
        {
            get { return this.catalogId; }
        }
    }
}
