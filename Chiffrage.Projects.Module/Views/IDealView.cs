using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Mvc.Views;
using System.Collections.Generic;

namespace Chiffrage.Projects.Module.Views
{
    public interface IDealView : IView
    {
        DealViewModel GetDealViewModel();

        void SetDealViewModel(DealViewModel viewModel);

        void SetCalendarItems(IEnumerable<DealProjectCalendarItemViewModel> calendarItems);
    }
}