using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Core;
using Chiffrage.Dto;
using System.Text.RegularExpressions;

namespace Chiffrage.WizardPages
{
    public partial class AddSupplyPage : UserControl
    {
        private BindingList<CatalogSupplySelectionDto> supplySelectionDtos;

        private BindingList<CatalogSupplySelectionDto> filteredSupplySelectionDtos;

        private Catalog catalog;
        public Catalog Catalog
        {
            get { return catalog; }
            set { catalog = value; }
        }

        public IList<Supply> SelectedSupplies
        {
            get
            {
                if (filteredSupplySelectionDtos == null)
                    return new List<Supply>();
                return this.filteredSupplySelectionDtos
                    .Where((dto) => dto.Selected)
                    .Select((dto) => dto.Supply).ToList();
            }
        }

        private bool refreshCheckbox = false;

        private void LoadCatalog()
        {
            catalogSupplySelectionDtoBindingSource.SuspendBinding();
            this.supplySelectionDtos = new BindingList<CatalogSupplySelectionDto>();
            foreach (var supplier in catalog.SupplierCatalogs)
            {
                foreach (var supply in supplier.Supplies)
                {
                    var dto = new CatalogSupplySelectionDto()
                        {
                            Supplier = supplier.SupplierName,
                            Supply = supply
                        };
                    supplySelectionDtos.Add(dto);
                    dto.PropertyChanged += new PropertyChangedEventHandler(dto_PropertyChanged);
                }
            }
            filteredSupplySelectionDtos = this.supplySelectionDtos;
            catalogSupplySelectionDtoBindingSource.DataSource = filteredSupplySelectionDtos;
            catalogSupplySelectionDtoBindingSource.ResumeBinding();
        }

        private void dto_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            refreshCheckbox = true;
            checkBoxSelectAll.Checked = IsAllSelected();
            refreshCheckbox = false;
        }

        public AddSupplyPage()
        {
            InitializeComponent();
        }

        private bool IsAllSelected()
        {
            foreach (var item in supplySelectionDtos)
            {
                if (!item.Selected)
                    return false;
            }
            return true;
        }

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!refreshCheckbox)
            {
                catalogSupplySelectionDtoBindingSource.SuspendBinding();
                foreach (var item in this.supplySelectionDtos)
                    item.Selected = checkBoxSelectAll.Checked;
                catalogSupplySelectionDtoBindingSource.ResumeBinding();
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (e.RowIndex > -1)
                {
                    var currentCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (currentCell.Selected)
                    {
                        currentCell.Value = !(bool) currentCell.Value;
                        dataGridView.EndEdit();
                    }
                }
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

            catalogSupplySelectionDtoBindingSource.SuspendBinding();
            if (string.IsNullOrEmpty(textBoxSearch.Text))
            {
                filteredSupplySelectionDtos = this.supplySelectionDtos;
            }
            else
            {
                Regex searchRegex = new Regex(string.Format(".*{0}.*", textBoxSearch.Text), RegexOptions.IgnoreCase);
                filteredSupplySelectionDtos = new BindingList<CatalogSupplySelectionDto>(
                    (from dto in this.supplySelectionDtos
                     where searchRegex.IsMatch(dto.Name) || searchRegex.IsMatch(dto.Reference)
                     select dto).ToList());
            }
            catalogSupplySelectionDtoBindingSource.DataSource = filteredSupplySelectionDtos;
            catalogSupplySelectionDtoBindingSource.ResumeBinding();
        }

        private void AddSupplyPage_Load(object sender, EventArgs e)
        {
            LoadCatalog();
        }
    }
}
