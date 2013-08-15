using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Mvc;
using Chiffrage.Catalogs.Module.ViewModel;

namespace Chiffrage.Projects.Module.Views.Impl.WizardPages
{
    public partial class NewProjectSupplyPage : UserControl
    {
        private IList<CatalogSupplySelectionViewModel> supplies;

        private IList<CatalogViewModel> catalogs;

        public IList<CatalogSupplySelectionViewModel> CatalogSupplyViewModel
        {
            get
            {
                return this.supplies.Where(x => x.Selected).ToList();
            }
        }

        public IList<CatalogSupplySelectionViewModel> Supplies
        {
            set 
            {
                this.supplies = value;

                var catalogMap = new Dictionary<int, string>();
                foreach (var s in this.supplies)
                {
                    if (!catalogMap.ContainsKey(s.CatalogId))
                    {
                        catalogMap.Add(s.CatalogId, s.CatalogName);
                    }
                }

                catalogs = catalogMap.Select(x => new CatalogViewModel { Id = x.Key, SupplierName = x.Value }).ToList();
                catalogs.Insert(0, new CatalogViewModel { Id = -1, SupplierName = String.Empty });
            }
        }

        public NewProjectSupplyPage()
        {
            this.InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.catalogSupplyViewModelBindingSource.DataSource = new SortableBindingList<CatalogSupplySelectionViewModel>(this.supplies);
            this.catalogSupplyViewModelBindingSource.ResetBindings(false);

            this.catalogViewModelBindingSource.DataSource = new BindingList<CatalogViewModel>(this.catalogs);
            this.catalogViewModelBindingSource.ResetBindings(true);
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);

            var selected = this.CatalogSupplyViewModel;

            if (selected.Count == 0)
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.labelnvisible, "Obligatoire");
            }
        }

        private void timerFilter_Tick(object sender, EventArgs e)
        {
            var searchRegex = new Regex(string.Format(".*{0}.*", Regex.Escape(this.textBoxSearch.Text)), RegexOptions.IgnoreCase);
            var catalogId = (this.catalogViewModelBindingSource.Current as CatalogViewModel).Id;
            this.catalogSupplyViewModelBindingSource.DataSource = this.supplies.Where(x =>
                {
                    if (catalogId != -1 && !x.CatalogId.Equals(catalogId))
                    {
                        return false;
                    }

                    return (x.Name != null && searchRegex.IsMatch(x.Name)) ||
                        (x.Reference != null && searchRegex.IsMatch(x.Reference));
                }).ToList();
            this.catalogSupplyViewModelBindingSource.ResetBindings(false);
            this.timerFilter.Enabled = false;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            this.timerFilter.Enabled = false;
            this.timerFilter.Enabled = true;
        }

        private void comboBoxCatalogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.timerFilter.Enabled = false;
            this.timerFilter.Enabled = true;
        }

        private void dataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView.IsCurrentCellDirty)
            {
                dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}