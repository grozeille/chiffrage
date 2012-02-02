using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Commands
{
    public class UpdateSupplyCommand : IEvent
    {
        private readonly int catalogId;

        private readonly int supplyId;

        private readonly string name;

        private readonly string reference;

        private readonly string category;

        private readonly int moduleSize;

        private readonly double catalogPrice;

        private readonly int pfc0;

        private readonly int pfc12;

        private readonly int cap;

        public UpdateSupplyCommand(
            int catalogId,
            int supplyId,
            string name,
            string reference,
            string category,
            int moduleSize,
            double catalogPrice,
            int pfc12,
            int pfc0,
            int cap)
        {
            this.catalogId = catalogId;
            this.supplyId = supplyId;
            this.name = name;
            this.reference = reference;
            this.category = category;
            this.moduleSize = moduleSize;
            this.catalogPrice = catalogPrice;
            this.pfc0 = pfc0;
            this.pfc12 = pfc12;
            this.cap = cap;       
        }


        public int CatalogId { get { return this.catalogId; } }

        public int SupplyId { get { return this.supplyId; } }

        public string Name { get { return this.name; } }

        public string Reference { get { return this.reference; } }

        public string Category { get { return this.category; } }

        public int ModuleSize { get { return this.moduleSize; } }

        public double CatalogPrice { get { return this.catalogPrice; } }

        public int PFC12 { get { return this.pfc12; } }

        public int PFC0 { get { return this.pfc0; } }

        public int Cap { get { return this.cap; } }
    }
}
