using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Catalogs.Module.ViewModel;
using System.Globalization;

namespace Chiffrage.Catalogs.Module.Views.Impl.WizardPages
{
    public partial class EditSupplyPage : UserControl
    {
        private int catalogId;

        private int supplyId;

        public EditSupplyPage()
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

            if (!int.TryParse(this.textBoxModuleSize.Text, out temp))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxModuleSize, "Doit être un nombre");
            }

            if (!double.TryParse(this.textBoxCatalogPrice.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxCatalogPrice, "Doit être un nombre");
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

        public int ModuleSize
        {
            get { return int.Parse(this.textBoxModuleSize.Text); }
            set { this.textBoxModuleSize.Text = value.ToString(); }
        }

        public double CatalogPrice
        {
            get { return double.Parse(this.textBoxCatalogPrice.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxCatalogPrice.Text = value.ToString(CultureInfo.InvariantCulture); }
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
