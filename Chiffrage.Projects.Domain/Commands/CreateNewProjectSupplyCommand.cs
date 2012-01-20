using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
    public class CreateNewProjectSupplyCommand : IEvent
    {
        private readonly int projectId;

        private readonly int catalogId;

        private readonly int supplyId;

        public CreateNewProjectSupplyCommand(int projectId, int catalogId, int supplyId)
        {
            this.projectId = projectId;
            this.catalogId = catalogId;
            this.supplyId = supplyId;
        }

        public int CatalogId { get { return this.catalogId; } }

        public int SupplyId { get { return this.supplyId; } }

        public int ProjectId { get { return this.projectId; } }
    }
}
