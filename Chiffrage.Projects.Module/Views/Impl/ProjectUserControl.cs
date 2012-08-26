﻿using System.Linq;
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

namespace Chiffrage.Projects.Module.Views.Impl
{
    public partial class ProjectUserControl : UserControlView, IProjectView
    {
        private int? id;

        private readonly SortableBindingList<ProjectSupplyViewModel> supplies = new SortableBindingList<ProjectSupplyViewModel>();

        private readonly SortableBindingList<ProjectHardwareViewModel> hardwares = new SortableBindingList<ProjectHardwareViewModel>();

        private readonly SortableBindingList<ProjectSummaryItemViewModel> summaryItems = new SortableBindingList<ProjectSummaryItemViewModel>();

        private readonly SortableBindingList<ProjectFrameViewModel> frames = new SortableBindingList<ProjectFrameViewModel>();

        private readonly SortableBindingList<ProjectHardwareWorkViewModel> works = new SortableBindingList<ProjectHardwareWorkViewModel>();

        private readonly SortableBindingList<ProjectHardwareExecutiveWorkViewModel> executiveWorks = new SortableBindingList<ProjectHardwareExecutiveWorkViewModel>();

        private readonly SortableBindingList<ProjectHardwareStudyReferenceTestViewModel> studyReferenceTests = new SortableBindingList<ProjectHardwareStudyReferenceTestViewModel>();

        private Font defaultFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular,
                                            GraphicsUnit.Point, ((byte) (0)));
        
        private readonly IEventBroker eventBroker;

        private readonly string rateRegex = @"(\d+\.?\d*)(?: +€/j)?";

        public ProjectUserControl()
        {
            this.InitializeComponent();

            this.projectSupplyViewModelBindingSource.DataSource = supplies;
            this.projectHardwareViewModelBindingSource.DataSource = hardwares;
            this.projectFrameViewModelBindingSource.DataSource = frames;
            this.projectSummaryItemViewModelBindingSource.DataSource = summaryItems;
            this.projectHardwareWorkViewModelBindingSource.DataSource = works;
            this.projectHardwareExecutiveWorkViewModelBindingSource.DataSource = executiveWorks;
            this.projectHardwareStudyReferenceTestViewModelBindingSource.DataSource = studyReferenceTests;

            this.textBoxProjectName.Validating += this.ValidateIsRequiredTextBox;

            this.textBoxReferenceRate.Validating += this.ValidateIsRateTextBox;
            this.textBoxStudyRate.Validating += this.ValidateIsRateTextBox;
            this.textBoxWorkDayRate.Validating += this.ValidateIsRateTextBox;
            this.textBoxWorkShortNightsRate.Validating += this.ValidateIsRateTextBox;
            this.textBoxWorkLongNightsRate.Validating += this.ValidateIsRateTextBox;
            this.textBoxTestDayRate.Validating += this.ValidateIsRateTextBox;
            this.textBoxTestNightRate.Validating += this.ValidateIsRateTextBox;

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
            return value.ToString(@"#.## €/j;#.## €/j;\0 €/j", CultureInfo.InvariantCulture);
        }
        
        public ProjectUserControl(IEventBroker eventBroker)
            :this()
        {
            this.eventBroker = eventBroker;
            this.CausesValidation = true;

            //this.toolStripButtonAdd.Click += OnSelect;
            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonAdd, () =>
                this.id.HasValue ? new RequestNewProjectSupplyAction(this.id.Value) : null);

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonRemove, () =>
            {
                if (this.id.HasValue)
                {
                    var projectSupply = this.projectSupplyViewModelBindingSource.Current as ProjectSupplyViewModel;
                    if (projectSupply != null)
                    {
                        var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer le composant '" + projectSupply.Name + "'?", "Supprimer?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                        {
                            return new DeleteProjectSupplyCommand(this.id.Value, projectSupply.Id);
                        }
                    }
                }

                return null;
            });

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonAddHardware, () =>
                this.id.HasValue ? new RequestNewProjectHardwareAction(this.id.Value) : null);

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonRemoveHardware, () =>
            {
                if (this.id.HasValue)
                {
                    var projectHardware = this.projectHardwareViewModelBindingSource.Current as ProjectHardwareViewModel;
                    if (projectHardware != null)
                    {
                        var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer le matériel '" + projectHardware.Name + "'?", "Supprimer?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                        {
                            return new DeleteProjectHardwareCommand(this.id.Value, projectHardware.Id);
                        }
                    }
                }

                return null;
            });

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonAddFrame, () =>
                this.id.HasValue ? new RequestNewProjectFrameAction(this.id.Value) : null);

            this.eventBroker.RegisterToolStripBouttonClickEventSource(this.toolStripButtonRemoveFrame,() =>
            {
                if (this.id.HasValue)
                {
                    var projectFrame = this.projectFrameViewModelBindingSource.Current as ProjectFrameViewModel;
                    if (projectFrame != null)
                    {
                        var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce chassis ?", "Supprimer?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                        {
                            return new DeleteProjectFrameCommand(this.id.Value, projectFrame.Id);
                        }
                    }
                }

                return null;
            });
        }

        #region Summary

        private void BuildBigTotalRow(Bitmap icon, string name, double? days, double cost)
        {
            int index = this.dataGridViewSummary.Rows.Add(
                icon,
                name,
                string.Format("{0} j", days),
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
                days.HasValue ? string.Format("{0} j", days) : string.Empty,
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
                string.Format("{0} j", days),
                string.Format("{0} €/j", rate),
                string.Format("{0} €", cost)
                );
            foreach (DataGridViewCell cell in this.dataGridViewSummary.Rows[index].Cells)
            {
                if (cell.ColumnIndex != 3)
                    cell.ReadOnly = true;
            }
        }
        #endregion

        private void textBox_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).SelectAll();
        }
        
        #region IProjectView Members
        
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
                
                var command = new UpdateProjectCommand(
                    this.id.Value,
                    this.textBoxProjectName.Text,
                    this.commentUserControl.Rtf,
                    this.textBoxReference.Text,
                    this.dateTimePickerProjectBegin.Value,
                    this.dateTimePickerProjectEnd.Value,
                    ParseRate(this.textBoxStudyRate.Text),
                    ParseRate(this.textBoxReferenceRate.Text),
                    ParseRate(this.textBoxWorkDayRate.Text),
                    ParseRate(this.textBoxWorkShortNightsRate.Text),
                    ParseRate(this.textBoxWorkLongNightsRate.Text),
                    ParseRate(this.textBoxTestDayRate.Text),
                    ParseRate(this.textBoxTestNightRate.Text));

                this.eventBroker.Publish(command);
            });
        }

        #endregion

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

        private void dataGridViewStudyReferenceTest_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var hardware = this.projectHardwareStudyReferenceTestViewModelBindingSource[e.RowIndex] as ProjectHardwareStudyReferenceTestViewModel;
            if (hardware != null)
            {
                this.eventBroker.Publish(new RequestEditProjectHardwareStudyReferenceTestAction(hardware));
            }
        }

        private void dataGridViewWork_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var hardware = this.projectHardwareWorkViewModelBindingSource[e.RowIndex] as ProjectHardwareWorkViewModel;
            if (hardware != null)
            {
                this.eventBroker.Publish(new RequestEditProjectHardwareWorkAction(hardware));
            }
        }

        private void dataGridViewExecutiveWork_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var hardware = this.projectHardwareExecutiveWorkViewModelBindingSource[e.RowIndex] as ProjectHardwareExecutiveWorkViewModel;
            if (hardware != null)
            {
                this.eventBroker.Publish(new RequestEditProjectHardwareExecutiveWorkAction(hardware));
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
                    this.textBoxReferenceRate.Text = string.Empty;
                    this.textBoxStudyRate.Text = string.Empty;
                    this.textBoxWorkDayRate.Text = string.Empty;
                    this.textBoxWorkShortNightsRate.Text = string.Empty;
                    this.textBoxWorkLongNightsRate.Text = string.Empty;
                    this.textBoxTestDayRate.Text = string.Empty;
                    this.textBoxTestNightRate.Text = string.Empty;
                    this.textBoxTotalDays.Text = string.Empty;
                    this.textBoxTotalPrice.Text = string.Empty;
                    
                    this.textBoxTotalModules.Text = string.Empty;
                    this.textBoxModulesNotInFrame.Text = string.Empty;
                }
                else
                {
                    this.id = viewModel.Id;

                    this.textBoxProjectName.Text = viewModel.Name;
                    this.textBoxReference.Text = viewModel.Reference;
                    this.dateTimePickerProjectBegin.Value = viewModel.StartDate;
                    this.dateTimePickerProjectEnd.Value = viewModel.EndDate;
                    this.dateTimePickerProjectEnd.Value = viewModel.EndDate;

                    this.textBoxReferenceRate.Text = ToRate(viewModel.ReferenceRate);
                    this.textBoxStudyRate.Text = ToRate(viewModel.StudyRate);
                    this.textBoxWorkDayRate.Text = ToRate(viewModel.WorkDayRate);
                    this.textBoxWorkShortNightsRate.Text = ToRate(viewModel.WorkShortNightsRate);
                    this.textBoxWorkLongNightsRate.Text = ToRate(viewModel.WorkLongNightsRate);
                    this.textBoxTestDayRate.Text = ToRate(viewModel.TestDayRate);
                    this.textBoxTestNightRate.Text = ToRate(viewModel.TestNightRate);
                    this.textBoxTotalDays.Text = string.Format("{0} j", viewModel.TotalDays.ToString(CultureInfo.InvariantCulture));
                    this.textBoxTotalPrice.Text = string.Format("{0} €", viewModel.TotalPrice.ToString(CultureInfo.InvariantCulture));
                    
                    this.textBoxTotalModules.Text = viewModel.TotalModules.ToString(CultureInfo.InvariantCulture);
                    this.textBoxModulesNotInFrame.Text = viewModel.ModulesNotInFrame.ToString(CultureInfo.InvariantCulture);
                    this.pictureBoxWarningFrame.Visible = viewModel.ModulesNotInFrame > 0;
                }
            });
        }

        public void AddSupply(ProjectSupplyViewModel viewModel)
        {
            this.InvokeIfRequired(() => supplies.Add(viewModel));
        }

        public void RemoveAllSupplies()
        {
            this.InvokeIfRequired(() =>
            {
                this.projectSupplyViewModelBindingSource.SuspendBinding();
                this.supplies.Clear();
                this.projectSupplyViewModelBindingSource.ResumeBinding();
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
            });
        }

        public void RemoveSupply(ProjectSupplyViewModel supply)
        {
            this.InvokeIfRequired(() =>
            {
                var item = this.supplies.Where(x => x.Id == supply.Id).First();
                this.supplies.Remove(item);
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
            });
        }

        public void UpdateSupply(ProjectSupplyViewModel supply)
        {
            this.InvokeIfRequired(() =>
            {
                var s = this.supplies.Where(x => x.Id == supply.Id).First();
                var index = this.supplies.IndexOf(s);
                this.supplies[index] = supply;
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
                });
        }
        
        public void AddHardware(ProjectHardwareViewModel viewModel)
        {
            this.InvokeIfRequired(() =>
                {
                    hardwares.Add(viewModel);
                });
        }

        public void RemoveHardware(ProjectHardwareViewModel hardware)
        {
            this.InvokeIfRequired(() =>
            {
                var item = this.hardwares.Where(x => x.Id == hardware.Id).First();
                this.hardwares.Remove(item);
            });
        }

        public void UpdateHardware(ProjectHardwareViewModel hardware)
        {
            this.InvokeIfRequired(() =>
            {
                var h = this.hardwares.Where(x => x.Id == hardware.Id).First();
                var index = this.hardwares.IndexOf(h);
                this.hardwares[index] = hardware;
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

            this.dataGridViewWork.SetDoubleBuffered();
            this.dataGridViewExecutiveWork.SetDoubleBuffered();
            this.dataGridViewStudyReferenceTest.SetDoubleBuffered();
            this.dataGridViewOther.SetDoubleBuffered();

            this.dataGridViewSummary.SetDoubleBuffered();
        }

        private void dataGridViewHardwareSupplies_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var hardwareSupply = this.componentsBindingSource[e.RowIndex] as ProjectHardwareSupplyViewModel;
            if (hardwareSupply != null)
            {
                this.eventBroker.Publish(new RequestEditProjectHardwareSupplyAction(hardwareSupply));
            }
        }

        public void AddHardwareWork(ProjectHardwareWorkViewModel workViewModel)
        {
            this.InvokeIfRequired(() =>
            {
                this.works.Add(workViewModel);
            });
        }

        public void AddHardwareExecutiveWork(ProjectHardwareExecutiveWorkViewModel executiveWorkViewModel)
        {
            this.InvokeIfRequired(() =>
            {
                this.executiveWorks.Add(executiveWorkViewModel);
            });
        }

        public void AddHardwareStudyReferenceTest(ProjectHardwareStudyReferenceTestViewModel studyReferenceTestViewModel)
        {
            this.InvokeIfRequired(() =>
            {
                this.studyReferenceTests.Add(studyReferenceTestViewModel);
            });
        }

        public void SetHardwareWorks(IEnumerable<ProjectHardwareWorkViewModel> works)
        {
            this.InvokeIfRequired(() =>
            {
                this.works.Clear();
                if (works != null)
                {
                    foreach (var item in works)
                    {
                        this.works.Add(item);
                    }
                }
            });
        }

        public void SetHardwareExecutiveWorks(IEnumerable<ProjectHardwareExecutiveWorkViewModel> executiveWorks)
        {
            this.InvokeIfRequired(() =>
            {
                this.executiveWorks.Clear();
                if (executiveWorks != null)
                {
                    foreach (var item in executiveWorks)
                    {
                        this.executiveWorks.Add(item);
                    }
                }
            });
        }

        public void SetHardwareStudyReferenceTests(IEnumerable<ProjectHardwareStudyReferenceTestViewModel> studyReferenceTests)
        {
            this.InvokeIfRequired(() =>
            {
                this.studyReferenceTests.Clear();
                if (studyReferenceTests != null)
                {
                    foreach (var item in studyReferenceTests)
                    {
                        this.studyReferenceTests.Add(item);
                    }
                }
            });
        }

        public void UpdateHardwareStudyReferenceTest(ProjectHardwareStudyReferenceTestViewModel hardware)
        {
            this.InvokeIfRequired(() =>
            {
                var h = this.studyReferenceTests.Where(x => x.Id == hardware.Id).First();
                var index = this.studyReferenceTests.IndexOf(h);
                this.studyReferenceTests[index] = hardware;
            });
        }

        public void UpdateHardwareExecutiveWork(ProjectHardwareExecutiveWorkViewModel hardware)
        {
            this.InvokeIfRequired(() =>
            {
                var h = this.executiveWorks.Where(x => x.Id == hardware.Id).First();
                var index = this.executiveWorks.IndexOf(h);
                this.executiveWorks[index] = hardware;
            });
        }

        public void UpdateHardwareWork(ProjectHardwareWorkViewModel hardware)
        {
            this.InvokeIfRequired(() =>
            {
                var h = this.works.Where(x => x.Id == hardware.Id).First();
                var index = this.works.IndexOf(h);
                this.works[index] = hardware;
            });
        }

        public void RemoveHardwareWork(ProjectHardwareWorkViewModel hardware)
        {
            this.InvokeIfRequired(() =>
            {
                var item = this.works.Where(x => x.Id == hardware.Id).First();
                this.works.Remove(item);
            });
        }

        public void RemoveHardwareExecutiveWork(ProjectHardwareExecutiveWorkViewModel hardware)
        {
            this.InvokeIfRequired(() =>
            {
                var item = this.executiveWorks.Where(x => x.Id == hardware.Id).First();
                this.executiveWorks.Remove(item);
            });
        }

        public void RemoveHardwareStudyReferenceTest(ProjectHardwareStudyReferenceTestViewModel hardware)
        {
            this.InvokeIfRequired(() =>
            {
                var item = this.studyReferenceTests.Where(x => x.Id == hardware.Id).First();
                this.studyReferenceTests.Remove(item);
            });
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
                            else if (item.ProjectCostSummaryType == ProjectCostSummaryType.TotalStudyReference)
                            {
                                this.BuildTotalRow(Resources.map_edit, item.Name, item.TotalTime, item.TotalCost);
                            }
                            else if (item.ProjectCostSummaryType == ProjectCostSummaryType.TotalWork)
                            {
                                this.BuildTotalRow(Resources.wrench, item.Name, item.TotalTime, item.TotalCost);
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
    }
}