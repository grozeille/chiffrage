using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Chiffrage.Mvc.Views
{
    public class UserControlView : UserControl, IView
    {
        public void SetParent(Control parent)
        {
            this.Parent = parent;
            this.Dock = DockStyle.Fill;
        }

        public void ShowView()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(this.ShowView));
                return;
            }

            this.Show();
        }

        public void HideView()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(this.HideView));
                return;
            }

            this.Hide();
        }
    }
}