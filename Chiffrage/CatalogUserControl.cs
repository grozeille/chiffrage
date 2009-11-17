using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Core;
using System.Text.RegularExpressions;

namespace Chiffrage
{
    public partial class CatalogUserControl : UserControl
    {
        private SupplierCatalog catalog;

        private BindingList<Supply> bindingList;

        public event EventHandler CatalogChanged;

        public CatalogUserControl()
        {
            InitializeComponent();
        }

        private bool loading = false;

        public SupplierCatalog Catalog
        {
            get {
                return catalog;
            }
            set {
                catalog = value;
                RefreshCatalog();
            }
        }

        private void RefreshCatalog()
        {
            loading = true;
            if (catalog == null)
                this.bindingList = null;
            else
                bindingList = new BindingList<Supply>(catalog.Supplies);
            this.supplyBindingSource.DataSource = bindingList;
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
            if(string.IsNullOrEmpty(this.comboBoxCategory.Text))
                bindingList = new BindingList<Supply>(catalog.Supplies);
            else
            {            
                Regex regex = new Regex(string.Format(".*{0}.*", this.comboBoxCategory.Text));
                bindingList = new BindingList<Supply>(catalog.Supplies.Where((s) => regex.IsMatch(s.Category)).ToList());
            }
            this.supplyBindingSource.DataSource = bindingList;
            loading = false;
        }

        private void supplyBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            FireCatalogChanged();
        }

        private void FireCatalogChanged()
        {
            if(!loading && CatalogChanged != null)
                CatalogChanged(this, new EventArgs());
        }

        private void RefreshCategories()
        {
            if (!loading)
            {
                if (this.comboBoxCategory.SelectedValue == null && this.comboBoxCategory.Items.Count > 1)
                    this.comboBoxCategory.SelectedValue = this.comboBoxCategory.Items[0];
                var selected = this.comboBoxCategory.SelectedValue;
                this.comboBoxCategory.Items.Clear();
                this.comboBoxCategory.Items.Add(string.Empty);
                if (catalog != null)
                {
                    this.comboBoxCategory.Items.AddRange(catalog.Supplies.Where((s) => s.Category != null).Select((s) => s.Category).Distinct().ToArray());
                }
                this.comboBoxCategory.SelectedValue = selected;
            }
        }

        private void supplyBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            //RefreshCategories();
            FireCatalogChanged();
        }

        private void dataGridViewCatalog_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if(e.ColumnIndex == dataGridViewCatalog.columnHeader)
        }
    }
}
