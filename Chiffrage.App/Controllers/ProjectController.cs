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

namespace Chiffrage.App.Controllers
{
    public class ProjectController :
        IController,
        IGenericEventHandler<ApplicationStartEvent>,
        IGenericEventHandler<ProjectSelectedEvent>,
        IGenericEventHandler<ProjectUnselectedEvent>,
        IGenericEventHandler<SaveEvent>,
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
    }
}
