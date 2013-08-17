using Chiffrage.Projects.Domain;
using System.ComponentModel;
using System.Collections.Generic;

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

        public string Category { get; set; }

        public virtual int TotalModuleSize { get; set; }

        public virtual double TotalCatalogPrice { get; set; }

        public virtual double TotalPrice { get; set; }

        public virtual double Milestone { get; set; }

        public BindingList<ProjectHardwareSupplyViewModel> Components { get; set; }

        public IList<ProjectHardwareTask> Tasks { get; set; }
    }
}