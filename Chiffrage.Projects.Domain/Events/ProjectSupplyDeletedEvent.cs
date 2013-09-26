using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using Chiffrage.Projects.Domain;

namespace Chiffrage.Projects.Domain.Events
{
    public class ProjectSupplyDeletedEvent : IProjectEvent
    {
        private readonly int projectId;
        private readonly int projectSupplyId;

        public ProjectSupplyDeletedEvent(int projectId, int projectSupplyId)
        {
            this.projectId = projectId;
            this.projectSupplyId = projectSupplyId;
        }

        public int ProjectId { get { return this.projectId; } }
        public int ProjectSupplyId { get { return this.projectSupplyId; } }
    }
}
