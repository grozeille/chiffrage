using System;
using System.Windows.Forms;
using Chiffrage.App.Events;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Views;

namespace Chiffrage
{
    public partial class ApplicationForm : FormView, IApplicationView
    {
        private IEventBroker eventBroker;

        public ApplicationForm(
            IEventBroker eventBroker, 
            INavigationView applicationView, 
            ICatalogView catalogView,
            IDealView dealView,
            IErrorLogView errorLogView,
            IProjectView projectView)
            : this()
        {
            applicationView.SetParent(this.splitContainer.Panel1);
            catalogView.SetParent(this.splitContainer.Panel2);
            dealView.SetParent(this.splitContainer.Panel2);
            projectView.SetParent(this.splitContainer.Panel2);
            errorLogView.SetParent(this.splitContainerMain.Panel2);
            
            eventBroker.RegisterToolStripBouttonClickEventSource(this.saveToolStripButton, new SaveEvent());
            eventBroker.RegisterToolStripMenuItemClickEventSource(this.affaireToolStripMenuItem2, new RequestNewDealEvent());
            //eventBroker.RegisterToolStripMenuItemClickEventSource(this.projetToolStripMenuItem2, ()=>
            //    {
            //        new RequestNewProjectEvent(this.)
            //    });
        }

        public ApplicationForm()
        {
            this.InitializeComponent();
        }

        private void newToolStripSplitButton_ButtonClick(object sender, EventArgs e)
        {
            var wizard = new NewWizardWizardView(eventBroker);
            wizard.Wizards = new WizardView[] 
            {
                new NewProjectWizardView(eventBroker),
                new NewDealWizardView(eventBroker),
                new NewCatalogWizardView(eventBroker)
            };
            wizard.ShowView();
        }
    }
}