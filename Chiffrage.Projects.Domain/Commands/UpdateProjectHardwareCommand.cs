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

        private readonly IEnumerable<ProjectHardwareTask> tasks;

        public UpdateProjectHardwareCommand(
            int projectId,
            int id,
            double milestone,
            IEnumerable<ProjectHardwareTask> tasks)
        {
            this.projectId = projectId;
            this.id = id;
            this.milestone = milestone;
            this.tasks = tasks;
        }

        public int ProjectId { get { return this.projectId; } }

        public int Id { get { return this.id; } }

        public double Milestone { get { return this.milestone; } }

        public IEnumerable<ProjectHardwareTask> Tasks { get { return this.tasks; } }
    }
}
