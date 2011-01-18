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
        IGenericEventHandler<DealUpdatedEvent>,
        IGenericEventHandler<NewDealEvent>,
        IGenericEventHandler<CreateNewDealEvent>
    {
        private readonly IEventBroker eventBroker;

        private readonly IDealRepository dealRepository;
        private readonly IDealView dealView;
        private readonly INewDealView newDealView;

        public DealController(IEventBroker eventBroker, IDealRepository dealRepository, IDealView dealView, INewDealView newDealView)
        {
            this.eventBroker = eventBroker;
            this.dealView = dealView;
            this.newDealView = newDealView;
            this.dealRepository = dealRepository;
        }

        public void ProcessAction(ApplicationStartEvent eventObject)
        {
            this.dealView.HideView();
        }

        public void ProcessAction(DealSelectedEvent eventObject)
        {
            var deal = this.dealRepository.FindById(eventObject.Id);

            Mapper.CreateMap<Deal, DealViewModel>();

            var dealViewModel = Mapper.Map<Deal, DealViewModel>(deal);

            this.dealView.Display(dealViewModel);
            this.dealView.ShowView();
        }

        public void ProcessAction(DealUnselectedEvent eventObject)
        {
            this.dealView.HideView();
        }

        public void ProcessAction(SaveEvent eventObject)
        {
            var viewModel = this.dealView.GetViewModel();
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

            this.dealView.Display(result);
        }

        public void ProcessAction(NewDealEvent eventObject)
        {
            this.newDealView.ShowView();
        }

        public void ProcessAction(CreateNewDealEvent eventObject)
        {
            var newDeal = new Deal();
            newDeal.Name = eventObject.DealName;

            this.dealRepository.Save(newDeal);

            this.eventBroker.Publish(new DealCreatedEvent(newDeal));
        }
    }
}