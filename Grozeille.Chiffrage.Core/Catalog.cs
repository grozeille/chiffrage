using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grozeille.Chiffrage.Core
{
    public class Catalog
    {
        public IList<SupplierCatalog> SupplierCatalogs { get; set; }

        public Catalog()
        {
            SupplierCatalogs = new List<SupplierCatalog>();
        }
    }
}
