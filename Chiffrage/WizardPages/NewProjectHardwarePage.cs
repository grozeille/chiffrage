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
    public partial class NewProjectHardwarePage : UserControl
    {
        private IList<CatalogHardwareViewModel> hardwares;

        public CatalogHardwareViewModel CatalogHardwareViewModel
        {
            get
            {
                return this.catalogHardwareViewModelBindingSource.Current as CatalogHardwareViewModel;
            }
        }

        public int Quantity
        {
            get
            {
                return int.Parse(this.textBoxQuantity.Text);
            }
        }

        public IList<CatalogHardwareViewModel> Hardwares
        {
            set { this.hardwares = value; }
        }

        public NewProjectHardwarePage()
        {
            this.InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.catalogHardwareViewModelBindingSource.DataSource = new SortableBindingList<CatalogHardwareViewModel>(this.hardwares);
            this.catalogHardwareViewModelBindingSource.ResetBindings(false);
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);

            int temp;

            if (!int.TryParse(this.textBoxQuantity.Text, out temp))
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.textBoxQuantity, "Doit être un nombre");
            }

            var selected = this.catalogHardwareViewModelBindingSource.Current as CatalogHardwareViewModel;

            if (selected == null)
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.labelSupply, "Obligatoire");
            }
        }

        private void timerFilter_Tick(object sender, EventArgs e)
        {
            var searchRegex = new Regex(string.Format(".*{0}.*", this.textBoxSearch.Text), RegexOptions.IgnoreCase);
            this.catalogHardwareViewModelBindingSource.DataSource = this.hardwares.Where(x => searchRegex.IsMatch(x.Name) || searchRegex.IsMatch(x.Reference)).ToList();
            this.catalogHardwareViewModelBindingSource.ResetBindings(false);
            this.timerFilter.Enabled = false;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            this.timerFilter.Enabled = false;
            this.timerFilter.Enabled = true;
        }

        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /*var col = dataGridView.Columns[e.ColumnIndex];
            if (this.dataGridView.SortedColumn == col)
            {
                if (this.dataGridView.SortOrder == SortOrder.Ascending)
                {
                    this.dataGridView.Sort(col, ListSortDirection.Descending);
                }
                else
                {
                    this.dataGridView.Sort(col, ListSortDirection.Ascending);
                }
            }
            else
            {
                this.dataGridView.Sort(col, ListSortDirection.Ascending);
            }*/
        }
    }
}