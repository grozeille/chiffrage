using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
    public class DeleteProjectHardwareCommand : IEvent
    {
        private readonly int projectId;

        private readonly int projectHardwareId;

        public DeleteProjectHardwareCommand(int projectId, int projectHardwareId)
        {
            this.projectId = projectId;
            this.projectHardwareId = projectHardwareId;
        }

        public int ProjectHardwareId { get { return this.projectHardwareId; } }

        public int ProjectId { get { return this.projectId; } }
    }
}
