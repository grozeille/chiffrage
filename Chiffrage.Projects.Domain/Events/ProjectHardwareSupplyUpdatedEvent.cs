using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Domain.Events
{
    public class ProjectHardwareSupplyUpdatedEvent : IProjectEvent
    {
        private readonly int projectId;

        private readonly int hardwareSupplyId;

        private readonly int hardwareId;

        public ProjectHardwareSupplyUpdatedEvent(int projectId, int hardwareId, int hardwareSupplyId)
        {
            this.projectId = projectId;
            this.hardwareId = hardwareId;
            this.hardwareSupplyId = hardwareSupplyId;
        }

        public int ProjectId { get { return this.projectId; } }

        public int ProjectHardwareId { get { return this.hardwareId; } }

        public int ProjectHardwareSupplyId { get { return this.hardwareSupplyId; } }
    }
}
