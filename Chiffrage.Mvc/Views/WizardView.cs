using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Exceptions;

namespace Chiffrage.Mvc.Views
{
    public abstract class WizardView : IView
    {
        protected readonly IEventBroker EventBroker;

        protected Control Parent;

        protected readonly WizardForm Form;

        protected WizardView(IEventBroker eventBroker)
        {
            this.EventBroker = eventBroker;
            this.Form = new WizardForm();
        }

        public void SetParent(Control parent)
        {
            this.Parent = parent;
        }

        public void ShowView()
        {
            if (this.Parent == null)
            {
                this.Parent = Application.OpenForms[0];
            }

            this.Form.WizardSettings = this.BuildWizardPages();

            this.Parent.BeginInvoke(new Action(() =>
            {
                var result = this.Form.ShowDialog(this.Parent);
                this.OnWizardClosed(result);
            }));
        }

        protected abstract WizardSetting[] BuildWizardPages();

        protected abstract void OnWizardClosed(DialogResult result);

        public void HideView()
        {
            this.Form.Close();
        }
    }
}