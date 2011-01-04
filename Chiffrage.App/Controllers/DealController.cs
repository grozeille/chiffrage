using System;
using AutoMapper;
using Chiffrage.App.Events;
using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.Projects.Domain;
using Chiffrage.Projects.Domain.Repositories;
using System.Linq;

namespace Chiffrage.App.Controllers
{
    public class DealController :
        IGenericEventHandler<DealSelectedEvent>,
        IGenericEventHandler<DealUnselectedEvent>,
        IGenericEventHandler<ApplicationStartEvent>,
        IGenericEventHandler<SaveEvent>,
        IGenericEventHandler<DealUpdatedEvent>
    {
        private readonly IEventBroker eventBroker;

        private readonly IDealRepository dealRepository;
        private readonly IDealView view;

        public DealController(IEventBroker eventBroker, IDealRepository dealRepository, IDealView view)
        {
            this.eventBroker = eventBroker;
            this.view = view;
            this.dealRepository = dealRepository;
        }

        #region IGenericEventHandler<ApplicationStartEvent> Members

        public void ProcessAction(ApplicationStartEvent eventObject)
        {
            this.view.HideView();
        }

        #endregion

        #region IGenericEventHandler<DealSelectedEvent> Members

        public void ProcessAction(DealSelectedEvent eventObject)
        {
            var deal = this.dealRepository.FindById(eventObject.Id);

            Mapper.CreateMap<Deal, DealViewModel>();

            var dealViewModel = Mapper.Map<Deal, DealViewModel>(deal);

            this.view.Display(dealViewModel);
            this.view.ShowView();
        }

        #endregion

        #region IGenericEventHandler<DealUnselectedEvent> Members

        public void ProcessAction(DealUnselectedEvent eventObject)
        {
            this.view.HideView();
        }

        #endregion

        public void ProcessAction(SaveEvent eventObject)
        {
            var viewModel = this.view.GetViewModel();
            if (viewModel == null)
            {
                return;
            }

            Mapper.CreateMap<DealViewModel, Deal>();

            var deal = this.dealRepository.FindById(viewModel.Id);

            Mapper.Map(viewModel, deal);

            this.dealRepository.Save(deal);

            this.eventBroker.Publish(new DealUpdatedEvent(deal));
        }

        public void ProcessAction(DealUpdatedEvent eventObject)
        {
            Mapper.CreateMap<Deal, DealViewModel>();

            var result = Mapper.Map<Deal, DealViewModel>(eventObject.NewDeal);

            this.view.Display(result);
        }
    }
}