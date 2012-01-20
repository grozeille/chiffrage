using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Commands
{
    public class DeleteHardwareSupplyCommand : IEvent
    {
        private readonly int catalogId;

        private readonly int hardwareId;

        private readonly int hardwareSupplyId;

        public DeleteHardwareSupplyCommand(int catalogId, int hardwareId, int hardwareSupplyId)
        {
            this.catalogId = catalogId;
            this.hardwareId = hardwareId; 
            this.hardwareSupplyId = hardwareSupplyId;
        }

        public int CatalogId { get { return this.catalogId; } }
        public int HardwareId { get { return this.hardwareId; } }
        public int HardwareSupplyId { get { return this.hardwareSupplyId; } }
    }
}
