using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Views;
using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Catalogs.Module.ViewModel;

namespace Chiffrage.Projects.Module.Views
{
    public interface INewProjectHardwareView : IView
    {
        int ProjectId { set; }

        IList<CatalogHardwareViewModel> Hardwares { set; }
    }
}
