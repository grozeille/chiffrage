using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Views;
using Chiffrage.Projects.Module.ViewModel;

namespace Chiffrage.Projects.Module.Views
{
    public interface IEditProjectHardwareView : IView
    {
        ProjectHardwareViewModel Hardware { set; }
    }
}
