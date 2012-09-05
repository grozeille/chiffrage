using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Projects.Module.ViewModel;

namespace Chiffrage.Projects.Module.Actions
{
    public class RequestEditProjectHardwareWorkerWorkAction
    {
        private readonly ProjectHardwareWorkerWorkViewModel hardware;

        public RequestEditProjectHardwareWorkerWorkAction(ProjectHardwareWorkerWorkViewModel hardware)
        {
            this.hardware = hardware;
        }

        public ProjectHardwareWorkerWorkViewModel Hardware
        {
            get { return this.hardware; }
        }
    }
}
