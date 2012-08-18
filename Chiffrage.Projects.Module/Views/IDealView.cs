using Chiffrage.App.ViewModel;
using Chiffrage.Mvc.Views;

namespace Chiffrage.App.Views
{
    public interface IDealView : IView
    {
        DealViewModel GetDealViewModel();

        void SetDealViewModel(DealViewModel viewModel);
    }
}