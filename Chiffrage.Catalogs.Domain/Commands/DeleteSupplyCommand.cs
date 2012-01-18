using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Commands
{
    public class DeleteSupplyCommand: IEvent
    {
        private readonly int catalogId;

        private readonly int supplyId;

        public DeleteSupplyCommand(int catalogId, int supplyId)
        {
            this.catalogId = catalogId;
            this.supplyId = supplyId;
        }

        public int SupplyId
        {
            get { return this.supplyId; }
        }

        public int CatalogId
        {
            get { return this.catalogId; }
        }
    }
}
