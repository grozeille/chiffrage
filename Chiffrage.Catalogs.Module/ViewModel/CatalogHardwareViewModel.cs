using System.ComponentModel;

namespace Chiffrage.Catalogs.Module.ViewModel
{
    public class CatalogHardwareViewModel
    {
        public CatalogHardwareViewModel()
        {
            this.Components = new BindingList<CatalogHardwareSupplyViewModel>();
        }

        public int Id { get; set; }

        public int CatalogId { get; set; }

        public string Name { get; set; }

        public string Reference { get; set; }

        public string Category { get; set; }

        public int ModuleSize { get; set; }

        public double CatalogPrice { get; set; }

        public double CatalogStudyDays { get; set; }

        public double CatalogReferenceDays { get; set; }

        public double CatalogTechnicianWorkDays { get; set; }

        public double CatalogWorkerWorkDays { get; set; }

        public double CatalogTestsDays { get; set; }

        public BindingList<CatalogHardwareSupplyViewModel> Components { get; set; }
    }
}