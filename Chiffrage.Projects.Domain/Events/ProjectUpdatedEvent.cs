using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using Chiffrage.Projects.Domain;

namespace Chiffrage.Projects.Domain.Events
{
    public class ProjectUpdatedEvent: IProjectEvent
    {
        private readonly int projectId;

        public ProjectUpdatedEvent(int projectId)
        {
            this.projectId = projectId;
        }

        public int ProjectId
        {
            get { return this.projectId; }
        }
    }
}
