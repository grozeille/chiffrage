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
using Chiffrage.Catalogs.Domain.Commands;

namespace Chiffrage
{
    public class NewCatalogWizardView : WizardView, INewCatalogView
    {
        private GenericWizardSetting<NewCatalogPage> newCatalogPage;

        public NewCatalogWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {
            this.newCatalogPage = new GenericWizardSetting<NewCatalogPage>("Nouveau catalogue", "Création d'un nouveau catalogue fournisseur", true);

            return new WizardSettingListIterator(this.newCatalogPage);
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if (result == DialogResult.OK)
            {
                this.EventBroker.Publish(new CreateNewCatalogCommand(newCatalogPage.TypedPage.SupplierName));
            }
        }

        public override string Name
        {
            get { return "Nouveau catalogue"; }
        }
    }
}
