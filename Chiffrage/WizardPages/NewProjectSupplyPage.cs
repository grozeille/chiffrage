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
    public partial class NewProjectSupplyPage : UserControl
    {
        private IList<CatalogSupplyViewModel> supplies;

        public CatalogSupplyViewModel CatalogSupplyViewModel
        {
            get
            {
                return this.catalogSupplyViewModelBindingSource.Current as CatalogSupplyViewModel;
            }
        }

        public IList<CatalogSupplyViewModel> Supplies
        { 
            set { this.supplies = value; }
        }

        public NewProjectSupplyPage()
        {
            this.InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.catalogSupplyViewModelBindingSource.DataSource = this.supplies;
            this.catalogSupplyViewModelBindingSource.ResetBindings(false);
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);

            int temp;
            
            var selected = this.catalogSupplyViewModelBindingSource.Current as CatalogSupplyViewModel;

            if (selected == null)
            {
                e.Cancel = true;
                this.errorProvider.SetError(this.labelSupply, "Obligatoire");
            }
        }

        private void timerFilter_Tick(object sender, EventArgs e)
        {
            var searchRegex = new Regex(string.Format(".*{0}.*", this.textBoxSearch.Text), RegexOptions.IgnoreCase);
            this.catalogSupplyViewModelBindingSource.DataSource = this.supplies.Where(x => searchRegex.IsMatch(x.Name) || searchRegex.IsMatch(x.Reference)).ToList();
            this.catalogSupplyViewModelBindingSource.ResetBindings(false);
            this.timerFilter.Enabled = false;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            this.timerFilter.Enabled = false;
            this.timerFilter.Enabled = true;
        }
    }
}