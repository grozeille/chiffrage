using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.Catalogs.Domain.Events
{
    public class SupplyMustBeUniqueErrorEvent : IEvent
    {
        private int catalogId;
        private Supply supply;

        public SupplyMustBeUniqueErrorEvent(int catalogId, Supply supply)
        {
            this.catalogId = catalogId;
            this.supply = supply;
        }
    }
}
