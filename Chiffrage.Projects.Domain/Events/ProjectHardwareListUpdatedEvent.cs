using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Events
{
    public class ProjectHardwareListUpdatedEvent
    {
        private readonly IEnumerable<ProjectHardwareUpdatedEvent> commands;

        public ProjectHardwareListUpdatedEvent(IEnumerable<ProjectHardwareUpdatedEvent> commands)
        {
            this.commands = commands;
        }

        public IEnumerable<ProjectHardwareUpdatedEvent> Commands { get { return this.commands; } }
    }
}
