using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
    public class CreateNewProjectSupplyCommand
    {
        private readonly int projectId;

        private readonly int catalogId;

        private readonly int supplyId;

        private readonly int quantity;

        public CreateNewProjectSupplyCommand(int projectId, int catalogId, int supplyId, int quantity)
        {
            this.projectId = projectId;
            this.catalogId = catalogId;
            this.supplyId = supplyId;
            this.quantity = quantity;
        }

        public int CatalogId { get { return this.catalogId; } }

        public int SupplyId { get { return this.supplyId; } }

        public int ProjectId { get { return this.projectId; } }

        public int Quantity { get { return this.quantity; } }
    }
}
