using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.App.Events
{
    public class HardwareSupplyMustBeUniqueErrorEvent : IEvent
    {
        private int catalogId;
        private int hardwareId;
        private Supply supply;

        public HardwareSupplyMustBeUniqueErrorEvent(int catalogId, int hardwareId, Supply supply)
        {
            this.catalogId = catalogId;
            this.hardwareId = hardwareId;
            this.supply = supply;
        }
    }
}
