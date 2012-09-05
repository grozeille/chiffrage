using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Projects.Module.ViewModel;

namespace Chiffrage.Projects.Module.Actions
{
    public class RequestEditProjectHardwareTechnicianWorkAction
    {
        private readonly ProjectHardwareTechnicianWorkViewModel hardware;

        public RequestEditProjectHardwareTechnicianWorkAction(ProjectHardwareTechnicianWorkViewModel hardware)
        {
            this.hardware = hardware;
        }

        public ProjectHardwareTechnicianWorkViewModel Hardware
        {
            get { return this.hardware; }
        }
    }
}
