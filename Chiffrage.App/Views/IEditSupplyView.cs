﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Views;
using Chiffrage.App.ViewModel;

namespace Chiffrage.App.Views
{
    public interface IEditSupplyView : IView
    {
        CatalogSupplyViewModel Supply { set; }
    }
}
