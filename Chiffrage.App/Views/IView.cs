using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chiffrage.App.Views
{
    public interface IView
    {
        void SetParent(Control parent);

        void ShowView();

        void HideView();
    }
}
