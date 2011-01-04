using System;
using System.Windows.Forms;
using Chiffrage.App.Views;

namespace Chiffrage
{
    public partial class FormContainer : Form
    {
        private readonly IApplicationView applicationView;
        private readonly ICatalogView catalogView;
        private readonly IDealView dealView;

        public FormContainer(IApplicationView applicationView, ICatalogView catalogView, IDealView dealView)
            : this()
        {
            this.applicationView = applicationView;
            this.catalogView = catalogView;
            this.dealView = dealView;
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
        }
    }
}