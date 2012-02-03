using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Exceptions;
using System.Drawing;

namespace Chiffrage.Mvc.Views
{
    public abstract class WizardView : IView
    {
        protected readonly IEventBroker EventBroker;

        protected Control Parent;

        protected readonly WizardForm Form;

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
        }

        public void SetParent(Control parent)
        {
            this.Parent = parent;
        }

        public void PrepareView()
        {
            if (this.Parent == null)
            {
                this.Parent = Application.OpenForms[0];
            }

            this.Parent.BeginInvoke(new Action(() =>
            {
                this.wizardSettingIterator = this.BuildWizardPages();
            }));
        }

        public void ShowView()
        {
            if (this.Parent == null)
            {
                this.Parent = Application.OpenForms[0];
            }

            
            this.Parent.BeginInvoke(new Action(() =>
            {
                this.Form.Text = this.Name;
                this.wizardSettingIterator = this.BuildWizardPages();
                this.Form.WizardSettings = this.wizardSettingIterator;
                var result = this.Form.ShowDialog(this.Parent);
                this.OnWizardClosed(result);
            }));
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