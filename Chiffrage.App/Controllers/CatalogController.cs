using System.Linq;
using AutoMapper;
using Chiffrage.App.Events;
using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Catalogs.Domain.Repositories;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Controllers;

namespace Chiffrage.App.Controllers
{
    public class CatalogController :
        IController,
        IGenericEventHandler<CatalogSelectedEvent>,
        IGenericEventHandler<CatalogUnselectedEvent>,
        IGenericEventHandler<ApplicationStartEvent>,
        IGenericEventHandler<CatalogUpdatedEvent>,
        IGenericEventHandler<SaveEvent>,
        IGenericEventHandler<RequestNewCatalogEvent>,
        IGenericEventHandler<RequestNewSupplyEvent>,
        IGenericEventHandler<CreateNewSupplyEvent>,
        IGenericEventHandler<CreateNewCatalogEvent>,
        IGenericEventHandler<SupplyCreatedEvent>,
        IGenericEventHandler<RequestEditSupplyEvent>,
        IGenericEventHandler<EditSupplyEvent>,
        IGenericEventHandler<SupplyUpdatedEvent>,
        IGenericEventHandler<RequestDeleteSupplyEvent>,
        IGenericEventHandler<SupplyDeletedEvent>
    {
        private readonly ICatalogView catalogView;
        private readonly IEventBroker eventBroker;
        private readonly INewCatalogView newCatalogView;
        private readonly INewSupplyView newSupplyView;
        private readonly IEditSupplyView editSupplyView;
        private readonly ICatalogRepository repository;

        public CatalogController(
            IEventBroker eventBroker,
            ICatalogView catalogView,
            INewCatalogView newCatalogView,
            INewSupplyView newSupplyView,
            IEditSupplyView editSupplyView,
            ICatalogRepository repository)
        {
            this.catalogView = catalogView;
            this.newCatalogView = newCatalogView;
            this.newSupplyView = newSupplyView;
            this.editSupplyView = editSupplyView;
            this.repository = repository;
            this.eventBroker = eventBroker;
        }

        public void ProcessAction(ApplicationStartEvent eventObject)
        {
            this.catalogView.HideView();
        }

        public void ProcessAction(CatalogSelectedEvent eventObject)
        {
            this.catalogView.ShowView();
            this.DisplayCatalog(eventObject.Id);
        }

        public void ProcessAction(CatalogUnselectedEvent eventObject)
        {
            this.catalogView.HideView();
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

        public void ProcessAction(CatalogUpdatedEvent eventObject)
        {
            Mapper.CreateMap<SupplierCatalog, CatalogViewModel>();

            var result = Mapper.Map<SupplierCatalog, CatalogViewModel>(eventObject.NewCatalog);

            this.catalogView.Display(result);
        }

        public void ProcessAction(CreateNewCatalogEvent eventObject)
        {
            var catalog = new SupplierCatalog();
            catalog.SupplierName = eventObject.Name;

            this.repository.Save(catalog);

            this.eventBroker.Publish(new CatalogCreatedEvent(catalog));
        }

        public void ProcessAction(CreateNewSupplyEvent eventObject)
        {
            var catalog = this.repository.FindById(eventObject.ViewModel.CatalogId);

            Mapper.CreateMap<CatalogSupplyViewModel, Supply>();

            var supply = Mapper.Map<CatalogSupplyViewModel, Supply>(eventObject.ViewModel);

            // supply name must be unique
            if (catalog.Supplies.Where(x => x.Name.Equals(supply.Name, System.StringComparison.OrdinalIgnoreCase)).Any())
            {
                this.eventBroker.Publish(new SupplyMustBeUniqueErrorEvent(catalog.Id, supply));
            }
            else
            {
                catalog.Supplies.Add(supply);

                this.repository.Save(catalog);

                this.eventBroker.Publish(new SupplyCreatedEvent(catalog.Id, supply));
            }
        }

        public void ProcessAction(RequestNewSupplyEvent eventObject)
        {
            this.newSupplyView.CatalogId = eventObject.CatalogId;
            this.newSupplyView.ShowView();
        }

        public void ProcessAction(RequestNewCatalogEvent eventObject)
        {
            this.newCatalogView.ShowView();
        }

        public void ProcessAction(SaveEvent eventObject)
        {
            var viewModel = this.catalogView.GetViewModel();
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

        public void DisplayCatalog(int id)
        {
            var catalog = this.repository.FindById(id);

            Mapper.CreateMap<SupplierCatalog, CatalogViewModel>();
            Mapper.CreateMap<Supply, CatalogSupplyViewModel>();
            
            var result = Mapper.Map<SupplierCatalog, CatalogViewModel>(catalog);
            foreach(var item in result.Supplies)
            {
                item.CatalogId = result.Id;
            }

            this.catalogView.Display(result);
        }

        public void SaveCatalog(CatalogViewModel model)
        {
            Mapper.CreateMap<CatalogViewModel, SupplierCatalog>();

            var catalog = this.repository.FindById(model.Id);

            Mapper.Map(model, catalog);

            this.repository.Save(catalog);

            this.eventBroker.Publish(new CatalogUpdatedEvent(catalog));
        }

        public void ProcessAction(SupplyCreatedEvent eventObject)
        {
            Mapper.CreateMap<Supply, CatalogSupplyViewModel>();

            var result = Mapper.Map<Supply, CatalogSupplyViewModel>(eventObject.Supply);
            result.CatalogId = eventObject.CatalogId;

            this.catalogView.AddSupply(result);
        }

        public void ProcessAction(RequestEditSupplyEvent eventObject)
        {
            this.editSupplyView.Supply = eventObject.Supply;

            this.editSupplyView.ShowView();
        }

        public void ProcessAction(EditSupplyEvent eventObject)
        {
            var catalog = this.repository.FindById(eventObject.ViewModel.CatalogId);

            var supply = catalog.Supplies.Where(s => s.Id == eventObject.ViewModel.Id).First();

            Mapper.CreateMap<CatalogSupplyViewModel, Supply>();

            Mapper.Map(eventObject.ViewModel, supply);

            this.repository.Save(catalog);

            this.eventBroker.Publish(new SupplyUpdatedEvent(catalog.Id, supply));
        }

        public void ProcessAction(SupplyUpdatedEvent eventObject)
        {
            Mapper.CreateMap<Supply, CatalogSupplyViewModel>();

            var result = Mapper.Map<Supply, CatalogSupplyViewModel>(eventObject.Supply);
            result.CatalogId = eventObject.CatalogId;

            this.catalogView.UpdateSupply(result);
        }

        public void ProcessAction(RequestDeleteSupplyEvent eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);

            var supply = catalog.Supplies.Where(x => x.Id == eventObject.SupplyId).FirstOrDefault();

            if (supply != null)
            {
                catalog.Supplies.Remove(supply);

                this.repository.Save(catalog);

                this.eventBroker.Publish(new SupplyDeletedEvent(catalog.Id, supply));
            }
        }

        public void ProcessAction(SupplyDeletedEvent eventObject)
        {
            Mapper.CreateMap<Supply, CatalogSupplyViewModel>();

            var result = Mapper.Map<Supply, CatalogSupplyViewModel>(eventObject.Supply);

            this.catalogView.RemoveSupply(result);
        }
    }
}