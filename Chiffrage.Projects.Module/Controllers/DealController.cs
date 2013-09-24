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
using Chiffrage.Mvc.Views;
using Chiffrage.Catalogs.Domain.Repositories;

namespace Chiffrage.Projects.Module.Controllers
{
    [Topic(Topics.UI)]
    public class DealController : IController
    {
        private static ILog logger = LogManager.GetLogger(typeof(DealController));

        private readonly IDealRepository dealRepository;
        private readonly ITaskRepository taskRepository;
        private readonly IDealView dealView;
        private readonly INewDealView newDealView;
        private readonly ILoadingView loadingView;

        private int? currentDealId;

        public DealController(IDealRepository dealRepository, ITaskRepository taskRepository, IDealView dealView, INewDealView newDealView, ILoadingView loadingView)
        {
            this.dealView = dealView;
            this.newDealView = newDealView;
            this.loadingView = loadingView;
            this.taskRepository = taskRepository;
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
            this.loadingView.Continuous = true;
            this.loadingView.ShowView();

            var deal = this.dealRepository.FindById(eventObject.Id);
            var dealViewModel = this.Map(deal);
            
            Mapper.CreateMap<Project, DealProjectCalendarItemViewModel>()
                .ForMember(x => x.ProjectId, y => y.MapFrom(z => z.Id));

            var calendarItems = Mapper.Map<IList<Project>, List<DealProjectCalendarItemViewModel>>(deal.Projects);
            
            this.dealView.SetDealViewModel(dealViewModel);
            this.dealView.SetCalendarItems(calendarItems);
            this.dealView.SetSummaryItems(deal.BuildSummaryItems(), deal.Projects);
            this.dealView.SetProjectCostSummaryItems(deal.BuildDealProjectCostSummaryItems().ToList());

            this.loadingView.HideView();
            this.dealView.ShowView();

            this.currentDealId = eventObject.Id;
        }

        [Subscribe]
        public void ProcessAction(DealUnselectedAction eventObject)
        {
            if (this.currentDealId.HasValue && currentDealId.Value == eventObject.Id)
            {
                this.ProcessAction(new SaveAction());

                this.dealView.HideView();
                this.dealView.SetDealViewModel(null);

                this.currentDealId = null;
            }
        }

        [Subscribe]
        public void ProcessAction(SaveAction eventObject)
        {
            this.dealView.Save();
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(DealUpdatedEvent eventObject)
        {
            if (this.currentDealId.HasValue && currentDealId.Value == eventObject.NewDeal.Id)
            {
                var result = this.Map(eventObject.NewDeal);

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

            dealViewModel.TotalPrice = 0;
            dealViewModel.TotalDays = 0;
            foreach (var project in deal.Projects)
            {
                foreach (var item in project.Supplies)
                {
                    dealViewModel.TotalPrice += item.Quantity*item.Price;
                }

                foreach (var item in project.Hardwares)
                {
                    // total price of components
                    dealViewModel.TotalPrice += item.Components.Sum(x => x.Supply.Price*x.Quantity);

                    foreach (var task in item.Tasks)
                    {
                        double rate = 0.0;
                        if (task.Task != null)
                        {
                            switch (task.HardwareTaskType)
                            {
                                case ProjectHardwareTaskType.DAY:
                                    rate = task.Task.DayRate;
                                    break;
                                case ProjectHardwareTaskType.SHORT_NIGHT:
                                    rate = task.Task.ShortNightRate;
                                    break;
                                case ProjectHardwareTaskType.LONG_NIGHT:
                                    rate = task.Task.LongNightRate;
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                        }
                        dealViewModel.TotalPrice += rate*task.Value;
                        dealViewModel.TotalDays += task.Value;
                    }
                }

                dealViewModel.TotalPrice += project.OtherBenefits.Sum(x => x.Hours * x.CostRate);
                dealViewModel.TotalDays += project.OtherBenefits.Sum(x => x.Hours);
            }

            return dealViewModel;
        }

    }
}