using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Events
{
    public class ProjectSupplyCreatedEvent
    {
        private readonly int projectId;
        private readonly ProjectSupply projectSupply;

        public ProjectSupplyCreatedEvent(int projectId, ProjectSupply projectSupply)
        {
            this.projectId = projectId;
            this.projectSupply = projectSupply;
        }

        public int ProjectId { get { return this.projectId; } }
        public ProjectSupply ProjectSupply { get { return this.projectSupply; } }
    }
}
