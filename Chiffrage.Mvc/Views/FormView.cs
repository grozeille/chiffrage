using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Chiffrage.Mvc.Exceptions;

namespace Chiffrage.Mvc.Views
{
    public class FormView : Form, IView
    {
        #region IView Members

        public virtual void SetParent(IWin32Window parent)
        {
            this.Parent = parent as Control;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        public virtual void ShowView()
        {
            InvokeIfRequired(() =>
            {

                this.Show();
                this.BringToFront();
                
            });
        }

        public virtual void HideView()
        {
            InvokeIfRequired(Close);
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

        public T InvokeIfRequired<T>(Func<T> func)
        {
            if (this.InvokeRequired)
            {
                var asyncResult = BeginInvoke(func);
                return (T)EndInvoke(asyncResult);
            }
            else
            {
                return func();
            }
        }
    }
}
