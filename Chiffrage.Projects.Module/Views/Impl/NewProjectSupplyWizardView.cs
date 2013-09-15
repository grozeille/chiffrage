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
    public class NewProjectSupplyWizardView : WizardView, INewProjectSupplyView
    {
        private GenericWizardSetting<NewProjectSupplyPage> newProjectSupplyPage;

        private int projectId;

        private IList<CatalogSupplySelectionViewModel> supplies;

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
                foreach(var item in newProjectSupplyPage.TypedPage.CatalogSupplyViewModel)
                {
                    var command = new CreateNewProjectSupplyCommand(
                        projectId,
                        item.CatalogId,
                        item.Id,
                        item.Quantity);

                    this.EventBroker.Publish(command, "topic://commands");
                }
            }
        }


        public int ProjectId
        {
            set { this.projectId = value; }
        }

        public IList<CatalogSupplySelectionViewModel> Supplies
        {
            set { this.supplies = value; }
        }

        public override string Name
        {
            get { return "Ajout de fourniture"; }
        }
    }
}
