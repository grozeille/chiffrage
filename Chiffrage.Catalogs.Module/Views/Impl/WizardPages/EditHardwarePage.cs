using System.Windows.Forms;
using System.ComponentModel;
using Chiffrage.Catalogs.Module.ViewModel;
using System.Globalization;

namespace Chiffrage.Catalogs.Module.Views.Impl.WizardPages
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

            double tempDouble;

            if (string.IsNullOrEmpty(this.textBoxHardwareName.Text))
            {
                e.Cancel = true; this.errorProvider.SetError(this.textBoxHardwareName, "Obligatoire");
            }

            if (!double.TryParse(this.textBoxStudyDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true; this.errorProvider.SetError(this.textBoxStudyDays, "Doit être un nombre");
            }

            if (!double.TryParse(this.textBoxReferenceDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxReferenceDays, "Doit être un nombre");
            }

            if (!double.TryParse(this.textBoxCatalogExecutiveWorkDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxCatalogExecutiveWorkDays, "Doit être un nombre");
            }

            if (!double.TryParse(this.textBoxCatalogTechnicianWorkDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxCatalogTechnicianWorkDays, "Doit être un nombre");
            }

            if (!double.TryParse(this.textBoxCatalogWorkerWorkDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxCatalogWorkerWorkDays, "Doit être un nombre");
            }

            if (!double.TryParse(this.textBoxTestsDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
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

        public double CatalogExecutiveWorkDays
        {
            get { return double.Parse(this.textBoxCatalogExecutiveWorkDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxCatalogExecutiveWorkDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double CatalogTechnicianWorkDays
        {
            get { return double.Parse(this.textBoxCatalogTechnicianWorkDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxCatalogTechnicianWorkDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double CatalogWorkerWorkDays
        {
            get { return double.Parse(this.textBoxCatalogWorkerWorkDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxCatalogWorkerWorkDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double CatalogTestDays
        {
            get { return double.Parse(this.textBoxTestsDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxTestsDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }
    }
}