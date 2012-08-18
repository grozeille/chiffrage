using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Projects.Module.Views;
using Chiffrage.Mvc.Views;
using Chiffrage.Projects.Module.Views.Impl.WizardPages;
using Chiffrage.Mvc.Events;
using Chiffrage.Projects.Module.Events;
using Chiffrage.Projects.Domain.Commands;

namespace Chiffrage.Projects.Module.Views.Impl
{
    public class NewDealWizardView : WizardView, INewDealView
    {
        private GenericWizardSetting<NewDealPage> newDealPage;

        public NewDealWizardView(IEventBroker eventBroker):base(eventBroker)
        {
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {
            this.newDealPage = new GenericWizardSetting<NewDealPage>("Nouvelle affaire", "Création d'une nouvelle affaire", true);

            return new WizardSettingListIterator(this.newDealPage);
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if (result == DialogResult.OK)
            {
                this.EventBroker.Publish(new CreateNewDealCommand(newDealPage.TypedPage.DealName));
            }
        }

        public override string Name
        {
            get { return "Nouvelle affaire"; }
        }
    }
}
