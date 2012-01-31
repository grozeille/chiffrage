﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Chiffrage.App.Events;
using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.Projects.Domain;
using Chiffrage.Projects.Domain.Repositories;
using Chiffrage.Mvc.Controllers;
using Chiffrage.Projects.Domain.Commands;
using Chiffrage.Catalogs.Domain.Repositories;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Projects.Domain.Events;

namespace Chiffrage.App.Controllers
{
    public class ProjectController :
        IController,
        IGenericEventHandler<ApplicationStartEvent>,
        IGenericEventHandler<ProjectSelectedEvent>,
        IGenericEventHandler<ProjectUnselectedEvent>,
        IGenericEventHandler<SaveEvent>,
        IGenericEventHandler<RequestNewProjectEvent>,
        IGenericEventHandler<RequestNewProjectSupplyEvent>,
        IGenericEventHandler<ProjectSupplyCreatedEvent>,
        IGenericEventHandler<ProjectSupplyDeletedEvent>,
        IGenericEventHandler<RequestEditProjectSupplyEvent>,
        IGenericEventHandler<RequestNewProjectHardwareEvent>,
        IGenericEventHandler<ProjectHardwareCreatedEvent>
    {
        private readonly IProjectView projectView;

        private readonly INewProjectView newProjectView;

        private readonly IProjectRepository projectRepository;

        private readonly IDealRepository dealRepository;

        private readonly ICatalogRepository catalogRepository;

        private readonly IEventBroker eventBroker;

        private readonly INewProjectSupplyView newProjectSupplyView;

        private readonly INewProjectHardwareView newProjectHardwareView;

        public ProjectController(
            IEventBroker eventBroker, 
            IProjectView projectView, 
            INewProjectView newProjectView, 
            IProjectRepository projectRepository, 
            IDealRepository dealRepository,
            INewProjectSupplyView newProjectSupplyView,
            INewProjectHardwareView newProjectHardwareView,
            ICatalogRepository catalogRepository)
        {
            this.projectView = projectView;
            this.newProjectView = newProjectView;
            this.eventBroker = eventBroker;
            this.projectRepository = projectRepository;
            this.dealRepository = dealRepository;
            this.newProjectSupplyView = newProjectSupplyView;
            this.newProjectHardwareView = newProjectHardwareView;
            this.catalogRepository = catalogRepository;
        }

        public void ProcessAction(ApplicationStartEvent eventObject)
        {
            this.projectView.HideView();
        }

        public void ProcessAction(ProjectSelectedEvent eventObject)
        {
            var project = this.projectRepository.FindById(eventObject.Id);

            Mapper.CreateMap<Project, ProjectViewModel>();
            Mapper.CreateMap<ProjectSupply, ProjectSupplyViewModel>();

            var viewModel = Mapper.Map<Project, ProjectViewModel>(project);
            
            var supplies = new List<ProjectSupplyViewModel>();
            foreach (var item in project.Supplies)
            {
                supplies.Add(Map(item, project.Id));
            }
            var hardwares = new List<ProjectHardwareViewModel>();
            foreach (var item in project.Hardwares)
            {
                hardwares.Add(Map(item, project.Id));
            }

            this.projectView.Display(viewModel, supplies, hardwares);

            this.projectView.ShowView();
        }

        public void ProcessAction(ProjectUnselectedEvent eventObject)
        {
            this.projectView.HideView();
        }

        public void ProcessAction(SaveEvent eventObject)
        {
            var viewModel = this.projectView.GetViewModel();

            if (viewModel == null)
            {
                return;
            }

            var command = new UpdateProjectCommand(
                viewModel.Id,
                viewModel.Name,
                viewModel.Comment,
                viewModel.Reference,
                viewModel.StartDate,
                viewModel.EndDate);

            this.eventBroker.Publish(command);
        }

        public void ProcessAction(RequestNewProjectEvent eventObject)
        {
            this.newProjectView.ParentDealId = eventObject.DealId;
            this.newProjectView.ShowView();
        }

        public void ProcessAction(RequestNewProjectSupplyEvent eventObject)
        {
            var catalogs = this.catalogRepository.FindAll();
            List<CatalogSupplyViewModel> suppliesViewModel = new List<CatalogSupplyViewModel>();
            Mapper.CreateMap<Supply, CatalogSupplyViewModel>();

            foreach(var catalog in catalogs)
            {
                var supplies = Mapper.Map<IList<Supply>, IList<CatalogSupplyViewModel>>(catalog.Supplies);
                foreach (var item in supplies)
                {
                    item.CatalogId = catalog.Id;
                }
                suppliesViewModel.AddRange(supplies);
            }

            this.newProjectSupplyView.Supplies = suppliesViewModel;
            this.newProjectSupplyView.ProjectId = eventObject.ProjectId;
            this.newProjectSupplyView.ShowView();
        }

        public void ProcessAction(ProjectSupplyCreatedEvent eventObject)
        {
            Mapper.CreateMap<ProjectSupply, ProjectSupplyViewModel>();
            var viewModel = Mapper.Map<ProjectSupply, ProjectSupplyViewModel>(eventObject.ProjectSupply);
            viewModel.TotalModuleSize = eventObject.ProjectSupply.ModuleSize * eventObject.ProjectSupply.Quantity;
            viewModel.TotalCatalogExecutiveWorkDays = eventObject.ProjectSupply.CatalogExecutiveWorkDays * eventObject.ProjectSupply.Quantity;
            viewModel.TotalCatalogPrice = eventObject.ProjectSupply.CatalogPrice * eventObject.ProjectSupply.Quantity;
            viewModel.TotalCatalogTestsDays = eventObject.ProjectSupply.CatalogTestsDays * eventObject.ProjectSupply.Quantity;
            viewModel.TotalCatalogWorkDays = eventObject.ProjectSupply.CatalogWorkDays * eventObject.ProjectSupply.Quantity;
            viewModel.TotalReferenceDays = eventObject.ProjectSupply.ReferenceDays * eventObject.ProjectSupply.Quantity;
            viewModel.TotalStudyDays = eventObject.ProjectSupply.StudyDays * eventObject.ProjectSupply.Quantity;
            viewModel.ProjectId = eventObject.ProjectId;

            this.projectView.AddSupply(viewModel);
        }

        public void ProcessAction(ProjectSupplyDeletedEvent eventObject)
        {
            Mapper.CreateMap<ProjectSupply, ProjectSupplyViewModel>();

            var supply = Mapper.Map<ProjectSupply, ProjectSupplyViewModel>(eventObject.Supply);
            supply.ProjectId = eventObject.ProjectId;

            this.projectView.RemoveSupply(supply);

            this.projectView.ShowView();
        }

        public void ProcessAction(RequestEditProjectSupplyEvent eventObject)
        {
            throw new NotImplementedException();
        }

        public void ProcessAction(RequestNewProjectHardwareEvent eventObject)
        {
            var catalogs = this.catalogRepository.FindAll();
            List<CatalogHardwareViewModel> hardwaresViewModel = new List<CatalogHardwareViewModel>();
            Mapper.CreateMap<Hardware, CatalogHardwareViewModel>();
            Mapper.CreateMap<HardwareSupply, CatalogHardwareSupplyViewModel>();

            foreach (var catalog in catalogs)
            {
                var hardwares = Mapper.Map<IList<Hardware>, IList<CatalogHardwareViewModel>>(catalog.Hardwares);
                foreach (var item in hardwares)
                {
                    item.CatalogId = catalog.Id;
                    item.ModuleSize = item.Components.Sum(x => x.SupplyModuleSize * x.Quantity);
                    item.CatalogExecutiveWorkDays = item.Components.Sum(x => x.SupplyCatalogWorkDays * x.Quantity);
                    item.CatalogPrice = item.Components.Sum(x => x.SupplyCatalogPrice * x.Quantity);
                    item.CatalogTestsDays = item.Components.Sum(x => x.SupplyCatalogTestsDays * x.Quantity);
                    item.CatalogWorkDays = item.Components.Sum(x => x.SupplyCatalogWorkDays * x.Quantity);
                    item.ReferenceDays = item.Components.Sum(x => x.SupplyReferenceDays * x.Quantity);
                    item.StudyDays = item.Components.Sum(x => x.SupplyStudyDays * x.Quantity);
                    foreach (var subItem in item.Components)
                    {
                        subItem.HardwareId = item.Id;
                        subItem.CatalogId = catalog.Id;
                    }
                }
                hardwaresViewModel.AddRange(hardwares);
            }

            this.newProjectHardwareView.ProjectId = eventObject.ProjectId;
            this.newProjectHardwareView.Hardwares = hardwaresViewModel;
            this.newProjectHardwareView.ShowView();
        }

        public void ProcessAction(ProjectHardwareCreatedEvent eventObject)
        {
            var viewModel = Map(eventObject.ProjectHardware, eventObject.ProjectId);

            this.projectView.AddHardware(viewModel);
        }

        private ProjectHardwareViewModel Map(ProjectHardware hardware, int projectId)
        {
            Mapper.CreateMap<ProjectHardware, ProjectHardwareViewModel>()
                .ForMember(x => x.ProjectId, y => y.UseValue(projectId));
            Mapper.CreateMap<ProjectHardwareSupply, ProjectHardwareSupplyViewModel>();
            var viewModel = Mapper.Map<ProjectHardware, ProjectHardwareViewModel>(hardware);

            viewModel.ModuleSize = hardware.Components.Sum(x => x.Supply.ModuleSize * x.Quantity);
            viewModel.CatalogExecutiveWorkDays = hardware.Components.Sum(x => x.Supply.CatalogExecutiveWorkDays * x.Quantity);
            viewModel.CatalogPrice = hardware.Components.Sum(x => x.Supply.CatalogPrice * x.Quantity);
            viewModel.CatalogTestsDays = hardware.Components.Sum(x => x.Supply.CatalogTestsDays * x.Quantity);
            viewModel.CatalogWorkDays = hardware.Components.Sum(x => x.Supply.CatalogWorkDays * x.Quantity);
            viewModel.ReferenceDays = hardware.Components.Sum(x => x.Supply.ReferenceDays * x.Quantity);
            viewModel.StudyDays = hardware.Components.Sum(x => x.Supply.StudyDays * x.Quantity);

            viewModel.TotalModuleSize = viewModel.ModuleSize * viewModel.Quantity;
            viewModel.TotalCatalogExecutiveWorkDays = viewModel.CatalogExecutiveWorkDays * viewModel.Quantity;
            viewModel.TotalCatalogPrice = viewModel.CatalogPrice * viewModel.Quantity;
            viewModel.TotalCatalogTestsDays = viewModel.CatalogTestsDays * viewModel.Quantity;
            viewModel.TotalCatalogWorkDays = viewModel.CatalogWorkDays * viewModel.Quantity;
            viewModel.TotalReferenceDays = viewModel.ReferenceDays * viewModel.Quantity;
            viewModel.TotalStudyDays = viewModel.StudyDays * viewModel.Quantity;

            return viewModel;
        }

        private ProjectSupplyViewModel Map(ProjectSupply supply, int projectId)
        {
            Mapper.CreateMap<ProjectSupply, ProjectSupplyViewModel>()
                .ForMember(x => x.ProjectId, y => y.UseValue(projectId));

            var viewModel = Mapper.Map<ProjectSupply, ProjectSupplyViewModel>(supply);

            viewModel.TotalModuleSize = viewModel.ModuleSize * viewModel.Quantity;
            viewModel.TotalCatalogExecutiveWorkDays = viewModel.CatalogExecutiveWorkDays * viewModel.Quantity;
            viewModel.TotalCatalogPrice = viewModel.CatalogPrice * viewModel.Quantity;
            viewModel.TotalCatalogTestsDays = viewModel.CatalogTestsDays * viewModel.Quantity;
            viewModel.TotalCatalogWorkDays = viewModel.CatalogWorkDays * viewModel.Quantity;
            viewModel.TotalReferenceDays = viewModel.ReferenceDays * viewModel.Quantity;
            viewModel.TotalStudyDays = viewModel.StudyDays * viewModel.Quantity;

            return viewModel;
        }
    }
}
