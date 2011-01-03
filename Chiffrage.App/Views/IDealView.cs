using Chiffrage.App.ViewModel;
using Chiffrage.Mvc.Views;

namespace Chiffrage.App.Views
{
    public interface IDealView : IView
    {
        void DisplayDeal(DealViewModel viewModel);
    }
}