using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.App.ViewModel;
using AutoMapper;
using System.Globalization;

namespace Chiffrage.WizardPages
{
    public partial class NewSupplyPage : UserControl
    {
        public NewSupplyPage()
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
        }

        public string Reference
        {
            get { return this.textBoxReference.Text; }
        }

        public string Category
        {
            get { return this.comboBoxCategory.Text; }
        }

        public int ModuleSize
        {
            get { return int.Parse(this.textBoxModuleSize.Text); }
        }

        public double CatalogPrice
        {
            get { return double.Parse(this.textBoxCatalogPrice.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
        }

        public int PFC12
        {
            get { return int.Parse(this.textBoxPFC12.Text); }
        }

        public int PFC0
        {
            get { return int.Parse(this.textBoxPFC0.Text); }
        }

        public int Cap
        {
            get { return int.Parse(this.textBoxCap.Text); }
        }
    }
}
