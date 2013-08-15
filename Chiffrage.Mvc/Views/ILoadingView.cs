using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Mvc.Views
{
    public interface ILoadingView : IView
    {
        bool Continuous { set; }

        int Position { set; }
    }
}
