using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Catalogs.Module.Views;
using Chiffrage.Mvc.Views;
using Chiffrage.Catalogs.Module.Views.Impl.WizardPages;
using Chiffrage.Mvc.Events;
using Chiffrage.Catalogs.Module.Actions;
using Chiffrage.Catalogs.Domain.Commands;

namespace Chiffrage.Catalogs.Module.Views.Impl
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
                this.EventBroker.Publish(new CreateNewCatalogCommand(newCatalogPage.TypedPage.SupplierName), Topics.COMMANDS);
            }
        }

        public override string Name
        {
            get { return "Nouveau catalogue"; }
        }
    }
}
