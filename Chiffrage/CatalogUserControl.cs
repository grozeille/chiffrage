using System.Linq;
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

        private readonly BindingList<CatalogSupplyViewModel> supplies = new BindingList<CatalogSupplyViewModel>();

        private readonly BindingList<CatalogHardwareViewModel> hardwares = new BindingList<CatalogHardwareViewModel>();

        public CatalogUserControl(IEventBroker eventBroker)
            : this()
        {
            this.eventBroker = eventBroker;

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonAddSupply, () =>
                this.catalogId.HasValue ? new RequestNewSupplyEvent(this.catalogId.Value) : null);

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonRemoveSupply, () =>
                {
                    if (this.catalogId.HasValue)
                    {
                        var supply = this.suppliesBindingSource.Current as CatalogSupplyViewModel;
                        if (supply != null)
                        {
                            var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer le composant '" + supply.Name + "'?", "Supprimer?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (result == DialogResult.OK)
                            {
                                return new RequestDeleteSupplyEvent(this.catalogId.Value, supply.Id);
                            }
                        }
                    }

                    return null;
                });

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonAddHardware, () =>
               this.catalogId.HasValue ? new RequestNewHardwareEvent(this.catalogId.Value) : null);

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonRemoveHardware, () =>
            {
                if (this.catalogId.HasValue)
                {
                    var hardware = this.hardwaresBindingSource.Current as CatalogHardwareViewModel;
                    if (hardware != null)
                    {
                        var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer le matériel '" + hardware.Name + "'?", "Supprimer?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                        {
                            return new RequestDeleteHardwareEvent(this.catalogId.Value, hardware.Id);
                        }
                    }
                }

                return null;
            });

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonAddHardwareSupply, () =>
                {
                    if (this.catalogId.HasValue)
                    {
                        var hardware = this.hardwaresBindingSource.Current as CatalogHardwareViewModel;
                        if (hardware != null)
                        {
                            return new RequestNewHardwareSupplyEvent(this.catalogId.Value, hardware.Id);
                        }
                    }

                    return null;
                });

        }

        public CatalogUserControl()
        {
            this.InitializeComponent();

            this.suppliesBindingSource.DataSource = supplies;
            this.hardwaresBindingSource.DataSource = hardwares;
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

                this.supplies.Clear();
                foreach (var item in viewModel.Supplies)
                {
                    this.supplies.Add(item);
                }

                this.hardwares.Clear();
                foreach (var item in viewModel.Hardwares)
                {
                    this.hardwares.Add(item);
                }
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

        public void AddHardware(CatalogHardwareViewModel result)
        {
            this.InvokeIfRequired(() => this.hardwares.Add(result));
        }

        public void AddSupply(CatalogSupplyViewModel result)
        {
            this.InvokeIfRequired(() => this.supplies.Add(result));
        }

        public void AddHardwareSupply(CatalogHardwareSupplyViewModel result)
        {
            this.InvokeIfRequired(() =>
                {
                    // TODO : if the selected hardware is the correct one, add the item to the grid
                });
        }

        public void UpdateSupply(CatalogSupplyViewModel result)
        {
            this.InvokeIfRequired(() =>
            {
                var supply = this.supplies.Where(s => s.Id == result.Id).First();
                var index = this.supplies.IndexOf(supply);
                this.supplies[index] = result;
            });
        }

        public void UpdateHardware(CatalogHardwareViewModel result)
        {
            this.InvokeIfRequired(() =>
            {
                var hardware = this.hardwares.Where(s => s.Id == result.Id).First();
                var index = this.hardwares.IndexOf(hardware);
                this.hardwares[index] = result;
            });
        }

        public void RemoveSupply(CatalogSupplyViewModel result)
        {
            this.InvokeIfRequired(() =>
            {
                var supply = this.supplies.Where(x => x.Id == result.Id).First();
                this.supplies.Remove(supply);
            });
        }

        public void RemoveHardware(CatalogHardwareViewModel result)
        {
            this.InvokeIfRequired(() =>
            {
                var hardware = this.hardwares.Where(x => x.Id == result.Id).First();
                this.hardwares.Remove(hardware);
            });
        }

        #endregion

        /*
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
                foreach (var item in page2.SelectedItems)
                {
                    var supply = new HardwareSupply();
                    supply.Supply = item as Supply;
                    hardware.Components.Add(supply);
                }

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
                //    // TODO: current.CopyTo(tmp);
                //    current.CopyFrom(tmp);

                //    this.componentsBindingSource.ResetBindings(false);
                //}
            }
        }

        private void toolStripButtonHardwareRemove_Click(object sender, EventArgs e)
        {
        }*/

        public override void HideView()
        {
            this.catalogId = null;
            base.HideView();
        }

        private void dataGridViewSupplies_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var supply = this.suppliesBindingSource[e.RowIndex] as CatalogSupplyViewModel;
            if (supply != null)
            {
                this.eventBroker.Publish(new RequestEditSupplyEvent(supply));
            }
        }

        private void dataGridViewHardwares_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var hardware = this.hardwaresBindingSource[e.RowIndex] as CatalogHardwareViewModel;
            if (hardware != null)
            {
                this.eventBroker.Publish(new RequestEditHardwareEvent(hardware));
            }
        }
    }
}