using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.App.Events;
using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Views;
using Chiffrage.WizardPages;

namespace Chiffrage
{
    public class EditSupplyWizardView : WizardView, IEditSupplyView
    {
        private GenericWizardSetting<EditSupplyPage> editSupplyPage;

        private CatalogSupplyViewModel supply;

        public EditSupplyWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }

        protected override WizardSetting[] BuildWizardPages()
        {

            this.editSupplyPage = new GenericWizardSetting<EditSupplyPage>("Edition d'une fourniture",
                                                                         "Vous pouvez ici éditer une fourniture", true);
            this.editSupplyPage.TypedPage.ViewModel = this.supply;

            return new WizardSetting[] { this.editSupplyPage };
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if(result == DialogResult.OK)
            {
                this.EventBroker.Publish(new EditSupplyEvent(editSupplyPage.TypedPage.ViewModel));
            }
        }

        public CatalogSupplyViewModel Supply
        {
            set { this.supply = value; }
        }
    }
}
