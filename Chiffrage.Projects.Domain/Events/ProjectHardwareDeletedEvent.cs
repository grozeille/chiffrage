using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Events
{
    public class ProjectHardwareDeletedEvent : IEvent
    {
        private readonly int projectId;
        private readonly ProjectHardware hardware;

        public ProjectHardwareDeletedEvent(int projectId, ProjectHardware hardware)
        {
            this.projectId = projectId;
            this.hardware = hardware;
        }

        public int ProjectId { get { return this.projectId; } }

        public ProjectHardware Hardware { get { return this.hardware; } }
    }
}
