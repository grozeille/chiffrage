using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Domain.Commands
{
    public class UpdateProjectHardwareCommand
    {
        private readonly int projectId;

        private readonly int id;

        private readonly int quantity;

        public UpdateProjectHardwareCommand(
            int projectId,
            int id,
            int quantity)
        {
            this.projectId = projectId;
            this.id = id;
            this.quantity = quantity;
        }

        public int ProjectId { get { return this.projectId; } }

        public int Id { get { return this.id; } }
    }
}
