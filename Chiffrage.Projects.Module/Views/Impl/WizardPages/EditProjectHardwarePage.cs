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

            double tempDouble;

            if (!double.TryParse(this.textBoxMilestone.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out tempDouble))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxMilestone, "Doit être un nombre");
            }
        }
        
        public string HardwareName
        {
            set { this.textBoxHardwareName.Text = value; }
        }

        public double Milestone
        {
            get { return double.Parse(this.textBoxMilestone.Text, NumberStyles.Float, CultureInfo.InvariantCulture); }
            set { this.textBoxMilestone.Text = value.ToString(CultureInfo.InvariantCulture); }
        }
    }
}
