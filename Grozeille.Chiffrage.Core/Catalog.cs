using System;
using System.Collections.Generic;
using System.Text;

namespace Chiffrage.Core
{
    public class Catalog
    {
        public int Id { get; set; }

        public virtual IList<SupplierCatalog> SupplierCatalogs { get; set; }

        public Catalog()
        {
            SupplierCatalogs = new List<SupplierCatalog>();
        }
    }
}
