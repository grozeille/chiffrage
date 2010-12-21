using System.Collections.Generic;

namespace Chiffrage.Catalogs.Domain
{
    public class Catalog
    {
        public Catalog()
        {
            this.SupplierCatalogs = new List<SupplierCatalog>();
        }

        public int Id { get; set; }

        public virtual IList<SupplierCatalog> SupplierCatalogs { get; set; }
    }
}