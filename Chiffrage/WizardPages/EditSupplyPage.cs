using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.App.ViewModel;
using System.Globalization;

namespace Chiffrage.WizardPages
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

            if (!int.TryParse(this.textBoxStudyDays.Text, out temp))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxStudyDays, "Doit être un nombre");
            }

            if (!int.TryParse(this.textBoxReferenceDays.Text, out temp))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxReferenceDays, "Doit être un nombre");
            }

            if (!int.TryParse(this.textBoxCatalogWorkDays.Text, out temp))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxCatalogWorkDays, "Doit être un nombre");
            }

            if (!int.TryParse(this.textBoxCatalogExecutiveWorkDays.Text, out temp))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxCatalogExecutiveWorkDays, "Doit être un nombre");
            }

            if (!int.TryParse(this.textBoxTestsDays.Text, out temp))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxTestsDays, "Doit être un nombre");
            }
        }

        public CatalogSupplyViewModel ViewModel
        {
            get
            {
                return new CatalogSupplyViewModel
                {
                    CatalogId = this.catalogId,
                    Id = this.supplyId,
                    Name = this.textBoxName.Text,
                    Reference = this.textBoxReference.Text,
                    Category = this.comboBoxCategory.Text,
                    ModuleSize = int.Parse(this.textBoxModuleSize.Text),
                    CatalogPrice = double.Parse(this.textBoxCatalogPrice.Text, NumberStyles.Float, CultureInfo.InvariantCulture),
                    StudyDays = int.Parse(this.textBoxStudyDays.Text),
                    ReferenceDays = int.Parse(this.textBoxReferenceDays.Text),
                    CatalogWorkDays = int.Parse(this.textBoxCatalogWorkDays.Text),
                    CatalogExecutiveWorkDays = int.Parse(this.textBoxCatalogExecutiveWorkDays.Text),
                    CatalogTestsDays = int.Parse(this.textBoxTestsDays.Text)
                };
            }

            set
            {
                this.catalogId = value.CatalogId;
                this.supplyId = value.Id;
                this.textBoxName.Text = value.Name;
                this.textBoxReference.Text = value.Reference;
                this.comboBoxCategory.Text = value.Category;
                this.textBoxModuleSize.Text = value.ModuleSize.ToString();
                this.textBoxCatalogPrice.Text = value.CatalogPrice.ToString(CultureInfo.InvariantCulture);
                this.textBoxStudyDays.Text = value.StudyDays.ToString();
                this.textBoxReferenceDays.Text = value.ReferenceDays.ToString();
                this.textBoxCatalogWorkDays.Text = value.CatalogWorkDays.ToString();
                this.textBoxCatalogExecutiveWorkDays.Text = value.CatalogExecutiveWorkDays.ToString();
                this.textBoxTestsDays.Text = value.CatalogTestsDays.ToString();
            }
        }
    }
}
