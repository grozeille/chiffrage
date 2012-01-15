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
    public class EditHardwareWizardView : WizardView, IEditHardwareView
    {
        private GenericWizardSetting<EditHardwarePage> editHardwarePage;

        private CatalogHardwareViewModel hardware;

        public EditHardwareWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }

        protected override WizardSetting[] BuildWizardPages()
        {

            this.editHardwarePage = new GenericWizardSetting<EditHardwarePage>("Edition d'un matériel",
                                                                         "Vous pouvez ici éditer un matériel", true);
            this.editHardwarePage.TypedPage.ViewModel = this.hardware;

            return new WizardSetting[] { this.editHardwarePage };
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if(result == DialogResult.OK)
            {
                this.EventBroker.Publish(new EditHardwareEvent(editHardwarePage.TypedPage.ViewModel));
            }
        }

        public CatalogHardwareViewModel Hardware
        {
            set { this.hardware = value; }
        }
    }
}
