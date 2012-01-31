using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
    public class CreateNewProjectHardwareCommand : IEvent
    {
        private readonly int projectId;

        private readonly int catalogId;

        private readonly int hardwareId;

        private readonly int quantity;

        public CreateNewProjectHardwareCommand(int projectId, int catalogId, int hardwareId, int quantity)
        {
            this.projectId = projectId;
            this.catalogId = catalogId;
            this.hardwareId = hardwareId;
            this.quantity = quantity;
        }

        public int CatalogId { get { return this.catalogId; } }

        public int HardwareId { get { return this.hardwareId; } }

        public int ProjectId { get { return this.projectId; } }

        public int Quantity { get { return this.quantity; } }
    }
}
