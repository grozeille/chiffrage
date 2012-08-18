using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.App.ViewModel;
using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
{
    public class RequestEditSupplyEvent : IEvent
    {
        private readonly CatalogSupplyViewModel supply;

        public RequestEditSupplyEvent(CatalogSupplyViewModel supply)
        {
            this.supply = supply;
        }

        public CatalogSupplyViewModel Supply
        {
            get { return this.supply; }
        }
    }
}
