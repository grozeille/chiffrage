using System;
using AutoMapper;
using Chiffrage.App.Events;
using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.Projects.Domain;
using Chiffrage.Projects.Domain.Repositories;
using System.Linq;
using Chiffrage.Mvc.Controllers;
using Chiffrage.Projects.Domain.Events;
using Chiffrage.Projects.Domain.Commands;
using Chiffrage.Common.Module.Events;

namespace Chiffrage.App.Controllers
{
    public class DealController :
        IController,
        IGenericEventHandler<DealSelectedEvent>,
        IGenericEventHandler<DealUnselectedEvent>,
        IGenericEventHandler<ApplicationStartEvent>,
        IGenericEventHandler<SaveEvent>,
        IGenericEventHandler<DealUpdatedEvent>,
        IGenericEventHandler<RequestNewDealEvent>
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

            var dealViewModel = this.Map(deal);

            this.dealView.SetDealViewModel(dealViewModel);
            this.dealView.ShowView();
        }

        public void ProcessAction(DealUnselectedEvent eventObject)
        {
            this.dealView.HideView();
            this.dealView.SetDealViewModel(null);
        }

        public void ProcessAction(SaveEvent eventObject)
        {
            var viewModel = this.dealView.GetDealViewModel();
            if (viewModel == null)
            {
                return;
            }
            var command = new UpdateDealCommand(
                viewModel.Id,
                viewModel.Name,
                viewModel.Comment,
                viewModel.Reference,
                viewModel.StartDate,
                viewModel.EndDate);

            this.eventBroker.Publish(command);
        }

        public void ProcessAction(DealUpdatedEvent eventObject)
        {
            var result = this.Map(eventObject.NewDeal);

            var viewModel = this.dealView.GetDealViewModel();
            if (viewModel != null && viewModel.Id == result.Id)
            {
                this.dealView.SetDealViewModel(result);
            }
        }

        public void ProcessAction(RequestNewDealEvent eventObject)
        {
            this.newDealView.ShowView();
        }

        private DealViewModel Map(Deal deal)
        {
            Mapper.CreateMap<Deal, DealViewModel>();

            var dealViewModel = Mapper.Map<Deal, DealViewModel>(deal);

            if (dealViewModel.Comment == null || !(dealViewModel.Comment.StartsWith("{\\rtf") && dealViewModel.Comment.EndsWith("}")))
                dealViewModel.Comment = "{\\rtf" + dealViewModel.Comment + "}";

            if (dealViewModel.StartDate == DateTime.MinValue)
            {
                dealViewModel.StartDate = DateTime.Now;
            }

            if (dealViewModel.EndDate == DateTime.MinValue)
            {
                dealViewModel.EndDate = DateTime.Now;
            }

            return dealViewModel;
        }

    }
}