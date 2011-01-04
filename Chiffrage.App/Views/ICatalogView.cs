using Chiffrage.App.ViewModel;
using Chiffrage.Mvc.Views;

namespace Chiffrage.App.Views
{
    public interface ICatalogView : IView
    {
        void Display(CatalogViewModel viewModel);
        CatalogViewModel GetViewModel();
    }
}