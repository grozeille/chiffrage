using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Views;
using Chiffrage.App.ViewModel;

namespace Chiffrage.App.Views
{
    public interface INewProjectSupplyView : IView
    {
        int ProjectId { set; }

        IList<CatalogSupplyViewModel> Supplies { set; }
    }
}
