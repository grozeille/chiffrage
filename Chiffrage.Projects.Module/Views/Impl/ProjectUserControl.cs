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

namespace Chiffrage.Projects.Module.Views.Impl
{
    public partial class ProjectUserControl : UserControlView, IProjectView
    {
        private int? id;

        private readonly SortableBindingList<ProjectSupplyViewModel> supplies = new SortableBindingList<ProjectSupplyViewModel>();

        private readonly SortableBindingList<ProjectHardwareViewModel> hardwares = new SortableBindingList<ProjectHardwareViewModel>();

        private readonly SortableBindingList<ProjectFrameViewModel> frames = new SortableBindingList<ProjectFrameViewModel>();

        private Font defaultFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular,
                                            GraphicsUnit.Point, ((byte) (0)));
        
        private readonly IEventBroker eventBroker;

        public ProjectUserControl()
        {
            this.InitializeComponent();

            this.projectSupplyViewModelBindingSource.DataSource = supplies;
            this.projectHardwareViewModelBindingSource.DataSource = hardwares;
            this.projectFrameViewModelBindingSource.DataSource = frames;

            this.textBoxStudyRate.Validating += this.ValidateIsDoubleTextBox;
            this.textBoxProjectName.Validating += this.ValidateIsRequiredTextBox;
            this.textBoxReferenceRate.Validating += this.ValidateIsDoubleTextBox;
            this.textBoxWorkDayRate.Validating += this.ValidateIsDoubleTextBox;
            this.textBoxWorkShortNightsRate.Validating += this.ValidateIsDoubleTextBox;
            this.textBoxWorkLongNightsRate.Validating += this.ValidateIsDoubleTextBox;
            this.textBoxTestDayRate.Validating += this.ValidateIsDoubleTextBox;
            this.textBoxTestNightRate.Validating += this.ValidateIsDoubleTextBox;
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
        /*
        private void BuildSummary()
        {
            this.dataGridViewSummary.SuspendLayout();
            this.dataGridViewSummary.Rows.Clear();
            if (this.project != null)
            {
                this.BuildTotalRow(Resources.package, "Total matériel", null, this.project.TotalSuppliesCost);
                this.BuildRow("Etude", this.project.TotalStudyDays, this.project.StudyRate,
                              this.project.TotalStudyDaysPrice);
                this.BuildRow("Saisie", this.project.TotalReferenceDays, this.project.ReferenceRate,
                              this.project.TotalReferenceDaysPrice);
                this.BuildTotalRow(Resources.map_edit, "Total Etude",
                                   this.project.TotalStudyDays + this.project.TotalReferenceDays,
                                   this.project.TotalStudyDaysPrice + this.project.TotalReferenceDaysPrice);
                this.BuildRow("Traveaux jour", this.project.TotalWorkDays, this.project.WorkDayRate,
                              this.project.TotalWorkDaysPrice);
                this.BuildRow("Traveaux nuit courte", this.project.TotalWorkShortNights,
                              this.project.WorkShortNightsRate,
                              this.project.TotalWorkShortNightsPrice);
                this.BuildRow("Traveaux nuit longue", this.project.TotalWorkLongNights, this.project.WorkLongNightsRate,
                              this.project.TotalWorkLongNightsPrice);
                this.BuildTotalRow(Resources.wrench, "Total Travaux",
                                   this.project.TotalWorkDays + this.project.TotalWorkShortNights +
                                   this.project.TotalWorkLongNights,
                                   this.project.TotalWorkDaysPrice + this.project.TotalWorkShortNightsPrice +
                                   this.project.TotalWorkLongNightsPrice);
                this.BuildRow("Essais jour", this.project.TotalTestDays, this.project.TestDayRate,
                              this.project.TotalTestDayPrice);
                this.BuildRow("Essais nuit", this.project.TotalTestNights, this.project.TestNightRate,
                              this.project.TotalTestNightPrice);
                this.BuildTotalRow(Resources.rosette, "Total Essais",
                                   this.project.TotalTestDays + this.project.TotalTestNights,
                                   this.project.TotalTestDayPrice + this.project.TotalTestNightPrice);
                this.BuildTotalRow(Resources.user_suit, "Total Divers", this.project.TotalOtherDays,
                                   this.project.TotalOtherDaysPrice);
                this.BuildBigTotalRow(Resources.coins, "Total", this.project.TotalDays, this.project.TotalPrice);
            }
            this.dataGridViewSummary.ResumeLayout(true);
        }

        private void BuildBigTotalRow(Bitmap icon, string name, double? days, double cost)
        {
            int index = this.dataGridViewSummary.Rows.Add(
                icon,
                name,
                days,
                null,
                cost
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
                days,
                null,
                cost
                );
            foreach (DataGridViewCell cell in this.dataGridViewSummary.Rows[index].Cells)
            {
                cell.Style.BackColor = SystemColors.ControlLight;
                cell.Style.Font = new Font(this.defaultFont, FontStyle.Bold);
                cell.ReadOnly = true;
            }
        }

        private void BuildRow(string name, double time, double rate, double cost)
        {
            int index = this.dataGridViewSummary.Rows.Add(
                Resources.blank,
                name,
                time,
                rate,
                cost
                );
            foreach (DataGridViewCell cell in this.dataGridViewSummary.Rows[index].Cells)
            {
                if (cell.ColumnIndex != 3)
                    cell.ReadOnly = true;
            }
        }
        */
        #endregion

        private void textBox_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).SelectAll();
        }
        
        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            //e.DrawBackground();
            /*var control = (TabControl) sender;
            e.Bounds.Inflate(this.imageListProject.Images[0].Width + 4, 0);
            e.Graphics.DrawImage(this.imageListProject.Images[0], e.Bounds.X + 2, e.Bounds.Y + 2);
            var drawBrush = new SolidBrush(Color.Black);
            e.Graphics.DrawString("toto", control.Font, drawBrush, 0, 0);
            e.Graphics.DrawString(
                control.TabPages[e.Index].Text,
                control.Font,
                drawBrush,
                e.Bounds.X + 2 + this.imageListProject.Images[0].Size.Width + 2,
                e.Bounds.Y + 2);*/
        }

        #region IProjectView Members
        
        public ProjectViewModel GetProjectViewModel()
        {
            return this.InvokeIfRequired(() =>
            {
                if (!this.id.HasValue)
                {
                    return null;
                }


                this.errorProvider.Clear();
                if (!this.Validate())
                {
                    return null;
                }

                this.commentUserControl.Validate();

                return new ProjectViewModel
                {
                    Id = this.id.Value,
                    Name = this.textBoxProjectName.Text,
                    Reference = this.textBoxReference.Text,
                    StartDate = this.dateTimePickerProjectBegin.Value,
                    EndDate = this.dateTimePickerProjectEnd.Value,
                    ReferenceRate = double.Parse(this.textBoxReferenceRate.Text, NumberStyles.Float, CultureInfo.InvariantCulture),
                    StudyRate = double.Parse(this.textBoxStudyRate.Text, NumberStyles.Float, CultureInfo.InvariantCulture),
                    WorkDayRate = double.Parse(this.textBoxWorkDayRate.Text, NumberStyles.Float, CultureInfo.InvariantCulture),
                    WorkShortNightsRate = double.Parse(this.textBoxWorkShortNightsRate.Text, NumberStyles.Float, CultureInfo.InvariantCulture),
                    WorkLongNightsRate = double.Parse(this.textBoxWorkLongNightsRate.Text, NumberStyles.Float, CultureInfo.InvariantCulture),
                    TestDayRate = double.Parse(this.textBoxTestDayRate.Text, NumberStyles.Float, CultureInfo.InvariantCulture),
                    TestNightRate = double.Parse(this.textBoxTestNightRate.Text, NumberStyles.Float, CultureInfo.InvariantCulture),
                    TotalDays = int.Parse(this.textBoxTotalDays.Text, NumberStyles.Integer, CultureInfo.InvariantCulture),
                    TotalPrice = double.Parse(this.textBoxTotalPrice.Text, NumberStyles.Float, CultureInfo.InvariantCulture),
                    Comment = this.commentUserControl.Rtf
                };
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

        public void AddSupplies(IList<ProjectSupplyViewModel> supplies)
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
                    
                    this.textBoxReferenceRate.Text = viewModel.ReferenceRate.ToString(CultureInfo.InvariantCulture);
                    this.textBoxStudyRate.Text = viewModel.StudyRate.ToString(CultureInfo.InvariantCulture);
                    this.textBoxWorkDayRate.Text = viewModel.WorkDayRate.ToString(CultureInfo.InvariantCulture);
                    this.textBoxWorkShortNightsRate.Text = viewModel.WorkShortNightsRate.ToString(CultureInfo.InvariantCulture);
                    this.textBoxWorkLongNightsRate.Text = viewModel.WorkLongNightsRate.ToString(CultureInfo.InvariantCulture);
                    this.textBoxTestDayRate.Text = viewModel.TestDayRate.ToString(CultureInfo.InvariantCulture);
                    this.textBoxTestNightRate.Text = viewModel.TestNightRate.ToString(CultureInfo.InvariantCulture);
                    this.textBoxTotalDays.Text = viewModel.TotalDays.ToString(CultureInfo.InvariantCulture);
                    this.textBoxTotalPrice.Text = viewModel.TotalPrice.ToString(CultureInfo.InvariantCulture);
                    this.textBoxTotalModules.Text = viewModel.TotalModules.ToString(CultureInfo.InvariantCulture);
                    this.textBoxModulesNotInFrame.Text = viewModel.ModulesNotInFrame.ToString(CultureInfo.InvariantCulture);
                    this.pictureBoxWarningFrame.Visible = viewModel.ModulesNotInFrame > 0;
                }
            });
        }

        public void SetSupplies(IList<ProjectSupplyViewModel> supplies)
        {
            this.InvokeIfRequired(() =>
                {
                    this.projectSupplyViewModelBindingSource.SuspendBinding();
                    this.supplies.Clear();
                    if (supplies != null)
                    {
                        foreach (var item in supplies)
                        {
                            this.supplies.Add(item);
                        }
                    }
                    this.projectSupplyViewModelBindingSource.ResumeBinding();
                });
        }

        public void SetHardwares(IList<ProjectHardwareViewModel> hardwares)
        {
            this.InvokeIfRequired(() =>
                {
                    this.projectHardwareViewModelBindingSource.SuspendBinding();
                    this.hardwares.Clear();
                    if (hardwares != null)
                    {
                        foreach (var item in hardwares)
                        {
                            this.hardwares.Add(item);
                        }
                    }
                    this.projectHardwareViewModelBindingSource.ResumeBinding();
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

        public void SetFrames(IList<ProjectFrameViewModel> frames)
        {
            this.InvokeIfRequired(() =>
            {
                this.projectFrameViewModelBindingSource.SuspendBinding();
                this.frames.Clear();
                if (frames != null)
                {
                    foreach (var item in frames)
                    {
                        this.frames.Add(item);
                    }
                }
                this.projectFrameViewModelBindingSource.ResumeBinding();
            });
        }

        public void AddFrame(ProjectFrameViewModel frame)
        {
            this.InvokeIfRequired(() =>
               {
                   frames.Add(frame);
               });
        }

        public void AddFrames(IList<ProjectFrameViewModel> frames)
        {
            this.InvokeIfRequired(() =>
            {
                this.projectFrameViewModelBindingSource.SuspendBinding();
                foreach (var item in frames)
                {
                    this.frames.Add(item);
                }
                this.projectFrameViewModelBindingSource.ResumeBinding();
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

        private void ProjectUserControl_Load(object sender, EventArgs e)
        {
            this.tabControl.SetDoubleBuffered();

            this.dataGridView.SetDoubleBuffered();
            this.dataGridViewHardware.SetDoubleBuffered();
            this.dataGridViewHardwareSupplies.SetDoubleBuffered();
            this.dataGridViewModules.SetDoubleBuffered();
            this.dataGridViewAllHardware.SetDoubleBuffered();

            this.dataGridViewWork.SetDoubleBuffered();
            this.dataGridViewWorkExecutive.SetDoubleBuffered();
            this.dataGridViewStudy.SetDoubleBuffered();
            this.dataGridViewTests.SetDoubleBuffered();
            this.dataGridViewOther.SetDoubleBuffered();

            this.dataGridViewSummary.SetDoubleBuffered();
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
    }
}