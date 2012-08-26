using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Remoting.Contracts.Model;

namespace Chiffrage.Excel.Actions
{
    public class RequestImportCatalogAction
    {
        private readonly CatalogItem catalogItem;

        public RequestImportCatalogAction(CatalogItem catalogItem)
        {
            this.catalogItem = catalogItem;
        }

        public CatalogItem CatalogItem
        {
            get
            {
                return this.catalogItem;
            }
        }
    }
}
