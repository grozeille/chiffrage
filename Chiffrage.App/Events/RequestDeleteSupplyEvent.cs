using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
{
    public class RequestDeleteSupplyEvent: IEvent
    {
        private readonly int catalogId;

        private readonly int supplyId;

        public RequestDeleteSupplyEvent(int catalogId, int supplyId)
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
