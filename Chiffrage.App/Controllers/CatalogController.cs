using System;
using AutoMapper;
using Chiffrage.App.Events;
using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Catalogs.Domain.Repositories;
using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Controllers
{
    public class CatalogController : IGenericEventHandler<CatalogSelectedEvent>,
                                     IGenericEventHandler<CatalogUnselectedEvent>,
                                     IGenericEventHandler<ApplicationStartEvent>,
                                     IGenericEventHandler<CatalogUpdatedEvent>,
                                     IGenericEventHandler<SaveEvent>
    {
        private readonly ICatalogRepository repository;
        private readonly ICatalogView view;
        private readonly IEventBroker eventBroker;

        public CatalogController(IEventBroker eventBroker, ICatalogView view, ICatalogRepository repository)
        {
            this.view = view;
            this.repository = repository;
            this.eventBroker = eventBroker;
        }

        /*
        public CatalogViewModel BuildCatalogViewModel(SupplierCatalog catalog)
        {
            Mapper.CreateMap<Supply, CatalogSupplyViewModel>();

            Mapper.CreateMap<SupplierCatalog, CatalogViewModel>()
                .ForMember(dest => dest.Hardwares, opt => opt.Ignore());
                //.ForMember(dest => dest.Supplies, opt => opt.Ignore());

            var result = new CatalogViewModel();

            Mapper.Map(catalog, result);

            foreach (var item in catalog.Hardwares)
            {
                var viewModel = new CatalogHardwareViewModel();
                this.Map(item, viewModel);
                result.Hardwares.Add(viewModel);
            }

            return result;
        }

        private void Map(Hardware hardware, CatalogHardwareViewModel viewModel)
        {
            Mapper.CreateMap<Hardware, CatalogHardwareViewModel>();
            Mapper.CreateMap<HardwareSupply, CatalogHardwareSupplyViewModel>();

            Mapper.Map(hardware, this);

            for (int i = 0; i < hardware.Components.Count; i++)
            {
                var supply = hardware.Components[i].Supply;
                var supplyViewModel = viewModel.Components[i];

                Mapper.CreateMap<Supply, CatalogHardwareSupplyViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.SupplyId, opt => opt.MapFrom(src => src.Id));

                Mapper.Map(supply, supplyViewModel);
            }
        }

        private void Map(CatalogHardwareViewModel viewModel, Hardware hardware)
        {
            Mapper.CreateMap<CatalogHardwareViewModel, Hardware>();
            Mapper.CreateMap<CatalogHardwareSupplyViewModel, HardwareSupply>();

            Mapper.Map(this, hardware);

            for (int i = 0; i < hardware.Components.Count; i++)
            {
                var supply = hardware.Components[i].Supply;
                var supplyViewModel = viewModel.Components[i];

                Mapper.CreateMap<CatalogHardwareSupplyViewModel, Supply>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SupplyId));
                Mapper.Map(supplyViewModel, supply);
            }

        }*/

        #region ICatalogController Members

        public void DisplayCatalog(int id)
        {
            var catalog = this.repository.FindById(id);

            Mapper.CreateMap<SupplierCatalog, CatalogViewModel>();

            var result = Mapper.Map<SupplierCatalog, CatalogViewModel>(catalog);

            this.view.Display(result);
        }

        public void SaveCatalog(CatalogViewModel model)
        {
            Mapper.CreateMap<CatalogViewModel, SupplierCatalog>();

            var catalog = this.repository.FindById(model.Id);

            Mapper.Map(model, catalog);

            this.repository.Save(catalog);

            this.eventBroker.Publish(new CatalogUpdatedEvent(catalog));
        }

        #endregion

        #region IGenericEventHandler<ApplicationStartEvent> Members

        public void ProcessAction(ApplicationStartEvent eventObject)
        {
            this.view.HideView();
        }

        #endregion

        #region IGenericEventHandler<CatalogSelectedEvent> Members

        public void ProcessAction(CatalogSelectedEvent eventObject)
        {
            this.view.ShowView();
            this.DisplayCatalog(eventObject.Id);
        }

        #endregion

        #region IGenericEventHandler<CatalogUnselectedEvent> Members

        public void ProcessAction(CatalogUnselectedEvent eventObject)
        {
            this.view.HideView();
        }

        #endregion

        public void ProcessAction(CatalogUpdatedEvent eventObject)
        {
            Mapper.CreateMap<SupplierCatalog, CatalogViewModel>();

            var result = Mapper.Map<SupplierCatalog, CatalogViewModel>(eventObject.NewCatalog);

            this.view.Display(result);
        }

        public void ProcessAction(SaveEvent eventObject)
        {
            var viewModel = this.view.GetViewModel();
            if (viewModel == null)
            {
                return;
            }

            Mapper.CreateMap<CatalogViewModel, SupplierCatalog>();

            var catalog = this.repository.FindById(viewModel.Id);

            Mapper.Map(viewModel, catalog);

            this.repository.Save(catalog);

            this.eventBroker.Publish(new CatalogUpdatedEvent(catalog));
        }
    }
}