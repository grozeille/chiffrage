using Chiffrage.App.ViewModel;
using Chiffrage.Mvc.Views;

namespace Chiffrage.App.Views
{
    public interface INavigationView : IView
    {
        void Display(NavigationItemViewModel viewModel);

        void UpdateCatalog(CatalogItemViewModel viewModel);

        void UpdateDeal(DealItemViewModel viewModel);

        void AddDeal(DealItemViewModel viewModel);
    }
}