using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Mvc.Views;

namespace Chiffrage.Projects.Module.Views
{
    public interface IDealView : IView
    {
        DealViewModel GetDealViewModel();

        void SetDealViewModel(DealViewModel viewModel);
    }
}