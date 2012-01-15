using System.Windows.Forms;
using System.ComponentModel;
using Chiffrage.App.ViewModel;

namespace Chiffrage.WizardPages
{
    public partial class NewHardwarePage : UserControl
    {
        private int catalogId;

        public NewHardwarePage()
        {
            this.InitializeComponent();
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);

            if (string.IsNullOrEmpty(this.textBoxHardwareName.Text))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxHardwareName, "Obligatoire");
            }
        }

        public CatalogHardwareViewModel ViewModel
        {
            get
            {
                return new CatalogHardwareViewModel
                {
                    CatalogId = this.catalogId,
                    Name = this.textBoxHardwareName.Text
                };
            }
        }

        public int CatalogId
        {
            set { this.catalogId = value; }
        }
    }
}