using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Module.Actions
{
    public class RequestNewHardwareAction
    {
        private readonly int catalogId;

        public RequestNewHardwareAction(int catalogId)
        {
            this.catalogId = catalogId;
        }

        public int CatalogId
        {
            get { return this.catalogId; }
        }
    }
}
