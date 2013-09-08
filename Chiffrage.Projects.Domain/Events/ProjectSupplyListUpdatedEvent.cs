using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Events
{
    public class ProjectSupplyListUpdatedEvent
    {
        private readonly IEnumerable<ProjectSupplyUpdatedEvent> commands;

        public ProjectSupplyListUpdatedEvent(IEnumerable<ProjectSupplyUpdatedEvent> commands)
        {
            this.commands = commands;
        }

        public IEnumerable<ProjectSupplyUpdatedEvent> Commands { get { return this.commands; } }
    }
}
