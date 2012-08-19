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

            if (!int.TryParse(this.textBoxStudyDays.Text, out temp))
            {
                e.Cancel = true; this.errorProvider.SetError(this.textBoxStudyDays, "Doit être un nombre");
            }

            if (!int.TryParse(this.textBoxReferenceDays.Text, out temp))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxReferenceDays, "Doit être un nombre");
            }

            if (!int.TryParse(this.textBoxWorkDays.Text, out temp))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxWorkDays, "Doit être un nombre");
            }

            if (!int.TryParse(this.textBoxExecutiveWorkDays.Text, out temp))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxExecutiveWorkDays, "Doit être un nombre");
            }

            if (!int.TryParse(this.textBoxTestsDays.Text, out temp))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxTestsDays, "Doit être un nombre");
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

        public double CatalogStudyDays
        {
            set { this.textBoxCatalogStudyDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double CatalogReferenceDays
        {
            set { this.textBoxCatalogReferenceDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double CatalogWorkDays
        {
            set { this.textBoxCatalogWorkDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double CatalogExecutiveWorkDays
        {
            set { this.textBoxCatalogExecutiveWorkDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double CatalogTestDays
        {
            set { this.textBoxCatalogTestsDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double StudyDays
        {
            get { return double.Parse(this.textBoxStudyDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxStudyDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double ReferenceDays
        {
            get { return double.Parse(this.textBoxReferenceDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxReferenceDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double WorkDays
        {
            get { return double.Parse(this.textBoxWorkDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxWorkDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double ExecutiveWorkDays
        {
            get { return double.Parse(this.textBoxExecutiveWorkDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxExecutiveWorkDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double TestDays
        {
            get { return double.Parse(this.textBoxTestsDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxTestsDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }
    }
}
