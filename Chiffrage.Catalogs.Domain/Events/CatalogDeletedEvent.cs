using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Events
{
    public class CatalogDeletedEvent
    {
        private readonly int catalogId;

        public CatalogDeletedEvent(int catalogId)
        {
            this.catalogId = catalogId;
        }

        public int CatalogId { get { return this.catalogId; } }
    }
}
