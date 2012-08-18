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
using Chiffrage.Mvc.Views;

namespace Chiffrage.WizardPages
{
    public partial class NewSupplyPage : WithValidationUserControl
    {
        public NewSupplyPage()
        {
            InitializeComponent();

            this.textBoxName.Validating += this.ValidateIsRequiredTextBox;
            this.textBoxModuleSize.Validating += this.ValidateIsIntegerTextBox;
            this.textBoxCatalogPrice.Validating += this.ValidateIsDoubleTextBox;
            this.textBoxPFC0.Validating += this.ValidateIsIntegerTextBox;
            this.textBoxPFC12.Validating += this.ValidateIsIntegerTextBox;
            this.textBoxCap.Validating += this.ValidateIsIntegerTextBox;
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
