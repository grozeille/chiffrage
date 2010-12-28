using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.App.Views;

namespace Chiffrage
{
    public partial class FormContainer : Form
    {
        private readonly IApplicationView applicationView;
        private readonly ICatalogView catalogView;

        public FormContainer(IApplicationView applicationView, ICatalogView catalogView)
            : this()
        {
            this.applicationView = applicationView;
            this.catalogView = catalogView;
        }

        public FormContainer()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.applicationView.SetParent(this.splitContainer.Panel1);
            this.catalogView.SetParent(this.splitContainer.Panel2);
        }
    }
}
