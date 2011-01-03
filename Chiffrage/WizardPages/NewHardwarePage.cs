using System.Windows.Forms;

namespace Chiffrage.WizardPages
{
    public partial class NewHardwarePage : UserControl
    {
        public NewHardwarePage()
        {
            this.InitializeComponent();
        }

        public string HardwareName
        {
            get { return this.textBoxHardwareName.Text; }
        }
    }
}