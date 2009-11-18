using System;
using System.Collections.Generic;
using System.Text;

namespace Chiffrage.Core
{
    public class SupplierCatalog
    {
        public virtual int Id { get; set; }

        public virtual string SupplierName { get; set; }

        public virtual IList<Supply> Supplies { get; set; }

        public SupplierCatalog()
        {
            Supplies = new List<Supply>();
        }
    }
}
