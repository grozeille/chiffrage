using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Module.Actions
{
    public class RequestNewSupplyAction : IEvent
    {
        private readonly int catalogId;

        public RequestNewSupplyAction(int catalogId)
        {
            this.catalogId = catalogId;
        }

        public int CatalogId
        {
            get { return this.catalogId; }
        }
    }
}
