using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
    public class ReloadProjectListSupplyCommand
    {
        private readonly IEnumerable<ReloadProjectSupplyCommand> commands;

        public ReloadProjectListSupplyCommand(IEnumerable<ReloadProjectSupplyCommand> commands)
        {
            this.commands = commands;
        }

        public IEnumerable<ReloadProjectSupplyCommand> Commands { get { return this.commands; } }
    }
}
