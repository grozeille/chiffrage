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
using Common.Logging;

namespace Chiffrage.Projects.Module.Controllers
{
    public class DealController : IController
    {
        private static ILog logger = LogManager.GetLogger(typeof(DealController));

        private readonly IDealRepository dealRepository;
        private readonly IDealView dealView;
        private readonly INewDealView newDealView;

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
            logger.Error("ProcessAction");
            var deal = this.dealRepository.FindById(eventObject.Id);
            logger.Error("ProcessAction FindById End");
            var dealViewModel = this.Map(deal);
            logger.Error("ProcessAction Map End");

            Mapper.CreateMap<Project, DealProjectCalendarItemViewModel>()
                .ForMember(x => x.ProjectId, y => y.MapFrom(z => z.Id));

            logger.Error("ProcessAction CreateMap End");
            var calendarItems = Mapper.Map<IList<Project>, List<DealProjectCalendarItemViewModel>>(deal.Projects);
            logger.Error("ProcessAction Map End");

            this.dealView.SetDealViewModel(dealViewModel);
            logger.Error("ProcessAction SetDealViewModel End");
            this.dealView.SetCalendarItems(calendarItems);
            logger.Error("ProcessAction SetCalendarItems End");
            this.dealView.SetSummaryItems(deal.BuildSummaryItems());
            logger.Error("ProcessAction SetSummaryItems End");
            this.dealView.SetProjectCostSummaryItems(deal.BuildDealProjectCostSummaryItems());
            logger.Error("ProcessAction SetProjectCostSummaryItems End");
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
            this.dealView.Save();
        }

        [Subscribe]
        public void ProcessAction(DealUpdatedEvent eventObject)
        {
            var result = this.Map(eventObject.NewDeal);

            this.dealView.SetDealViewModel(result);
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