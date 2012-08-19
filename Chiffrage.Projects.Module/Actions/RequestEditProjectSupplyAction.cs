using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Module.Actions
{
    public class RequestEditProjectSupplyAction
    {
        private readonly ProjectSupplyViewModel supply;

        public RequestEditProjectSupplyAction(ProjectSupplyViewModel supply)
        {
            this.supply = supply;
        }

        public ProjectSupplyViewModel Supply
        {
            get { return this.supply; }
        }
    }
}
