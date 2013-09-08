using System.ComponentModel;
using System.Collections.Generic;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Mvc;

namespace Chiffrage.Catalogs.Module.ViewModel
{
    public class CatalogHardwareViewModel
    {
        public CatalogHardwareViewModel()
        {
            this.Components = new SortableBindingList<CatalogHardwareSupplyViewModel>();
        }

        public int Id { get; set; }

        public int CatalogId { get; set; }

        public string Name { get; set; }

        public string Reference { get; set; }

        public int ModuleSize { get; set; }

        public double CatalogPrice { get; set; }

        public SortableBindingList<CatalogHardwareSupplyViewModel> Components { get; set; }

        public IList<HardwareTask> Tasks { get; set; }
    }
}