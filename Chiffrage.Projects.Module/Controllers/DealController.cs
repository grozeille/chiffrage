using System;
using AutoMapper;
using Chiffrage.Projects.Module.Actions;
using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Projects.Module.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.Projects.Domain;
using Chiffrage.Projects.Domain.Repositories;
using System.Linq;
using Chiffrage.Mvc.Controllers;
using Chiffrage.Projects.Domain.Events;
using Chiffrage.Projects.Domain.Commands;
using Chiffrage.Common.Module.Actions;

namespace Chiffrage.Projects.Module.Controllers
{
    public class DealController :
        IController,
        IGenericEventHandler<DealSelectedAction>,
        IGenericEventHandler<DealUnselectedAction>,
        IGenericEventHandler<ApplicationStartAction>,
        IGenericEventHandler<SaveAction>,
        IGenericEventHandler<DealUpdatedEvent>,
        IGenericEventHandler<RequestNewDealAction>
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

        public void ProcessAction(ApplicationStartAction eventObject)
        {
            this.dealView.HideView();
        }

        public void ProcessAction(DealSelectedAction eventObject)
        {
            var deal = this.dealRepository.FindById(eventObject.Id);

            var dealViewModel = this.Map(deal);

            this.dealView.SetDealViewModel(dealViewModel);
            this.dealView.ShowView();
        }

        public void ProcessAction(DealUnselectedAction eventObject)
        {
            this.dealView.HideView();
            this.dealView.SetDealViewModel(null);
        }

        public void ProcessAction(SaveAction eventObject)
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

        public void ProcessAction(RequestNewDealAction eventObject)
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