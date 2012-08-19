using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Module.ViewModel;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Module.Actions
{
    public class RequestEditHardwareAction
    {
        private readonly CatalogHardwareViewModel hardware;

        public RequestEditHardwareAction(CatalogHardwareViewModel hardware)
        {
            this.hardware = hardware;
        }

        public CatalogHardwareViewModel Hardware
        {
            get { return this.hardware; }
        }
    }
}
