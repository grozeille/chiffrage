using System.Windows.Forms;

namespace Chiffrage.Mvc.Views
{
    public interface IView
    {
        void SetParent(IWin32Window parent);

        void ShowView();

        void HideView();
    }
}