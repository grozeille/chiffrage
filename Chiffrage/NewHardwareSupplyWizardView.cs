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
using Chiffrage.App.ViewModel;

namespace Chiffrage
{
    public class NewHardwareSupplyWizardView : WizardView, INewHardwareSupplyView
    {
        private int parentHardwareId;

        private int catalogId;

        private IList<CatalogSupplyViewModel> supplies;

        private GenericWizardSetting<NewHardwareSupplyPage> newHardwareSupplyPage;

        public NewHardwareSupplyWizardView(IEventBroker eventBroker)
            :base(eventBroker)
        {
            
        }

        protected override WizardSetting[] BuildWizardPages()
        {
            this.newHardwareSupplyPage = new GenericWizardSetting<NewHardwareSupplyPage>("Nouveau composant de matériel", "Ajout d'un composant au matériel", true);
            this.newHardwareSupplyPage.TypedPage.Supplies = this.supplies;

            return new WizardSetting[] { this.newHardwareSupplyPage };
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if (result == DialogResult.OK)
            {
                this.EventBroker.Publish(new CreateNewHardwareSupplyEvent(this.catalogId, this.parentHardwareId, this.newHardwareSupplyPage.TypedPage.SelectedSupply, this.newHardwareSupplyPage.TypedPage.Quantity));
            }
        }

        public int CatalogId
        {
            set { this.catalogId = value; }
        }

        public IList<CatalogSupplyViewModel> Supplies
        {
            set { this.supplies = value; }
        }


        public int ParentHardwareId
        {
            set { this.parentHardwareId = value; }
        }
    }
}
