using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Views;
using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Projects.Domain;

namespace Chiffrage.Projects.Module.Views
{
    public interface IEditProjectHardwareView : IView
    {
        ProjectHardwareViewModel Hardware { set; }

        IList<ProjectTask> ProjectTasks { set; }

        IList<ProjectHardwareTask> HardwareTask { set; }
    }
}
