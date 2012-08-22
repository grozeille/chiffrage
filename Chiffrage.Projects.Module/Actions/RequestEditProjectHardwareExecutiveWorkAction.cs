using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Projects.Module.ViewModel;

namespace Chiffrage.Projects.Module.Actions
{
    public class RequestEditProjectHardwareExecutiveWorkAction
    {
        private readonly ProjectHardwareExecutiveWorkViewModel hardware;

        public RequestEditProjectHardwareExecutiveWorkAction(ProjectHardwareExecutiveWorkViewModel hardware)
        {
            this.hardware = hardware;
        }

        public ProjectHardwareExecutiveWorkViewModel Hardware
        {
            get { return this.hardware; }
        }
    }
}
