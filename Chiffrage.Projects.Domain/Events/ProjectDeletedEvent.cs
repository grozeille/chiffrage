using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Domain.Events
{
    public class ProjectDeletedEvent : IProjectEvent
    {
        private readonly int dealId;

        private readonly int projectId;

        public ProjectDeletedEvent(int dealId, int projectId)
        {
            this.dealId = dealId;
            this.projectId = projectId;
        }

        public int DealId
        {
            get { return this.dealId; }
        }

        public int ProjectId
        {
            get { return this.projectId; }
        }
    }
}
