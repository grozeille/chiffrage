using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grozeille.Chiffrage.Core
{
    public class SupplierCatalog
    {
        public string SupplierName { get; set; }

        public IList<Supply> Supplies { get; set; }

        public SupplierCatalog()
        {
            Supplies = new List<Supply>();
        }
    }
}
