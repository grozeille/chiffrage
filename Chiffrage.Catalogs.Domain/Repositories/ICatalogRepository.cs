using System.Collections.Generic;

namespace Chiffrage.Catalogs.Domain.Repositories
{
    public interface ICatalogRepository
    {
        void Save(Catalog catalog);

        void Save(SupplierCatalog catalog);

        IList<SupplierCatalog> FindAll();

        SupplierCatalog FindById(int catalogId);
    }
}