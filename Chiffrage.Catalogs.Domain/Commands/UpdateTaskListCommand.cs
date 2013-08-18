using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Commands
{
    public class UpdateTaskListCommand
    {
        private readonly IEnumerable<UpdateTaskCommand> tasks;

        public UpdateTaskListCommand(IEnumerable<UpdateTaskCommand> tasks)
        {
            this.tasks = tasks;
        }

        public IEnumerable<UpdateTaskCommand> Tasks { get { return this.tasks; } }
    }
}
