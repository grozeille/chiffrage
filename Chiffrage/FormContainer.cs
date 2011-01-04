using System;
using System.Windows.Forms;
using Chiffrage.App.Events;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Events;

namespace Chiffrage
{
    public partial class FormContainer : Form
    {
        private readonly IEventBroker eventBroker;

        private readonly IApplicationView applicationView;
        private readonly ICatalogView catalogView;
        private readonly IDealView dealView;        
        private readonly IErrorLogView errorLogView;

        public FormContainer(IEventBroker eventBroker, IApplicationView applicationView, ICatalogView catalogView, IDealView dealView, IErrorLogView errorLogView)
            : this()
        {
            this.applicationView = applicationView;
            this.catalogView = catalogView;
            this.dealView = dealView;
            this.errorLogView = errorLogView;
            this.eventBroker = eventBroker;
        }

        public FormContainer()
        {
            this.InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.applicationView.SetParent(this.splitContainer.Panel1);
            this.catalogView.SetParent(this.splitContainer.Panel2);
            this.dealView.SetParent(this.splitContainer.Panel2);
            this.errorLogView.SetParent(this.splitContainerMain.Panel2);

            eventBroker.RegisterToolStripBouttonClickEventSource(this.saveToolStripButton, new SaveEvent());
        }
    }
}