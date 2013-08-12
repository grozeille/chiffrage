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
        private readonly IProjectRepository projectRepository;
        private readonly IDealView dealView;
        private readonly INewDealView newDealView;
        private readonly IEventBroker eventBroker;

        public DealController(IDealRepository dealRepository, IProjectRepository projectRepository, IDealView dealView, INewDealView newDealView, IEventBroker eventBroker)
        {
            this.dealView = dealView;
            this.newDealView = newDealView;
            this.dealRepository = dealRepository;
            this.eventBroker = eventBroker;
            this.projectRepository = projectRepository;
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

        [Subscribe]
        public void ProcessAction(RequestCopyDealAction eventObject)
        {
            var deal = this.dealRepository.FindById(eventObject.DealId);
            Mapper.CreateMap<ProjectSupply, ProjectSupply>();
            Mapper.CreateMap<ProjectHardwareSupply, ProjectHardwareSupply>();
            Mapper.CreateMap<ProjectHardware, ProjectHardware>();
            Mapper.CreateMap<OtherBenefit, OtherBenefit>();
            Mapper.CreateMap<ProjectFrame, ProjectFrame>();
            Mapper.CreateMap<Project, Project>();
            Mapper.CreateMap<Deal, Deal>();

            var cloneDeal = Mapper.Map<Deal, Deal>(deal);
            cloneDeal.Name += " (copie)";
            cloneDeal.Id = 0;

            cloneDeal.Projects = new List<Project>();
            foreach (var p in deal.Projects)
            {
                Project cloneProject = Mapper.Map<Project, Project>(p);
                cloneProject.Id = 0;
                cloneDeal.Projects.Add(cloneProject);

                cloneProject.Supplies = new List<ProjectSupply>();
                foreach (var s in p.Supplies)
                {
                    ProjectSupply cloneProjectSupply = Mapper.Map<ProjectSupply, ProjectSupply>(s);
                    cloneProjectSupply.Id = 0;
                    cloneProject.Supplies.Add(cloneProjectSupply);
                }

                cloneProject.Hardwares = new List<ProjectHardware>();
                foreach (var h in p.Hardwares)
                {
                    ProjectHardware cloneHardware = Mapper.Map<ProjectHardware, ProjectHardware>(h);
                    cloneHardware.Id = 0;
                    cloneProject.Hardwares.Add(cloneHardware);

                    cloneHardware.Components = new List<ProjectHardwareSupply>();
                    foreach (var s in h.Components)
                    {
                        ProjectHardwareSupply cloneSupply = Mapper.Map<ProjectHardwareSupply, ProjectHardwareSupply>(s);
                        s.Id = 0;
                        cloneHardware.Components.Add(s);
                    }
                }

                cloneProject.OtherBenefits = new List<OtherBenefit>();
                foreach (var o in p.OtherBenefits)
                {
                    OtherBenefit cloneOtherBenefits = Mapper.Map<OtherBenefit, OtherBenefit>(o);
                    cloneOtherBenefits.Id = 0;
                    cloneProject.OtherBenefits.Add(cloneOtherBenefits);
                }

                cloneProject.Frames = new List<ProjectFrame>();
                foreach (var f in p.Frames)
                {
                    ProjectFrame cloneFrame = Mapper.Map<ProjectFrame, ProjectFrame>(f);
                    cloneFrame.Id = 0;
                    cloneProject.Frames.Add(cloneFrame);
                }
            }


            this.dealRepository.Save(cloneDeal);
            
            this.eventBroker.Publish(new DealCreatedEvent(cloneDeal));
            foreach (var p in cloneDeal.Projects)
            {
                this.eventBroker.Publish(new ProjectCreatedEvent(cloneDeal, p));
            }
        }


        [Subscribe]
        public void ProcessAction(RequestDeleteDealAction eventObject)
        {
            var deal = this.dealRepository.FindById(eventObject.DealId);

            this.dealRepository.Delete(deal);

            this.eventBroker.Publish(new DealDeletedEvent(deal.Id));
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