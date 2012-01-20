using System.Windows.Forms;

namespace Chiffrage.WizardPages
{
    public partial class NewProjectPage : UserControl
    {
        public NewProjectPage()
        {
            this.InitializeComponent();
        }

        public string ProjectName
        {
            get { return this.textBoxProjectName.Text; }
        }
    }
}