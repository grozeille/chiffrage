using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.Catalogs.Domain.Events
{
    public class SupplyDeletedEvent : ICatalogEvent
    {
        private readonly int catalogId;
        private readonly int supplyId;

        public SupplyDeletedEvent(int catalogId, int supplyId)
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
