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
    public partial class NewProjectHardwarePage : UserControl
    {
        private IList<CatalogHardwareSelectionViewModel> hardwares;

        private IList<CatalogViewModel> catalogs;

        public IList<CatalogHardwareSelectionViewModel> CatalogHardwareViewModel
        {
            get
            {
                return this.hardwares.Where(x => x.Selected).ToList();
            }
        }

        public IList<CatalogHardwareSelectionViewModel> Hardwares
        {
            set 
            { 
                this.hardwares = value;

                var catalogMap = new Dictionary<int, string>();
                foreach (var h in this.hardwares)
                {
                    if (!catalogMap.ContainsKey(h.CatalogId))
                    {
                        catalogMap.Add(h.CatalogId, h.CatalogName);
                    }
                }

                catalogs = catalogMap.Select(x => new CatalogViewModel { Id = x.Key, SupplierName = x.Value }).ToList();
                catalogs.Insert(0, new CatalogViewModel { Id = -1, SupplierName = String.Empty });
            }
        }

        public NewProjectHardwarePage()
        {
            this.InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.catalogHardwareViewModelBindingSource.DataSource = new SortableBindingList<CatalogHardwareSelectionViewModel>(this.hardwares);
            this.catalogHardwareViewModelBindingSource.ResetBindings(false);

            this.catalogViewModelBindingSource.DataSource = new BindingList<CatalogViewModel>(this.catalogs);
            this.catalogViewModelBindingSource.ResetBindings(true);
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);

            var selected = this.CatalogHardwareViewModel;

            if (selected.Count == 0)
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.labelInvisible, "Obligatoire");
            }
        }

        private void timerFilter_Tick(object sender, EventArgs e)
        {
            var searchRegex = new Regex(string.Format(".*{0}.*", Regex.Escape(this.textBoxSearch.Text)), RegexOptions.IgnoreCase);
            var catalogId = (this.catalogViewModelBindingSource.Current as CatalogViewModel).Id;
            this.catalogHardwareViewModelBindingSource.DataSource = this.hardwares.Where(x =>
                {
                    if (catalogId != -1 && !x.CatalogId.Equals(catalogId))
                    {
                        return false;
                    }

                    return (x.Name != null && searchRegex.IsMatch(x.Name)) ||
                        (x.Reference != null && searchRegex.IsMatch(x.Reference));
                }).ToList();
            this.catalogHardwareViewModelBindingSource.ResetBindings(false);
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
    }
}