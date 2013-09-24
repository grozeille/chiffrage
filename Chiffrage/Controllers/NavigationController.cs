using System;
using System.Collections.Generic;
using AutoMapper;
using Chiffrage.App.Events;
using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Catalogs.Domain.Repositories;
using Chiffrage.Mvc.Events;
using Chiffrage.Projects.Domain;
using Chiffrage.Projects.Domain.Repositories;
using Chiffrage.Mvc.Controllers;
using Chiffrage.Catalogs.Domain.Events;
using Chiffrage.Projects.Domain.Events;
using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Catalogs.Module.ViewModel;
using Chiffrage.Common.Module.Actions;

namespace Chiffrage.App.Controllers
{
    [Topic(Topics.UI)]
    public class NavigationController : IController
    {
        private readonly INavigationView navigationView;

        private readonly IEventBroker eventBroker;

        private readonly ICatalogRepository catalogRepository;

        private readonly IDealRepository dealRepository;

        public NavigationController(
            IEventBroker eventBroker,
            ICatalogRepository catalogRepository,
            IDealRepository dealRepository,
            INavigationView navigationView)
        {
            this.eventBroker = eventBroker;
            this.catalogRepository = catalogRepository;
            this.dealRepository = dealRepository;
            this.navigationView = navigationView;
        }

        [Subscribe]
        public void ProcessAction(ApplicationStartAction eventObject)
        {
            var result = new NavigationItemViewModel();

            this.eventBroker.Publish(new ApplicationLoadedEvent(0, 2, "Loading catalogs..."), "topic://UI");

            var catalogs = this.catalogRepository.FindAll();

            Mapper.CreateMap<SupplierCatalog, CatalogItemViewModel>();

            result.Catalogs = Mapper.Map<IList<SupplierCatalog>, CatalogItemViewModel[]>(catalogs);

            this.eventBroker.Publish(new ApplicationLoadedEvent(1, 2, "Loading deals..."), "topic://UI");

            var deals = this.dealRepository.FindAll();

            Mapper.CreateMap<Deal, DealItemViewModel>();
            Mapper.CreateMap<Project, ProjectItemViewModel>();

            result.Deals = Mapper.Map<IList<Deal>, DealItemViewModel[]>(deals);

            this.eventBroker.Publish(new ApplicationLoadedEvent(2, 2, "Application loaded"), "topic://UI");

            this.navigationView.Display(result);

            this.navigationView.ShowView();
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(CatalogUpdatedEvent eventObject)
        {
            Mapper.CreateMap<SupplierCatalog, CatalogItemViewModel>();

            var catalog = this.catalogRepository.FindById(eventObject.CatalogId);

            var result = Mapper.Map<SupplierCatalog, CatalogItemViewModel>(catalog);

            this.navigationView.UpdateCatalog(result);
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(DealUpdatedEvent eventObject)
        {
            Mapper.CreateMap<Deal, DealItemViewModel>();

            var result = Mapper.Map<Deal, DealItemViewModel>(eventObject.NewDeal);

            this.navigationView.UpdateDeal(result);
        }

        [Subscribe]
        public void ProcessAction(DealCreatedEvent eventObject)
        {
            Mapper.CreateMap<Deal, DealItemViewModel>();

            var result = Mapper.Map<Deal, DealItemViewModel>(eventObject.NewDeal);

            this.navigationView.AddDeal(result);
            this.navigationView.SelectDeal(result.Id);
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(DealDeletedEvent eventObject)
        {
            this.navigationView.RemoveDeal(eventObject.DealId);
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(CatalogDeletedEvent eventObject)
        {
            this.navigationView.RemoveCatalog(eventObject.CatalogId);
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(ProjectDeletedEvent eventObject)
        {
            this.navigationView.RemoveProject(eventObject.DealId, eventObject.ProjectId);
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(CatalogCreatedEvent eventObject)
        {
            Mapper.CreateMap<SupplierCatalog, CatalogItemViewModel>();

            var catalog = this.catalogRepository.FindById(eventObject.CatalogId);

            var result = Mapper.Map<SupplierCatalog, CatalogItemViewModel>(catalog);

            this.navigationView.AddCatalog(result);
            this.navigationView.SelectCatalog(result.Id);
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(ProjectCreatedEvent eventObject)
        {
            Mapper.CreateMap<Project, ProjectItemViewModel>();

            var result = Mapper.Map<Project, ProjectItemViewModel>(eventObject.NewProject);

            this.navigationView.AddProject(eventObject.ParentDeal.Id, result);
            this.navigationView.SelectProject(result.Id);
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(ProjectUpdatedEvent eventObject)
        {
            Mapper.CreateMap<Project, ProjectItemViewModel>();

            var result = Mapper.Map<Project, ProjectItemViewModel>(eventObject.NewProject);

            this.navigationView.UpdateProject(result);
        }
    }
}