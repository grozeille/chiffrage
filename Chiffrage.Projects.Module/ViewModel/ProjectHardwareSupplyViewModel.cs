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

        public int SupplyPFC0 { get; set; }

        public int SupplyPFC12 { get; set; }

        public int SupplyCap { get; set; }

        public int Quantity { get; set; }

        public string Comment { get; set; }

        public int TotalSupplyModuleSize { get; set; }

        public double TotalSupplyCatalogPrice { get; set; }

        public double TotalSupplyPFC0 { get; set; }

        public double TotalSupplyPFC12 { get; set; }

        public double TotalSupplyCap { get; set; }

        public double TotalSupplyPrice { get; set; }
    }
}