using Chiffrage.Projects.Domain;
using System.ComponentModel;

namespace Chiffrage.Projects.Module.ViewModel
{
    public class ProjectHardwareViewModel
    {
        public ProjectHardwareViewModel()
        {
            this.Components = new BindingList<ProjectHardwareSupplyViewModel>();
        }

        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int CatalogId { get; set; }

        public string Name { get; set; }

        public string Reference { get; set; }

        public string Category { get; set; }

        public int Quantity { get; set; }

        public virtual int TotalModuleSize { get; set; }

        public virtual double TotalCatalogPrice { get; set; }

        public virtual double TotalPrice { get; set; }

        public BindingList<ProjectHardwareSupplyViewModel> Components { get; set; }
    }
}