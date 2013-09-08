using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Events
{
    public class ProjectSupplyListCreatedEvent
    {
        private readonly IEnumerable<ProjectSupplyCreatedEvent> commands;

        public ProjectSupplyListCreatedEvent(IEnumerable<ProjectSupplyCreatedEvent> commands)
        {
            this.commands = commands;
        }

        public IEnumerable<ProjectSupplyCreatedEvent> Commands { get { return this.commands; } }
    }
}
