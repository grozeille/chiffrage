using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AutoMapper;
using Chiffrage.App.ViewModel;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Core;
using Chiffrage.Mvc.Views;
using Chiffrage.WizardPages;
using Chiffrage.ViewModel;
using Chiffrage.App.Views;

namespace Chiffrage
{
    public partial class CatalogUserControl : UserControlView, ICatalogView
    {
        private int id;

        private CatalogViewModel catalog;

        private bool loading = false;

        public CatalogUserControl()
        {
            InitializeComponent();
        }

        public Catalog GlobalCatalog { get; set; }

        public CatalogViewModel Catalog
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

            /*if (catalog != null)
            {
                if (catalog.Comment == null)
                    catalog.Comment = string.Empty;
                if (!(catalog.Comment.StartsWith("{\\rtf") && catalog.Comment.EndsWith("}")))
                    catalog.Comment = "{\\rtf" + catalog.Comment + "}";

                catalogBindingSource.DataSource = catalog;        
            }*/
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
                if (toolStripComboBoxCategory.SelectedItem == null && toolStripComboBoxCategory.Items.Count > 1)
                    toolStripComboBoxCategory.SelectedItem = toolStripComboBoxCategory.Items[0];
                object selected = toolStripComboBoxCategory.SelectedItem;
                toolStripComboBoxCategory.Items.Clear();
                toolStripComboBoxCategory.Items.Add(string.Empty);
                /*if (catalog != null)
                {
                     toolStripComboBoxCategory.Items.AddRange(
                        catalog.Supplies.Where((s) => s.Category != null).Select((s) => s.Category).Distinct().ToArray());
                }*/
                toolStripComboBoxCategory.SelectedItem = selected;
            }
        }

        private void dataGridViewCatalog_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == categoryDataGridViewTextBoxColumn.Index)
            {
                RefreshCategories();
            }
        }

        private void item_CurrentItemChanged(object sender, EventArgs e)
        {
            FireCatalogChanged();
        }

        private void toolStripButtonAddHardware_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonRemoveHardware_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            loading = true;
            /*if (string.IsNullOrEmpty(toolStripComboBoxCategory.Text))
                supplyBindingSource.DataSource = catalog.Supplies;
            else
            {
                var regex = new Regex(string.Format(".*{0}.*", toolStripComboBoxCategory.Text));
                supplyBindingSource.DataSource = new BindingList<CatalogSupplyViewModel>(catalog.Supplies.Where((s) => s.Category != null && regex.IsMatch(s.Category)).ToList());
            }*/
            loading = false;
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var page1 = new NewHardwarePage();
            var setting1 = new WizardSetting(page1, "Nouveau Matériel", "Création d'un nouveau matériel", true);
            
            var page2 = new AddCatalogItemPage();
            page2.Catalog = this.GlobalCatalog;
            var setting2 = new WizardSetting(page2, "Ajout d'un composant", "Ajouter un composant au matériel", true);

            if (new WizardForm().ShowDialog(new WizardSetting[]{setting1, setting2})== System.Windows.Forms.DialogResult.OK)
            {
                Hardware hardware = new Hardware();
                hardware.Name = page1.HardwareName;
                hardware.Components = new BindingList<HardwareSupply>();
                foreach (var item in page2.SelectedItems)
                {
                    HardwareSupply supply = new HardwareSupply();
                    supply.Supply = item as Supply;
                    hardware.Components.Add(supply);
                }

                // TODO : catalog.Hardwares.Add(CatalogHardwareViewModel.CreateFrom(hardware));
                hardwaresBindingSource.ResetBindings(false);
                componentsBindingSource.ResetBindings(false);
            }
        }

        private void toolStripButtonHardwareAdd_Click(object sender, EventArgs e)
        {
            var page = new AddCatalogItemPage();
            page.Catalog = this.GlobalCatalog;
            page.DisplayItemType = AddCatalogItemPage.ItemType.Supply;
            var setting = new WizardSetting(page, "Ajout d'un composant", "Ajouter un composant au matériel", true);
            if (new WizardForm().ShowDialog(setting) == System.Windows.Forms.DialogResult.OK)
            {
                var current = hardwaresBindingSource.Current as CatalogHardwareViewModel;
                if (current != null)
                {
                    foreach (var item in page.SelectedItems)
                    {
                        HardwareSupply supply = new HardwareSupply();
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
            componentsBindingSource.RemoveCurrent();
        }

        #region ICatalogView Members

        public void Display(CatalogViewModel viewModel)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<CatalogViewModel>(this.Display), viewModel);
                return;
            }

            this.textBoxCatalogName.Text = viewModel.SupplierName;
            this.id = viewModel.Id;
            if (!(viewModel.Comment.StartsWith("{\\rtf") && viewModel.Comment.EndsWith("}")))
                viewModel.Comment = "{\\rtf" + viewModel.Comment + "}";
            this.commentUserControl.Rtf = viewModel.Comment;
        }

        #endregion
    }
}