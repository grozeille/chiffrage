using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Exceptions;
using System.Drawing;
using System.Diagnostics;
using System.Threading;

namespace Chiffrage.Mvc.Views
{
    public abstract class WizardView : IView
    {
        protected readonly IEventBroker EventBroker;

        protected IWin32Window Parent;

        protected readonly WizardForm Form;

        protected readonly SynchronizationContext UISynchronizationContext;

        public virtual Icon Icon
        {
            get 
            {
                return null;
            }
        }

        public abstract String Name
        {
            get;
        }

        private IWizardSettingIterator wizardSettingIterator;

        protected WizardView(IEventBroker eventBroker)
        {
            this.EventBroker = eventBroker;
            this.Form = new WizardForm();
            this.UISynchronizationContext = WindowsFormsSynchronizationContext.Current;
        }

        public void SetParent(IWin32Window parent)
        {
            this.Parent = parent;
        }

        public void PrepareView()
        {
            if (this.Parent == null)
            {
                this.Parent = Application.OpenForms[0];
            }

            this.UISynchronizationContext.Post(new SendOrPostCallback(new Action<object>((x) =>
            {
                this.wizardSettingIterator = this.BuildWizardPages();
            })), null);
        }

        public void ShowView()
        {
            if (this.Parent == null)
            {
                IntPtr hdl = Process.GetCurrentProcess().MainWindowHandle;
                var window = new NativeWindow();
                window.AssignHandle(hdl);

                this.Parent = window;
            }

            this.UISynchronizationContext.Post(new SendOrPostCallback(new Action<object>((x) =>
            {
                if (this.Form.Visible)
                {
                    this.Form.Focus();
                }
                else
                {
                    this.Form.Text = this.Name;
                    this.wizardSettingIterator = this.BuildWizardPages();
                    this.Form.WizardSettings = this.wizardSettingIterator;
                    var result = this.Form.ShowDialog(this.Parent);
                    this.OnWizardClosed(result);
                }
            })), null);
        }

        protected abstract IWizardSettingIterator BuildWizardPages();

        public IWizardSettingIterator WizardSettingIterator
        {
            get
            {
                return this.wizardSettingIterator;
            }
        }

        protected abstract void OnWizardClosed(DialogResult result);

        public void HideView()
        {
            this.Form.Close();
        }
    }
}