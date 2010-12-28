using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.App.ViewModel;

namespace Chiffrage.App.Views
{
    public interface ICatalogView: IView
    {
        void Display(CatalogViewModel viewModel);
    }
}