using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
{
    public class CatalogCreatedEvent : IEvent
    {
        private readonly SupplierCatalog newCatalog;

        public CatalogCreatedEvent(SupplierCatalog newCatalog)
        {
            this.newCatalog = newCatalog;
        }

        public SupplierCatalog NewCatalog
        {
            get { return this.newCatalog; }
        }
    }
}
