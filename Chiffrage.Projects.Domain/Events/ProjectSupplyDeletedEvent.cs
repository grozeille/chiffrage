using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using Chiffrage.Projects.Domain;

namespace Chiffrage.Projects.Domain.Events
{
    public class ProjectSupplyDeletedEvent : IEvent
    {
        private readonly int projectId;

        private readonly ProjectSupply supply;

        public ProjectSupplyDeletedEvent(int projectId, ProjectSupply supply)
        {
            this.projectId = projectId;
            this.supply = supply;
        }

        public int ProjectId { get { return this.projectId; } }

        public ProjectSupply ProjectSupply { get { return this.supply; } }
    }
}
