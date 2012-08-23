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

        private readonly double milestone;

        public UpdateProjectHardwareCommand(
            int projectId,
            int id,
            double milestone)
        {
            this.projectId = projectId;
            this.id = id;
            this.milestone = milestone;
        }

        public int ProjectId { get { return this.projectId; } }

        public int Id { get { return this.id; } }

        public double Milestone { get { return this.milestone; } }
    }
}
