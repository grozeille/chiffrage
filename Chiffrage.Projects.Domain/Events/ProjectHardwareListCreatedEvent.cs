using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Events
{
    public class ProjectHardwareListCreatedEvent
    {
        private readonly IEnumerable<ProjectHardwareCreatedEvent> commands;

        public ProjectHardwareListCreatedEvent(IEnumerable<ProjectHardwareCreatedEvent> commands)
        {
            this.commands = commands;
        }

        public IEnumerable<ProjectHardwareCreatedEvent> Commands { get { return this.commands; } }
    }
}
