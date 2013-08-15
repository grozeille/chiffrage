using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Views;
using Chiffrage.Catalogs.Module.ViewModel;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.Catalogs.Module.Views
{
    public interface INewHardwareView : IView
    {
        int CatalogId { set; }

        IList<Task> Tasks { set; }
    }
}
