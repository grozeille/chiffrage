using System.Windows.Forms;
using System.ComponentModel;
using Chiffrage.App.ViewModel;
using System.Globalization;

namespace Chiffrage.WizardPages
{
    public partial class NewHardwarePage : UserControl
    {
        public NewHardwarePage()
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

            if (!double.TryParse(this.textBoxCatalogWorkDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxCatalogWorkDays, "Doit être un nombre");
            }

            if (!double.TryParse(this.textBoxCatalogExecutiveWorkDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxCatalogExecutiveWorkDays, "Doit être un nombre");
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
        }

        public double StudyDays
        {
            get { return double.Parse(this.textBoxStudyDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
        }

        public double ReferenceDays
        {
            get { return double.Parse(this.textBoxReferenceDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
        }

        public double CatalogWorkDays
        {
            get { return double.Parse(this.textBoxCatalogWorkDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
        }

        public double CatalogExecutiveWorkDays
        {
            get { return double.Parse(this.textBoxCatalogExecutiveWorkDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
        }

        public double CatalogTestDays
        {
            get { return double.Parse(this.textBoxTestsDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
        }
    }
}