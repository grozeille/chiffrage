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

namespace Chiffrage.Wizards
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
                this.EventBroker.Publish(new CreateNewProjectCommand(parentDealId, newProjectPage.TypedPage.ProjectName));
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
