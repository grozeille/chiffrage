﻿using System;
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

            if (!int.TryParse(this.textBoxQuantity.Text, out temp))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxQuantity, "Doit être un nombre");
            }

            if (!double.TryParse(this.textBoxPrice.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxPrice, "Doit être un nombre");
            }
        }

        public string SupplyName
        {
            set { this.textBoxName.Text = value; }
        }

        public string Reference
        {
            set { this.textBoxReference.Text = value; }
        }

        public string Category
        {
            set { this.textBoxCategory.Text = value; }
        }

        public int Quantity
        {
            get { return int.Parse(this.textBoxQuantity.Text); }
            set { this.textBoxQuantity.Text = value.ToString(); }
        }

        public int ModuleSize
        {
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
            set { this.textBoxPFC12.Text = value.ToString(); }
        }

        public int PFC0
        {
            set { this.textBoxPFC0.Text = value.ToString(); }
        }

        public int Cap
        {
            set { this.textBoxCap.Text = value.ToString(); }
        }
    }
}
