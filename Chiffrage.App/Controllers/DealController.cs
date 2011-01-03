using AutoMapper;
using Chiffrage.App.Events;
using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.Projects.Domain;
using Chiffrage.Projects.Domain.Repositories;

namespace Chiffrage.App.Controllers
{
    public class DealController :
        IGenericEventHandler<DealSelectedEvent>,
        IGenericEventHandler<DealUnselectedEvent>,
        IGenericEventHandler<ApplicationStartEvent>
    {
        private readonly IDealRepository dealRepository;
        private readonly IDealView dealView;

        public DealController(IDealRepository dealRepository, IDealView dealView)
        {
            this.dealView = dealView;
            this.dealRepository = dealRepository;
        }

        #region IGenericEventHandler<ApplicationStartEvent> Members

        public void ProcessAction(ApplicationStartEvent eventObject)
        {
            this.dealView.HideView();
        }

        #endregion

        #region IGenericEventHandler<DealSelectedEvent> Members

        public void ProcessAction(DealSelectedEvent eventObject)
        {
            var deal = this.dealRepository.FindById(eventObject.Id);

            Mapper.CreateMap<Deal, DealViewModel>();

            var dealViewModel = Mapper.Map<Deal, DealViewModel>(deal);

            this.dealView.DisplayDeal(dealViewModel);
            this.dealView.ShowView();
        }

        #endregion

        #region IGenericEventHandler<DealUnselectedEvent> Members

        public void ProcessAction(DealUnselectedEvent eventObject)
        {
            this.dealView.HideView();
        }

        #endregion
    }
}