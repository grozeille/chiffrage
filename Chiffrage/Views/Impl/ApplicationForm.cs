using System;
using System.Windows.Forms;
using Chiffrage.App.Events;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Views;
using Chiffrage.Projects.Module.Views;
using Chiffrage.Catalogs.Module.Views;
using Chiffrage.Common.Module.Actions;
using Chiffrage.Projects.Module.Actions;

namespace Chiffrage
{
    public partial class ApplicationForm : FormView, IApplicationView
    {
        public ApplicationForm(
            IEventBroker eventBroker, 
            INavigationView navigationView, 
            ICatalogView catalogView,
            IDealView dealView,
            IErrorLogView errorLogView,
            IProjectView projectView,
            ITasksView tasksView,
            ILoadingView loadingView)
            : this()
        {
            navigationView.SetParent(this.splitContainer.Panel1);
            catalogView.HideView();
            catalogView.SetParent(this.splitContainer.Panel2);
            dealView.HideView();
            dealView.SetParent(this.splitContainer.Panel2);
            projectView.HideView();
            projectView.SetParent(this.splitContainer.Panel2);
            errorLogView.SetParent(this.splitContainerMain.Panel2);
            loadingView.HideView();
            loadingView.SetParent(this.splitContainer.Panel2);
            tasksView.HideView();
            tasksView.SetParent(this.splitContainer.Panel2);

            eventBroker.RegisterToolStripBouttonClickEventSource(this.saveToolStripButton, new SaveAction());
            eventBroker.RegisterToolStripMenuItemClickEventSource(this.affaireToolStripMenuItem2, new RequestNewDealAction());
            //eventBroker.RegisterToolStripMenuItemClickEventSource(this.projetToolStripMenuItem2, ()=>
            //    {
            //        new RequestNewProjectEvent(this.)
            //    });
        }

        public ApplicationForm()
        {
            this.InitializeComponent();
        }
    }
}