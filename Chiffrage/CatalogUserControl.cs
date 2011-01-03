using System;
using System.ComponentModel;
using System.Windows.Forms;
using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Mvc.Views;
using Chiffrage.WizardPages;

namespace Chiffrage
{
    public partial class CatalogUserControl : UserControlView, ICatalogView
    {
        private CatalogViewModel catalog;
        private int id;

        private bool loading = false;

        public CatalogUserControl()
        {
            this.InitializeComponent();
        }

        public Catalog GlobalCatalog { get; set; }

        public CatalogViewModel Catalog
        {
            get { return this.catalog; }
            set
            {
                this.catalog = value;
                this.RefreshCatalog();
            }
        }

        #region ICatalogView Members

        public void Display(CatalogViewModel viewModel)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<CatalogViewModel>(this.Display), viewModel);
                return;
            }

            this.textBoxCatalogName.Text = viewModel.SupplierName;
            this.id = viewModel.Id;
            if (!(viewModel.Comment.StartsWith("{\\rtf") && viewModel.Comment.EndsWith("}")))
                viewModel.Comment = "{\\rtf" + viewModel.Comment + "}";
            this.commentUserControl.Rtf = viewModel.Comment;
        }

        #endregion

        public event EventHandler CatalogChanged;

        private void RefreshCatalog()
        {
            this.loading = true;

            /*if (catalog != null)
            {
                if (catalog.Comment == null)
                    catalog.Comment = string.Empty;
                if (!(catalog.Comment.StartsWith("{\\rtf") && catalog.Comment.EndsWith("}")))
                    catalog.Comment = "{\\rtf" + catalog.Comment + "}";

                catalogBindingSource.DataSource = catalog;        
            }*/
            this.loading = false;
            this.RefreshCategories();
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

        private void FireCatalogChanged()
        {
            if (!this.loading && this.CatalogChanged != null)
                this.CatalogChanged(this, new EventArgs());
        }

        private void RefreshCategories()
        {
            if (!this.loading)
            {
                if (this.toolStripComboBoxCategory.SelectedItem == null &&
                    this.toolStripComboBoxCategory.Items.Count > 1)
                    this.toolStripComboBoxCategory.SelectedItem = this.toolStripComboBoxCategory.Items[0];
                object selected = this.toolStripComboBoxCategory.SelectedItem;
                this.toolStripComboBoxCategory.Items.Clear();
                this.toolStripComboBoxCategory.Items.Add(string.Empty);
                /*if (catalog != null)
                {
                     toolStripComboBoxCategory.Items.AddRange(
                        catalog.Supplies.Where((s) => s.Category != null).Select((s) => s.Category).Distinct().ToArray());
                }*/
                this.toolStripComboBoxCategory.SelectedItem = selected;
            }
        }

        private void dataGridViewCatalog_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.categoryDataGridViewTextBoxColumn.Index)
            {
                this.RefreshCategories();
            }
        }

        private void item_CurrentItemChanged(object sender, EventArgs e)
        {
            this.FireCatalogChanged();
        }

        private void toolStripButtonAddHardware_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButtonRemoveHardware_Click(object sender, EventArgs e)
        {
        }

        private void toolStripComboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.loading = true;
            /*if (string.IsNullOrEmpty(toolStripComboBoxCategory.Text))
                supplyBindingSource.DataSource = catalog.Supplies;
            else
            {
                var regex = new Regex(string.Format(".*{0}.*", toolStripComboBoxCategory.Text));
                supplyBindingSource.DataSource = new BindingList<CatalogSupplyViewModel>(catalog.Supplies.Where((s) => s.Category != null && regex.IsMatch(s.Category)).ToList());
            }*/
            this.loading = false;
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var page1 = new NewHardwarePage();
            var setting1 = new WizardSetting(page1, "Nouveau Matériel", "Création d'un nouveau matériel", true);

            var page2 = new AddCatalogItemPage();
            page2.Catalog = this.GlobalCatalog;
            var setting2 = new WizardSetting(page2, "Ajout d'un composant", "Ajouter un composant au matériel", true);

            if (new WizardForm().ShowDialog(new WizardSetting[] {setting1, setting2}) == DialogResult.OK)
            {
                var hardware = new Hardware();
                hardware.Name = page1.HardwareName;
                hardware.Components = new BindingList<HardwareSupply>();
                foreach (var item in page2.SelectedItems)
                {
                    var supply = new HardwareSupply();
                    supply.Supply = item as Supply;
                    hardware.Components.Add(supply);
                }

                // TODO : catalog.Hardwares.Add(CatalogHardwareViewModel.CreateFrom(hardware));
                this.hardwaresBindingSource.ResetBindings(false);
                this.componentsBindingSource.ResetBindings(false);
            }
        }

        private void toolStripButtonHardwareAdd_Click(object sender, EventArgs e)
        {
            var page = new AddCatalogItemPage();
            page.Catalog = this.GlobalCatalog;
            page.DisplayItemType = AddCatalogItemPage.ItemType.Supply;
            var setting = new WizardSetting(page, "Ajout d'un composant", "Ajouter un composant au matériel", true);
            if (new WizardForm().ShowDialog(setting) == DialogResult.OK)
            {
                var current = this.hardwaresBindingSource.Current as CatalogHardwareViewModel;
                if (current != null)
                {
                    foreach (var item in page.SelectedItems)
                    {
                        var supply = new HardwareSupply();
                        supply.Supply = item as Supply;
                        current.Components.Add(CatalogHardwareSupplyViewModel.CreateFrom(supply));
                    }

                    var tmp = new Hardware();
                    /* TODO: current.CopyTo(tmp);
                    current.CopyFrom(tmp);*/

                    this.componentsBindingSource.ResetBindings(false);
                }
            }
        }

        private void toolStripButtonHardwareRemove_Click(object sender, EventArgs e)
        {
            this.componentsBindingSource.RemoveCurrent();
        }
    }
}