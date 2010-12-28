using Chiffrage.App.ViewModel;

namespace Chiffrage.App.Controllers
{
    public interface ICatalogController
    {
        void DisplayCatalog(int id);
        void SaveCatalog(CatalogViewModel model);
    }
}