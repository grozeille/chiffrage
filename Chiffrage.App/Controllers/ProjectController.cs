using System;
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
        IGenericEventHandler<RequestEditProjectSupplyEvent>
    {
        private readonly IProjectView projectView;

        private readonly INewProjectView newProjectView;

        private readonly IProjectRepository projectRepository;

        private readonly IDealRepository dealRepository;

        private readonly ICatalogRepository catalogRepository;

        private readonly IEventBroker eventBroker;

        private readonly INewProjectSupplyView newProjectSupplyView;

        public ProjectController(
            IEventBroker eventBroker, 
            IProjectView projectView, 
            INewProjectView newProjectView, 
            IProjectRepository projectRepository, 
            IDealRepository dealRepository,
            INewProjectSupplyView newProjectSupplyView,
            ICatalogRepository catalogRepository)
        {
            this.projectView = projectView;
            this.newProjectView = newProjectView;
            this.eventBroker = eventBroker;
            this.projectRepository = projectRepository;
            this.dealRepository = dealRepository;
            this.newProjectSupplyView = newProjectSupplyView;
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
            var supplies = Mapper.Map<IList<ProjectSupply>, IList<ProjectSupplyViewModel>>(project.Supplies);
            foreach (var item in supplies)
            {
                item.ProjectId = viewModel.Id;
            }

            this.projectView.Display(viewModel, supplies);

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
    }
}
