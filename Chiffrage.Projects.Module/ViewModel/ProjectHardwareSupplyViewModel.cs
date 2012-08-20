using System.ComponentModel;

namespace Chiffrage.Projects.Module.ViewModel
{
    public class ProjectHardwareSupplyViewModel
    {
        public int Id { get; set; }

        public int CatalogId { get; set; }

        public int ProjectId { get; set; }

        public int HardwareId { get; set; }

        public int SupplyId { get; set; }

        public string SupplyName { get; set; }

        public string SupplyReference { get; set; }

        public string SupplyCategory { get; set; }

        public int SupplyModuleSize { get; set; }

        public double SupplyCatalogPrice { get; set; }

        public double SupplyPrice { get; set; }

        public virtual int SupplyPFC0 { get; set; }

        public virtual int SupplyPFC12 { get; set; }

        public virtual int SupplyCap { get; set; }

        public int Quantity { get; set; }

        public string Comment { get; set; }
    }
}