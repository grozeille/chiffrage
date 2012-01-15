using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.App.Events
{
    public class HardwareMustBeUniqueErrorEvent : IEvent
    {
        private int catalogId;
        private Hardware hardware;

        public HardwareMustBeUniqueErrorEvent(int catalogId, Hardware hardware)
        {
            this.catalogId = catalogId;
            this.hardware = hardware;
        }
    }
}
