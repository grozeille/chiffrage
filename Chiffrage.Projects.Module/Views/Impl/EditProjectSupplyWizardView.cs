using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Projects.Module.Actions;
using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Projects.Module.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Views;
using Chiffrage.Projects.Module.Views.Impl.WizardPages;
using Chiffrage.Catalogs.Domain.Commands;
using Chiffrage.Projects.Domain.Commands;

namespace Chiffrage.Projects.Module.Views.Impl
{
    public class EditProjectSupplyWizardView : WizardView, IEditProjectSupplyView
    {
        private GenericWizardSetting<EditProjectSupplyPage> editSupplyPage;

        private ProjectSupplyViewModel supply;

        public EditProjectSupplyWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {

            this.editSupplyPage = new GenericWizardSetting<EditProjectSupplyPage>("Edition d'une fourniture",
                                                                         "Vous pouvez ici éditer une fourniture", true);
            this.editSupplyPage.TypedPage.Quantity = this.supply.Quantity;
            this.editSupplyPage.TypedPage.SupplyName = this.supply.Name;
            this.editSupplyPage.TypedPage.Reference = this.supply.Reference;
            this.editSupplyPage.TypedPage.Category = this.supply.Category;
            this.editSupplyPage.TypedPage.ModuleSize = this.supply.ModuleSize;
            this.editSupplyPage.TypedPage.CatalogPrice = this.supply.CatalogPrice;
            this.editSupplyPage.TypedPage.Price = this.supply.Price;
            this.editSupplyPage.TypedPage.PFC12 = this.supply.PFC12;
            this.editSupplyPage.TypedPage.PFC0 = this.supply.PFC0;
            this.editSupplyPage.TypedPage.Cap = this.supply.Cap;

            return new WizardSettingListIterator(this.editSupplyPage);
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if(result == DialogResult.OK)
            {
                var command = new UpdateProjectSupplyCommand(
                    this.supply.ProjectId,
                    this.supply.Id,
                    editSupplyPage.TypedPage.Quantity,
                    editSupplyPage.TypedPage.Price);
                this.EventBroker.Publish(command, "topic://commands");
            }
        }

        public ProjectSupplyViewModel Supply
        {
            set { this.supply = value; }
        }

        public override string Name
        {
            get { return "Edition de fourniture"; }
        }
    }
}
