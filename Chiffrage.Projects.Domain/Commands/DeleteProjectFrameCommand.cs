using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
    public class DeleteProjectFrameCommand : IEvent
    {
        private readonly int projectId;

        private readonly int projectFrameId;

        public DeleteProjectFrameCommand(int projectId, int projectFrameId)
        {
            this.projectId = projectId;
            this.projectFrameId = projectFrameId;
        }

        public int ProjectFrameId { get { return this.projectFrameId; } }

        public int ProjectId { get { return this.projectId; } }
    }
}
