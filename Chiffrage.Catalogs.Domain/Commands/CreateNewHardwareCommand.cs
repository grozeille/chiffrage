using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Commands
{
    public class CreateNewHardwareCommand
    {
        private readonly int catalogId;

        private readonly string name;

        private readonly IList<HardwareTask> tasks;

        public CreateNewHardwareCommand(
            int catalogId,
            string name,
            IList<HardwareTask> tasks)
        {
            this.catalogId = catalogId;
            this.name = name;
            this.tasks = tasks;
        }

        public int CatalogId { get { return this.catalogId; } }

        public string Name { get { return this.name; } }

        public IList<HardwareTask> Tasks { get { return this.tasks; } }
    }
}
