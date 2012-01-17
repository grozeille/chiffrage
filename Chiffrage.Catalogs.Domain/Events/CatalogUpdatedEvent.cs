using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.Catalogs.Domain.Events
{
    public class CatalogUpdatedEvent : IEvent
    {
        private readonly SupplierCatalog catalog;

        public CatalogUpdatedEvent(SupplierCatalog catalog)
        {
            this.catalog = catalog;
        }

        public SupplierCatalog Catalog { get { return this.catalog; } }
    }
}
