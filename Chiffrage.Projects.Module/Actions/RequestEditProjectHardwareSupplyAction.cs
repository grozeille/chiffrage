using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Projects.Module.ViewModel;

namespace Chiffrage.Projects.Module.Actions
{
    public class RequestEditProjectHardwareSupplyAction
    {
        private readonly ProjectHardwareSupplyViewModel hardwareSupply;

        public RequestEditProjectHardwareSupplyAction(ProjectHardwareSupplyViewModel hardwareSupply)
        {
            this.hardwareSupply = hardwareSupply;
        }

        public ProjectHardwareSupplyViewModel HardwareSupply
        {
            get { return this.hardwareSupply; }
        }
    }
}
