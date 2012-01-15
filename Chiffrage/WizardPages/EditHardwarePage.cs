using System.Windows.Forms;
using System.ComponentModel;
using Chiffrage.App.ViewModel;

namespace Chiffrage.WizardPages
{
    public partial class EditHardwarePage : UserControl
    {
        private int catalogId;

        private int hardwareId;

        public EditHardwarePage()
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
                    Id = this.hardwareId,
                    Name = this.textBoxHardwareName.Text
                };
            }
            set
            {
                this.catalogId = value.CatalogId;
                this.hardwareId = value.Id;
                this.textBoxHardwareName.Text = value.Name;
            }
        }
    }
}