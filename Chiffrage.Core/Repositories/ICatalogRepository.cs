using System;
using System.Collections.Generic;
using System.Text;

namespace Chiffrage.Core.Repositories
{
    public interface ICatalogRepository
    {
        void Save(Catalog catalog);

        SupplierCatalog Save(SupplierCatalog catalog);
    }
}
