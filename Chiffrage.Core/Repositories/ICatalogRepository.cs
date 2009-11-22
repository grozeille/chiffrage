namespace Chiffrage.Core.Repositories
{
    public interface ICatalogRepository
    {
        void Save(Catalog catalog);

        SupplierCatalog Save(SupplierCatalog catalog);
    }
}