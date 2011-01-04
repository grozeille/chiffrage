using Chiffrage.App.ViewModel;
using Chiffrage.Mvc.Views;

namespace Chiffrage.App.Views
{
    public interface IDealView : IView
    {
        void Display(DealViewModel viewModel);
        
        DealViewModel GetViewModel();
    }
}