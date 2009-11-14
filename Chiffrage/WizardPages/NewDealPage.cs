using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chiffrage.WizardPages
{
    public partial class NewDealPage : UserControl
    {
        public string DealName 
        {
            get { return this.textBoxDealName.Text; }
        }

        public NewDealPage()
        {
            InitializeComponent();
        }
    }
}
