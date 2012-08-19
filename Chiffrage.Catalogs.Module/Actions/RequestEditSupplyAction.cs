using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Module.ViewModel;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Module.Actions
{
    public class RequestEditSupplyAction
    {
        private readonly CatalogSupplyViewModel supply;

        public RequestEditSupplyAction(CatalogSupplyViewModel supply)
        {
            this.supply = supply;
        }

        public CatalogSupplyViewModel Supply
        {
            get { return this.supply; }
        }
    }
}
