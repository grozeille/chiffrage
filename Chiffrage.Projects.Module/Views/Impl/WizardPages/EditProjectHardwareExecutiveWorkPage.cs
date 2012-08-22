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
    public partial class EditProjectHardwareExecutiveWorkPage : UserControl
    {
        public EditProjectHardwareExecutiveWorkPage()
        {
            InitializeComponent();
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);

            double tempDouble;

            if (!double.TryParse(this.textBoxExecutiveWorkDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxExecutiveWorkDays, "Doit être un nombre");
            }

            if (!double.TryParse(this.textBoxExecutiveWorkShortNights.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxExecutiveWorkShortNights, "Doit être un nombre");
            }

            if (!double.TryParse(this.textBoxExecutiveWorkLongNights.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxExecutiveWorkLongNights, "Doit être un nombre");
            }
        }
        public string HardwareName
        {
            set { this.textBoxHardwareName.Text = value; }
        }

        public double CatalogExecutiveWorkDays
        {
            set { this.textBoxCatalogExecutiveWorkDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double ExecutiveWorkDays
        {
            get { return double.Parse(this.textBoxExecutiveWorkDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxExecutiveWorkDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double ExecutiveWorkShortNights
        {
            get { return double.Parse(this.textBoxExecutiveWorkShortNights.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxExecutiveWorkShortNights.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double ExecutiveWorkLongNights
        {
            get { return double.Parse(this.textBoxExecutiveWorkLongNights.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxExecutiveWorkLongNights.Text = value.ToString(CultureInfo.InvariantCulture); }
        }
    }
}
