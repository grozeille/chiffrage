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
using Chiffrage.Catalogs.Domain.Commands;

namespace Chiffrage
{
    public class NewSupplyWizardView : WizardView, INewSupplyView
    {
        private int catalogId;

        private GenericWizardSetting<NewSupplyPage> newSupplyPage;

        public NewSupplyWizardView(IEventBroker eventBroker) : base(eventBroker)
        {
        }

        protected override WizardSetting[] BuildWizardPages()
        {

            this.newSupplyPage = new GenericWizardSetting<NewSupplyPage>("Création d'une fourniture",
                                                                         "Vous pouvez ici créer une nouvelle fourniture", true);
            this.newSupplyPage.TypedPage.CatalogId = this.catalogId;

            return new WizardSetting[] { this.newSupplyPage };
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if(result == DialogResult.OK)
            {
                var command = new CreateNewSupplyCommand(
                    newSupplyPage.TypedPage.ViewModel.CatalogId,
                    newSupplyPage.TypedPage.ViewModel.Name,
                    newSupplyPage.TypedPage.ViewModel.Reference,
                    newSupplyPage.TypedPage.ViewModel.Category,
                    newSupplyPage.TypedPage.ViewModel.ModuleSize,
                    newSupplyPage.TypedPage.ViewModel.CatalogPrice,
                    newSupplyPage.TypedPage.ViewModel.StudyDays,
                    newSupplyPage.TypedPage.ViewModel.ReferenceDays,
                    newSupplyPage.TypedPage.ViewModel.CatalogWorkDays,
                    newSupplyPage.TypedPage.ViewModel.CatalogExecutiveWorkDays,
                    newSupplyPage.TypedPage.ViewModel.CatalogTestsDays);
                this.EventBroker.Publish(command);
            }
        }

        public int CatalogId
        {
            set { this.catalogId = value; }
        }
    }
}
