using System.ComponentModel;

namespace Chiffrage.App.ViewModel
{
    public class CatalogHardwareViewModel
    {
        public CatalogHardwareViewModel()
        {
            this.Components = new BindingList<CatalogHardwareSupplyViewModel>();
        }

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
    }
}