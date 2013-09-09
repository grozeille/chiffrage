using System.Linq;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Projects.Module.Views;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Mvc.Views;
using Chiffrage.Projects.Domain;
using Chiffrage.Projects.Module.Views.Impl.WizardPages;
using Chiffrage.Mvc.Events;
using System.Collections.Generic;
using Chiffrage.Projects.Domain.Commands;
using Chiffrage.Mvc;
using System.Globalization;
using Chiffrage.Projects.Module.Actions;
using Chiffrage.Projects.Module.Properties;
using System.Windows.Forms.DataVisualization.Charting;
using System.Text.RegularExpressions;
using System.Text;

namespace Chiffrage.Projects.Module.Views.Impl
{
    public partial class ProjectUserControl : UserControlView, IProjectView
    {
        private int? id;

        private readonly SortableBindingList<ProjectSupplyViewModel> supplies = new SortableBindingList<ProjectSupplyViewModel>();

        private readonly ProjectHardwareList hardwares = new ProjectHardwareList();

        private readonly SortableBindingList<ProjectSummaryItemViewModel> summaryItems = new SortableBindingList<ProjectSummaryItemViewModel>();

        private readonly SortableBindingList<ProjectFrameViewModel> frames = new SortableBindingList<ProjectFrameViewModel>();
        
        private IList<DataGridViewTextBoxColumn> taskColumns = new List<DataGridViewTextBoxColumn>();

        private BindingList<OtherBenefit> otherBenefits;

        private IList<string> categories = new List<string>();

        private IList<TextBox> dayRates = new List<TextBox>();
        private IList<TextBox> nightRates = new List<TextBox>();
        private IList<TextBox> longNightRates = new List<TextBox>();
        private IList<TextBox> shortNightRates = new List<TextBox>();

        private Font defaultFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular,
                                            GraphicsUnit.Point, ((byte) (0)));
        
        private readonly IEventBroker eventBroker;

        private readonly string rateRegex = @"(\d+\.?\d*)(?: +€/h)?";

        public ProjectUserControl()
        {
            this.InitializeComponent();

            this.projectSupplyViewModelBindingSource.DataSource = supplies;
            this.projectHardwareViewModelBindingSource.DataSource = hardwares;
            this.projectFrameViewModelBindingSource.DataSource = frames;
            this.projectSummaryItemViewModelBindingSource.DataSource = summaryItems;
            
            this.textBoxProjectName.Validating += this.ValidateIsRequiredTextBox;

            this.chartCostSummary.Series[0]["PieLabelStyle"] = "Outside";
            this.chartCostSummary.Series[0]["PieLineColor"] = "Black";
            //this.chartCostSummary.Series[0].Label = "#VALX (#PERCENT)";
            this.chartCostSummary.Series[0].Label = "#VALX #VALY €";
            //this.chartCostSummary.Series[0].LegendText = "#PERCENT{P0}";
            this.chartCostSummary.Series[0].LegendText = "#VALX (#PERCENT)";

            //this.chartCostSummary.Legends[0].Enabled = true;
            //this.chartCostSummary.Legends[0].Docking = Docking.Bottom;
            //this.chartCostSummary.Legends[0].Alignment = System.Drawing.StringAlignment.Center;
            //this.chartCostSummary.Legends[0].ItemColumnSpacing = 30;
        }

        private void ValidateIsRateTextBox(object sender, CancelEventArgs args)
        {
            args.Cancel = !this.ValidateRegex((TextBox)sender, rateRegex, "Doit être un taux (ou un nombre)");
        }

        private double ParseRate(string stringValue)
        {
            return double.Parse(Regex.Match(stringValue, rateRegex).Groups[1].Value, NumberStyles.Float, CultureInfo.InvariantCulture);
        }

        private string ToRate(double value)
        {
            return value.ToString(@"#.## €/h;#.## €/h;\0 €/h", CultureInfo.InvariantCulture);
        }
        
        public ProjectUserControl(IEventBroker eventBroker)
            :this()
        {
            this.eventBroker = eventBroker;
            this.CausesValidation = true;

            //this.toolStripButtonAdd.Click += OnSelect;
            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonSupplyAdd, AddSupply);
            this.eventBroker.RegisterToolStripMenuItemClickEventSource(this.toolStripMenuItemSupplyAdd, AddSupply);

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonSupplyRemove, RemoveSupply);
            this.eventBroker.RegisterToolStripMenuItemClickEventSource(this.toolStripMenuItemSupplyRemove, RemoveSupply);

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonSupplyReload, ReloadSupply); 
            this.eventBroker.RegisterToolStripMenuItemClickEventSource(this.toolStripMenuItemSupplyReload, ReloadSupply);

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonHardwareAdd, AddHardware);
            this.eventBroker.RegisterToolStripMenuItemClickEventSource(this.toolStripMenuItemHardwareAdd, AddHardware);

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonHardwareRemove, RemoveHardware);
            this.eventBroker.RegisterToolStripMenuItemClickEventSource(this.toolStripMenuItemHardwareRemove, RemoveHardware);

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonHardwareReload, ReloadHardware);
            this.eventBroker.RegisterToolStripMenuItemClickEventSource(this.toolStripMenuItemHardwareReload, ReloadHardware);

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonAddFrame, AddFrame);

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonRemoveFrame,RemoveFrame);

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonRefreshTasks, ReloadTasks);

        }

        private RequestNewProjectSupplyAction AddSupply()
        {
            return this.id.HasValue ? new RequestNewProjectSupplyAction(this.id.Value) : null;
        }

        private RequestNewProjectFrameAction AddFrame()
        {
            return this.id.HasValue ? new RequestNewProjectFrameAction(this.id.Value) : null;
        }

        private RequestNewProjectHardwareAction AddHardware()
        {
            return this.id.HasValue ? new RequestNewProjectHardwareAction(this.id.Value) : null;
        }

        private ReloadProjectSupplyListCommand ReloadSupply()
        {
            if (this.id.HasValue)
            {
                IDictionary<int, ProjectSupplyViewModel> selected = new Dictionary<int, ProjectSupplyViewModel>();
                foreach (DataGridViewCell item in this.dataGridView.SelectedCells)
                {
                    var supply = this.dataGridView.Rows[item.RowIndex].DataBoundItem as ProjectSupplyViewModel;
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

                    var result =
                        MessageBox.Show(
                            "Êtes-vous sûr de vouloir recharger les valeurs du catalogue pour les fournitures: \n" +
                            builder.ToString(), "Recharger?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    
                    if (result == DialogResult.OK)
                    {
                        var commands = new List<ReloadProjectSupplyCommand>();
                        foreach (var item in selectedList)
                        {
                            commands.Add(new ReloadProjectSupplyCommand(this.id.Value, item.Id));
                        }
                        return new ReloadProjectSupplyListCommand(commands);
                    }

                    return null;
                }
            }

            return null;
        }

        private RefreshProjectTasksCommand ReloadTasks()
        {
            if (this.id.HasValue)
            {
                var result =
                    MessageBox.Show("Êtes-vous sûr de vouloir recharger les tâches pour ce projet?les matériels: \n" +
                                    "ATTENTION: les temps des tâches supprimées vont à leur tour être supprimés.",
                                    "Recharger?",
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    return new RefreshProjectTasksCommand(this.id.Value);
                }
            }

            return null;
        }

        private DeleteProjectFrameCommand RemoveFrame()
        {
            if (this.id.HasValue)
            {
                var projectFrame = this.projectFrameViewModelBindingSource.Current as ProjectFrameViewModel;
                if (projectFrame != null)
                {
                    var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce chassis ?", "Supprimer?",
                                                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        return new DeleteProjectFrameCommand(this.id.Value, projectFrame.Id);
                    }
                }
            }

            return null;
        }

        private IList<DeleteProjectHardwareCommand> RemoveHardware()
        {
            if (this.id.HasValue)
            {
                IDictionary<int, ProjectHardwareViewModel> selected = new Dictionary<int, ProjectHardwareViewModel>();
                foreach (DataGridViewCell item in this.dataGridViewHardware.SelectedCells)
                {
                    var hardware = this.dataGridViewHardware.Rows[item.RowIndex].DataBoundItem as ProjectHardwareViewModel;
                    if (!selected.ContainsKey(hardware.Id))
                    {
                        selected.Add(hardware.Id, hardware);
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

                    var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer les matériels: \n" + builder.ToString(),
                                                 "Supprimer?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    var commands = new List<DeleteProjectHardwareCommand>();
                    if (result == DialogResult.OK)
                    {
                        foreach (var item in selectedList)
                        {
                            commands.Add(new DeleteProjectHardwareCommand(this.id.Value, item.Id));
                        }
                    }

                    return commands;
                }
            }

            return null;
        }

        private IList<DeleteProjectSupplyCommand> RemoveSupply()
        {
            if (this.id.HasValue)
            {
                IDictionary<int, ProjectSupplyViewModel> selected = new Dictionary<int, ProjectSupplyViewModel>();
                foreach (DataGridViewCell item in this.dataGridView.SelectedCells)
                {
                    var supply = this.dataGridView.Rows[item.RowIndex].DataBoundItem as ProjectSupplyViewModel;
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

                    var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer les fournitures: \n" + builder.ToString(),
                                                 "Supprimer?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    var commands = new List<DeleteProjectSupplyCommand>();
                    if (result == DialogResult.OK)
                    {
                        foreach (var item in selectedList)
                        {
                            commands.Add(new DeleteProjectSupplyCommand(this.id.Value, item.Id));
                        }
                    }

                    return commands;
                }
            }

            return null;
        }

        private ReloadProjectHardwareListCommand ReloadHardware()
        {
            if (this.id.HasValue)
            {
                IDictionary<int, ProjectHardwareViewModel> selected = new Dictionary<int, ProjectHardwareViewModel>();
                foreach (DataGridViewCell item in this.dataGridViewHardware.SelectedCells)
                {
                    var hardware = this.dataGridViewHardware.Rows[item.RowIndex].DataBoundItem as ProjectHardwareViewModel;
                    if (!selected.ContainsKey(hardware.Id))
                    {
                        selected.Add(hardware.Id, hardware);
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

                    var result = MessageBox.Show("Êtes-vous sûr de vouloir recharger les valeurs du catalogue pour les matériels: \n" + builder.ToString(),
                                                 "Supprimer?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    
                    if (result == DialogResult.OK)
                    {
                        var commands = new List<ReloadProjectHardwareCommand>();
                        foreach (var item in selectedList)
                        {
                            commands.Add(new ReloadProjectHardwareCommand(this.id.Value, item.Id));
                        }
                        return new ReloadProjectHardwareListCommand(commands);
                    }

                    return null;
                }
            }

            return null;
        }

        #region Summary

        private void BuildBigTotalRow(Bitmap icon, string name, double? days, double cost)
        {
            int index = this.dataGridViewSummary.Rows.Add(
                icon,
                name,
                string.Format("{0} h", days),
                null,
                string.Format("{0} €", cost)
                );
            foreach (DataGridViewCell cell in this.dataGridViewSummary.Rows[index].Cells)
            {
                cell.Style.BackColor = SystemColors.ControlDarkDark;
                cell.Style.Font = new Font(this.defaultFont, FontStyle.Bold);
                cell.Style.ForeColor = SystemColors.Window;
                cell.ReadOnly = true;
            }
        }

        private void BuildTotalRow(Bitmap icon, string name, double? days, double cost)
        {
            int index = this.dataGridViewSummary.Rows.Add(
                icon,
                name,
                days.HasValue ? string.Format("{0} h", days) : string.Empty,
                null,
                string.Format("{0} €", cost) 
                );
            foreach (DataGridViewCell cell in this.dataGridViewSummary.Rows[index].Cells)
            {
                cell.Style.BackColor = SystemColors.ControlLight;
                cell.Style.Font = new Font(this.defaultFont, FontStyle.Bold);
                cell.ReadOnly = true;
            }
        }

        private void BuildRow(string name, double days, double rate, double cost)
        {
            int index = this.dataGridViewSummary.Rows.Add(
                Resources.blank,
                name,
                string.Format("{0} h", days),
                string.Format("{0} €/h", rate),
                string.Format("{0} €", cost)
                );
            foreach (DataGridViewCell cell in this.dataGridViewSummary.Rows[index].Cells)
            {
                if (cell.ColumnIndex != 3)
                    cell.ReadOnly = true;
            }
        }
        #endregion

        public void Save()
        {
            this.InvokeIfRequired(() =>
            {
                if (!this.id.HasValue)
                {
                    return;
                }


                this.errorProvider.Clear();
                if (!this.Validate())
                {
                    return;
                }

                this.commentUserControl.Validate();

                var error = false;
                var projectTasks = new List<ProjectTask>();
                foreach (var item in dayRates)
                {
                    var projectTask = item.Tag as ProjectTask;
                    projectTask.DayRate = this.ParseRate(item.Text);
                    projectTasks.Add(projectTask);
                }
                foreach (var item in nightRates)
                {
                    if (item.Enabled)
                    {
                        var projectTask = item.Tag as ProjectTask;
                        projectTask.NightRate = this.ParseRate(item.Text);
                    }
                }
                foreach (var item in longNightRates)
                {
                    if (item.Enabled)
                    {
                        var projectTask = item.Tag as ProjectTask;
                        projectTask.LongNightRate = this.ParseRate(item.Text);
                    }
                }
                foreach (var item in shortNightRates)
                {
                    if (item.Enabled)
                    {
                        var projectTask = item.Tag as ProjectTask;
                        projectTask.ShortNightRate = this.ParseRate(item.Text);
                    }
                }
                if (error)
                {
                    return;
                }

                var command = new UpdateProjectCommand(
                    this.id.Value,
                    this.textBoxProjectName.Text,
                    this.commentUserControl.Rtf,
                    this.textBoxReference.Text,
                    this.dateTimePickerProjectBegin.Value,
                    this.dateTimePickerProjectEnd.Value,
                    projectTasks,
                    otherBenefits);

                this.eventBroker.Publish(command);
            });
        }

        public override void HideView()
        {
            base.HideView();
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var supply = this.projectSupplyViewModelBindingSource[e.RowIndex] as ProjectSupplyViewModel;
            if (supply != null)
            {
                this.eventBroker.Publish(new RequestEditProjectSupplyAction(supply));
            }
        }

        private void dataGridViewHardware_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var hardware = this.projectHardwareViewModelBindingSource[e.RowIndex] as ProjectHardwareViewModel;
            if (hardware != null)
            {
                this.eventBroker.Publish(new RequestEditProjectHardwareAction(hardware));
            }
        }

        public void SetProjectViewModel(ProjectViewModel viewModel)
        {
            this.InvokeIfRequired(() =>
            {
                if (viewModel == null)
                {
                    this.id = null;

                    this.textBoxProjectName.Text = string.Empty;
                    this.textBoxReference.Text = string.Empty;
                    this.dateTimePickerProjectBegin.Value = DateTime.Now;
                    this.dateTimePickerProjectEnd.Value = DateTime.Now;
                    this.textBoxTotalDays.Text = string.Empty;
                    this.textBoxTotalPrice.Text = string.Empty;
                    
                    this.textBoxTotalModules.Text = string.Empty;
                    this.textBoxModulesNotInFrame.Text = string.Empty;

                    this.commentUserControl.Rtf = "{\\rtf}";
                }
                else
                {
                    this.id = viewModel.Id;

                    this.textBoxProjectName.Text = viewModel.Name;
                    this.textBoxReference.Text = viewModel.Reference;
                    this.dateTimePickerProjectBegin.Value = viewModel.StartDate;
                    this.dateTimePickerProjectEnd.Value = viewModel.EndDate;
                    this.dateTimePickerProjectEnd.Value = viewModel.EndDate;

                    this.textBoxTotalDays.Text = string.Format(CultureInfo.InvariantCulture, "{0:0.##} h", viewModel.TotalDays);
                    this.textBoxTotalPrice.Text = string.Format(CultureInfo.InvariantCulture, "{0:0.##} €", viewModel.TotalPrice);
                    
                    this.textBoxTotalModules.Text = viewModel.TotalModules.ToString(CultureInfo.InvariantCulture);
                    this.textBoxModulesNotInFrame.Text = viewModel.ModulesNotInFrame.ToString(CultureInfo.InvariantCulture);
                    this.pictureBoxWarningFrame.Visible = viewModel.ModulesNotInFrame > 0;

                    if (viewModel.Comment == null || !(viewModel.Comment.StartsWith("{\\rtf") && viewModel.Comment.EndsWith("}")))
                        viewModel.Comment = "{\\rtf" + viewModel.Comment + "}";
                    this.commentUserControl.Rtf = viewModel.Comment;

                    this.otherBenefits = new BindingList<OtherBenefit>(viewModel.OtherBenefits);
                    this.otherBenefitBindingSource.DataSource = otherBenefits;
                    this.otherBenefitBindingSource.ResetBindings(false);
                }


                hardwares.ProjectTasks = null;
                if (viewModel != null && viewModel.Tasks != null)
                {
                    var orderedTasks = viewModel.Tasks.OrderBy(x => x.OrderId).ToList();

                    hardwares.ProjectTasks = orderedTasks;

                    foreach (var item in taskColumns)
                    {
                        this.dataGridViewHardware.Columns.Remove(item);
                    }

                    taskColumns.Clear();
                    foreach (var item in orderedTasks)
                    {
                        var column = new DataGridViewTextBoxColumn();
                        column.HeaderText = new String(new char[] { item.Name[0] }).ToUpper() + item.Name.Substring(1); ;
                        column.Name = "task_" + item.Id;
                        column.Tag = item.Id;
                        column.ReadOnly = true;
                        column.Visible = true;
                        column.DataPropertyName = "Tasks[" + item.Id + "]";
                        this.dataGridViewHardware.Columns.Add(column);
                        taskColumns.Add(column);
                    }

                    this.tableLayoutPanelTasks.SetDoubleBuffered();
                    this.tableLayoutPanelTasks.SuspendLayout();

                    this.tableLayoutPanelTasks.ColumnStyles[0] = new ColumnStyle(SizeType.AutoSize);
                    
                    this.tableLayoutPanelTasks.RowCount = 2 + viewModel.Tasks.Count;
                    this.tableLayoutPanelTasks.RowStyles.Clear();
                    this.tableLayoutPanelTasks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));

                    this.tableLayoutPanelTasks.Controls.Clear();
                    this.dayRates.Clear();
                    this.nightRates.Clear();
                    this.longNightRates.Clear();
                    this.shortNightRates.Clear();
                    
                    this.tableLayoutPanelTasks.Controls.Add(this.labelHeaderTasksDay, 1, 0);
                    this.tableLayoutPanelTasks.Controls.Add(this.labelHeaderTasksLongNights, 2, 0);
                    this.tableLayoutPanelTasks.Controls.Add(this.labelHeaderTasksShortNight, 3, 0);

                    int cptRow = 1;
                    foreach (var item in orderedTasks)
                    {
                        this.tableLayoutPanelTasks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));

                        Label taskLabel = new Label();
                        taskLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                        taskLabel.AutoSize = true;
                        taskLabel.Text = new String(new char[] { item.Name[0] }).ToUpper() + item.Name.Substring(1);

                        this.tableLayoutPanelTasks.Controls.Add(taskLabel, 0, cptRow);

                        TextBox taskDayTextBox = new TextBox();
                        taskDayTextBox.Text = this.ToRate(item.DayRate);
                        taskDayTextBox.Tag = item;
                        taskDayTextBox.Validating += ValidateIsRateTextBox;
                        this.dayRates.Add(taskDayTextBox);
                        this.tableLayoutPanelTasks.Controls.Add(taskDayTextBox, 1, cptRow);

                        TextBox taskLongNightTextBox = new TextBox();
                        this.longNightRates.Add(taskLongNightTextBox);
                        taskLongNightTextBox.Tag = item;
                        taskLongNightTextBox.Enabled = item.Type == TaskType.DAYS_NIGHT;
                        if (taskLongNightTextBox.Enabled)
                        {
                            taskLongNightTextBox.Text = this.ToRate(item.LongNightRate);
                            taskLongNightTextBox.Validating += ValidateIsRateTextBox;
                        }
                        this.tableLayoutPanelTasks.Controls.Add(taskLongNightTextBox, 2, cptRow);
                        
                        TextBox taskShortNightTextBox = new TextBox();
                        this.shortNightRates.Add(taskShortNightTextBox);
                        taskShortNightTextBox.Tag = item;
                        taskShortNightTextBox.Enabled = item.Type == TaskType.DAYS_NIGHT;
                        if (taskShortNightTextBox.Enabled)
                        {
                            taskShortNightTextBox.Text = this.ToRate(item.ShortNightRate);
                            taskShortNightTextBox.Validating += ValidateIsRateTextBox;
                        }
                        this.tableLayoutPanelTasks.Controls.Add(taskShortNightTextBox, 3, cptRow);
                        
                        cptRow++;
                    }

                    this.tableLayoutPanelTasks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
                }

                this.RefreshCategories();
                this.toolStripTextBoxHardwareFilter.Text = "";
                this.toolStripTextBoxSupplyFilter.Text = "";

                this.ApplyHardwareFilter();
                this.ApplySupplyFilter();

                this.tableLayoutPanelTasks.ResumeLayout(true);
            });
        }

        public void AddSupply(ProjectSupplyViewModel viewModel)
        {
            this.InvokeIfRequired(() =>
                                      {
                                          this.supplies.Add(viewModel);
                                          this.RefreshCategories();
                                          this.ApplySupplyFilter();
                                      });
        }

        public void RemoveAllSupplies()
        {
            this.InvokeIfRequired(() =>
            {
                this.projectSupplyViewModelBindingSource.SuspendBinding();
                this.supplies.Clear();
                this.projectSupplyViewModelBindingSource.ResumeBinding();
                this.RefreshCategories();
                this.ApplySupplyFilter();
            });
        }

        public void AddSupplies(IEnumerable<ProjectSupplyViewModel> supplies)
        {
            this.InvokeIfRequired(() =>
            {
                this.projectSupplyViewModelBindingSource.SuspendBinding();
                foreach (var item in supplies)
                {
                    this.supplies.Add(item);
                }
                this.projectSupplyViewModelBindingSource.ResumeBinding();
                this.RefreshCategories();
                this.ApplySupplyFilter();
            });
        }

        public void RemoveSupply(ProjectSupplyViewModel supply)
        {
            this.InvokeIfRequired(() =>
            {
                var item = this.supplies.Where(x => x.Id == supply.Id).First();
                this.supplies.Remove(item);
                this.RefreshCategories();
                this.ApplySupplyFilter();
            });
        }
        
        public void SetSupplies(IEnumerable<ProjectSupplyViewModel> supplies)
        {
            this.InvokeIfRequired(() =>
            {
                this.supplies.Clear();
                if (supplies != null)
                {
                    foreach (var item in supplies)
                    {
                        this.supplies.Add(item);
                    }
                }
                this.RefreshCategories();
                this.ApplySupplyFilter();
            });
        }

        public void UpdateSupply(ProjectSupplyViewModel supply)
        {
            this.InvokeIfRequired(() =>
            {
                var s = this.supplies.Where(x => x.Id == supply.Id).First();
                var index = this.supplies.IndexOf(s);
                this.supplies[index] = supply;
                this.RefreshCategories();
                this.ApplySupplyFilter();
            });
        }

        public void SetHardwares(IEnumerable<ProjectHardwareViewModel> hardwares)
        {
            this.InvokeIfRequired(() =>
                {
                    this.hardwares.Clear();
                    if (hardwares != null)
                    {
                        foreach (var item in hardwares)
                        {
                            this.hardwares.Add(item);
                        }
                    }
                    this.ApplyHardwareFilter();
                });
        }
        
        public void AddHardware(ProjectHardwareViewModel viewModel)
        {
            this.InvokeIfRequired(() =>
                {
                    hardwares.Add(viewModel);
                    this.ApplyHardwareFilter();
                });
        }

        public void RemoveHardware(ProjectHardwareViewModel hardware)
        {
            this.InvokeIfRequired(() =>
            {
                var item = this.hardwares.Where(x => x.Id == hardware.Id).First();
                this.hardwares.Remove(item);
                this.ApplyHardwareFilter();
            });
        }

        public void UpdateHardware(ProjectHardwareViewModel hardware)
        {
            this.InvokeIfRequired(() =>
            {
                var h = this.hardwares.Where(x => x.Id == hardware.Id).First();
                var index = this.hardwares.IndexOf(h);
                this.hardwares[index] = hardware;
                this.ApplyHardwareFilter();
            });
        }

        public void SetFrames(IEnumerable<ProjectFrameViewModel> frames)
        {
            this.InvokeIfRequired(() =>
            {
                this.frames.Clear();
                if (frames != null)
                {
                    foreach (var item in frames)
                    {
                        this.frames.Add(item);
                    }
                }
            });
        }

        public void AddFrame(ProjectFrameViewModel frame)
        {
            this.InvokeIfRequired(() =>
               {
                   frames.Add(frame);
               });
        }

        public void AddFrames(IEnumerable<ProjectFrameViewModel> frames)
        {
            this.InvokeIfRequired(() =>
            {
                foreach (var item in frames)
                {
                    this.frames.Add(item);
                }
            });
        }

        public void RemoveFrame(ProjectFrameViewModel frame)
        {
            this.InvokeIfRequired(() =>
            {
                var item = this.frames.Where(x => x.Id == frame.Id).First();
                this.frames.Remove(item);
            });
        }

        public void SetSummaryItems(IEnumerable<ProjectSummaryItemViewModel> summaryItems)
        {
            this.InvokeIfRequired(() =>
            {
                this.summaryItems.Clear();
                if (summaryItems != null)
                {
                    foreach (var item in summaryItems)
                    {
                        this.summaryItems.Add(item);
                    }
                }
            });
        }

        private void ProjectUserControl_Load(object sender, EventArgs e)
        {
            this.tabControl.SetDoubleBuffered();

            this.dataGridView.SetDoubleBuffered();
            this.dataGridViewHardware.SetDoubleBuffered();
            this.dataGridViewHardwareSupplies.SetDoubleBuffered();
            this.dataGridViewModules.SetDoubleBuffered();
            this.dataGridViewItemSummary.SetDoubleBuffered();

            this.dataGridViewOther.SetDoubleBuffered();

            this.dataGridViewSummary.SetDoubleBuffered();
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

        private void dataGridViewHardwareSupplies_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var hardwareSupply = this.componentsBindingSource[e.RowIndex] as ProjectHardwareSupplyViewModel;
            if (hardwareSupply != null)
            {
                this.eventBroker.Publish(new RequestEditProjectHardwareSupplyAction(hardwareSupply));
            }
        }

        public void SetCostSummaryItems(IEnumerable<ProjectCostSummaryViewModel> summaryItems)
        {
            this.InvokeIfRequired(() =>
            {
                this.dataGridViewSummary.Rows.Clear();
                this.chartCostSummary.Series[0].Points.Clear();
                if (summaryItems != null)
                {
                    foreach (var item in summaryItems)
                    {
                        if (item.ProjectCostSummaryType == ProjectCostSummaryType.Simple)
                        {
                            this.BuildRow(item.Name, item.TotalTime, item.Rate, item.TotalCost);
                        }
                        else if (item.ProjectCostSummaryType == ProjectCostSummaryType.BigTotal)
                        {
                            this.BuildBigTotalRow(Resources.coins, item.Name, item.TotalTime, item.TotalCost);
                        }
                        else
                        {
                            if (item.ProjectCostSummaryType == ProjectCostSummaryType.TotalSupply)
                            {
                                this.BuildTotalRow(Resources.package, item.Name, null, item.TotalCost);
                            }
                            else if (item.ProjectCostSummaryType == ProjectCostSummaryType.TotalWork)
                            {
                                this.BuildTotalRow(Resources.wrench, item.Name, item.TotalTime, item.TotalCost);
                            }
                            else if (item.ProjectCostSummaryType == ProjectCostSummaryType.TotalStudy)
                            {
                                this.BuildTotalRow(Resources.map_edit, item.Name, item.TotalTime, item.TotalCost);
                            }
                            else if (item.ProjectCostSummaryType == ProjectCostSummaryType.TotalTests)
                            {
                                this.BuildTotalRow(Resources.rosette, item.Name, item.TotalTime, item.TotalCost);
                            }
                            else if (item.ProjectCostSummaryType == ProjectCostSummaryType.TotalOther)
                            {
                                this.BuildTotalRow(Resources.user_suit, item.Name, item.TotalTime, item.TotalCost);
                            }

                            this.chartCostSummary.Series[0].Points.AddXY(item.Name, item.TotalCost);
                        }
                    }
                }
            });
        }

        private void ApplySupplyFilter()
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
            this.projectSupplyViewModelBindingSource.DataSource = new SortableBindingList<ProjectSupplyViewModel>(filtered, this.supplies);
            this.projectSupplyViewModelBindingSource.ResetBindings(false);
        }

        private void timerSupplyFilter_Tick(object sender, EventArgs e)
        {
            this.ApplySupplyFilter();
            this.timerSupplyFilter.Enabled = false;
        }

        private void toolStripTextBoxSupplyFilter_TextChanged(object sender, EventArgs e)
        {
            this.timerSupplyFilter.Enabled = false;
            this.timerSupplyFilter.Enabled = true;
        }

        private void toolStripTextBoxHardwareFilter_TextChanged(object sender, EventArgs e)
        {
            this.timerHardwareFilter.Enabled = false;
            this.timerHardwareFilter.Enabled = true;
        }

        private void ApplyHardwareFilter()
        {
            var searchRegex = new Regex(string.Format(".*{0}.*", Regex.Escape(this.toolStripTextBoxHardwareFilter.Text)), RegexOptions.IgnoreCase);
            var filtered = this.hardwares.Where(x =>
            {
                return (x.Name != null && searchRegex.IsMatch(x.Name));
            });
            this.projectHardwareViewModelBindingSource.DataSource = new ProjectHardwareList(filtered, this.hardwares);
            this.projectHardwareViewModelBindingSource.ResetBindings(false);
        }

        private void timerHardwareFilter_Tick(object sender, EventArgs e)
        {
            this.ApplyHardwareFilter();
            this.timerHardwareFilter.Enabled = false;
        }
    }
}