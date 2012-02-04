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
using Chiffrage.Projects.Domain.Commands;
using Chiffrage.App.ViewModel;

namespace Chiffrage.Wizards
{
    public class NewProjectSupplyWizardView : WizardView, INewProjectSupplyView
    {
        private GenericWizardSetting<NewProjectSupplyPage> newProjectSupplyPage;

        private int projectId;

        private IList<CatalogSupplyViewModel> supplies;

        public NewProjectSupplyWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {
            this.newProjectSupplyPage = new GenericWizardSetting<NewProjectSupplyPage>("Ajout d'un composant", "Ajouter un composant au project", true);
            this.newProjectSupplyPage.TypedPage.Supplies = this.supplies;

            return new WizardSettingListIterator(this.newProjectSupplyPage);
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if (result == DialogResult.OK)
            {
                var command = new CreateNewProjectSupplyCommand(
                    projectId,
                    newProjectSupplyPage.TypedPage.CatalogSupplyViewModel.CatalogId,
                    newProjectSupplyPage.TypedPage.CatalogSupplyViewModel.Id,
                    newProjectSupplyPage.TypedPage.Quantity);

                this.EventBroker.Publish(command);
            }
        }


        public int ProjectId
        {
            set { this.projectId = value; }
        }

        public IList<CatalogSupplyViewModel> Supplies
        {
            set { this.supplies = value; }
        }

        public override string Name
        {
            get { return "Ajout de fourniture"; }
        }
    }
}
