using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Events
{
    public class ProjectFrameCreatedEvent
    {
        private readonly int projectId;
        private readonly ProjectFrame projectFrame;

        public ProjectFrameCreatedEvent(int projectId, ProjectFrame projectFrame)
        {
            this.projectId = projectId;
            this.projectFrame = projectFrame;
        }

        public int ProjectId { get { return this.projectId; } }
        public ProjectFrame ProjectFrame { get { return this.projectFrame; } }
    }
}
