using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.App.Events
{
    public class SupplyDeletedEvent  : IEvent
    {
        private readonly int catalogId;
        private readonly Supply supply;

        public SupplyDeletedEvent(int catalogId, Supply supply)
        {
            this.catalogId = catalogId;
            this.supply = supply;
        }

        public Supply Supply
        {
            get { return this.supply; }
        }

        public int CatalogId
        {
            get { return this.catalogId; }
        }
    }
}
