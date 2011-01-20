using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using Chiffrage.App.Events;
using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Mvc.Views;
using Chiffrage.WizardPages;
using Chiffrage.Mvc.Events;

namespace Chiffrage
{
    public partial class CatalogUserControl : UserControlView, ICatalogView
    {
        private readonly IEventBroker eventBroker;

        private int? catalogId;

        private BindingList<CatalogSupplyViewModel> supplies = new BindingList<CatalogSupplyViewModel>();

        public CatalogUserControl(IEventBroker eventBroker):this()
        {
            this.eventBroker = eventBroker;

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonAddSupply, () => 
                this.catalogId.HasValue ? new RequestAddSupplyToCatalogEvent(this.catalogId.Value) : null);
        }

        public CatalogUserControl()
        {
            this.InitializeComponent();

            this.suppliesBindingSource.DataSource = supplies;
        }

        public Catalog GlobalCatalog { get; set; }

        #region ICatalogView Members

        public void Display(CatalogViewModel viewModel)
        {
            this.InvokeIfRequired(() =>
            {
                this.textBoxCatalogName.Text = viewModel.SupplierName;
                this.catalogId = viewModel.Id;
                if (viewModel.Comment == null || !(viewModel.Comment.StartsWith("{\\rtf") && viewModel.Comment.EndsWith("}")))
                    viewModel.Comment = "{\\rtf" + viewModel.Comment + "}";
                this.commentUserControl.Rtf = viewModel.Comment;
            });
        }

        public CatalogViewModel GetViewModel()
        {
            return this.InvokeIfRequired(() =>
            {
                if (!this.catalogId.HasValue)
                {
                    return null;
                }

                var viewModel = new CatalogViewModel();

                viewModel.SupplierName = this.textBoxCatalogName.Text;
                viewModel.Id = this.catalogId.Value;                
                viewModel.Comment = this.commentUserControl.Rtf;

                return viewModel;
            });
        }

        public void AddSupply(CatalogSupplyViewModel result)
        {
            this.InvokeIfRequired(() =>
            {
                this.supplies.Add(result);
            });
        }

        #endregion

        public event EventHandler CatalogChanged;

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var page1 = new NewHardwarePage();
            var setting1 = new WizardSetting(page1, "Nouveau Matériel", "Création d'un nouveau matériel", true);

            var page2 = new AddCatalogItemPage();
            //page2.Catalog = this.GlobalCatalog;
            var setting2 = new WizardSetting(page2, "Ajout d'un composant", "Ajouter un composant au matériel", true);

            var wizard = new WizardForm
            {
                WizardSettings = new[] {setting1, setting2}
            };
            if (wizard.ShowDialog() == DialogResult.OK)
            {
                var hardware = new Hardware();
                hardware.Name = page1.HardwareName;
                hardware.Components = new BindingList<HardwareSupply>();
                /*foreach (var item in page2.SelectedItems)
                {
                    var supply = new HardwareSupply();
                    supply.Supply = item as Supply;
                    hardware.Components.Add(supply);
                }*/

                // TODO : catalog.Hardwares.Add(CatalogHardwareViewModel.CreateFrom(hardware));
                this.hardwaresBindingSource.ResetBindings(false);
            }
        }

        private void toolStripButtonHardwareAdd_Click(object sender, EventArgs e)
        {
            var page = new AddCatalogItemPage();
            //page.Catalog = this.GlobalCatalog;
            //page.DisplayItemType = AddCatalogItemPage.ItemType.Supply;
            var setting = new WizardSetting(page, "Ajout d'un composant", "Ajouter un composant au matériel", true);

            var wizard = new WizardForm
            {
                WizardSettings = new[] {setting}
            };

            if (wizard.ShowDialog() == DialogResult.OK)
            {
                //var current = this.hardwaresBindingSource.Current as CatalogHardwareViewModel;
                //if (current != null)
                //{
                //    foreach (var item in page.SelectedItems)
                //    {
                //        var supply = new HardwareSupply();
                //        supply.Supply = item as Supply;
                //        current.Components.Add(CatalogHardwareSupplyViewModel.CreateFrom(supply));
                //    }

                //    var tmp = new Hardware();
                //    /* TODO: current.CopyTo(tmp);
                //    current.CopyFrom(tmp);*/

                //    this.componentsBindingSource.ResetBindings(false);
                //}
            }
        }

        private void toolStripButtonHardwareRemove_Click(object sender, EventArgs e)
        {
        }

        public override void HideView()
        {
            this.catalogId = null;
            base.HideView();
        }

        private void suppliesBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            if(e.ListChangedType == ListChangedType.ItemChanged)
            {

            }
            else if(e.ListChangedType == ListChangedType.ItemDeleted)
            {
                
            }
        }

        private void hardwaresBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {

        }

        private void componentsBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {

        }
    }
}