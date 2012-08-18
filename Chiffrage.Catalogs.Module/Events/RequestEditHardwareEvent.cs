using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Module.ViewModel;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Module.Events
{
    public class RequestEditHardwareEvent : IEvent
    {
        private readonly CatalogHardwareViewModel hardware;

        public RequestEditHardwareEvent(CatalogHardwareViewModel hardware)
        {
            this.hardware = hardware;
        }

        public CatalogHardwareViewModel Hardware
        {
            get { return this.hardware; }
        }
    }
}
