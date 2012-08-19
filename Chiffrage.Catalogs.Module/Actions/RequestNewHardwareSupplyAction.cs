using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Module.Actions
{
    public class RequestNewHardwareSupplyAction : IEvent
    {
        private readonly int catalogId;

        private readonly int hardwareId;

        public RequestNewHardwareSupplyAction(int catalogId, int hardwareId)
        {
            this.catalogId = catalogId;
            this.hardwareId = hardwareId;
        }

        public int CatalogId
        {
            get { return this.catalogId; }
        }

        public int HardwareId
        {
            get { return this.hardwareId; }
        }
    }
}
