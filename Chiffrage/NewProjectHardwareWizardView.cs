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

namespace Chiffrage
{
    public class NewProjectHardwareWizardView : WizardView, INewProjectHardwareView
    {
        private GenericWizardSetting<NewProjectHardwarePage> newProjectSupplyPage;

        private int projectId;

        private IList<CatalogHardwareViewModel> hardwares;

        public NewProjectHardwareWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {
            this.newProjectSupplyPage = new GenericWizardSetting<NewProjectHardwarePage>("Ajout d'un composant", "Ajouter un composant au project", true);
            this.newProjectSupplyPage.TypedPage.Hardwares = this.hardwares;

            return new WizardSettingListIterator(this.newProjectSupplyPage);
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if (result == DialogResult.OK)
            {
                var command = new CreateNewProjectHardwareCommand(
                    projectId,
                    newProjectSupplyPage.TypedPage.CatalogHardwareViewModel.CatalogId,
                    newProjectSupplyPage.TypedPage.CatalogHardwareViewModel.Id,
                    newProjectSupplyPage.TypedPage.Quantity);

                this.EventBroker.Publish(command);
            }
        }


        public int ProjectId
        {
            set { this.projectId = value; }
        }

        public IList<CatalogHardwareViewModel> Hardwares
        {
            set { this.hardwares = value; }
        }

        public override string Name
        {
            get { return "Ajout de matériel"; }
        }
    }
}
