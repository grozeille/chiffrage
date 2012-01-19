using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Views;
using Chiffrage.WizardPages;
using Chiffrage.Mvc.Events;
using Chiffrage.App.Events;
using Chiffrage.Projects.Domain.Commands;

namespace Chiffrage
{
    public class NewDealWizardView : WizardView, INewDealView
    {
        private GenericWizardSetting<NewDealPage> newDealPage;

        public NewDealWizardView(IEventBroker eventBroker):base(eventBroker)
        {
        }

        protected override WizardSetting[] BuildWizardPages()
        {
            this.newDealPage = new GenericWizardSetting<NewDealPage>("Nouvelle affaire", "Création d'une nouvelle affaire", true);

            return new WizardSetting[] { this.newDealPage };
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if (result == DialogResult.OK)
            {
                this.EventBroker.Publish(new CreateNewDealCommand(newDealPage.TypedPage.DealName));
            }
        }
    }
}
