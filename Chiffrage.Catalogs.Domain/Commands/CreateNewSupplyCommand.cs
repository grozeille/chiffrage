using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Commands
{
    public class CreateNewSupplyCommand
    {
        private readonly int catalogId;

        private readonly string name;

        private readonly string reference;

        private readonly string category;

        private readonly int moduleSize;

        private readonly double catalogPrice;

        private readonly int pfc0;

        private readonly int pfc12;

        private readonly int cap;

        public CreateNewSupplyCommand(
            int catalogId,
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
            this.name = name;
            this.reference = reference;
            this.category = category;
            this.moduleSize = moduleSize;
            this.pfc0 = pfc0;
            this.pfc12 = pfc12;
            this.cap = cap;
            this.catalogPrice = catalogPrice;
        }
        
        public int CatalogId { get { return this.catalogId; } }

        public string Name { get { return this.name; } }

        public string Reference { get { return this.reference; } }

        public string Category { get { return this.category; } }

        public int ModuleSize { get { return this.moduleSize; } }

        public int PFC12 { get { return this.pfc12; } }

        public int PFC0 { get { return this.pfc0; } }

        public int Cap { get { return this.cap; } }

        public double CatalogPrice { get { return this.catalogPrice; } }
    }
}
