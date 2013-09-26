using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Events
{
    public class CatalogCreatedEvent : ICatalogEvent
    {
        private readonly int catalogId;

        public CatalogCreatedEvent(int catalogId)
        {
            this.catalogId = catalogId;
        }

        public int CatalogId { get { return this.catalogId; } }
    }
}
