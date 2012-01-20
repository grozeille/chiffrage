using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Commands
{
    public class UpdateHardwareSupplyCommand : IEvent
    {
        private readonly int catalogId;
        private readonly int hardwareId;
        private readonly int hardwareSupplyId;
        private readonly int quantity;

        public UpdateHardwareSupplyCommand(int catalogId, int hardwareId, int hardwareSupplyId, int quantity)
        {
            this.catalogId = catalogId;
            this.hardwareId = hardwareId;
            this.hardwareSupplyId = hardwareSupplyId;
            this.quantity = quantity;
        }

        public int HardwareSupplyId
        {
            get { return this.hardwareSupplyId; }
        }

        public int CatalogId
        {
            get { return this.catalogId; }
        }

        public int HardwareId
        {
            get { return this.hardwareId; }
        }

        public int Quantity
        {
            get { return this.quantity; }
        }
    }
}
