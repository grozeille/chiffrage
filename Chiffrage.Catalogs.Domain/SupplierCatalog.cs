using System.Collections.Generic;
using System.ComponentModel;

namespace Chiffrage.Catalogs.Domain
{
    public class SupplierCatalog
    {
        public SupplierCatalog()
        {
            this.Supplies = new List<Supply>();
            this.Hardwares = new List<Hardware>();
            this.Cables = new List<Cable>();
        }

        public virtual int Id
        { get; set; }

        public virtual string SupplierName
        { get; set; }

        public virtual IList<Supply> Supplies
        { get; set; }

        public virtual IList<Hardware> Hardwares
        { get; set; }

        public virtual IList<Cable> Cables
        { get; set; }

        public virtual string Comment
        { get; set; }
    }
}