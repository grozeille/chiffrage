using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Events
{
    public class ProjectHardwareCreatedEvent : IEvent
    {
        private readonly int projectId;
        private readonly ProjectHardware projectHardware;

        public ProjectHardwareCreatedEvent(int projectId, ProjectHardware projectHardware)
        {
            this.projectId = projectId;
            this.projectHardware = projectHardware;
        }

        public int ProjectId { get { return this.projectId; } }
        public ProjectHardware ProjectHardware { get { return this.projectHardware; } }
    }
}
