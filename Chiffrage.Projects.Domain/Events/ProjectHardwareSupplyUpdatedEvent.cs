using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Domain.Events
{
    public class ProjectHardwareSupplyUpdatedEvent
    {
        private readonly int projectId;

        private readonly ProjectHardwareSupply hardwareSupply;

        private readonly ProjectHardware hardware;

        public ProjectHardwareSupplyUpdatedEvent(int projectId, ProjectHardware hardware, ProjectHardwareSupply hardwareSupply)
        {
            this.projectId = projectId;
            this.hardware = hardware;
            this.hardwareSupply = hardwareSupply;
        }

        public int ProjectId { get { return this.projectId; } }

        public ProjectHardware ProjectHardware { get { return this.hardware; } }

        public ProjectHardwareSupply ProjectHardwareSupply { get { return this.hardwareSupply; } }
    }
}
