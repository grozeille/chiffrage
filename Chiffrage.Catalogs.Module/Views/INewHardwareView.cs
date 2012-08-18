using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Views;

namespace Chiffrage.Catalogs.Module.Views
{
    public interface INewHardwareView : IView
    {
        int CatalogId { set; }
    }
}
