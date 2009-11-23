using Chiffrage.Core;

namespace Chiffrage.Dto
{
    public interface ICatalogItemSelectionDto
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