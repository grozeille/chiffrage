using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using AutoMapper;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.ViewModel
{
    public class CatalogViewModel
    {
        public static CatalogViewModel Build(SupplierCatalog catalog)
        {
            Mapper.CreateMap<SupplierCatalog, CatalogViewModel>()
                .ForMember(dest => dest.Hardwares, opt => opt.Ignore())
                .ForMember(dest => dest.Supplies, opt => opt.Ignore());

            var result = new CatalogViewModel();
            Mapper.Map(catalog, result);

            foreach(var item in catalog.Supplies)
            {
                result.Supplies.Add(CatalogSupplyViewModel.Build(item));
            }

            foreach (var item in catalog.Hardwares)
            {
                result.Hardwares.Add(CatalogHardwareViewModel.Build(item));
            }

            return result;
        }

        public int Id { get; set; }

        public string SupplierName { get; set; }

        public string Comment { get; set; }

        public BindingList<CatalogSupplyViewModel> Supplies { get; set; }

        public BindingList<CatalogHardwareViewModel> Hardwares { get; set; }

        public CatalogViewModel()
        {
            this.Supplies = new BindingList<CatalogSupplyViewModel>();
            this.Hardwares = new BindingList<CatalogHardwareViewModel>();
        }
    }
}
