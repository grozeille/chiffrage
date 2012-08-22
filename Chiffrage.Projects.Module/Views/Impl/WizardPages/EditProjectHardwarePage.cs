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
    public partial class EditProjectHardwarePage : UserControl
    {
        public EditProjectHardwarePage()
        {
            InitializeComponent();
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

            if (string.IsNullOrEmpty(this.textBoxHardwareName.Text))
            {
                e.Cancel = true; this.errorProvider.SetError(this.textBoxHardwareName, "Obligatoire");
            }
        }

        public int Quantity
        {
            get { return int.Parse(this.textBoxQuantity.Text); }
            set { this.textBoxQuantity.Text = value.ToString(); }
        }

        public string HardwareName
        {
            get { return this.textBoxHardwareName.Text; }
            set { this.textBoxHardwareName.Text = value; }
        }
    }
}
