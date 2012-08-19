using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Module.Actions
{
    public class RequestImportHardwareAction : IEvent
    {
        private int catalogId;

        public RequestImportHardwareAction(int catalogId)
        {
            this.catalogId = catalogId;
        }

        public int CatalogId
        {
            get
            {
                return this.catalogId;
            }
        }
    }
}
