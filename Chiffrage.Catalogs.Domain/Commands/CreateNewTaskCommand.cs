using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Commands
{
    public class CreateNewTaskCommand
    {
        private readonly string name;

        public CreateNewTaskCommand(string name)
        {
            this.name = name;
        }

        public string Name { get { return this.name; } }
    }
}
