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

namespace Chiffrage.App.Controllers
{
    public class ProjectController :
        IController,
        IGenericEventHandler<ApplicationStartEvent>,
        IGenericEventHandler<ProjectSelectedEvent>,
        IGenericEventHandler<ProjectUnselectedEvent>,
        IGenericEventHandler<SaveEvent>,
        IGenericEventHandler<CreateNewProjectEvent>,
        IGenericEventHandler<RequestNewProjectEvent>
    {
        private readonly IProjectView projectView;

        private readonly INewProjectView newProjectView;

        private readonly IProjectRepository projectRepository;

        private readonly IDealRepository dealRepository;

        private readonly IEventBroker eventBroker;

        public ProjectController(IEventBroker eventBroker, IProjectView projectView, INewProjectView newProjectView, IProjectRepository projectRepository, IDealRepository dealRepository)
        {
            this.projectView = projectView;
            this.newProjectView = newProjectView;
            this.eventBroker = eventBroker;
            this.projectRepository = projectRepository;
            this.dealRepository = dealRepository;
        }

        public void ProcessAction(ApplicationStartEvent eventObject)
        {
            this.projectView.HideView();
        }

        public void ProcessAction(ProjectSelectedEvent eventObject)
        {
            var project = this.projectRepository.FindById(eventObject.Id);

            Mapper.CreateMap<Project, ProjectViewModel>();

            var viewModel = Mapper.Map<Project, ProjectViewModel>(project);

            this.projectView.Display(viewModel);

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

            MapperUtils.CreateDefaultMap();
            Mapper.CreateMap<ProjectViewModel, Project>();

            var project = this.projectRepository.FindById(viewModel.Id);

            Mapper.Map(viewModel, project);

            this.projectRepository.Save(project);

            this.eventBroker.Publish(new ProjectUpdatedEvent(project));
        }

        public void ProcessAction(CreateNewProjectEvent eventObject)
        {
            var deal = this.dealRepository.FindById(eventObject.DealId);

            var newProject = new Project();
            newProject.Name = eventObject.ProjectName;

            this.projectRepository.Save(newProject);
            deal.Projects.Add(newProject);
            this.dealRepository.Save(deal);

            this.eventBroker.Publish(new ProjectCreatedEvent(deal, newProject));
        }

        public void ProcessAction(RequestNewProjectEvent eventObject)
        {
            this.newProjectView.SetParentDeal(eventObject.DealId);
            this.newProjectView.ShowView();
        }
    }
}
