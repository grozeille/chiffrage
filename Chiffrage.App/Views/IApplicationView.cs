using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.App.Views
{
    public interface IApplicationView : IView
    {
        void Display(Chiffrage.App.ViewModel.ApplicationItemViewModel viewModel);
    }
}
