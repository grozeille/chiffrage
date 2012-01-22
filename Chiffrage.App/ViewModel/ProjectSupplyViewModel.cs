using Chiffrage.Projects.Domain;

namespace Chiffrage.App.ViewModel
{
    public class ProjectSupplyViewModel
    {
        public virtual int Id { get; set; }

        public virtual int CatalogId { get; set; }

        public virtual int SupplyId { get; set; }

        public virtual int Quantity { get; set; }

        public virtual string Name { get; set; }

        public virtual string Reference { get; set; }

        public virtual string Category { get; set; }

        public virtual int ModuleSize { get; set; }

        public virtual double CatalogPrice { get; set; }

        public virtual double StudyDays { get; set; }

        public virtual double ReferenceDays { get; set; }

        public virtual double CatalogWorkDays { get; set; }

        public virtual double CatalogExecutiveWorkDays { get; set; }

        public virtual double CatalogTestsDays { get; set; }

        public int ProjectId { get; set; }

        public virtual int TotalModuleSize { get; set; }

        public virtual double TotalCatalogPrice { get; set; }

        public virtual double TotalStudyDays { get; set; }

        public virtual double TotalReferenceDays { get; set; }

        public virtual double TotalCatalogWorkDays { get; set; }

        public virtual double TotalCatalogExecutiveWorkDays { get; set; }

        public virtual double TotalCatalogTestsDays { get; set; }

    }
}