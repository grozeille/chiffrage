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

namespace Chiffrage.App.Controllers
{
    public class NavigationController : 
        IGenericEventHandler<ApplicationStartEvent>,
        IGenericEventHandler<CatalogUpdatedEvent>,
        IGenericEventHandler<DealUpdatedEvent>,
        IGenericEventHandler<DealCreatedEvent>
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

        #region IGenericEventHandler<ApplicationStartEvent> Members

        public void ProcessAction(ApplicationStartEvent eventObject)
        {
            var result = new NavigationItemViewModel();

            this.eventBroker.Publish(new ApplicationLoadedEvent(0, 2, "Loading catalogs..."));

            var catalogs = this.catalogRepository.FindAll();

            Mapper.CreateMap<SupplierCatalog, CatalogItemViewModel>();

            result.Catalogs = Mapper.Map<IList<SupplierCatalog>, CatalogItemViewModel[]>(catalogs);

            this.eventBroker.Publish(new ApplicationLoadedEvent(1, 2, "Loading deals..."));

            var deals = this.dealRepository.FindAll();

            Mapper.CreateMap<Deal, DealItemViewModel>();
            Mapper.CreateMap<Project, ProjectItemViewModel>();

            result.Deals = Mapper.Map<IList<Deal>, DealItemViewModel[]>(deals);

            this.eventBroker.Publish(new ApplicationLoadedEvent(2, 2, "Application loaded"));

            this.navigationView.Display(result);

            this.navigationView.ShowView();
        }


        #endregion

        public void ProcessAction(CatalogUpdatedEvent eventObject)
        {
            Mapper.CreateMap<SupplierCatalog, CatalogItemViewModel>();

            var result = Mapper.Map<SupplierCatalog, CatalogItemViewModel>(eventObject.NewCatalog);

            this.navigationView.UpdateCatalog(result);
        }

        public void ProcessAction(DealUpdatedEvent eventObject)
        {
            Mapper.CreateMap<Deal, DealItemViewModel>();

            var result = Mapper.Map<Deal, DealItemViewModel>(eventObject.NewDeal);

            this.navigationView.UpdateDeal(result);
        }

        public void ProcessAction(DealCreatedEvent eventObject)
        {
            Mapper.CreateMap<Deal, DealItemViewModel>();

            var result = Mapper.Map<Deal, DealItemViewModel>(eventObject.NewDeal);

            this.navigationView.AddDeal(result);
        }
    }
}