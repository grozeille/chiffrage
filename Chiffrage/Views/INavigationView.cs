using Chiffrage.App.ViewModel;
using Chiffrage.Mvc.Views;
using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Catalogs.Module.ViewModel;

namespace Chiffrage.App.Views
{
    public interface INavigationView : IView
    {
        void Display(NavigationItemViewModel viewModel);

        void UpdateCatalog(CatalogItemViewModel viewModel);

        void UpdateDeal(DealItemViewModel viewModel);

        void AddDeal(DealItemViewModel viewModel);

        void AddCatalog(CatalogItemViewModel viewModel);

        void AddProject(int dealId, ProjectItemViewModel viewModel);

        void UpdateProject(ProjectItemViewModel viewModel);

        void SelectDeal(int dealId);

        void SelectCatalog(int catalogId);

        void SelectProject(int projectId);
    }
}