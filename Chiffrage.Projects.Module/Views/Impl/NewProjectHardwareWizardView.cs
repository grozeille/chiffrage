using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Projects.Module.Views;
using Chiffrage.Mvc.Views;
using Chiffrage.Projects.Module.Views.Impl.WizardPages;
using Chiffrage.Mvc.Events;
using Chiffrage.Projects.Module.Actions;
using Chiffrage.Projects.Domain.Commands;
using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Catalogs.Module.ViewModel;

namespace Chiffrage.Projects.Module.Views.Impl
{
    public class NewProjectHardwareWizardView : WizardView, INewProjectHardwareView
    {
        private GenericWizardSetting<NewProjectHardwarePage> newProjectSupplyPage;

        private int projectId;

        private IList<CatalogHardwareSelectionViewModel> hardwares;

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
                foreach(var i in newProjectSupplyPage.TypedPage.CatalogHardwareViewModel)
                {
                    for (int cpt = 0; cpt < i.Quantity; cpt++)
                    {
                        var command = new CreateNewProjectHardwareCommand(
                        projectId,
                        i.CatalogId,
                        i.Id);

                        this.EventBroker.Publish(command, "topic://commands");
                    }
                }
            }
        }


        public int ProjectId
        {
            set { this.projectId = value; }
        }

        public IList<CatalogHardwareSelectionViewModel> Hardwares
        {
            set { this.hardwares = value; }
        }

        public override string Name
        {
            get { return "Ajout de matériel"; }
        }
    }
}
