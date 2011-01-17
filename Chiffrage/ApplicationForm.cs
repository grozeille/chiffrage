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
        public ApplicationForm(
            IEventBroker eventBroker, 
            INavigationView applicationView, 
            ICatalogView catalogView,
            IDealView dealView,
            IErrorLogView errorLogView,
            IProjectView projectView,
            INewDealView newDealView)
            : this()
        {
            applicationView.SetParent(this.splitContainer.Panel1);
            catalogView.SetParent(this.splitContainer.Panel2);
            dealView.SetParent(this.splitContainer.Panel2);
            projectView.SetParent(this.splitContainer.Panel2);
            errorLogView.SetParent(this.splitContainerMain.Panel2);
            newDealView.SetParent(this);

            eventBroker.RegisterToolStripBouttonClickEventSource(this.saveToolStripButton, new SaveEvent());
            eventBroker.RegisterToolStripMenuItemClickEventSource(this.affaireToolStripMenuItem2, new NewDealEvent());
        }

        public ApplicationForm()
        {
            this.InitializeComponent();
        }
    }
}