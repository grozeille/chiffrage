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
using Chiffrage.Catalogs.Domain.Commands;

namespace Chiffrage
{
    public class EditHardwareSupplyWizardView : WizardView, IEditHardwareSupplyView
    {
        private GenericWizardSetting<EditHardwareSupplyPage> editHardwareSupplyPage;

        private CatalogHardwareSupplyViewModel hardwareSupply;

        public EditHardwareSupplyWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {

            this.editHardwareSupplyPage = new GenericWizardSetting<EditHardwareSupplyPage>("Edition d'un composant de matériel",
                                                                         "Vous pouvez ici éditer le composant du matériel", true);
            this.editHardwareSupplyPage.TypedPage.Quantity = this.hardwareSupply.Quantity;
            this.editHardwareSupplyPage.TypedPage.Comment = this.hardwareSupply.Comment;

            return new WizardSettingListIterator(this.editHardwareSupplyPage);
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if(result == DialogResult.OK)
            {
                var command = new UpdateHardwareSupplyCommand(
                    hardwareSupply.CatalogId,
                    hardwareSupply.HardwareId,
                    hardwareSupply.Id,
                    this.editHardwareSupplyPage.TypedPage.Quantity,
                    this.editHardwareSupplyPage.TypedPage.Comment);
                this.EventBroker.Publish(command);
            }
        }

        public CatalogHardwareSupplyViewModel HardwareSupply
        {
            set { this.hardwareSupply = value; }
        }

        public override string Name
        {
            get { return "Edition de composant de matériel"; }
        }
    }
}
