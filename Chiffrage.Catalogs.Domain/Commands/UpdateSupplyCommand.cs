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

        private readonly double studyDays;

        private readonly double referenceDays;

        private readonly double catalogWorkDays;

        private readonly double catalogExecutiveWorkDays;

        private readonly double catalogTestsDays;


        public UpdateSupplyCommand(
            int catalogId,
            int supplyId,
            string name,
            string reference,
            string category,
            int moduleSize,
            double catalogPrice,
            double studyDays,
            double referenceDays,
            double catalogWorkDays,
            double catalogExecutiveWorkDays,
            double catalogTestsDays)
        {
            this.catalogId = catalogId;
            this.supplyId = supplyId;
            this.name = name;
            this.reference = reference;
            this.category = category;
            this.moduleSize = moduleSize;
            this.catalogPrice = catalogPrice;
            this.studyDays = studyDays;
            this.referenceDays = referenceDays;
            this.catalogWorkDays = catalogWorkDays;
            this.catalogExecutiveWorkDays = catalogExecutiveWorkDays;
            this.catalogTestsDays = catalogTestsDays;
        }


        public int CatalogId { get { return this.catalogId; } }

        public int SupplyId { get { return this.supplyId; } }

        public string Name { get { return this.name; } }

        public string Reference { get { return this.reference; } }

        public string Category { get { return this.category; } }

        public int ModuleSize { get { return this.moduleSize; } }

        public double CatalogPrice { get { return this.catalogPrice; } }

        public double StudyDays { get { return this.studyDays; } }

        public double ReferenceDays { get { return this.referenceDays; } }

        public double CatalogWorkDays { get { return this.catalogWorkDays; } }

        public double CatalogExecutiveWorkDays { get { return this.catalogExecutiveWorkDays; } }

        public double CatalogTestsDays { get { return this.catalogTestsDays; } }
    }
}
