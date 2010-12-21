using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.ViewModel
{
    public class CatalogHardwareViewModel
    {
        public int Id { get; set; }

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

        public BindingList<CatalogHardwareSupplyViewModel> Components { get; set; }

        public CatalogHardwareViewModel()
        {
            this.Components = new BindingList<CatalogHardwareSupplyViewModel>();
        }

        public static CatalogHardwareViewModel Build(Hardware hardware)
        {
            var result = new CatalogHardwareViewModel
            {
                Id = hardware.Id,
                Name = hardware.Name,
                CatalogExecutiveWorkDays = hardware.CatalogExecutiveWorkDays,
                CatalogPrice = hardware.CatalogPrice,
                CatalogTestsDays = hardware.CatalogTestsDays,
                CatalogWorkDays = hardware.CatalogWorkDays,
                Category = hardware.Category,
                ModuleSize = hardware.ModuleSize,
                Reference = hardware.Reference,
                ReferenceDays = hardware.ReferenceDays
            };

            foreach(var item in hardware.Components)
            {
                result.Components.Add(CatalogHardwareSupplyViewModel.Build(item));
            }

            return result;
        }
    }
}
