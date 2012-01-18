using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Commands
{
    public class CreateNewHardwareCommand : IEvent
    {
        private readonly int catalogId;

        private readonly string name;

        public CreateNewHardwareCommand(int catalogId, string name)
        {
            this.catalogId = catalogId;
            this.name = name;
        }

        public int CatalogId { get { return this.catalogId; } }

        public string Name { get { return this.name; } }
    }
}
