using System.Linq;
using AutoMapper;
using Chiffrage.App.Events;
using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Catalogs.Domain.Repositories;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Controllers;
using System.Collections.Generic;
using Chiffrage.Catalogs.Domain.Commands;
using Chiffrage.Catalogs.Domain.Events;
using System.ComponentModel;

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
        IGenericEventHandler<RequestNewHardwareEvent>,
        IGenericEventHandler<RequestNewHardwareSupplyEvent>,
        IGenericEventHandler<RequestEditSupplyEvent>,
        IGenericEventHandler<RequestEditHardwareEvent>,
        IGenericEventHandler<SupplyCreatedEvent>,
        IGenericEventHandler<SupplyUpdatedEvent>,        
        IGenericEventHandler<SupplyDeletedEvent>,
        IGenericEventHandler<HardwareCreatedEvent>,
        IGenericEventHandler<HardwareUpdatedEvent>,        
        IGenericEventHandler<HardwareDeletedEvent>,
        IGenericEventHandler<HardwareSupplyCreatedEvent>
    {
        private readonly ICatalogView catalogView;
        private readonly IEventBroker eventBroker;
        private readonly INewCatalogView newCatalogView;
        private readonly INewSupplyView newSupplyView;
        private readonly INewHardwareView newHardwareView;
        private readonly IEditSupplyView editSupplyView;
        private readonly IEditHardwareView editHardwareView;
        private readonly ICatalogRepository repository;
        private readonly INewHardwareSupplyView newHardwareSupplyView;

        public CatalogController(
            IEventBroker eventBroker,
            ICatalogView catalogView,
            INewCatalogView newCatalogView,
            INewSupplyView newSupplyView,
            INewHardwareView newHardwareView,
            IEditSupplyView editSupplyView,
            IEditHardwareView editHardwareView,
            INewHardwareSupplyView newHardwareSupplyView,
            ICatalogRepository repository)
        {
            this.catalogView = catalogView;
            this.newCatalogView = newCatalogView;
            this.newSupplyView = newSupplyView;
            this.newHardwareView = newHardwareView;
            this.editSupplyView = editSupplyView;
            this.editHardwareView = editHardwareView;
            this.newHardwareSupplyView = newHardwareSupplyView;
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

            var result = Mapper.Map<SupplierCatalog, CatalogViewModel>(eventObject.Catalog);

            this.catalogView.Display(result);
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

            this.eventBroker.Publish(new UpdateCatalogCommand(viewModel.Id, viewModel.SupplierName, viewModel.Comment));
        }

        public void DisplayCatalog(int id)
        {
            var catalog = this.repository.FindById(id);

            Mapper.CreateMap<SupplierCatalog, CatalogViewModel>();
            Mapper.CreateMap<Supply, CatalogSupplyViewModel>();
            Mapper.CreateMap<Hardware, CatalogHardwareViewModel>();
            Mapper.CreateMap<HardwareSupply, CatalogHardwareSupplyViewModel>();

            var catalogViewModel = Mapper.Map<SupplierCatalog, CatalogViewModel>(catalog);

            var suppliesViewModel = Mapper.Map<IList<Supply>, IList<CatalogSupplyViewModel>>(catalog.Supplies);
            foreach (var item in suppliesViewModel)
            {
                item.CatalogId = catalogViewModel.Id;
            }

            var hardwaresViewModel = new List<CatalogHardwareViewModel>();
            foreach (var item in catalog.Hardwares)
            {
                hardwaresViewModel.Add(Map(catalog.Id, item));
            }
            
            this.catalogView.Display(catalogViewModel);
            this.catalogView.RemoveAllHardwares();
            this.catalogView.RemoveSupplies();
            this.catalogView.AddSupplies(suppliesViewModel);
            this.catalogView.AddHardwares(hardwaresViewModel);
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

        public void ProcessAction(RequestEditHardwareEvent eventObject)
        {
            this.editHardwareView.Hardware = eventObject.Hardware;

            this.editHardwareView.ShowView();
        }

        public void ProcessAction(SupplyUpdatedEvent eventObject)
        {
            Mapper.CreateMap<Supply, CatalogSupplyViewModel>();

            var result = Mapper.Map<Supply, CatalogSupplyViewModel>(eventObject.Supply);
            result.CatalogId = eventObject.CatalogId;

            this.catalogView.UpdateSupply(result);

            // update also the HardwareSupplies
            var catalog = this.repository.FindById(eventObject.CatalogId);
            var hardwareToUpdates = catalog.Hardwares
                .Where(x => x.Components.Where(y => y.Supply.Id == eventObject.Supply.Id).Any())
                .Select(x => Map(eventObject.CatalogId, x))
                .ToList();

            this.catalogView.UpdateHardwares(hardwareToUpdates);
        }

        public void ProcessAction(HardwareUpdatedEvent eventObject)
        {
            var result = Map(eventObject.CatalogId, eventObject.Hardware);

            this.catalogView.UpdateHardware(result);
        }

        public void ProcessAction(HardwareDeletedEvent eventObject)
        {
            Mapper.CreateMap<Hardware, CatalogHardwareViewModel>();

            var result = Mapper.Map<Hardware, CatalogHardwareViewModel>(eventObject.Hardware);

            this.catalogView.RemoveHardware(result);
        }

        public void ProcessAction(SupplyDeletedEvent eventObject)
        {
            Mapper.CreateMap<Supply, CatalogSupplyViewModel>();

            var result = Mapper.Map<Supply, CatalogSupplyViewModel>(eventObject.Supply);

            this.catalogView.RemoveSupply(result);
        }

        public void ProcessAction(RequestNewHardwareEvent eventObject)
        {
            this.newHardwareView.CatalogId = eventObject.CatalogId;
            this.newHardwareView.ShowView();
        }

        public void ProcessAction(RequestNewHardwareSupplyEvent eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);
            Mapper.CreateMap<Supply, CatalogSupplyViewModel>();

            var supplies = Mapper.Map<IList<Supply>, IList<CatalogSupplyViewModel>>(catalog.Supplies);

            this.newHardwareSupplyView.CatalogId = eventObject.CatalogId;
            this.newHardwareSupplyView.ParentHardwareId = eventObject.HardwareId;
            this.newHardwareSupplyView.Supplies = supplies;
            this.newHardwareSupplyView.ShowView();
        }

        public void ProcessAction(HardwareCreatedEvent eventObject)
        {
            Mapper.CreateMap<Supply, CatalogHardwareViewModel>();

            var result = Mapper.Map<Hardware, CatalogHardwareViewModel>(eventObject.Hardware);
            result.CatalogId = eventObject.CatalogId;

            this.catalogView.AddHardware(result);
        }

        public void ProcessAction(HardwareSupplyCreatedEvent eventObject)
        {
            var result = Map(eventObject.CatalogId, eventObject.Hardware);

            this.catalogView.UpdateHardware(result);
        }

        private CatalogHardwareViewModel Map(int catalogId, Hardware hardware)
        {
            Mapper.CreateMap<HardwareSupply, CatalogHardwareSupplyViewModel>();
            Mapper.CreateMap<Hardware, CatalogHardwareViewModel>();

            var result = Mapper.Map<Hardware, CatalogHardwareViewModel>(hardware);
            result.CatalogId = catalogId;
            result.ModuleSize = result.Components.Sum(x => x.SupplyModuleSize * x.Quantity);
            result.CatalogPrice = result.Components.Sum(x => x.SupplyCatalogPrice * x.Quantity);
            result.CatalogWorkDays = result.Components.Sum(x => x.SupplyCatalogWorkDays * x.Quantity);
            result.CatalogExecutiveWorkDays = result.Components.Sum(x => x.SupplyCatalogExecutiveWorkDays * x.Quantity);
            result.ReferenceDays = result.Components.Sum(x => x.SupplyReferenceDays * x.Quantity);
            result.StudyDays = result.Components.Sum(x => x.SupplyStudyDays * x.Quantity);
            result.CatalogTestsDays = result.Components.Sum(x => x.SupplyCatalogTestsDays * x.Quantity);
            foreach (var subItem in result.Components)
            {
                subItem.CatalogId = catalogId;
                subItem.HardwareId = result.Id;
            }

            return result;
        }
    }
}