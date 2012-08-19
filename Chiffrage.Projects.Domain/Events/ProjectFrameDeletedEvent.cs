using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Events
{
    public class ProjectFrameDeletedEvent
    {
        private readonly int projectId;
        private readonly ProjectFrame frame;

        public ProjectFrameDeletedEvent(int projectId, ProjectFrame frame)
        {
            this.projectId = projectId;
            this.frame = frame;
        }

        public int ProjectId { get { return this.projectId; } }

        public ProjectFrame Frame { get { return this.frame; } }
    }
}
