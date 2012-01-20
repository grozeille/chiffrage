using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.App.ViewModel;
using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
{
    public class RequestEditHardwareSupplyEvent : IEvent
    {
        private readonly CatalogHardwareSupplyViewModel hardwareSupply;

        public RequestEditHardwareSupplyEvent(CatalogHardwareSupplyViewModel hardwareSupply)
        {
            this.hardwareSupply = hardwareSupply;
        }

        public CatalogHardwareSupplyViewModel HardwareSupply
        {
            get { return this.hardwareSupply; }
        }
    }
}
