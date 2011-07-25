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

namespace Chiffrage
{
    public class NewProjectWizardView : INewProjectView
    {
        private readonly IEventBroker eventBroker;

        private Control parent;

        private readonly WizardForm form;

        private int parentDealId;

        public NewProjectWizardView(IEventBroker eventBroker)
        {
            this.eventBroker = eventBroker;
            this.form = new WizardForm();
        }

        public void SetParent(Control parent)
        {
            this.parent = parent;
        }

        public void ShowView()
        {
            var newProjectPage = new NewProjectPage();

            this.form.WizardSettings = new[]
            {
                new WizardSetting(newProjectPage, "Nouveau projet", "Création d'une nouveau projet", true)
            }; 

            this.parent.BeginInvoke(new Action(() =>
            {
                var result = this.form.ShowDialog(this.parent);
                if (result == DialogResult.OK)
                {
                    this.eventBroker.Publish(new CreateNewProjectEvent(parentDealId, newProjectPage.ProjectName));
                }
            }));            
        }

        public void HideView()
        {
            this.form.Close();
        }

        public void SetParentDeal(int parentDealId)
        {
            this.parentDealId = parentDealId;
        }
    }
}
