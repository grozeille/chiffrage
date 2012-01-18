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
    public class EditSupplyWizardView : WizardView, IEditSupplyView
    {
        private GenericWizardSetting<EditSupplyPage> editSupplyPage;

        private CatalogSupplyViewModel supply;

        public EditSupplyWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }

        protected override WizardSetting[] BuildWizardPages()
        {

            this.editSupplyPage = new GenericWizardSetting<EditSupplyPage>("Edition d'une fourniture",
                                                                         "Vous pouvez ici éditer une fourniture", true);
            this.editSupplyPage.TypedPage.ViewModel = this.supply;

            return new WizardSetting[] { this.editSupplyPage };
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if(result == DialogResult.OK)
            {
                var command = new UpdateSupplyCommand(
                    editSupplyPage.TypedPage.ViewModel.CatalogId,
                    editSupplyPage.TypedPage.ViewModel.Id,
                    editSupplyPage.TypedPage.ViewModel.Name,
                    editSupplyPage.TypedPage.ViewModel.Reference,
                    editSupplyPage.TypedPage.ViewModel.Category,
                    editSupplyPage.TypedPage.ViewModel.ModuleSize,
                    editSupplyPage.TypedPage.ViewModel.CatalogPrice,
                    editSupplyPage.TypedPage.ViewModel.StudyDays,
                    editSupplyPage.TypedPage.ViewModel.ReferenceDays,
                    editSupplyPage.TypedPage.ViewModel.CatalogWorkDays,
                    editSupplyPage.TypedPage.ViewModel.CatalogExecutiveWorkDays,
                    editSupplyPage.TypedPage.ViewModel.CatalogTestsDays);
                this.EventBroker.Publish(command);
            }
        }

        public CatalogSupplyViewModel Supply
        {
            set { this.supply = value; }
        }
    }
}
