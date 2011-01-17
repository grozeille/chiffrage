using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.App.Views;
using Chiffrage.WizardPages;
using Chiffrage.Mvc.Events;
using Chiffrage.App.Events;

namespace Chiffrage
{
    public class NewDealWizardView : INewDealView
    {
        private readonly IEventBroker eventBroker;

        private Control parent;

        private readonly WizardForm form;

        public NewDealWizardView(IEventBroker eventBroker)
        {
            this.eventBroker = eventBroker;
            this.form = new WizardForm();
        }

        public void SetParent(Control parent)
        {
            this.parent = parent;
        }

        public void ShowView()
        {
            var newDealPage = new NewDealPage();

            this.form.WizardSettings = new[]
            {
                new WizardSetting(newDealPage, "Nouvelle affaire", "Création d'une nouvelle affaire", true)
            }; 

            this.parent.BeginInvoke(new Action(() =>
            {
                var result = this.form.ShowDialog(this.parent);
                if (result == DialogResult.OK)
                {
                    this.eventBroker.Publish(new CreateNewDealEvent(newDealPage.DealName));
                }
            }));            
        }

        public void HideView()
        {
            this.form.Close();
        }
    }
}
