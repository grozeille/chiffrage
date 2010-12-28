using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.App.ViewModel
{
    public class ApplicationItemViewModel
    {
        public CatalogItemViewModel[] Catalogs { get; set; }

        public DealItemViewModel[] Deals { get; set; }
    }
}
