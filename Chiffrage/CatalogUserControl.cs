using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Chiffrage.Core;
using Chiffrage.WizardPages;

namespace Chiffrage
{
    public partial class CatalogUserControl : UserControl
    {
        private BindingList<Supply> supplyList;
        private SupplierCatalog catalog;
        private BindingList<Hardware> hardwareList;

        private bool loading = false;

        public CatalogUserControl()
        {
            InitializeComponent();
        }

        public SupplierCatalog Catalog
        {
            get { return catalog; }
            set
            {
                catalog = value;
                RefreshCatalog();
            }
        }

        public event EventHandler CatalogChanged;

        private void RefreshCatalog()
        {
            loading = true;
            if (catalog == null)
            {
                supplyList = null;
                hardwareList = null;
            }
            else
            {
                supplyList = new BindingList<Supply>(catalog.Supplies);
                hardwareList = new BindingList<Hardware>(catalog.Hardwares);
            }            
            hardwareBindingSource.DataSource = hardwareList;
            supplyBindingSource.DataSource = supplyList;

            if (catalog != null)
            {
                if (catalog.Comment == null)
                    catalog.Comment = string.Empty;
                if (!(catalog.Comment.StartsWith("{\\rtf") && catalog.Comment.EndsWith("}")))
                    catalog.Comment = "{\\rtf" + catalog.Comment + "}";
                supplierCatalogBindingSource.DataSource = catalog;                
            }
            loading = false;
            RefreshCategories();
        }

        private void CatalogUserControl_Load(object sender, EventArgs e)
        {
            /*SupplyCategory.DataSource = Enum.GetValues(typeof(SupplyCategory));
            SupplyCategory.DataPropertyName = "SupplyCategory";
            SupplyCategory.Name = "SupplyCategory";*/
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void supplyBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            FireCatalogChanged();
        }

        private void FireCatalogChanged()
        {
            if (!loading && CatalogChanged != null)
                CatalogChanged(this, new EventArgs());
        }

        private void RefreshCategories()
        {
            if (!loading)
            {
                if (toolStripComboBoxCategory.SelectedItem == null && toolStripComboBoxCategory.Items.Count > 1)
                    toolStripComboBoxCategory.SelectedItem = toolStripComboBoxCategory.Items[0];
                object selected = toolStripComboBoxCategory.SelectedItem;
                toolStripComboBoxCategory.Items.Clear();
                toolStripComboBoxCategory.Items.Add(string.Empty);
                if (catalog != null)
                {
                    toolStripComboBoxCategory.Items.AddRange(
                        catalog.Supplies.Where((s) => s.Category != null).Select((s) => s.Category).Distinct().ToArray());
                }
                toolStripComboBoxCategory.SelectedItem = selected;
            }
        }

        private void supplyBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            //RefreshCategories();
            FireCatalogChanged();
        }

        private void dataGridViewCatalog_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == categoryDataGridViewTextBoxColumn.Index)
            {
                RefreshCategories();
            }
        }

        private void supplierCatalogBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            FireCatalogChanged();
        }

        private void toolStripButtonAddHardware_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonRemoveHardware_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            loading = true;
            if (string.IsNullOrEmpty(toolStripComboBoxCategory.Text))
                supplyList = new BindingList<Supply>(catalog.Supplies);
            else
            {
                var regex = new Regex(string.Format(".*{0}.*", toolStripComboBoxCategory.Text));
                supplyList = new BindingList<Supply>(catalog.Supplies.Where((s) => s.Category != null && regex.IsMatch(s.Category)).ToList());
            }
            supplyBindingSource.DataSource = supplyList;
            loading = false;
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var page1 = new NewHardwarePage();
            var setting1 = new WizardSetting(page1, "Nouveau Matériel", "Création d'un nouveau matériel", true);
            
            var page2 = new AddCatalogItemPage();
            var c = new Catalog();
            c.SupplierCatalogs.Add(this.catalog);
            page2.Catalog = c;
            var setting2 = new WizardSetting(page2, "Ajout d'un composant", "Ajouter un composant au matériel", true);

            if (new WizardForm().ShowDialog(new WizardSetting[]{setting1, setting2})== System.Windows.Forms.DialogResult.OK)
            {
                Hardware hardware = new Hardware();
                hardware.Name = page1.HardwareName;
                hardware.Components = new BindingList<HardwareSupply>();
                foreach (var item in page2.SelectedItems)
                {
                    HardwareSupply supply = new HardwareSupply();
                    supply.Supply = item as Supply;
                    hardware.Components.Add(supply);
                }

                hardwareList.Add(hardware);
                hardwareBindingSource.ResetBindings(false);
                supplyBindingSourceHardware.ResetBindings(false);
            }
        }

        private void hardwareBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Hardware current = hardwareBindingSource.Current as Hardware;
            if (current != null)
                this.supplyBindingSourceHardware.DataSource = current.Components;
        }

        private void toolStripButtonHardwareAdd_Click(object sender, EventArgs e)
        {
            var page = new AddCatalogItemPage();
            var c = new Catalog();
            c.SupplierCatalogs.Add(this.catalog);
            page.Catalog = c;
            var setting = new WizardSetting(page, "Ajout d'un composant", "Ajouter un composant au matériel", true);
            if (new WizardForm().ShowDialog(setting) == System.Windows.Forms.DialogResult.OK)
            {
                Hardware current = hardwareBindingSource.Current as Hardware;
                if (current != null)
                {
                    foreach (var item in page.SelectedItems)
                    {
                        HardwareSupply supply = new HardwareSupply();
                        supply.Supply = item as Supply;
                        current.Components.Add(supply);
                    }
                    this.supplyBindingSourceHardware.ResetBindings(false);
                }                
            }
        }

        private void hardwareBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            FireCatalogChanged();
        }

        private void supplyBindingSourceHardware_CurrentItemChanged(object sender, EventArgs e)
        {
            hardwareBindingSource.ResetBindings(false);
            FireCatalogChanged();
        }

        private void supplyBindingSourceHardware_ListChanged(object sender, ListChangedEventArgs e)
        {
            hardwareBindingSource.ResetBindings(false);
        }

        private void hardwareBindingSource_PositionChanged(object sender, EventArgs e)
        {
            Hardware current = hardwareBindingSource.Current as Hardware;
            if (current != null)
                this.supplyBindingSourceHardware.DataSource = current.Components;
        }
    }
}