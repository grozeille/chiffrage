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

        public virtual int PFC0 { get; set; }

        public virtual int PFC12 { get; set; }

        public virtual int Cap { get; set; }

        public int ProjectId { get; set; }

        public virtual int TotalModuleSize { get; set; }

        public virtual double TotalCatalogPrice { get; set; }

        public virtual double TotalPFC0 { get; set; }

        public virtual double TotalPFC12 { get; set; }

        public virtual double TotalCap { get; set; }

    }
}