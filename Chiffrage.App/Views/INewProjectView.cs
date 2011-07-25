using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Views;

namespace Chiffrage.App.Views
{
    public interface INewProjectView : IView
    {
        void SetParentDeal(int parentDealId);
    }
}
