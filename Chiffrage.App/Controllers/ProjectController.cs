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
        IGenericEventHandler<SaveEvent>
    {
        private readonly IProjectView view;

        private readonly IProjectRepository projectRepository;

        private readonly IEventBroker eventBroker;

        public ProjectController(IEventBroker eventBroker, IProjectView view, IProjectRepository projectRepository)
        {
            this.view = view;
            this.eventBroker = eventBroker;
            this.projectRepository = projectRepository;
        }

        public void ProcessAction(ApplicationStartEvent eventObject)
        {
            this.view.HideView();
        }

        public void ProcessAction(ProjectSelectedEvent eventObject)
        {
            var project = this.projectRepository.FindById(eventObject.Id);

            Mapper.CreateMap<Project, ProjectViewModel>();

            var viewModel = Mapper.Map<Project, ProjectViewModel>(project);

            this.view.Display(viewModel);

            this.view.ShowView();
        }

        public void ProcessAction(ProjectUnselectedEvent eventObject)
        {
            this.view.HideView();
        }

        public void ProcessAction(SaveEvent eventObject)
        {
            
        }
    }
}
