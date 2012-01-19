using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Commands
{
    public class CreateNewHardwareSupplyCommand : IEvent
    {
        private readonly int catalogId;
        private readonly int hardwareId;
        private readonly int supplyId;
        private readonly int quantity;

        public CreateNewHardwareSupplyCommand(int catalogId, int hardwareId, int supplyId, int quantity)
        {
            this.catalogId = catalogId;
            this.hardwareId = hardwareId;
            this.supplyId = supplyId;
            this.quantity = quantity;
        }

        public int SupplyId
        {
            get { return this.supplyId; }
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
