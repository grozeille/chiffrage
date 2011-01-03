using System.Windows.Forms;

namespace Chiffrage.WizardPages
{
    public partial class NewCatalogPage : UserControl
    {
        public NewCatalogPage()
        {
            this.InitializeComponent();
        }

        public string SupplierName
        {
            get { return this.textBoxSupplierName.Text; }
        }
    }
}