using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.App.ViewModel;
using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
{
    public class CreateNewHardwareSupplyEvent : IEvent
    {
        private readonly int catalogId;
        private readonly int hardwareId;
        private readonly int supplyId;
        private readonly int quantity;

        public CreateNewHardwareSupplyEvent(int catalogId, int hardwareId, int supplyId, int quantity)
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
