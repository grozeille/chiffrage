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
    public partial class NewSupplyPage : UserControl
    {
        public NewSupplyPage()
        {
            InitializeComponent();
        }

        public CatalogSupplyViewModel ViewModel
        {
            get
            {
                return new CatalogSupplyViewModel
                {
                    Name = this.textBoxName.Text
                };
            }
        }
    }
}
