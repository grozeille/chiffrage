using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.App.ViewModel;
using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
{
    public class RequestEditProjectSupplyEvent : IEvent
    {
        private readonly ProjectSupplyViewModel supply;

        public RequestEditProjectSupplyEvent(ProjectSupplyViewModel supply)
        {
            this.supply = supply;
        }

        public ProjectSupplyViewModel Supply
        {
            get { return this.supply; }
        }
    }
}
