using System;
using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Projects.Module.Views;
using Chiffrage.Mvc.Views;
using System.Drawing;
using System.Windows.Forms.Calendar;
using System.Collections.Generic;

namespace Chiffrage.Projects.Module.Views.Impl
{
    public partial class DealUserControl : UserControlView, IDealView
    {
        private int? dealId;

        private Color[] calendarColors;

        private IList<CalendarItem> calendarItems = new List<CalendarItem>();

        public DealUserControl()
        {
            this.InitializeComponent();

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
        }

        #region IDealView Members

        public DealViewModel GetDealViewModel()
        {
            return this.InvokeIfRequired(() =>
            {
                if(!dealId.HasValue)
                {
                    return null;
                }

                var dealViewModel = new DealViewModel();
                dealViewModel.Id = dealId.Value;
                dealViewModel.Name = this.textBoxDealName.Text;
                dealViewModel.Reference = this.textBoxReference.Text;
                dealViewModel.StartDate = this.dateTimePickerDealBegin.Value;
                dealViewModel.EndDate = this.dateTimePickerDealEnd.Value;
                this.commentUserControl.Validate();
                dealViewModel.Comment = this.commentUserControl.Rtf;
                
                return dealViewModel;
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
                }
                else
                {
                    this.dealId = null;
                    this.textBoxDealName.Text = string.Empty;
                    this.textBoxReference.Text = string.Empty;
                    this.dateTimePickerDealBegin.Value = DateTime.Now;
                    this.dateTimePickerDealEnd.Value = DateTime.Now;
                    this.commentUserControl.Rtf = string.Empty;
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
                    this.calendarProjects.Items.Add(item);
                }
            }
        }


        public void SetCalendarItems(System.Collections.Generic.IEnumerable<DealProjectCalendarItemViewModel> calendarItems)
        {
            this.InvokeIfRequired(() =>
            {
                this.comboBoxProjects.Items.Clear();
                this.comboBoxProjects.Items.Add(string.Empty);

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
            var end = this.monthView.SelectionEnd;
            if (begin.AddDays(this.calendarProjects.MaximumViewDays) < end)
            {
                begin = end.AddDays(-this.calendarProjects.MaximumViewDays).AddDays(1);
                this.monthView.SelectionStart = begin;
            }
            this.calendarProjects.SetViewRange(begin, end);
            this.comboBoxProjects.Text = string.Empty;
        }

        private void comboBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxProjects.SelectedIndex > 0)
            {
                var selectedProject = this.calendarItems[this.comboBoxProjects.SelectedIndex - 1];
                this.calendarProjects.SetViewRange(selectedProject.StartDate, selectedProject.StartDate.AddMonths(1));
                this.monthView.ViewStart = selectedProject.StartDate;
            }
        }
    }
}