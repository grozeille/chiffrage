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
using System.Collections.Generic;

namespace Chiffrage.Projects.Module.Controllers
{
    public class DealController : IController
    {
        private readonly IDealRepository dealRepository;
        private readonly IDealView dealView;
        private readonly INewDealView newDealView;

        [Publish]
        public event Action<UpdateDealCommand> OnUpdateDealCommand;

        public DealController(IDealRepository dealRepository, IDealView dealView, INewDealView newDealView)
        {
            this.dealView = dealView;
            this.newDealView = newDealView;
            this.dealRepository = dealRepository;
        }

        [Subscribe]
        public void ProcessAction(ApplicationStartAction eventObject)
        {
            this.dealView.HideView();
        }

        [Subscribe]
        public void ProcessAction(DealSelectedAction eventObject)
        {
            var deal = this.dealRepository.FindById(eventObject.Id);

            var dealViewModel = this.Map(deal);

            Mapper.CreateMap<Project, DealProjectCalendarItemViewModel>()
                .ForMember(x => x.ProjectId, y => y.MapFrom(z => z.Id));

            var calendarItems = Mapper.Map<IList<Project>, List<DealProjectCalendarItemViewModel>>(deal.Projects);
            
            this.dealView.SetDealViewModel(dealViewModel);
            this.dealView.SetCalendarItems(calendarItems);

            this.dealView.SetSummaryItems(deal.BuildSummaryItems());

            this.dealView.SetProjectCostSummaryItems(deal.BuildDealProjectCostSummaryItems());

            this.dealView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(DealUnselectedAction eventObject)
        {
            this.dealView.HideView();
            this.dealView.SetDealViewModel(null);
        }

        [Subscribe]
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

            this.OnUpdateDealCommand(command);
        }

        [Subscribe]
        public void ProcessAction(DealUpdatedEvent eventObject)
        {
            var result = this.Map(eventObject.NewDeal);

            var viewModel = this.dealView.GetDealViewModel();
            if (viewModel != null && viewModel.Id == result.Id)
            {
                this.dealView.SetDealViewModel(result);
            }
        }

        [Subscribe]
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