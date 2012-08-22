using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Projects.Module.ViewModel;

namespace Chiffrage.Projects.Module.Actions
{
    public class RequestEditProjectHardwareWorkAction
    {
        private readonly ProjectHardwareWorkViewModel hardware;

        public RequestEditProjectHardwareWorkAction(ProjectHardwareWorkViewModel hardware)
        {
            this.hardware = hardware;
        }

        public ProjectHardwareWorkViewModel Hardware
        {
            get { return this.hardware; }
        }
    }
}
