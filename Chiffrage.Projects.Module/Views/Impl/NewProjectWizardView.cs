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

namespace Chiffrage.Projects.Module.Views.Impl
{
    public class NewProjectWizardView : WizardView, INewProjectView
    {
        private GenericWizardSetting<NewProjectPage> newProjectPage;

        private int parentDealId;

        public NewProjectWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {
            this.newProjectPage = new GenericWizardSetting<NewProjectPage>("Nouveau projet", "Création d'une nouveau projet", true);

            return new WizardSettingListIterator(this.newProjectPage);
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if (result == DialogResult.OK)
            {
                this.EventBroker.Publish(new CreateNewProjectCommand(parentDealId, newProjectPage.TypedPage.ProjectName), "topic://commands");
            }
        }

        public int ParentDealId
        {
            set { this.parentDealId = value; }
        }

        public override string Name
        {
            get { return "Nouveau projet"; }
        }
    }
}
