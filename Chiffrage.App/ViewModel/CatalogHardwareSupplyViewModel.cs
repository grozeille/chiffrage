using AutoMapper;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.App.ViewModel
{
    public class CatalogHardwareSupplyViewModel
    {
        public int Id { get; set; }

        public int SupplyId { get; set; }

        public int Quantity { get; set; }

        public string Name { get; set; }

        public string Reference { get; set; }

        public string Category { get; set; }

        public int ModuleSize { get; set; }

        public double CatalogPrice { get; set; }

        public double StudyDays { get; set; }

        public double ReferenceDays { get; set; }

        public double CatalogWorkDays { get; set; }

        public double CatalogExecutiveWorkDays { get; set; }

        public double CatalogTestsDays { get; set; }

        public static CatalogHardwareSupplyViewModel CreateFrom(HardwareSupply supply)
        {
            Mapper.CreateMap<HardwareSupply, CatalogHardwareViewModel>();
            Mapper.CreateMap<HardwareSupply, CatalogHardwareSupplyViewModel>();

            var result = new CatalogHardwareSupplyViewModel();

            Mapper.Map(supply, result);

            return result;
        }

        public void CopyTo(HardwareSupply supply)
        {
            Mapper.CreateMap<CatalogHardwareViewModel, HardwareSupply>();
            Mapper.CreateMap<CatalogHardwareSupplyViewModel, HardwareSupply>();

            Mapper.Map(this, supply);
        }
    }
}