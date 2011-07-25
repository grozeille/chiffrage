using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using Chiffrage.Projects.Domain;

namespace Chiffrage.App.Events
{
    public class ProjectCreatedEvent : IEvent
    {
        private readonly Project newProject;

        private readonly Deal parentDeal;

        public ProjectCreatedEvent(Deal parentDeal, Project newProject)
        {
            this.newProject = newProject;
            this.parentDeal = parentDeal;
        }

        public Project NewProject
        {
            get { return this.newProject; }
        }

        public Deal ParentDeal
        {
            get { return this.parentDeal; }
        }
    }
}
