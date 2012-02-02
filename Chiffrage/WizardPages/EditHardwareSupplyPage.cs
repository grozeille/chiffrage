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
    public partial class EditHardwareSupplyPage : UserControl
    {
        public EditHardwareSupplyPage()
        {
            InitializeComponent();
        }

        public int Quantity
        {
            get { return int.Parse(this.textBoxQuantity.Text); }
            set { this.textBoxQuantity.Text = value.ToString(); }
        }

        public string Comment
        {
            get { return this.commentUserContrl.Rtf; }
            set
            {
                if (value == null || !(value.StartsWith("{\\rtf") && value.EndsWith("}")))
                    value = "{\\rtf" + value + "}";
                this.commentUserContrl.Rtf = value;
            }
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);

            int temp;

            if (!int.TryParse(this.textBoxQuantity.Text, out temp))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxQuantity, "Doit être un nombre");
            }
        }
    }
}
