using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using Chiffrage.Projects.Domain;

namespace Chiffrage.Projects.Domain.Events
{
    public class ProjectUpdatedEvent : IEvent
    {
        public Project NewProject { get; private set; }

        public ProjectUpdatedEvent(Project newProject)
        {
            this.NewProject = newProject;
        }
    }
}
