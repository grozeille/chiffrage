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
        private IList<CatalogHardwareViewModel> hardwares;

        public CatalogHardwareViewModel CatalogHardwareViewModel
        {
            get
            {
                return this.catalogHardwareViewModelBindingSource.Current as CatalogHardwareViewModel;
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

            var selected = this.catalogHardwareViewModelBindingSource.Current as CatalogHardwareViewModel;

            if (selected == null)
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.labelInvisible, "Obligatoire");
            }
        }

        private void timerFilter_Tick(object sender, EventArgs e)
        {
            var searchRegex = new Regex(string.Format(".*{0}.*", Regex.Escape(this.textBoxSearch.Text)), RegexOptions.IgnoreCase);
            this.catalogHardwareViewModelBindingSource.DataSource = this.hardwares.Where(x =>
                {
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
    }
}