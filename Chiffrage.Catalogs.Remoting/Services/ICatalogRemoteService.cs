using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Remoting.Model;

namespace Chiffrage.Catalogs.Remoting
{
    public interface ICatalogRemoteService
    {
        CatalogItem[] GetCatalogs();

        object[,] GetCatalogData(int catalogId);

        bool Ping();
    }
}
