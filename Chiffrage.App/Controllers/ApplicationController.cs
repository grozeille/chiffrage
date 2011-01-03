using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.App.Events;
using Chiffrage.App.Views;
using Chiffrage.Catalogs.Domain.Repositories;
using Chiffrage.Mvc.Events;
using Chiffrage.Projects.Domain.Repositories;
using Chiffrage.App.ViewModel;
using AutoMapper;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Projects.Domain;

namespace Chiffrage.App.Controllers
{
    public class ApplicationController : IApplicationController,
        IGenericEventHandler<ApplicationStartEvent>
    {
        private readonly ICatalogRepository catalogRepository;

        private readonly IDealRepository dealRepository;

        private readonly IApplicationView applicationView;

        private readonly ICatalogController catalogController;

        public ApplicationController(ICatalogRepository catalogRepository, IDealRepository dealRepository, IApplicationView applicationView, ICatalogController catalogController)
        {
            this.catalogRepository = catalogRepository;
            this.dealRepository = dealRepository;
            this.applicationView = applicationView;
            this.catalogController = catalogController;
        }

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

        public void DisplayCatalog(int catalogId)
        {
            this.catalogController.DisplayCatalog(catalogId);
        }

        public void ProcessAction(ApplicationStartEvent eventObject)
        {
            this.Display();
        }
    }
}
