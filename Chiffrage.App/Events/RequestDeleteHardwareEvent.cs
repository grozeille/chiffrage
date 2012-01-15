using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
{
    public class RequestDeleteHardwareEvent: IEvent
    {
        private readonly int catalogId;

        private readonly int hardwareId;

        public RequestDeleteHardwareEvent(int catalogId, int hardwareId)
        {
            this.catalogId = catalogId;
            this.hardwareId = hardwareId;
        }

        public int HardwareId
        {
            get { return this.hardwareId; }
        }

        public int CatalogId
        {
            get { return this.catalogId; }
        }
    }
}
