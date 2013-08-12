using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Module.ViewModel
{
    public class CatalogHardwareSelectionViewModel
    {
        public int Id { get; set; }

        public int CatalogId { get; set; }

        public string CatalogName { get; set; }

        public string Name { get; set; }

        public string Reference { get; set; }

        public string Category { get; set; }

        public bool Selected { get; set; }

        public int Quantity { get; set; }
    }
}
