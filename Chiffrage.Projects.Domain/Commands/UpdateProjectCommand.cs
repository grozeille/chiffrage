using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
    public class UpdateProjectCommand
    {
        private readonly int projectId;

        private readonly string name;

        private readonly string comment;

        private readonly string reference;

        private readonly DateTime startDate;

        private readonly DateTime endDate;
        
        private readonly IEnumerable<ProjectTask> tasks;

        public UpdateProjectCommand(
            int projectId, 
            string name, 
            string comment, 
            string reference, 
            DateTime startDate, 
            DateTime endDate,
            IEnumerable<ProjectTask> tasks)
        {
            this.projectId = projectId;
            this.name = name;
            this.comment = comment;
            this.reference = reference;
            this.startDate = startDate;
            this.endDate = endDate;
            this.tasks = tasks;
        }

        public int ProjectId { get { return this.projectId; } }

        public string Name { get { return this.name; } }

        public string Comment { get { return this.comment; } }

        public string Reference { get { return this.reference; } }

        public DateTime StartDate { get { return this.startDate; } }

        public DateTime EndDate { get { return this.endDate; } }
        
        public IEnumerable<ProjectTask> Tasks { get { return this.tasks; } }
    }
}
