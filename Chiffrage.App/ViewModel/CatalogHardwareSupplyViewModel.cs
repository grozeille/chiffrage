using System.ComponentModel;

namespace Chiffrage.App.ViewModel
{
    public class CatalogHardwareSupplyViewModel
    {
        public int Id { get; set; }

        public int CatalogId { get; set; }

        public int HardwareId { get; set; }

        public int SupplyId { get; set; }

        public string SupplyName { get; set; }

        public string SupplyReference { get; set; }

        public string SupplyCategory { get; set; }

        public int SupplyModuleSize { get; set; }

        public double SupplyCatalogPrice { get; set; }

        public double SupplyStudyDays { get; set; }

        public double SupplyReferenceDays { get; set; }

        public double SupplyCatalogWorkDays { get; set; }

        public double SupplyCatalogExecutiveWorkDays { get; set; }

        public double SupplyCatalogTestsDays { get; set; }

        public int Quantity { get; set; }
    }
}