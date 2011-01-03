using System;
using System.Windows.Forms;

namespace Chiffrage.Mvc.Views
{
    public class UserControlView : UserControl, IView
    {
        #region IView Members

        public void SetParent(Control parent)
        {
            Parent = parent;
            Dock = DockStyle.Fill;
        }

        public void ShowView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(this.ShowView));
                return;
            }

            Show();
        }

        public void HideView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(this.HideView));
                return;
            }

            Hide();
        }

        #endregion
    }
}