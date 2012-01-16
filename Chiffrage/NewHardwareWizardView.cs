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

namespace Chiffrage
{
    public class NewHardwareWizardView : WizardView, INewHardwareView
    {
        private int catalogId;

        private GenericWizardSetting<NewHardwarePage> newHardwarePage;

        public NewHardwareWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }

        protected override WizardSetting[] BuildWizardPages()
        {
            this.newHardwarePage = new GenericWizardSetting<NewHardwarePage>("Création d'une matériel",
                                                                         "Vous pouvez ici créer un nouveau matériel", true);
            this.newHardwarePage.TypedPage.CatalogId = this.catalogId;

            return new WizardSetting[] { this.newHardwarePage };
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if(result == DialogResult.OK)
            {
                this.EventBroker.Publish(new CreateNewHardwareEvent(newHardwarePage.TypedPage.ViewModel));
            }
        }

        public int CatalogId
        {
            set { this.catalogId = value; }
        }
    }
}
