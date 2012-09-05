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
    public partial class EditProjectHardwareWorkerWorkPage : UserControl
    {
        public EditProjectHardwareWorkerWorkPage()
        {
            InitializeComponent();
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);

            double tempDouble;

            if (!double.TryParse(this.textBoxWorkerWorkDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxWorkerWorkDays, "Doit être un nombre");
            }

            if (!double.TryParse(this.textBoxWorkerWorkShortNights.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxWorkerWorkShortNights, "Doit être un nombre");
            }

            if (!double.TryParse(this.textBoxWorkerWorkLongNights.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxWorkerWorkLongNights, "Doit être un nombre");
            }
        }
        public string HardwareName
        {
            set { this.textBoxHardwareName.Text = value; }
        }

        public double CatalogWorkerWorkDays
        {
            set { this.textBoxCatalogWorkerWorkDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double WorkerWorkDays
        {
            get { return double.Parse(this.textBoxWorkerWorkDays.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxWorkerWorkDays.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double WorkerWorkShortNights
        {
            get { return double.Parse(this.textBoxWorkerWorkShortNights.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxWorkerWorkShortNights.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        public double WorkerWorkLongNights
        {
            get { return double.Parse(this.textBoxWorkerWorkLongNights.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxWorkerWorkLongNights.Text = value.ToString(CultureInfo.InvariantCulture); }
        }
    }
}
