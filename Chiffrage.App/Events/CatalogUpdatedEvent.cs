using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.App.Events
{
    public class CatalogUpdatedEvent : IEvent
    {
        public CatalogUpdatedEvent(SupplierCatalog newCatalog)
        {
            this.NewCatalog = newCatalog;
        }

        public SupplierCatalog NewCatalog { get; private set; }
    }
}
