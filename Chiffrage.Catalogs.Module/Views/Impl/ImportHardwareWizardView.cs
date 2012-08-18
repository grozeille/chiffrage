using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Views;
using Chiffrage.Catalogs.Module.Views;
using Chiffrage.Catalogs.Module.Views.Impl.WizardPages;
using Chiffrage.Mvc.Events;
using System.Windows.Forms;
using Chiffrage.Catalogs.Domain.Commands;

namespace Chiffrage.Catalogs.Module.Views.Impl
{
    public class ImportHardwareWizardView : WizardView, IImportHardwareView
    {
        private int catalogId;

        private GenericWizardSetting<ImportHardwareWizardPage> page;

        public int CatalogId
        {
            set { this.catalogId = value; }
        }

        public override string Name
        {
            get { return "Importer du matériel"; }
        }

         public ImportHardwareWizardView(IEventBroker eventBroker)
            :base(eventBroker)
        {
            
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {
            this.page = new GenericWizardSetting<ImportHardwareWizardPage>("Import de matériel", "Import de matériel", true);            

            return new WizardSettingListIterator(this.page);
        }

        protected override void OnWizardClosed(System.Windows.Forms.DialogResult result)
        {
            if (result == DialogResult.OK)
            {
                this.EventBroker.Publish(new ImportHardwareCommand(
                    this.catalogId,
                    this.page.TypedPage.Filepath));
            }
        }
    }
}
