using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Catalogs.Remoting.Model;

namespace Chiffrage.Excel.Views
{
    public partial class ImportCatalogWizardPage : UserControl
    {
        private CatalogItem[] catalogItem;

        public ImportCatalogWizardPage()
        {
            InitializeComponent();
        }

        public CatalogItem[] CatalogItem
        {
            set 
            {
                this.catalogItem = value;
                this.comboBoxCatalog.Items.Clear();
                this.comboBoxCatalog.Items.AddRange(this.catalogItem.Select(x => x.Name).ToArray());
                this.comboBoxCatalog.SelectedIndex = 0;
            }
        }

        public CatalogItem SelectedCatalogItem
        {
            get
            {
                return this.catalogItem[this.comboBoxCatalog.SelectedIndex];
            }
        }
    }
}
