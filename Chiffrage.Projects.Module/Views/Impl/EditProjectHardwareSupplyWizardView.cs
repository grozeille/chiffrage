using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Views;
using Chiffrage.Projects.Module.ViewModel;
using System.Windows.Forms;
using Chiffrage.Mvc.Events;
using Chiffrage.Projects.Module.Views.Impl.WizardPages;
using Chiffrage.Projects.Domain.Commands;

namespace Chiffrage.Projects.Module.Views.Impl
{
    public class EditProjectHardwareSupplyWizardView : WizardView, IEditProjectHardwareSupplyView
    {
        private GenericWizardSetting<EditProjectHardwareSupplyPage1> editHardwareSupplyPage1;

        private GenericWizardSetting<EditProjectHardwareSupplyPage2> editHardwareSupplyPage2;

        private ProjectHardwareSupplyViewModel hardwareSupply;

        public EditProjectHardwareSupplyWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {
            this.editHardwareSupplyPage1 = new GenericWizardSetting<EditProjectHardwareSupplyPage1>("Edition d'un composant",
                                                                         "Vous pouvez ici éditer le composant", true);
            
            this.editHardwareSupplyPage1.TypedPage.Quantity = this.hardwareSupply.Quantity;
            this.editHardwareSupplyPage1.TypedPage.SupplyName = this.hardwareSupply.SupplyName;
            this.editHardwareSupplyPage1.TypedPage.Reference = this.hardwareSupply.SupplyReference;
            this.editHardwareSupplyPage1.TypedPage.Category = this.hardwareSupply.SupplyCategory;
            this.editHardwareSupplyPage1.TypedPage.ModuleSize = this.hardwareSupply.SupplyModuleSize;
            this.editHardwareSupplyPage1.TypedPage.CatalogPrice = this.hardwareSupply.SupplyCatalogPrice;
            this.editHardwareSupplyPage1.TypedPage.Price = this.hardwareSupply.SupplyPrice;
            this.editHardwareSupplyPage1.TypedPage.PFC12 = this.hardwareSupply.SupplyPFC12;
            this.editHardwareSupplyPage1.TypedPage.PFC0 = this.hardwareSupply.SupplyPFC0;
            this.editHardwareSupplyPage1.TypedPage.Cap = this.hardwareSupply.SupplyCap;

            this.editHardwareSupplyPage2 = new GenericWizardSetting<EditProjectHardwareSupplyPage2>("Edition d'un composant",
                                                                         "Vous pouvez ici éditer le composant", true);

            this.editHardwareSupplyPage2.TypedPage.Comment = this.hardwareSupply.Comment;

            return new WizardSettingListIterator(this.editHardwareSupplyPage1, this.editHardwareSupplyPage2);
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if(result == DialogResult.OK)
            {
                var command = new UpdateProjectHardwareSupplyCommand(
                    this.hardwareSupply.ProjectId,
                    this.hardwareSupply.HardwareId,
                    this.hardwareSupply.Id,
                    this.editHardwareSupplyPage1.TypedPage.Price);
                this.EventBroker.Publish(command, "topic://commands");
            }
        }

        public ProjectHardwareSupplyViewModel HardwareSupply
        {
            set { this.hardwareSupply = value; }
        }

        public override string Name
        {
            get { return "Edition de composant"; }
        }
    }
}
