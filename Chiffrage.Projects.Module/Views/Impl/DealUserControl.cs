using System;
using System.Globalization;
using System.Windows.Forms;
using Chiffrage.Projects.Domain;
using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Projects.Module.Views;
using Chiffrage.Mvc.Views;
using System.Drawing;
using System.Windows.Forms.Calendar;
using System.Collections.Generic;
using Chiffrage.Mvc;
using Chiffrage.Mvc.Events;
using Chiffrage.Projects.Domain.Commands;

namespace Chiffrage.Projects.Module.Views.Impl
{
    public partial class DealUserControl : UserControlView, IDealView
    {
        private int? dealId;

        private Color[] calendarColors;

        private readonly IList<CalendarItem> calendarItems = new List<CalendarItem>();

        private readonly DealSummaryItemViewModelList summaryItems = new DealSummaryItemViewModelList();

        private IList<DataGridViewColumn> projectColumns = new List<DataGridViewColumn>();

        private readonly IEventBroker eventBroker;

        public DealUserControl()
        {
            this.InitializeComponent();

            this.dealSummaryItemViewModelBindingSource.DataSource = summaryItems;

            this.textBoxDealName.Validating += this.ValidateIsRequiredTextBox;

            var softGreen = System.Drawing.Color.FromArgb(255, 210, 242, 213);
            var softRed = System.Drawing.Color.FromArgb(255, 255, 206, 206);
            var softPurple = System.Drawing.Color.FromArgb(255, 235, 215, 255);
            var softYelow = System.Drawing.Color.FromArgb(255, 255, 248, 204);
            var softBlue = System.Drawing.Color.FromArgb(255, 198, 226, 255);
            var softGray = System.Drawing.Color.FromArgb(255, 238, 238, 238);

            calendarColors = new Color[] { softGreen, softRed, softPurple, softBlue, softGray };

            this.calendarProjects.ViewStart = DateTime.Now;
            this.calendarProjects.ViewEnd = DateTime.Now.AddMonths(1);
            this.calendarProjects.Renderer = new System.Windows.Forms.Calendar.CalendarSystemRenderer(this.calendarProjects);

            this.chartProjectCost.Series[0]["PieLabelStyle"] = "Outside";
            this.chartProjectCost.Series[0]["PieLineColor"] = "Black";
            //this.chartCostSummary.Series[0].Label = "#VALX (#PERCENT)";
            this.chartProjectCost.Series[0].Label = "#VALX #VALY €";
            //this.chartCostSummary.Series[0].LegendText = "#PERCENT{P0}";
            this.chartProjectCost.Series[0].LegendText = "#VALX (#PERCENT)";
        }

        public DealUserControl(IEventBroker eventBroker)
            :this()
        {
            this.eventBroker = eventBroker;
            this.CausesValidation = true;
        }

        #region IDealView Members

        public void Save()
        {
            this.InvokeIfRequired(() =>
            {
                if(!dealId.HasValue)
                {
                    return;
                }

                this.errorProvider.Clear();
                if (!this.Validate())
                {
                    return;
                }

                this.commentUserControl.Validate();

                var command = new UpdateDealCommand(
                    dealId.Value,
                    this.textBoxDealName.Text,
                    this.commentUserControl.Rtf,
                    this.textBoxReference.Text,
                    this.dateTimePickerDealBegin.Value,
                    this.dateTimePickerDealEnd.Value);

                this.eventBroker.Publish(command);
            });
        }

        public void SetDealViewModel(DealViewModel viewModel)
        {
            this.InvokeIfRequired(() =>
            {
                if (viewModel != null)
                {
                    this.dealId = viewModel.Id;
                    this.textBoxDealName.Text = viewModel.Name;
                    this.textBoxReference.Text = viewModel.Reference;
                    this.dateTimePickerDealBegin.Value = viewModel.StartDate;
                    this.dateTimePickerDealEnd.Value = viewModel.EndDate;
                    this.commentUserControl.Rtf = viewModel.Comment;

                    this.textBoxTotalDays.Text = string.Format(CultureInfo.InvariantCulture, "{0:0.##} h", viewModel.TotalDays);
                    this.textBoxTotalPrice.Text = string.Format(CultureInfo.InvariantCulture, "{0:0.##} €", viewModel.TotalPrice);
                }
                else
                {
                    this.dealId = null;
                    this.textBoxDealName.Text = string.Empty;
                    this.textBoxReference.Text = string.Empty;
                    this.dateTimePickerDealBegin.Value = DateTime.Now;
                    this.dateTimePickerDealEnd.Value = DateTime.Now;
                    this.commentUserControl.Rtf = string.Empty;

                    this.textBoxTotalDays.Text = string.Empty;
                    this.textBoxTotalPrice.Text = string.Empty;
                }
            });
        }

        #endregion

        private void calendar1_LoadItems(object sender, System.Windows.Forms.Calendar.CalendarLoadEventArgs e)
        {
            foreach (var item in calendarItems)
            {
                if (this.calendarProjects.ViewIntersects(item))
                {
                    try
                    {
                        this.calendarProjects.Items.Add(item);
                    }
                    catch (NullReferenceException)
                    {
                        this.calendarProjects.Items.Remove(item);
                    }
                }
            }
        }


        public void SetCalendarItems(System.Collections.Generic.IEnumerable<DealProjectCalendarItemViewModel> calendarItems)
        {
            this.InvokeIfRequired(() =>
            {
                this.comboBoxProjects.Items.Clear();
                this.comboBoxProjects.Items.Add(string.Empty);
                this.calendarItems.Clear();

                DateTime minDate = DateTime.Now;
                int colorCpt = 0;
                foreach (var item in calendarItems)
                {
                    if (item.StartDate.Date.Equals(DateTime.MinValue))
                    {
                        continue;
                    }

                    if (item.StartDate.Date < this.calendarProjects.ViewStart)
                    {
                        minDate = item.StartDate.Date;                        
                    }

                    var calendarItem = new System.Windows.Forms.Calendar.CalendarItem(this.calendarProjects, item.StartDate.Date, item.EndDate.Date.AddHours(23), item.Name);
                    calendarItem.Tag = item.ProjectId;
                    calendarItem.ApplyColor(this.calendarColors[colorCpt]);
                    this.calendarItems.Add(calendarItem);
                    this.comboBoxProjects.Items.Add(item.Name);

                    colorCpt = (colorCpt + 1) % this.calendarColors.Length;
                }

                this.calendarProjects.SetViewRange(DateTime.Now, DateTime.Now.AddMonths(1));
                this.calendarProjects.SetViewRange(minDate, minDate.AddMonths(1));
                this.monthView.ViewStart = minDate;
            });
        }

        private void monthView_SelectionChanged(object sender, EventArgs e)
        {
            var begin = this.monthView.SelectionStart;
            var end = begin.AddDays(this.calendarProjects.MaximumViewDays).AddDays(-1);
            /*var end = this.monthView.SelectionEnd;
            if (begin.AddDays(this.calendarProjects.MaximumViewDays) < end)
            {
                begin = end.AddDays(-this.calendarProjects.MaximumViewDays).AddDays(1);
                this.monthView.SelectionStart = begin;
            }*/
            this.calendarProjects.SetViewRange(begin, end);
            this.comboBoxProjects.Text = string.Empty;
        }

        private void comboBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxProjects.SelectedIndex > 0)
            {
                var selectedProject = this.calendarItems[this.comboBoxProjects.SelectedIndex - 1];

                var startDate = selectedProject.StartDate;
                if (selectedProject.StartDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    startDate = startDate.AddDays(-1);
                }

                this.calendarProjects.SetViewRange(startDate, selectedProject.StartDate.AddMonths(1));
                this.monthView.ViewStart = startDate;
            }
        }


        public void SetSummaryItems(IEnumerable<DealSummaryItemViewModel> summaryItems, IEnumerable<Project> projects)
        {
            this.InvokeIfRequired(() =>
            {
                if(projects != null)
                {
                    foreach (var item in projectColumns)
                    {
                        this.dataGridViewItemSummary.Columns.Remove(item);
                    }

                    projectColumns.Clear();
                    foreach (var item in projects)
                    {
                        var column = new DataGridViewTextBoxColumn();
                        column.HeaderText = new String(new char[] { item.Name[0] }).ToUpper() + item.Name.Substring(1);
                        column.Name = "project_" + item.Id;
                        column.Tag = item.Id;
                        column.ReadOnly = true;
                        column.Visible = true;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                        column.DataPropertyName = "ProjectItems[" + item.Id + "]";
                        this.dataGridViewItemSummary.Columns.Add(column);
                        projectColumns.Add(column);
                    }
                    var columnTotal = new DataGridViewTextBoxColumn();
                    columnTotal.HeaderText = "Total";
                    columnTotal.Name = "project_total";
                    columnTotal.ReadOnly = true;
                    columnTotal.Visible = true;
                    columnTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                    columnTotal.DataPropertyName = "TOTAL";
                    this.dataGridViewItemSummary.Columns.Add(columnTotal);
                    projectColumns.Add(columnTotal);
                }

                this.summaryItems.Projects = projects;
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

        public void SetProjectCostSummaryItems(IEnumerable<DealProjectCostSummaryViewModel> costSummaryItems)
        {
            this.InvokeIfRequired(() =>
            {
                this.chartProjectCost.Series[0].Points.Clear();
                if (costSummaryItems != null)
                {
                    foreach (var item in costSummaryItems)
                    {
                        this.chartProjectCost.Series[0].Points.AddXY(item.ProjectName, item.Cost);
                    }
                }
            });
        }

        private void dataGridViewItemSummary_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 2)
            {
                e.PaintBackground(e.ClipBounds, true);
                Rectangle rect = this.dataGridViewItemSummary.GetColumnDisplayRectangle(e.ColumnIndex, true);
                Size titleSize = TextRenderer.MeasureText(e.Value.ToString(), e.CellStyle.Font);
                if (this.dataGridViewItemSummary.ColumnHeadersHeight < titleSize.Width)
                {
                    this.dataGridViewItemSummary.ColumnHeadersHeight = titleSize.Width + 5;
                }
                e.Graphics.TranslateTransform(0, titleSize.Width);
                e.Graphics.RotateTransform(-90.0F);
                e.Graphics.DrawString(e.Value.ToString(), this.Font, Brushes.Black, new PointF(rect.Y - (dataGridViewItemSummary.ColumnHeadersHeight - titleSize.Width), rect.X));
                e.Graphics.RotateTransform(90.0F);
                e.Graphics.TranslateTransform(0, -titleSize.Width);
                e.Handled = true;
            }
        }
    }
}