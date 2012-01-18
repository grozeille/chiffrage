using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Commands
{
    public class UpdateHardwareCommand : IEvent
    {
        private readonly int catalogId;

        private readonly int hardwareId;

        private readonly string name;

        public UpdateHardwareCommand(int catalogId, int hardwareId, string name)
        {
            this.catalogId = catalogId;
            this.hardwareId = hardwareId;
            this.name = name;
        }

        public int CatalogId { get { return this.catalogId; } }

        public int HardwareId { get { return this.hardwareId; } }

        public string Name { get { return this.name; } }
    }
}
