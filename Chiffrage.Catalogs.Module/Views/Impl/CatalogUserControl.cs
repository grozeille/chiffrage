using System.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
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
using System.Text;

namespace Chiffrage.Catalogs.Module.Views.Impl
{
    public partial class CatalogUserControl : UserControlView, ICatalogView
    {
        private readonly IEventBroker eventBroker;

        private int? catalogId;

        private readonly SortableBindingList<CatalogSupplyViewModel> supplies = new SortableBindingList<CatalogSupplyViewModel>();

        private readonly CatalogHardwareList hardwares = new CatalogHardwareList();

        private IList<DataGridViewTextBoxColumn> taskColumns = new List<DataGridViewTextBoxColumn>();

        private IList<string> categories = new List<string>();

        public CatalogUserControl(IEventBroker eventBroker)
            : this()
        {
            this.eventBroker = eventBroker;

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonAddSupply, () =>
                this.catalogId.HasValue ? new RequestNewSupplyAction(this.catalogId.Value) : null, "topic://UI");

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonRemoveSupply, () =>
                {
                    if (this.catalogId.HasValue)
                    {
                        IDictionary<int, CatalogSupplyViewModel> selected = new Dictionary<int, CatalogSupplyViewModel>();
                        foreach (DataGridViewCell item in this.dataGridViewSupplies.SelectedCells)
                        {
                            var supply = this.dataGridViewSupplies.Rows[item.RowIndex].DataBoundItem as CatalogSupplyViewModel;
                            if (!selected.ContainsKey(supply.Id))
                            {
                                selected.Add(supply.Id, supply);
                            }
                        }

                        if (selected.Count > 0)
                        {
                            int maxItems = 10;
                            StringBuilder builder = new StringBuilder();
                            var selectedList = selected.Values.ToList();
                            for (int cpt = 0; cpt < (Math.Min(selected.Count, maxItems)); cpt++)
                            {
                                builder.Append(" - ").AppendLine(selectedList[cpt].Name);
                            }
                            if (selected.Count > maxItems)
                            {
                                builder.AppendLine("...");
                            }

                            var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer les fournitures: \n" + builder.ToString(), "Supprimer?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            var commands = new List<DeleteSupplyCommand>();
                            if (result == DialogResult.OK)
                            {
                                foreach (var item in selectedList)
                                {
                                    commands.Add(new DeleteSupplyCommand(this.catalogId.Value, item.Id));
                                }
                            }

                            return commands;
                        }
                    }

                    return null;
                }, "topic://commands");

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonAddHardware, () =>
               this.catalogId.HasValue ? new RequestNewHardwareAction(this.catalogId.Value) : null, "topic://UI");

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonRemoveHardware, () =>
            {
                if (this.catalogId.HasValue)
                {
                    IDictionary<int, CatalogHardwareViewModel> selected = new Dictionary<int, CatalogHardwareViewModel>();
                    foreach (DataGridViewCell item in this.dataGridViewHardwares.SelectedCells)
                    {
                        var supply = this.dataGridViewHardwares.Rows[item.RowIndex].DataBoundItem as CatalogHardwareViewModel;
                        if (!selected.ContainsKey(supply.Id))
                        {
                            selected.Add(supply.Id, supply);
                        }
                    }

                    if (selected.Count > 0)
                    {
                        int maxItems = 10;
                        StringBuilder builder = new StringBuilder();
                        var selectedList = selected.Values.ToList();
                        for (int cpt = 0; cpt < (Math.Min(selected.Count, maxItems)); cpt++)
                        {
                            builder.Append(" - ").AppendLine(selectedList[cpt].Name);
                        }
                        if (selected.Count > maxItems)
                        {
                            builder.AppendLine("...");
                        }

                        var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer les matériels: \n" + builder.ToString(), "Supprimer?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        var commands = new List<DeleteHardwareCommand>();
                        if (result == DialogResult.OK)
                        {
                            foreach (var item in selectedList)
                            {
                                commands.Add(new DeleteHardwareCommand(this.catalogId.Value, item.Id));
                            }
                        }

                        return commands;
                    }
                }

                return null;
            }, "topic://commands");

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
                }, "topic://UI");

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonRemoveHardwareSupply, () =>
                {
                    if (this.catalogId.HasValue)
                    {
                        IDictionary<int, CatalogHardwareSupplyViewModel> selected = new Dictionary<int, CatalogHardwareSupplyViewModel>();
                        foreach (DataGridViewCell item in this.dataGridViewHardwareSupplies.SelectedCells)
                        {
                            var supply = this.dataGridViewHardwareSupplies.Rows[item.RowIndex].DataBoundItem as CatalogHardwareSupplyViewModel;
                            if (!selected.ContainsKey(supply.Id))
                            {
                                selected.Add(supply.Id, supply);
                            }
                        }

                        if (selected.Count > 0)
                        {
                            int maxItems = 10;
                            StringBuilder builder = new StringBuilder();
                            var selectedList = selected.Values.ToList();
                            for (int cpt = 0; cpt < (Math.Min(selected.Count, maxItems)); cpt++)
                            {
                                builder.Append(" - ").AppendLine(selectedList[cpt].SupplyName);
                            }
                            if (selected.Count > maxItems)
                            {
                                builder.AppendLine("...");
                            }

                            var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer les composants: \n" + builder.ToString(), "Supprimer?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            var commands = new List<DeleteHardwareSupplyCommand>();
                            if (result == DialogResult.OK)
                            {
                                foreach (var item in selectedList)
                                {
                                    commands.Add(new DeleteHardwareSupplyCommand(this.catalogId.Value, item.HardwareId, item.Id));
                                }
                            }

                            return commands;
                        }
                    }

                    return null;
                }, "topic://commands");

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonImport, () =>
                {
                    if (this.catalogId.HasValue)
                    {
                        return new RequestImportHardwareAction(this.catalogId.Value);
                    }
                    
                    return null;
                }, "topic://UI");
        }

        public CatalogUserControl()
        {
            this.InitializeComponent();

            this.suppliesBindingSource.DataSource = supplies;
            this.hardwaresBindingSource.DataSource = hardwares;
        }

        #region ICatalogView Members

        public void Display(CatalogViewModel viewModel, IList<Task> tasks)
        {
            this.InvokeIfRequired(() =>
            {
                this.textBoxCatalogName.Text = viewModel.SupplierName;
                this.catalogId = viewModel.Id;
                if (viewModel.Comment == null || !(viewModel.Comment.StartsWith("{\\rtf") && viewModel.Comment.EndsWith("}")))
                    viewModel.Comment = "{\\rtf" + viewModel.Comment + "}";
                this.commentUserControl.Rtf = viewModel.Comment;

                foreach (var item in taskColumns)
                {
                    this.dataGridViewHardwares.Columns.Remove(item);
                }


                var orderedTasks = tasks.OrderBy(x => x.OrderId).ToList();

                this.hardwares.CatalogTasks = orderedTasks;
                taskColumns.Clear();
                foreach (var item in orderedTasks)
                {
                    var column = new DataGridViewTextBoxColumn();
                    column.HeaderText = new String(new char[]{ item.Name[0] }).ToUpper()+item.Name.Substring(1);;
                    column.Name = "task_" + item.Id;
                    column.Tag = item.Id;
                    column.ReadOnly = true;
                    column.Visible = true;
                    column.DataPropertyName = "Tasks[" + item.Id + "]";
                    this.dataGridViewHardwares.Columns.Add(column);
                    taskColumns.Add(column);
                }

                this.RefreshCategories();
                this.toolStripTextBoxSupplyFilter.Text = "";
                this.toolStripTextBoxHardwareFilter.Text = "";

                this.ApplyHardwareFilter();
                this.ApplySuppliesFilter();
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
            this.InvokeIfRequired(() =>
            {
                this.hardwares.Add(result);
                this.ApplyHardwareFilter();
            });
        }

        public void AddSupply(CatalogSupplyViewModel result)
        {
            this.InvokeIfRequired(() =>
                                      {
                                          this.supplies.Add(result);
                                          this.ApplySuppliesFilter();
                                          this.RefreshCategories();
                                      });
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
                this.RefreshCategories();
                this.ApplySuppliesFilter();
            });
        }

        public void UpdateHardware(CatalogHardwareViewModel result)
        {
            this.InvokeIfRequired(() =>
            {
                var hardware = this.hardwares.Where(s => s.Id == result.Id).First();
                var index = this.hardwares.IndexOf(hardware);
                this.hardwares[index] = result;
                this.ApplyHardwareFilter();
            });
        }

        public void RemoveSupply(int supplyId)
        {
            this.InvokeIfRequired(() =>
            {
                var supply = this.supplies.Where(x => x.Id == supplyId).First();
                this.supplies.Remove(supply);
                this.RefreshCategories();
                this.ApplySuppliesFilter();
            });
        }

        public void RemoveHardware(int hardwareId)
        {
            this.InvokeIfRequired(() =>
            {
                var hardware = this.hardwares.Where(x => x.Id == hardwareId).First();
                this.hardwares.Remove(hardware);
                this.ApplyHardwareFilter();
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
                this.RefreshCategories();
                this.ApplySuppliesFilter();
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
                this.ApplyHardwareFilter();
            });
        }

        public void RemoveSupplies()
        {
            this.InvokeIfRequired(() =>
            {
                this.supplies.Clear();
                this.RefreshCategories();
                this.ApplySuppliesFilter();
            });
        }

        public void RemoveAllHardwares()
        {
            this.InvokeIfRequired(() =>
            {
                this.hardwares.Clear();
                this.ApplyHardwareFilter();
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

                this.ApplyHardwareFilter();
                this.ApplySuppliesFilter();
            });
        }

        #endregion

        public override void HideView()
        {
            this.catalogId = null;
            base.HideView();
        }

        private void RefreshCategories()
        {
            this.categories = this.supplies.Select(x => x.Category).Where(x => x != null).Distinct().ToList();
            this.categories.Insert(0, "");
            var selected = this.toolStripComboBoxCategories.SelectedItem as String;
            this.toolStripComboBoxCategories.Items.Clear();
            this.toolStripComboBoxCategories.Items.AddRange(this.categories.ToArray());
            if (this.categories.Contains(selected))
            {
                this.toolStripComboBoxCategories.SelectedItem = selected;
            }
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
                this.eventBroker.Publish(new RequestEditSupplyAction(supply), "topic://UI");
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
                this.eventBroker.Publish(new RequestEditHardwareAction(hardware), "topic://UI");
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
                this.eventBroker.Publish(new RequestEditHardwareSupplyAction(hardwareSupply.CatalogId, hardwareSupply.HardwareId, hardwareSupply.Id), "topic://UI");
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

        private void ApplySuppliesFilter()
        {
            var searchRegex = new Regex(string.Format(".*{0}.*", Regex.Escape(this.toolStripTextBoxSupplyFilter.Text)), RegexOptions.IgnoreCase);
            var filtered = this.supplies.Where(x =>
            {
                var selectedCategory =
                    this.toolStripComboBoxCategories.SelectedItem as String;
                if (!string.IsNullOrEmpty(selectedCategory) && (x.Category == null || !x.Category.Equals(selectedCategory)))
                {
                    return false;
                }

                return (x.Name != null && searchRegex.IsMatch(x.Name)) ||
                    (x.Reference != null && searchRegex.IsMatch(x.Reference));
            });
            this.suppliesBindingSource.DataSource = new SortableBindingList<CatalogSupplyViewModel>(filtered, this.supplies);
            this.suppliesBindingSource.ResetBindings(false);
        }

        private void timerSupplyFilter_Tick(object sender, EventArgs e)
        {
            this.ApplySuppliesFilter();
            this.timerSupplyFilter.Enabled = false;
        }

        private void toolStripTextBoxSupplyFilter_TextChanged(object sender, EventArgs e)
        {
            this.timerSupplyFilter.Enabled = false;
            this.timerSupplyFilter.Enabled = true;
        }

        private void toolStripComboBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.timerSupplyFilter.Enabled = false;
            this.timerSupplyFilter.Enabled = true;
        }

        private void ApplyHardwareFilter()
        {
            var searchRegex = new Regex(string.Format(".*{0}.*", Regex.Escape(this.toolStripTextBoxHardwareFilter.Text)), RegexOptions.IgnoreCase);
            var filtered = this.hardwares.Where(x =>
            {
                return (x.Name != null && searchRegex.IsMatch(x.Name)) ||
                    (x.Reference != null && searchRegex.IsMatch(x.Reference));
            });
            this.hardwaresBindingSource.DataSource = new CatalogHardwareList(filtered, this.hardwares);
            this.hardwaresBindingSource.ResetBindings(false);
        }

        private void timerHardwareFilter_Tick(object sender, EventArgs e)
        {
            this.ApplyHardwareFilter();
            this.timerHardwareFilter.Enabled = false;
        }

        private void toolStripTextBoxHardwareFilter_TextChanged(object sender, EventArgs e)
        {
            this.timerHardwareFilter.Enabled = false;
            this.timerHardwareFilter.Enabled = true;
        }
    }
}