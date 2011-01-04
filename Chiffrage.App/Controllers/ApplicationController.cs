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
    public class ApplicationController : 
        IGenericEventHandler<ApplicationStartEvent>,
        IGenericEventHandler<CatalogUpdatedEvent>,
        IGenericEventHandler<DealUpdatedEvent>
    {
        private readonly IApplicationView applicationView;

        private readonly ICatalogRepository catalogRepository;

        private readonly IDealRepository dealRepository;

        public ApplicationController(ICatalogRepository catalogRepository, IDealRepository dealRepository,
                                     IApplicationView applicationView)
        {
            this.catalogRepository = catalogRepository;
            this.dealRepository = dealRepository;
            this.applicationView = applicationView;
        }

        #region IApplicationController Members

        public void Display()
        {
            var result = new ApplicationItemViewModel();

            var catalogs = this.catalogRepository.FindAll();

            Mapper.CreateMap<SupplierCatalog, CatalogItemViewModel>();

            result.Catalogs = Mapper.Map<IList<SupplierCatalog>, CatalogItemViewModel[]>(catalogs);

            var deals = this.dealRepository.FindAll();

            Mapper.CreateMap<Deal, DealItemViewModel>();
            Mapper.CreateMap<Project, ProjectItemViewModel>();

            result.Deals = Mapper.Map<IList<Deal>, DealItemViewModel[]>(deals);

            this.applicationView.Display(result);
        }

        #endregion

        #region IGenericEventHandler<ApplicationStartEvent> Members

        public void ProcessAction(ApplicationStartEvent eventObject)
        {
            this.Display();
        }

        #endregion

        public void ProcessAction(CatalogUpdatedEvent eventObject)
        {
            Mapper.CreateMap<SupplierCatalog, CatalogItemViewModel>();

            var result = Mapper.Map<SupplierCatalog, CatalogItemViewModel>(eventObject.NewCatalog);

            this.applicationView.UpdateCatalog(result);
        }

        public void ProcessAction(DealUpdatedEvent eventObject)
        {
            Mapper.CreateMap<Deal, DealItemViewModel>();

            var result = Mapper.Map<Deal, DealItemViewModel>(eventObject.NewDeal);

            this.applicationView.UpdateDeal(result);
        }
    }
}