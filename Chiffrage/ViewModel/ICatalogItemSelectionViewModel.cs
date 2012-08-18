using Chiffrage.Core;

namespace Chiffrage.App.ViewModel
{
    public interface ICatalogItemSelectionViewModel
    {
        ICatalogItem CatalogItem { get; }
        bool Selected { get; set; }
        string Name { get; }
        string Supplier { get; set; }
        string Reference { get; }
        double Price { get; }
        int ModuleSize { get; }
    }
}