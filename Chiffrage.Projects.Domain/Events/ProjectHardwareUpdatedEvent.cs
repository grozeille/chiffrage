using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Events
{
    public class ProjectHardwareUpdatedEvent : IProjectEvent
    {
        private readonly int projectId;
        private readonly int projectHardwareId;

        public ProjectHardwareUpdatedEvent(int projectId, int projectHardwareId)
        {
            this.projectId = projectId;
            this.projectHardwareId = projectHardwareId;
        }

        public int ProjectId { get { return this.projectId; } }
        public int ProjectHardwareId { get { return this.projectHardwareId; } }
    }
}
