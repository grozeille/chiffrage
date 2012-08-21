using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Catalogs.Module.ViewModel;
namespace Chiffrage.App.ViewModel
{
    public class NavigationItemViewModel
    {
        public CatalogItemViewModel[] Catalogs { get; set; }

        public DealItemViewModel[] Deals { get; set; }
    }
}