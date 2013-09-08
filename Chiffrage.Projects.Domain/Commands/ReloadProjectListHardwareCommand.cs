﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
    public class ReloadProjectListHardwareCommand
    {
        private readonly IEnumerable<ReloadProjectHardwareCommand> commands;

        public ReloadProjectListHardwareCommand(IEnumerable<ReloadProjectHardwareCommand> commands)
        {
            this.commands = commands;
        }

        public IEnumerable<ReloadProjectHardwareCommand> Commands { get { return this.commands; } }
    }
}
