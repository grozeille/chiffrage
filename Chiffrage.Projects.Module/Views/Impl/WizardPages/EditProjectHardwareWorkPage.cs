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
    public partial class EditProjectHardwareWorkPage : UserControl
    {
        public EditProjectHardwareWorkPage()
        {
            InitializeComponent();
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);

            double tempDouble;

            if (!double.TryParse(this.textBoxWorkDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxWorkDays, "Doit être un nombre");
            }

            if (!double.TryParse(this.textBoxWorkShortNights.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxWorkShortNights, "Doit être un nombre");
            }

            if (!double.TryParse(this.textBoxWorkLongNights.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxWorkLongNights, "Doit être un nombre");
            }
        }
        public string HardwareName
        {
            set { this.textBoxHardwareName.Text = value; }
        }

        public double CatalogWorkDays
        {
            set { this.textBoxCatalogWorkDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double WorkDays
        {
            get { return double.Parse(this.textBoxWorkDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxWorkDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double WorkShortNights
        {
            get { return double.Parse(this.textBoxWorkShortNights.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxWorkShortNights.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double WorkLongNights
        {
            get { return double.Parse(this.textBoxWorkLongNights.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxWorkLongNights.Text = value.ToString(CultureInfo.InvariantCulture); }
        }
    }
}
