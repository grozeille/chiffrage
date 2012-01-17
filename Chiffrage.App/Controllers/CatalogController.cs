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
        IGenericEventHandler<RequestDeleteSupplyEvent>,
        IGenericEventHandler<RequestDeleteHardwareEvent>, 
        IGenericEventHandler<CreateNewHardwareEvent>,
        IGenericEventHandler<CreateNewHardwareSupplyEvent>,
        IGenericEventHandler<EditSupplyEvent>,
        IGenericEventHandler<EditHardwareEvent>,
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
            Mapper.CreateMap<Supply, CatalogSupplyViewModel>();
            Mapper.CreateMap<Hardware, CatalogHardwareViewModel>();

            var result = Mapper.Map<SupplierCatalog, CatalogViewModel>(eventObject.Catalog);
            foreach (var item in result.Hardwares)
            {
                item.CatalogId = result.Id;
            }
            foreach (var item in result.Supplies)
            {
                item.CatalogId = result.Id;
            }

            this.catalogView.Display(result);
        }

        public void ProcessAction(CreateNewHardwareSupplyEvent eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);
            var hardware = catalog.Hardwares.Where(x => x.Id == eventObject.HardwareId).First();
            var supply = catalog.Supplies.Where(x => x.Id == eventObject.SupplyId).First();
            
            var hardwareSupply = new HardwareSupply
            {
                Quantity = eventObject.Quantity,
                Supply = supply
            };

            // supply name must be unique in hardaware components
            if (hardware.Components.Where(x => x.Id == supply.Id).Any())
            {
                this.eventBroker.Publish(new HardwareSupplyMustBeUniqueErrorEvent(catalog.Id, hardware.Id, supply));
            }
            else
            {
                hardware.Components.Add(hardwareSupply);

                this.repository.Save(catalog);

                this.eventBroker.Publish(new HardwareSupplyCreatedEvent(catalog.Id, hardware.Id, hardwareSupply));

                this.eventBroker.Publish(new HardwareUpdatedEvent(catalog.Id, hardware));
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

            this.eventBroker.Publish(new UpdateCatalogCommand(viewModel.Id, viewModel.SupplierName, viewModel.Comment));
        }

        public void DisplayCatalog(int id)
        {
            var catalog = this.repository.FindById(id);

            Mapper.CreateMap<SupplierCatalog, CatalogViewModel>();
            Mapper.CreateMap<Supply, CatalogSupplyViewModel>();
            Mapper.CreateMap<Hardware, CatalogHardwareViewModel>();
            Mapper.CreateMap<HardwareSupply, CatalogHardwareSupplyViewModel>();
            
            var result = Mapper.Map<SupplierCatalog, CatalogViewModel>(catalog);
            foreach(var item in result.Supplies)
            {
                item.CatalogId = result.Id;
            }
            foreach (var item in result.Hardwares)
            {
                item.CatalogId = result.Id;
                item.ModuleSize = item.Components.Sum(x => x.SupplyModuleSize * x.Quantity);
                item.CatalogPrice = item.Components.Sum(x => x.SupplyCatalogPrice * x.Quantity);
                item.CatalogWorkDays = item.Components.Sum(x => x.SupplyCatalogWorkDays * x.Quantity);
                item.CatalogExecutiveWorkDays = item.Components.Sum(x => x.SupplyCatalogExecutiveWorkDays * x.Quantity);
                item.ReferenceDays = item.Components.Sum(x => x.SupplyReferenceDays * x.Quantity);
                item.StudyDays = item.Components.Sum(x => x.SupplyStudyDays * x.Quantity);
                item.CatalogTestsDays = item.Components.Sum(x => x.SupplyCatalogTestsDays * x.Quantity);
                foreach (var subItem in item.Components)
                {
                    subItem.CatalogId = result.Id;
                    subItem.HardwareId = item.Id;
                }
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

        public void ProcessAction(RequestEditHardwareEvent eventObject)
        {
            this.editHardwareView.Hardware = eventObject.Hardware;

            this.editHardwareView.ShowView();
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

        public void ProcessAction(EditHardwareEvent eventObject)
        {
            var catalog = this.repository.FindById(eventObject.ViewModel.CatalogId);

            var hardware = catalog.Hardwares.Where(s => s.Id == eventObject.ViewModel.Id).First();

            Mapper.CreateMap<CatalogHardwareViewModel, Hardware>();

            Mapper.Map(eventObject.ViewModel, hardware);

            this.repository.Save(catalog);

            this.eventBroker.Publish(new HardwareUpdatedEvent(catalog.Id, hardware));
        }

        public void ProcessAction(SupplyUpdatedEvent eventObject)
        {
            Mapper.CreateMap<Supply, CatalogSupplyViewModel>();

            var result = Mapper.Map<Supply, CatalogSupplyViewModel>(eventObject.Supply);
            result.CatalogId = eventObject.CatalogId;

            this.catalogView.UpdateSupply(result);
        }

        public void ProcessAction(HardwareUpdatedEvent eventObject)
        {
            Mapper.CreateMap<Hardware, CatalogHardwareViewModel>();
            Mapper.CreateMap<HardwareSupply, CatalogHardwareSupplyViewModel>();

            var result = Mapper.Map<Hardware, CatalogHardwareViewModel>(eventObject.Hardware);
            result.CatalogId = eventObject.CatalogId;
            result.ModuleSize = result.Components.Sum(x => x.SupplyModuleSize * x.Quantity);
            result.CatalogPrice = result.Components.Sum(x => x.SupplyCatalogPrice * x.Quantity);
            result.CatalogWorkDays = result.Components.Sum(x => x.SupplyCatalogWorkDays * x.Quantity);
            result.CatalogExecutiveWorkDays = result.Components.Sum(x => x.SupplyCatalogExecutiveWorkDays * x.Quantity);
            result.ReferenceDays = result.Components.Sum(x => x.SupplyReferenceDays * x.Quantity);
            result.StudyDays = result.Components.Sum(x => x.SupplyStudyDays * x.Quantity);
            result.CatalogTestsDays = result.Components.Sum(x => x.SupplyCatalogTestsDays * x.Quantity);

            foreach (var item in result.Components)
            {
                item.CatalogId = result.Id;
                item.HardwareId = item.Id;
            }

            this.catalogView.UpdateHardware(result);
        }

        public void ProcessAction(HardwareDeletedEvent eventObject)
        {
            Mapper.CreateMap<Hardware, CatalogHardwareViewModel>();

            var result = Mapper.Map<Hardware, CatalogHardwareViewModel>(eventObject.Hardware);

            this.catalogView.RemoveHardware(result);
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

        public void ProcessAction(RequestDeleteHardwareEvent eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);

            var hardware = catalog.Hardwares.Where(x => x.Id == eventObject.HardwareId).FirstOrDefault();

            if (hardware != null)
            {
                catalog.Hardwares.Remove(hardware);

                this.repository.Save(catalog);

                this.eventBroker.Publish(new HardwareDeletedEvent(catalog.Id, hardware));
            }
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

        public void ProcessAction(CreateNewHardwareEvent eventObject)
        {
            var catalog = this.repository.FindById(eventObject.ViewModel.CatalogId);

            Mapper.CreateMap<CatalogHardwareViewModel, Hardware>();

            var hardware = Mapper.Map<CatalogHardwareViewModel, Hardware>(eventObject.ViewModel);

            // supply name must be unique
            if (catalog.Hardwares.Where(x => x.Name.Equals(hardware.Name, System.StringComparison.OrdinalIgnoreCase)).Any())
            {
                this.eventBroker.Publish(new HardwareMustBeUniqueErrorEvent(catalog.Id, hardware));
            }
            else
            {
                catalog.Hardwares.Add(hardware);

                this.repository.Save(catalog);

                this.eventBroker.Publish(new HardwareCreatedEvent(catalog.Id, hardware));
            }
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
            Mapper.CreateMap<Supply, CatalogHardwareSupplyViewModel>();

            var result = Mapper.Map<Supply, CatalogHardwareSupplyViewModel>(eventObject.Component.Supply);
            result.CatalogId = eventObject.CatalogId;
            result.SupplyId = eventObject.Component.Supply.Id;
            result.Id = eventObject.Component.Id;
            result.Quantity = eventObject.Component.Quantity;
            result.HardwareId = eventObject.HardwareId;

            this.catalogView.AddHardwareSupply(result);
        }
    }
}