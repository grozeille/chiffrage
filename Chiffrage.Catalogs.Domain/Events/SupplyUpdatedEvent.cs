using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Events
{
    public class SupplyUpdatedEvent : IEvent
    {
        private readonly int catalogId;
        private readonly Supply supply;

        public SupplyUpdatedEvent(int catalogId, Supply supply)
        {
            this.catalogId = catalogId;
            this.supply = supply;
        }

        public int CatalogId
        {
            get { return this.catalogId; }
        }

        public Supply Supply
        {
            get { return this.supply; }
        }
    }
}
