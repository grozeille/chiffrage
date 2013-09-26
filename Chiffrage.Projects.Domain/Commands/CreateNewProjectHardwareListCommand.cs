using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
    public class CreateNewProjectHardwareListCommand
    {
        private readonly IEnumerable<CreateNewProjectHardwareCommand> commands;

        public CreateNewProjectHardwareListCommand(IEnumerable<CreateNewProjectHardwareCommand> commands)
        {
            this.commands = commands;
        }

        public IEnumerable<CreateNewProjectHardwareCommand> Commands { get { return this.commands; } }
    }
}
