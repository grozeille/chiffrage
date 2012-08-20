﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Mvc.Views;

namespace Chiffrage.Projects.Module.Views
{
    public interface IEditProjectHardwareSupplyView : IView
    {
        ProjectHardwareSupplyViewModel HardwareSupply
        {
            set;
        }
    }
}
