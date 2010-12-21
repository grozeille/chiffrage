using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.ViewModel
{
    public class CatalogHardwareSupplyViewModel
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public string Name { get; set; }

        public string Reference { get; set; }

        public string Category { get; set; }

        public int ModuleSize { get; set; }

        public double CatalogPrice { get; set; }

        public double StudyDays { get; set; }

        public double ReferenceDays { get; set; }

        public double CatalogWorkDays { get; set; }

        public double CatalogExecutiveWorkDays { get; set; }

        public double CatalogTestsDays { get; set; }

        public static CatalogHardwareSupplyViewModel Build(HardwareSupply supply)
        {
            return new CatalogHardwareSupplyViewModel
            {
                Id = supply.Id,
                Name = supply.Name,
                CatalogExecutiveWorkDays = supply.CatalogExecutiveWorkDays,
                CatalogPrice = supply.CatalogPrice,
                CatalogTestsDays = supply.CatalogTestsDays,
                CatalogWorkDays = supply.CatalogWorkDays,
                Category = supply.Category,
                ModuleSize = supply.ModuleSize,
                Reference = supply.Reference,
                ReferenceDays = supply.ReferenceDays
            };
        }
    }
}
