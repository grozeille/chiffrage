﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Views;
using Chiffrage.Catalogs.Module.ViewModel;

namespace Chiffrage.Catalogs.Module.Views
{
    public interface INewHardwareSupplyView : IView
    {
        int CatalogId { set; }

        IList<CatalogSupplyViewModel> Supplies { set; }

        int ParentHardwareId { set; }
    }
}
