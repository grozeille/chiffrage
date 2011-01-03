using System.Windows.Forms;

namespace Chiffrage.Mvc.Views
{
    public interface IView
    {
        void SetParent(Control parent);

        void ShowView();

        void HideView();
    }
}