using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.Catalogs.Domain.Events
{
    public class CatalogUpdatedEvent : ICatalogEvent
    {
        private readonly int catalogId;

        public CatalogUpdatedEvent(int catalogId)
        {
            this.catalogId = catalogId;
        }

        public int CatalogId { get { return this.catalogId; } }
    }
}
