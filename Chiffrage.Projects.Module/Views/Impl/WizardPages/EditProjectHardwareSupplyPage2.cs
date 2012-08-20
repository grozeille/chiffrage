using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace Chiffrage.Projects.Module.Views.Impl.WizardPages
{
    public partial class EditProjectHardwareSupplyPage2 : UserControl
    {
        public EditProjectHardwareSupplyPage2()
        {
            InitializeComponent();
        }

        public string Comment
        {
            set
            {
                if (value == null || !(value.StartsWith(@"{\rtf")))
                {
                    this.commentUserContrl.Text = value;
                }
                else
                {
                    this.commentUserContrl.Rtf = value;
                }
            }
        }
    }
}
