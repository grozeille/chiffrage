using System.Linq;
using AutoMapper;
using Chiffrage.Catalogs.Module.Actions;
using Chiffrage.Catalogs.Module.ViewModel;
using Chiffrage.Catalogs.Module.Views;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Catalogs.Domain.Repositories;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Controllers;
using System.Collections.Generic;
using Chiffrage.Catalogs.Domain.Commands;
using Chiffrage.Catalogs.Domain.Events;
using System.ComponentModel;
using Chiffrage.Common.Module.Actions;
using System;
using Chiffrage.Mvc.Views;

namespace Chiffrage.Catalogs.Module.Controllers
{
    public class CatalogController : IController
    {
        private readonly ICatalogRepository repository;
        private readonly ITaskRepository taskRepository;
        
        private readonly ICatalogView catalogView;
        private readonly INewCatalogView newCatalogView;
        private readonly INewSupplyView newSupplyView;
        private readonly INewHardwareView newHardwareView;
        private readonly IEditSupplyView editSupplyView;
        private readonly IEditHardwareView editHardwareView;
        private readonly INewHardwareSupplyView newHardwareSupplyView;
        private readonly IEditHardwareSupplyView editHardwareSupplyView;
        private readonly IImportHardwareView importHardwareView;
        private readonly ILoadingView loadingView;

        // no better way...
        private readonly System.Windows.Forms.RichTextBox rtBox = new System.Windows.Forms.RichTextBox();

        [Publish]
        public event Action<UpdateCatalogCommand> OnCatalogUpdateCommand;

        public CatalogController(
            ICatalogRepository repository,
            ITaskRepository taskRepository,
            ICatalogView catalogView,
            INewCatalogView newCatalogView,
            INewSupplyView newSupplyView,
            INewHardwareView newHardwareView,
            IEditSupplyView editSupplyView,
            IEditHardwareView editHardwareView,
            INewHardwareSupplyView newHardwareSupplyView,
            IEditHardwareSupplyView editHardwareSupplyView,
            IImportHardwareView importHardwareView,
            ILoadingView loadingView)
        {
            this.catalogView = catalogView;
            this.newCatalogView = newCatalogView;
            this.newSupplyView = newSupplyView;
            this.newHardwareView = newHardwareView;
            this.editSupplyView = editSupplyView;
            this.editHardwareView = editHardwareView;
            this.newHardwareSupplyView = newHardwareSupplyView;
            this.editHardwareSupplyView = editHardwareSupplyView;
            this.importHardwareView = importHardwareView;
            this.loadingView = loadingView;
            this.repository = repository;
            this.taskRepository = taskRepository;
        }

        [Subscribe]
        public void ProcessAction(ApplicationStartAction eventObject)
        {
            this.catalogView.HideView();
        }

        [Subscribe]
        public void ProcessAction(CatalogSelectedAction eventObject)
        {
            this.loadingView.Continuous = true;
            this.loadingView.ShowView();

            this.DisplayCatalog(eventObject.Id);

            this.loadingView.HideView();
            this.catalogView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(CatalogUnselectedAction eventObject)
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

        [Subscribe]
        public void ProcessAction(CatalogUpdatedEvent eventObject)
        {
            Mapper.CreateMap<SupplierCatalog, CatalogViewModel>();

            var result = Mapper.Map<SupplierCatalog, CatalogViewModel>(eventObject.Catalog);

            this.catalogView.Display(result, this.taskRepository.FindAll());
        }

        [Subscribe]
        public void ProcessAction(RequestNewSupplyAction eventObject)
        {
            this.newSupplyView.CatalogId = eventObject.CatalogId;
            this.newSupplyView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(RequestNewCatalogAction eventObject)
        {
            this.newCatalogView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(SaveAction eventObject)
        {
            var viewModel = this.catalogView.GetViewModel();
            if (viewModel == null)
            {
                return;
            }

            //this.eventBroker.Publish(new UpdateCatalogCommand(viewModel.Id, viewModel.SupplierName, viewModel.Comment));
            OnCatalogUpdateCommand(new UpdateCatalogCommand(viewModel.Id, viewModel.SupplierName, viewModel.Comment));
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

            this.catalogView.Display(catalogViewModel, this.taskRepository.FindAll());
            this.catalogView.RemoveAllHardwares();
            this.catalogView.RemoveSupplies();
            this.catalogView.AddSupplies(suppliesViewModel);
            this.catalogView.AddHardwares(hardwaresViewModel);
        }

        [Subscribe]
        public void ProcessAction(SupplyCreatedEvent eventObject)
        {
            Mapper.CreateMap<Supply, CatalogSupplyViewModel>();

            var result = Mapper.Map<Supply, CatalogSupplyViewModel>(eventObject.Supply);
            result.CatalogId = eventObject.CatalogId;

            this.catalogView.AddSupply(result);
        }

        [Subscribe]
        public void ProcessAction(RequestEditSupplyAction eventObject)
        {
            this.editSupplyView.Supply = eventObject.Supply;

            this.editSupplyView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(RequestEditHardwareAction eventObject)
        {
            SupplierCatalog catalog = this.repository.FindById(eventObject.Hardware.CatalogId);
            Hardware hardware = catalog.Hardwares.Where(x => x.Id == eventObject.Hardware.Id).FirstOrDefault();

            this.editHardwareView.Hardware = eventObject.Hardware;
            this.editHardwareView.CatalogTasks = this.taskRepository.FindAll();
            this.editHardwareView.HardwareTask = hardware.Tasks;

            this.editHardwareView.ShowView();
        }

        [Subscribe]
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

        [Subscribe]
        public void ProcessAction(HardwareUpdatedEvent eventObject)
        {
            var result = Map(eventObject.CatalogId, eventObject.Hardware);

            this.catalogView.UpdateHardware(result);
        }

        [Subscribe]
        public void ProcessAction(HardwareDeletedEvent eventObject)
        {
            Mapper.CreateMap<Hardware, CatalogHardwareViewModel>();

            var result = Mapper.Map<Hardware, CatalogHardwareViewModel>(eventObject.Hardware);

            this.catalogView.RemoveHardware(result);
        }

        [Subscribe]
        public void ProcessAction(SupplyDeletedEvent eventObject)
        {
            Mapper.CreateMap<Supply, CatalogSupplyViewModel>();

            var result = Mapper.Map<Supply, CatalogSupplyViewModel>(eventObject.Supply);

            this.catalogView.RemoveSupply(result);
        }

        [Subscribe]
        public void ProcessAction(RequestNewHardwareAction eventObject)
        {
            this.newHardwareView.CatalogId = eventObject.CatalogId;
            this.newHardwareView.Tasks = this.taskRepository.FindAll();
            this.newHardwareView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(RequestNewHardwareSupplyAction eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);
            Mapper.CreateMap<Supply, CatalogSupplyViewModel>();

            var supplies = Mapper.Map<IList<Supply>, IList<CatalogSupplyViewModel>>(catalog.Supplies);

            this.newHardwareSupplyView.CatalogId = eventObject.CatalogId;
            this.newHardwareSupplyView.ParentHardwareId = eventObject.HardwareId;
            this.newHardwareSupplyView.Supplies = supplies;
            this.newHardwareSupplyView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(HardwareCreatedEvent eventObject)
        {
            var result = Map(eventObject.CatalogId, eventObject.Hardware);
            result.CatalogId = eventObject.CatalogId;

            this.catalogView.AddHardware(result);
        }

        [Subscribe]
        public void ProcessAction(HardwareSupplyCreatedEvent eventObject)
        {
            var result = Map(eventObject.CatalogId, eventObject.Hardware);

            this.catalogView.UpdateHardware(result);
        }

        [Subscribe]
        public void ProcessAction(HardwareSupplyDeletedEvent eventObject)
        {
            var result = Map(eventObject.CatalogId, eventObject.Hardware);

            this.catalogView.UpdateHardware(result);
        }

        [Subscribe]
        public void ProcessAction(HardwareSupplyUpdatedEvent eventObject)
        {
            var result = Map(eventObject.CatalogId, eventObject.Hardware);

            this.catalogView.UpdateHardware(result);
        }

        [Subscribe]
        public void ProcessAction(RequestEditHardwareSupplyAction eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);
            var hardware = catalog.Hardwares.Where(x => x.Id == eventObject.HardwareId).First();
            var hardwareSupply = hardware.Components.Where(x => x.Id == eventObject.HardwareSupplyId).First();

            Mapper.CreateMap<HardwareSupply, CatalogHardwareSupplyViewModel>();
            
            var viewModel = Mapper.Map<HardwareSupply, CatalogHardwareSupplyViewModel>(hardwareSupply);
            viewModel.CatalogId = eventObject.CatalogId;
            viewModel.HardwareId = eventObject.HardwareId;

            this.editHardwareSupplyView.HardwareSupply = viewModel;
            this.editHardwareSupplyView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(RequestImportHardwareAction eventObject)
        {
            this.importHardwareView.CatalogId = eventObject.CatalogId;
            this.importHardwareView.ShowView();
        }

        private CatalogHardwareViewModel Map(int catalogId, Hardware hardware)
        {
            Mapper.CreateMap<HardwareSupply, CatalogHardwareSupplyViewModel>();
            Mapper.CreateMap<Hardware, CatalogHardwareViewModel>();

            var result = Mapper.Map<Hardware, CatalogHardwareViewModel>(hardware);
            result.CatalogId = catalogId;
            result.ModuleSize = result.Components.Sum(x => x.SupplyModuleSize * x.Quantity);
            result.CatalogPrice = result.Components.Sum(x => x.SupplyCatalogPrice * x.Quantity);

            foreach (var subItem in result.Components)
            {
                subItem.CatalogId = catalogId;
                subItem.HardwareId = result.Id;
                if (subItem.Comment.StartsWith("{\\rtf"))
                {
                    rtBox.Rtf = string.IsNullOrEmpty(subItem.Comment) ? "{\\rtf}" : subItem.Comment;
                    subItem.Comment = rtBox.Text;
                }
            }

            return result;
        }

    }
}