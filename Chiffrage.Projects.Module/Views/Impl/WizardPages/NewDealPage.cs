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

        private void NewDealPage_Load(object sender, System.EventArgs e)
        {
            this.textBoxDealName.Focus();
        }
    }
}