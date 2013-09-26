using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using Chiffrage.Projects.Domain;

namespace Chiffrage.Projects.Domain.Events
{
    public class ProjectCreatedEvent : IProjectEvent
    {
         private readonly int dealId;

        private readonly int projectId;

        public ProjectCreatedEvent(int dealId, int projectId)
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
