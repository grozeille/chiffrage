using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.App.Events;
using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.Projects.Domain;
using Chiffrage.Projects.Domain.Repositories;
using AutoMapper;

namespace Chiffrage.App.Controllers
{
    public class DealController : 
        IGenericEventHandler<DealSelectedEvent>,
        IGenericEventHandler<DealUnselectedEvent>,
        IGenericEventHandler<ApplicationStartEvent>
    {
        private readonly IDealView dealView;

        private readonly IDealRepository dealRepository;

        public DealController(IDealRepository dealRepository, IDealView dealView)
        {
            this.dealView = dealView;
            this.dealRepository = dealRepository;
        }

        public void ProcessAction(DealSelectedEvent eventObject)
        {
            var deal = this.dealRepository.FindById(eventObject.Id);

            Mapper.CreateMap<Deal, DealViewModel>();

            var dealViewModel = Mapper.Map<Deal, DealViewModel>(deal);

            this.dealView.DisplayDeal(dealViewModel);
            this.dealView.ShowView();
        }

        public void ProcessAction(DealUnselectedEvent eventObject)
        {
            this.dealView.HideView();
        }

        public void ProcessAction(ApplicationStartEvent eventObject)
        {
            this.dealView.HideView();
        }
    }
}
