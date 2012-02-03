using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.App.Events;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Views;
using Chiffrage.WizardPages;
using Chiffrage.Catalogs.Domain.Commands;

namespace Chiffrage
{
    public class NewSupplyWizardView : WizardView, INewSupplyView
    {
        private int catalogId;

        private GenericWizardSetting<NewSupplyPage> newSupplyPage;

        public NewSupplyWizardView(IEventBroker eventBroker) : base(eventBroker)
        {
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {

            this.newSupplyPage = new GenericWizardSetting<NewSupplyPage>("Création d'une fourniture",
                                                                         "Vous pouvez ici créer une nouvelle fourniture", true);
            return new WizardSettingListIterator(this.newSupplyPage);
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if(result == DialogResult.OK)
            {
                var command = new CreateNewSupplyCommand(
                    this.catalogId,
                    newSupplyPage.TypedPage.SupplyName,
                    newSupplyPage.TypedPage.Reference,
                    newSupplyPage.TypedPage.Category,
                    newSupplyPage.TypedPage.ModuleSize,
                    newSupplyPage.TypedPage.CatalogPrice,
                    newSupplyPage.TypedPage.PFC12,
                    newSupplyPage.TypedPage.PFC0,
                    newSupplyPage.TypedPage.Cap);
                this.EventBroker.Publish(command);
            }
        }

        public int CatalogId
        {
            set { this.catalogId = value; }
        }

        public override string Name
        {
            get { return "Nouvelle fourniture"; }
        }
    }
}
