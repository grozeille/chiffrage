using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Chiffrage.App.ViewModel;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Core;

namespace Chiffrage.WizardPages
{
    public partial class AddCatalogItemPage : UserControl
    {
        #region ItemType enum

        public enum ItemType
        {
            All,
            Hardware,
            Supply
        }

        #endregion

        private BindingList<ICatalogItemSelectionViewModel> filteredselectionDtos;
        private bool refreshCheckbox = false;
        private BindingList<ICatalogItemSelectionViewModel> selectionDtos;

        public AddCatalogItemPage()
        {
            this.InitializeComponent();
        }

        public Catalog Catalog { get; set; }

        public ItemType DisplayItemType { get; set; }

        public IList<ICatalogItem> SelectedItems
        {
            get
            {
                if (this.filteredselectionDtos == null)
                    return new List<ICatalogItem>();
                return this.filteredselectionDtos
                    .Where((dto) => dto.Selected)
                    .Select((dto) => dto.CatalogItem).ToList();
            }
        }

        private void LoadCatalog()
        {
            this.iCatalogItemSelectionDtoBindingSource.SuspendBinding();
            this.selectionDtos = new BindingList<ICatalogItemSelectionViewModel>();
            foreach (SupplierCatalog supplier in this.Catalog.SupplierCatalogs)
            {
                if (this.DisplayItemType == ItemType.All || this.DisplayItemType == ItemType.Supply)
                {
                    foreach (Supply supply in supplier.Supplies)
                    {
                        var dto = new CatalogSupplySelectionViewModel()
                        {
                            Supplier = supplier.SupplierName,
                            Item = supply
                        };
                        this.selectionDtos.Add(dto);
                        dto.PropertyChanged += new PropertyChangedEventHandler(this.dto_PropertyChanged);
                    }
                }
                if (this.DisplayItemType == ItemType.All || this.DisplayItemType == ItemType.Hardware)
                {
                    foreach (Hardware hardware in supplier.Hardwares)
                    {
                        var dto = new CatalogHardwareSelectionViewModel()
                        {
                            Supplier = supplier.SupplierName,
                            Item = hardware
                        };
                        this.selectionDtos.Add(dto);
                        dto.PropertyChanged += new PropertyChangedEventHandler(this.dto_PropertyChanged);
                    }
                }
            }
            this.filteredselectionDtos = this.selectionDtos;
            this.iCatalogItemSelectionDtoBindingSource.DataSource = this.filteredselectionDtos;
            this.iCatalogItemSelectionDtoBindingSource.ResumeBinding();

            this.comboBoxCategory.Items.Clear();
            this.comboBoxCategory.Items.Add(string.Empty);
            var categories = new List<string>();
            if (this.DisplayItemType == ItemType.All || this.DisplayItemType == ItemType.Supply)
            {
                categories.AddRange(this.Catalog.SupplierCatalogs
                                        .SelectMany((s, c) => s.Supplies)
                                        .Select((s) => s.Category)
                                        .Where((c) => !string.IsNullOrEmpty(c)));
            }
            if (this.DisplayItemType == ItemType.All || this.DisplayItemType == ItemType.Hardware)
            {
                categories.AddRange(this.Catalog.SupplierCatalogs
                                        .SelectMany((s, c) => s.Hardwares)
                                        .Select((h) => h.Category)
                                        .Where((c) => !string.IsNullOrEmpty(c)));
            }
            this.comboBoxCategory.Items.AddRange(categories.Distinct().ToArray());
        }

        private void dto_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.refreshCheckbox = true;
            this.checkBoxSelectAll.Checked = this.IsAllSelected();
            this.refreshCheckbox = false;
        }

        private bool IsAllSelected()
        {
            foreach (ICatalogItemSelectionViewModel item in this.filteredselectionDtos)
            {
                if (!item.Selected)
                    return false;
            }
            return true;
        }

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.refreshCheckbox)
            {
                this.iCatalogItemSelectionDtoBindingSource.SuspendBinding();
                foreach (ICatalogItemSelectionViewModel item in this.filteredselectionDtos)
                    item.Selected = this.checkBoxSelectAll.Checked;
                this.iCatalogItemSelectionDtoBindingSource.ResumeBinding();
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (e.RowIndex > -1)
                {
                    DataGridViewCell currentCell = this.dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (currentCell.Selected)
                    {
                        currentCell.Value = !(bool) currentCell.Value;
                        this.dataGridView.EndEdit();
                    }
                }
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            this.DoFilter();
        }

        private void DoFilter()
        {
            this.iCatalogItemSelectionDtoBindingSource.SuspendBinding();

            // reset the filter
            this.filteredselectionDtos = this.selectionDtos;

            // filter by category
            if (!string.IsNullOrEmpty(this.comboBoxCategory.Text))
            {
                this.filteredselectionDtos = new BindingList<ICatalogItemSelectionViewModel>(
                    (from dto in this.filteredselectionDtos
                     where
                         dto.CatalogItem.Category != null && dto.CatalogItem.Category.Equals(this.comboBoxCategory.Text)
                     select dto).ToList());
            }

            // execute filter
            if (!string.IsNullOrEmpty(this.textBoxSearch.Text))
            {
                var searchRegex = new Regex(string.Format(".*{0}.*", this.textBoxSearch.Text), RegexOptions.IgnoreCase);
                this.filteredselectionDtos = new BindingList<ICatalogItemSelectionViewModel>(
                    (from dto in this.filteredselectionDtos
                     where
                         dto.Name != null && dto.Reference != null &&
                         (searchRegex.IsMatch(dto.Name) || searchRegex.IsMatch(dto.Reference))
                     select dto).ToList());
            }
            this.iCatalogItemSelectionDtoBindingSource.DataSource = this.filteredselectionDtos;
            this.iCatalogItemSelectionDtoBindingSource.ResumeBinding();
        }

        private void AddSupplyPage_Load(object sender, EventArgs e)
        {
            this.LoadCatalog();
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DoFilter();
        }
    }
}