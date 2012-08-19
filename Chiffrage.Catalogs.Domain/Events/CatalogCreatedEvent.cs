using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Events
{
    public class CatalogCreatedEvent
    {
        private readonly SupplierCatalog catalog;

        public CatalogCreatedEvent(SupplierCatalog catalog)
        {
            this.catalog = catalog;
        }

        public SupplierCatalog Catalog { get { return this.catalog; } }
    }
}
