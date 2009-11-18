using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Chiffrage.Core;

namespace Chiffrage
{
    public partial class CatalogUserControl : UserControl
    {
        private BindingList<Supply> bindingList;
        private SupplierCatalog catalog;

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
                bindingList = null;
            else
                bindingList = new BindingList<Supply>(catalog.Supplies);
            supplyBindingSource.DataSource = bindingList;

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
            loading = true;
            if (string.IsNullOrEmpty(comboBoxCategory.Text))
                bindingList = new BindingList<Supply>(catalog.Supplies);
            else
            {
                var regex = new Regex(string.Format(".*{0}.*", comboBoxCategory.Text));
                bindingList = new BindingList<Supply>(catalog.Supplies.Where((s) => s.Category != null && regex.IsMatch(s.Category)).ToList());
            }
            supplyBindingSource.DataSource = bindingList;
            loading = false;
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
                if (comboBoxCategory.SelectedValue == null && comboBoxCategory.Items.Count > 1)
                    comboBoxCategory.SelectedValue = comboBoxCategory.Items[0];
                object selected = comboBoxCategory.SelectedValue;
                comboBoxCategory.Items.Clear();
                comboBoxCategory.Items.Add(string.Empty);
                if (catalog != null)
                {
                    comboBoxCategory.Items.AddRange(
                        catalog.Supplies.Where((s) => s.Category != null).Select((s) => s.Category).Distinct().ToArray());
                }
                comboBoxCategory.SelectedValue = selected;
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
    }
}