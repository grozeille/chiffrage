using System.Windows.Forms;
using System.ComponentModel;
using Chiffrage.App.ViewModel;
using System.Globalization;

namespace Chiffrage.WizardPages
{
    public partial class EditHardwarePage : UserControl
    {
        public EditHardwarePage()
        {
            this.InitializeComponent();
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);

            int temp;

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

        public string HardwareName
        {
            get { return this.textBoxHardwareName.Text; }
            set { this.textBoxHardwareName.Text = value; }
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

        public double CatalogWorkDays
        {
            get { return double.Parse(this.textBoxCatalogWorkDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxCatalogWorkDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double CatalogExecutiveWorkDays
        {
            get { return double.Parse(this.textBoxCatalogExecutiveWorkDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxCatalogExecutiveWorkDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double CatalogTestDays
        {
            get { return double.Parse(this.textBoxTestsDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxTestsDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }
    }
}