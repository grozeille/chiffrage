using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
    public class CreateNewProjectSupplyListCommand
    {
        private readonly IEnumerable<CreateNewProjectSupplyCommand> commands;

        public CreateNewProjectSupplyListCommand(IEnumerable<CreateNewProjectSupplyCommand> commands)
        {
            this.commands = commands;
        }

        public IEnumerable<CreateNewProjectSupplyCommand> Commands { get { return this.commands; } }
    }
}
