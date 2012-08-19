using System.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using Chiffrage.Catalogs.Module.ViewModel;
using Chiffrage.Catalogs.Module.Views;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Mvc.Views;
using Chiffrage.Catalogs.Module.Views.Impl.WizardPages;
using Chiffrage.Mvc.Events;
using Chiffrage.Catalogs.Domain.Commands;
using System.Collections.Generic;
using Chiffrage.Mvc;
using Chiffrage.Catalogs.Module.Actions;

namespace Chiffrage.Catalogs.Module.Views.Impl
{
    public partial class CatalogUserControl : UserControlView, ICatalogView
    {
        private readonly IEventBroker eventBroker;

        private int? catalogId;

        private readonly SortableBindingList<CatalogSupplyViewModel> supplies = new SortableBindingList<CatalogSupplyViewModel>();

        private readonly SortableBindingList<CatalogHardwareViewModel> hardwares = new SortableBindingList<CatalogHardwareViewModel>();

        public CatalogUserControl(IEventBroker eventBroker)
            : this()
        {
            this.eventBroker = eventBroker;

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonAddSupply, () =>
                this.catalogId.HasValue ? new RequestNewSupplyAction(this.catalogId.Value) : null);

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
                                return new DeleteSupplyCommand(this.catalogId.Value, supply.Id);
                            }
                        }
                    }

                    return null;
                });

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonAddHardware, () =>
               this.catalogId.HasValue ? new RequestNewHardwareAction(this.catalogId.Value) : null);

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
                            return new DeleteHardwareCommand(this.catalogId.Value, hardware.Id);
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
                            return new RequestNewHardwareSupplyAction(this.catalogId.Value, hardware.Id);
                        }
                    }

                    return null;
                });

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonRemoveHardwareSupply, () =>
                {
                    if (this.catalogId.HasValue)
                    {
                        var hardwareSupply = this.componentsBindingSource.Current as CatalogHardwareSupplyViewModel;
                        if (hardwareSupply != null)
                        {
                            var hardware = this.hardwaresBindingSource.Current as CatalogHardwareViewModel;
                            var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer le componsant '" + hardwareSupply.SupplyName + "' du matériel '" + hardware.Name+ "' ?", "Supprimer?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (result == DialogResult.OK)
                            {
                                return new DeleteHardwareSupplyCommand(this.catalogId.Value, hardwareSupply.HardwareId, hardwareSupply.Id);
                            }
                        }
                    }

                    return null;
                });

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonImport, () =>
                {
                    if (this.catalogId.HasValue)
                    {
                        return new RequestImportHardwareAction(this.catalogId.Value);
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
                this.commentUserControl.Validate();
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

        public void AddSupplies(IList<CatalogSupplyViewModel> result)
        {
            this.InvokeIfRequired(() =>
            {
                foreach (var item in result)
                {
                    this.supplies.Add(item);
                }
            });
        }

        public void AddHardwares(IList<CatalogHardwareViewModel> result)
        {
            this.InvokeIfRequired(() => 
            {
                foreach(var item in result)
                {
                    this.hardwares.Add(item);
                }
            });
        }

        public void RemoveSupplies()
        {
            this.InvokeIfRequired(() =>
            {
                this.supplies.Clear();
            });
        }

        public void RemoveAllHardwares()
        {
            this.InvokeIfRequired(() =>
            {
                this.hardwares.Clear();
            });
        }


        public void UpdateHardwares(IList<CatalogHardwareViewModel> result)
        {
            this.InvokeIfRequired(() =>
            {
                foreach (var item in result)
                {
                    var hardware = this.hardwares.Where(s => s.Id == item.Id).First();
                    var index = this.hardwares.IndexOf(hardware);
                    this.hardwares[index] = item;
                }
            });
        }

        #endregion

        public override void HideView()
        {
            this.catalogId = null;
            base.HideView();
        }

        private void dataGridViewSupplies_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            var supply = this.suppliesBindingSource[e.RowIndex] as CatalogSupplyViewModel;
            if (supply != null)
            {
                this.eventBroker.Publish(new RequestEditSupplyAction(supply));
            }
        }

        private void dataGridViewHardwares_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            var hardware = this.hardwaresBindingSource[e.RowIndex] as CatalogHardwareViewModel;
            if (hardware != null)
            {
                this.eventBroker.Publish(new RequestEditHardwareAction(hardware));
            }
        }

        private void dataGridViewHardwareSupplies_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            var hardwareSupply = this.componentsBindingSource[e.RowIndex] as CatalogHardwareSupplyViewModel;
            if (hardwareSupply != null)
            {
                this.eventBroker.Publish(new RequestEditHardwareSupplyAction(hardwareSupply.CatalogId, hardwareSupply.HardwareId, hardwareSupply.Id));
            }
        }

        private void columnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /*DataGridView grid = (DataGridView)sender;
            var col = grid.Columns[e.ColumnIndex];
            if (grid.SortedColumn == col)
            {
                if (grid.SortOrder == SortOrder.Ascending)
                {
                    grid.Sort(col, ListSortDirection.Descending);
                }
                else
                {
                    grid.Sort(col, ListSortDirection.Ascending);
                }
            }
            else
            {
                grid.Sort(col, ListSortDirection.Ascending);
            }*/
        }

        private void CatalogUserControl_Load(object sender, EventArgs e)
        {
            this.tabControl.SetDoubleBuffered();

            this.toolStripHardware.SetDoubleBuffered();
            this.toolStripHardwareSupplies.SetDoubleBuffered();
            this.toolStripSupplies.SetDoubleBuffered();

            this.dataGridViewSupplies.SetDoubleBuffered();
            this.dataGridViewHardwares.SetDoubleBuffered();
            this.dataGridViewHardwareSupplies.SetDoubleBuffered();
        }
    }
}