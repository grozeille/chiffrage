using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
    public class CreateNewProjectHardwareCommand
    {
        private readonly int projectId;

        private readonly int catalogId;

        private readonly int hardwareId;

        public CreateNewProjectHardwareCommand(int projectId, int catalogId, int hardwareId)
        {
            this.projectId = projectId;
            this.catalogId = catalogId;
            this.hardwareId = hardwareId;
        }

        public int CatalogId { get { return this.catalogId; } }

        public int HardwareId { get { return this.hardwareId; } }

        public int ProjectId { get { return this.projectId; } }
    }
}
