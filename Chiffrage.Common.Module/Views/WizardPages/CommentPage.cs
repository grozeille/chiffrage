using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chiffrage.Common.Module.Views.WizardPages
{
    public partial class CommentPage : UserControl
    {
        public CommentPage()
        {
            InitializeComponent();
        }

        public string Comment
        {
            get
            {
                return this.commentUserContrl.Rtf;
            }
            set
            {
                if (value == null || !(value.StartsWith("{\\rtf") && value.EndsWith("}")))
                    value = "{\\rtf" + value + "}";
                this.commentUserContrl.Rtf = value;
            }
        }
    }
}
