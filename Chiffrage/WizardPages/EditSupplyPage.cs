using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.App.ViewModel;

namespace Chiffrage.WizardPages
{
    public partial class EditSupplyPage : UserControl
    {
        private int catalogId;

        private int supplyId;

        public EditSupplyPage()
        {
            InitializeComponent();
        }

        public CatalogSupplyViewModel ViewModel
        {
            get
            {
                return new CatalogSupplyViewModel
                {
                    CatalogId = this.catalogId,
                    Id = this.supplyId,
                    Name = this.textBoxName.Text
                };
            }

            set
            {
                this.catalogId = value.CatalogId;
                this.supplyId = value.Id;
                this.textBoxName.Text = value.Name;
            }
        }
    }
}
