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
    public partial class EditProjectHardwareStudyReferenceTestPage : UserControl
    {
        public EditProjectHardwareStudyReferenceTestPage()
        {
            InitializeComponent();
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);

            double tempDouble;

            if (!double.TryParse(this.textBoxStudyDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxStudyDays, "Doit être un nombre");
            }

            if (!double.TryParse(this.textBoxReferenceDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxReferenceDays, "Doit être un nombre");
            }

            if (!double.TryParse(this.textBoxTestsDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxTestsDays, "Doit être un nombre");
            }

            if (!double.TryParse(this.textBoxTestsNights.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxTestsNights, "Doit être un nombre");
            }
        }
        public string HardwareName
        {
            set { this.textBoxHardwareName.Text = value; }
        }

        public double CatalogStudyDays
        {
            set { this.textBoxCatalogStudyDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double StudyDays
        {
            get { return double.Parse(this.textBoxStudyDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxStudyDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double CatalogReferenceDays
        {
            set { this.textBoxCatalogReferenceDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double ReferenceDays
        {
            get { return double.Parse(this.textBoxReferenceDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxReferenceDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double CatalogTestsDays
        {
            set { this.textBoxCatalogTestsDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double TestsDays
        {
            get { return double.Parse(this.textBoxTestsDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxTestsDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double TestsNights
        {
            get { return double.Parse(this.textBoxTestsNights.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxTestsNights.Text = value.ToString(CultureInfo.InvariantCulture); }
        }
    }
}
