using System;
using System.Windows.Forms;
using Chiffrage.Mvc.Exceptions;

namespace Chiffrage.Mvc.Views
{
    public class UserControlView : UserControl, IView
    {
        #region IView Members

        public virtual void SetParent(Control parent)
        {
            Parent = parent;
            Dock = DockStyle.Fill;
        }

        public virtual void ShowView()
        {
            if(this.Parent == null)
            {
                throw new NoParentViewException();
            }
            else
            {
                InvokeIfRequired(Show);   
            }            
        }

        public virtual void HideView()
        {
            InvokeIfRequired(Hide);
        }

        #endregion

        public void InvokeIfRequired(Action action)
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(action);
            }
            else
            {
                action();   
            }            
        }
    }
}