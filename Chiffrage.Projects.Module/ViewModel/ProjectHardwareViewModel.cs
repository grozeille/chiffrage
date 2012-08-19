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

        public int ModuleSize { get; set; }

        public double CatalogPrice { get; set; }

        public double CatalogStudyDays { get; set; }

        public double CatalogReferenceDays { get; set; }

        public double CatalogWorkDays { get; set; }

        public double CatalogExecutiveWorkDays { get; set; }

        public double CatalogTestsDays { get; set; }

        public double StudyDays { get; set; }

        public double ReferenceDays { get; set; }

        public double WorkDays { get; set; }

        public double ExecutiveWorkDays { get; set; }

        public double TestsDays { get; set; }

        public int Quantity { get; set; }

        public virtual int TotalModuleSize { get; set; }

        public virtual double TotalCatalogPrice { get; set; }

        public virtual double TotalCatalogStudyDays { get; set; }

        public virtual double TotalCatalogReferenceDays { get; set; }

        public virtual double TotalCatalogWorkDays { get; set; }

        public virtual double TotalCatalogExecutiveWorkDays { get; set; }

        public virtual double TotalCatalogTestsDays { get; set; }

        public virtual double TotalStudyDays { get; set; }

        public virtual double TotalReferenceDays { get; set; }

        public virtual double TotalWorkDays { get; set; }

        public virtual double TotalExecutiveWorkDays { get; set; }

        public virtual double TotalTestsDays { get; set; }

        public BindingList<ProjectHardwareSupplyViewModel> Components { get; set; }
    }
}