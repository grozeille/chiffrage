using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Commands
{
    public class UpdateHardwareCommand
    {
        private readonly int catalogId;

        private readonly int hardwareId;

        private readonly string name;

        private readonly IList<HardwareTask> tasks;

        public UpdateHardwareCommand(
            int catalogId,
            int hardwareId,
            string name,
            IList<HardwareTask> tasks)
        {
            this.catalogId = catalogId;
            this.hardwareId = hardwareId;
            this.name = name;
            this.tasks = tasks;
        }

        public int CatalogId { get { return this.catalogId; } }

        public int HardwareId { get { return this.hardwareId; } }

        public string Name { get { return this.name; } }

        public IList<HardwareTask> Tasks { get { return this.tasks; } }
    }
}
