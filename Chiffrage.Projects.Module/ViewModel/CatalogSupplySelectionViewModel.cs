using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Module.ViewModel
{
    public class CatalogSupplySelectionViewModel
    {
        public int Id { get; set; }

        public int CatalogId { get; set; }

        public string CatalogName { get; set; }

        public string Name { get; set; }

        public string Reference { get; set; }

        public string Category { get; set; }

        public int ModuleSize { get; set; }

        public double CatalogPrice { get; set; }

        public virtual int PFC0 { get; set; }

        public virtual int PFC12 { get; set; }

        public virtual int Cap { get; set; }

        public bool Selected { get; set; }

        public int Quantity { get; set; }
    }
}
