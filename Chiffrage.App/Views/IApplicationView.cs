using Chiffrage.App.ViewModel;
using Chiffrage.Mvc.Views;

namespace Chiffrage.App.Views
{
    public interface IApplicationView : IView
    {
        void Display(ApplicationItemViewModel viewModel);

        void UpdateCatalog(CatalogItemViewModel viewModel);

        void UpdateDeal(DealItemViewModel viewModel);
    }
}