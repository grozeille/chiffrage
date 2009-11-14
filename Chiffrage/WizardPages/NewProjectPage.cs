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
    public partial class NewProjectPage : UserControl
    {
        public string ProjectName
        {
            get
            {
                return this.textBoxProjectName.Text;
            }
        }

        public NewProjectPage()
        {
            InitializeComponent();
        }
    }
}
