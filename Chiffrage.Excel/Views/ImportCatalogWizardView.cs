using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Views;
using Chiffrage.Mvc.Events;
using System.Windows.Forms;
using Chiffrage.Excel.Actions;
using Chiffrage.Catalogs.Remoting.Contracts.Model;

namespace Chiffrage.Excel.Views
{
    public class ImportCatalogWizardView : WizardView
    {
        private CatalogItem[] catalogItem;

        private GenericWizardSetting<ImportCatalogWizardPage> importCatalog;

        public ImportCatalogWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }

        public override string Name
        {
            get { return "Importer un catalogue"; }
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {
            this.importCatalog = new GenericWizardSetting<ImportCatalogWizardPage>("Importer un catalogue",
                                                                         "Vous pouvez ici importer les matériaux d'un catalogue", true);

            this.importCatalog.TypedPage.CatalogItem = this.catalogItem;

            return new WizardSettingListIterator(this.importCatalog);
        }

        protected override void OnWizardClosed(System.Windows.Forms.DialogResult result)
        {
            if (result == DialogResult.OK)
            {
                this.EventBroker.Publish(new RequestImportCatalogAction(this.importCatalog.TypedPage.SelectedCatalogItem), "topic://commands");
            }
        }

        public CatalogItem[] CatalogItem
        {
            set
            {
                this.catalogItem = value;
            }
        }
    }
}
