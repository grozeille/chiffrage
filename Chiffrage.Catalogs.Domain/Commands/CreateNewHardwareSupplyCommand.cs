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
        private readonly string comment;

        public CreateNewHardwareSupplyCommand(int catalogId, int hardwareId, int supplyId, int quantity, string comment)
        {
            this.catalogId = catalogId;
            this.hardwareId = hardwareId;
            this.supplyId = supplyId;
            this.quantity = quantity;
            this.comment = comment;
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

        public string Comment
        {
            get { return this.comment;  }
        }
    }
}
