using System.Windows.Forms;

namespace Chiffrage.WizardPages
{
    public partial class NewDealPage : UserControl
    {
        public NewDealPage()
        {
            this.InitializeComponent();
        }

        public string DealName
        {
            get { return this.textBoxDealName.Text; }
        }
    }
}