using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Events
{
    public class SupplyCreatedEvent : ICatalogEvent
    {
        private readonly int catalogId;
        private readonly int supplyId;

        public SupplyCreatedEvent(int catalogId, int supplyId)
        {
            this.catalogId = catalogId;
            this.supplyId = supplyId;
        }

        public int SupplyId
        {
            get { return this.supplyId; }
        }

        public int CatalogId
        {
            get { return this.catalogId; }
        }
    }
}
