using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Catalogs.Module.Events;
using Chiffrage.Catalogs.Module.ViewModel;
using Chiffrage.Catalogs.Module.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Views;
using Chiffrage.Catalogs.Module.Views.Impl.WizardPages;
using Chiffrage.Catalogs.Domain.Commands;

namespace Chiffrage.Catalogs.Module.Views.Impl
{
    public class EditSupplyWizardView : WizardView, IEditSupplyView
    {
        private GenericWizardSetting<EditSupplyPage> editSupplyPage;

        private CatalogSupplyViewModel supply;

        public EditSupplyWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {

            this.editSupplyPage = new GenericWizardSetting<EditSupplyPage>("Edition d'une fourniture",
                                                                         "Vous pouvez ici éditer une fourniture", true);
            this.editSupplyPage.TypedPage.SupplyName = this.supply.Name;
            this.editSupplyPage.TypedPage.Reference = this.supply.Reference;
            this.editSupplyPage.TypedPage.Category = this.supply.Category;
            this.editSupplyPage.TypedPage.ModuleSize = this.supply.ModuleSize;
            this.editSupplyPage.TypedPage.CatalogPrice = this.supply.CatalogPrice;
            this.editSupplyPage.TypedPage.PFC12 = this.supply.PFC12;
            this.editSupplyPage.TypedPage.PFC0 = this.supply.PFC0;
            this.editSupplyPage.TypedPage.Cap = this.supply.Cap;

            return new WizardSettingListIterator(this.editSupplyPage);
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if(result == DialogResult.OK)
            {
                var command = new UpdateSupplyCommand(
                    this.supply.CatalogId,
                    this.supply.Id,
                    editSupplyPage.TypedPage.SupplyName,
                    editSupplyPage.TypedPage.Reference,
                    editSupplyPage.TypedPage.Category,
                    editSupplyPage.TypedPage.ModuleSize,
                    editSupplyPage.TypedPage.CatalogPrice,
                    editSupplyPage.TypedPage.PFC12,
                    editSupplyPage.TypedPage.PFC0,
                    editSupplyPage.TypedPage.Cap);
                this.EventBroker.Publish(command);
            }
        }

        public CatalogSupplyViewModel Supply
        {
            set { this.supply = value; }
        }

        public override string Name
        {
            get { return "Edition de fourniture"; }
        }
    }
}
