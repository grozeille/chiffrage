using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Module.Events
{
    public class RequestEditProjectHardwareEvent : IEvent
    {
        private readonly ProjectHardwareViewModel hardware;

        public RequestEditProjectHardwareEvent(ProjectHardwareViewModel hardware)
        {
            this.hardware = hardware;
        }

        public ProjectHardwareViewModel Hardware
        {
            get { return this.hardware; }
        }
    }
}
