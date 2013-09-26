using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Events
{
    public class ProjectFrameDeletedEvent : IProjectEvent
    {
        private readonly int projectId;
        private readonly int projectFrameId;

        public ProjectFrameDeletedEvent(int projectId, int projectFrameId)
        {
            this.projectId = projectId;
            this.projectFrameId = projectFrameId;
        }

        public int ProjectId { get { return this.projectId; } }
        public int ProjectFrameId { get { return this.projectFrameId; } }
    }
}
