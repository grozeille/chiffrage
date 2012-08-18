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
    public partial class EditProjectSupplyPage : UserControl
    {
        public EditProjectSupplyPage()
        {
            InitializeComponent();
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);

            int temp;
            double tempDouble;

            if (string.IsNullOrEmpty(this.textBoxName.Text))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxName, "Obligatoire");
            }

            if (!int.TryParse(this.textBoxQuantity.Text, out temp))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxQuantity, "Doit être un nombre");
            }

            if (!int.TryParse(this.textBoxModuleSize.Text, out temp))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxModuleSize, "Doit être un nombre");
            }

            if (!double.TryParse(this.textBoxPrice.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxPrice, "Doit être un nombre");
            }

            if (!int.TryParse(this.textBoxPFC0.Text, out temp))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxPFC0, "Doit être un nombre");
            }

            if (!int.TryParse(this.textBoxPFC12.Text, out temp))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxPFC12, "Doit être un nombre");
            }

            if (!int.TryParse(this.textBoxCap.Text, out temp))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxCap, "Doit être un nombre");
            }
        }

        public string SupplyName
        {
            get { return this.textBoxName.Text; }
            set { this.textBoxName.Text = value; }
        }

        public string Reference
        {
            get { return this.textBoxReference.Text; }
            set { this.textBoxReference.Text = value; }
        }

        public string Category
        {
            get { return this.comboBoxCategory.Text; }
            set { this.comboBoxCategory.Text = value; }
        }

        public int Quantity
        {
            get { return int.Parse(this.textBoxQuantity.Text); }
            set { this.textBoxQuantity.Text = value.ToString(); }
        }

        public int ModuleSize
        {
            get { return int.Parse(this.textBoxModuleSize.Text); }
            set { this.textBoxModuleSize.Text = value.ToString(); }
        }

        public double CatalogPrice
        {
            set { this.textBoxCatalogPrice.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double Price
        {
            get { return double.Parse(this.textBoxPrice.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxPrice.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public int PFC12
        {
            get { return int.Parse(this.textBoxPFC12.Text); }
            set { this.textBoxPFC12.Text = value.ToString(); }
        }

        public int PFC0
        {
            get { return int.Parse(this.textBoxPFC0.Text); }
            set { this.textBoxPFC0.Text = value.ToString(); }
        }

        public int Cap
        {
            get { return int.Parse(this.textBoxCap.Text); }
            set { this.textBoxCap.Text = value.ToString(); }
        }
    }
}
