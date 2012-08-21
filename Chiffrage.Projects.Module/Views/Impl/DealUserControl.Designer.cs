namespace Chiffrage.Projects.Module.Views.Impl
{
    partial class DealUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange1 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange2 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange3 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange4 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange5 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            this.dateTimePickerDealEnd = new System.Windows.Forms.DateTimePicker();
            this.labelEnd = new System.Windows.Forms.Label();
            this.dateTimePickerDealBegin = new System.Windows.Forms.DateTimePicker();
            this.labelDealDate = new System.Windows.Forms.Label();
            this.textBoxReference = new System.Windows.Forms.TextBox();
            this.labelRef = new System.Windows.Forms.Label();
            this.textBoxDealName = new System.Windows.Forms.TextBox();
            this.labelDeal = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.commentUserControl = new Chiffrage.Common.Module.Views.CommentUserControl();
            this.tabControlDeal = new System.Windows.Forms.TabControl();
            this.tabPageDeal = new System.Windows.Forms.TabPage();
            this.tabPageSummary = new System.Windows.Forms.TabPage();
            this.tabPageScheduling = new System.Windows.Forms.TabPage();
            this.calendarProjects = new System.Windows.Forms.Calendar.Calendar();
            this.monthView = new System.Windows.Forms.Calendar.MonthView();
            this.panelSelectDate = new System.Windows.Forms.Panel();
            this.bindingSourceDeal = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panelMain.SuspendLayout();
            this.tabControlDeal.SuspendLayout();
            this.tabPageDeal.SuspendLayout();
            this.tabPageScheduling.SuspendLayout();
            this.panelSelectDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDeal)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePickerDealEnd
            // 
            this.dateTimePickerDealEnd.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceDeal, "EndDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dateTimePickerDealEnd.Location = new System.Drawing.Point(76, 87);
            this.dateTimePickerDealEnd.Name = "dateTimePickerDealEnd";
            this.dateTimePickerDealEnd.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDealEnd.TabIndex = 3;
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.Location = new System.Drawing.Point(10, 93);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(24, 13);
            this.labelEnd.TabIndex = 2;
            this.labelEnd.Text = "Fin:";
            // 
            // dateTimePickerDealBegin
            // 
            this.dateTimePickerDealBegin.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceDeal, "StartDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dateTimePickerDealBegin.Location = new System.Drawing.Point(76, 61);
            this.dateTimePickerDealBegin.Name = "dateTimePickerDealBegin";
            this.dateTimePickerDealBegin.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDealBegin.TabIndex = 3;
            // 
            // labelDealDate
            // 
            this.labelDealDate.AutoSize = true;
            this.labelDealDate.Location = new System.Drawing.Point(10, 67);
            this.labelDealDate.Name = "labelDealDate";
            this.labelDealDate.Size = new System.Drawing.Size(39, 13);
            this.labelDealDate.TabIndex = 2;
            this.labelDealDate.Text = "Début:";
            // 
            // textBoxReference
            // 
            this.textBoxReference.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceDeal, "Reference", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxReference.Location = new System.Drawing.Point(76, 36);
            this.textBoxReference.Name = "textBoxReference";
            this.textBoxReference.Size = new System.Drawing.Size(200, 20);
            this.textBoxReference.TabIndex = 1;
            // 
            // labelRef
            // 
            this.labelRef.AutoSize = true;
            this.labelRef.Location = new System.Drawing.Point(10, 39);
            this.labelRef.Name = "labelRef";
            this.labelRef.Size = new System.Drawing.Size(60, 13);
            this.labelRef.TabIndex = 0;
            this.labelRef.Text = "Référence:";
            // 
            // textBoxDealName
            // 
            this.textBoxDealName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceDeal, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxDealName.Location = new System.Drawing.Point(76, 10);
            this.textBoxDealName.Name = "textBoxDealName";
            this.textBoxDealName.Size = new System.Drawing.Size(200, 20);
            this.textBoxDealName.TabIndex = 1;
            // 
            // labelDeal
            // 
            this.labelDeal.AutoSize = true;
            this.labelDeal.Location = new System.Drawing.Point(10, 13);
            this.labelDeal.Name = "labelDeal";
            this.labelDeal.Size = new System.Drawing.Size(40, 13);
            this.labelDeal.TabIndex = 0;
            this.labelDeal.Text = "Affaire:";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.dateTimePickerDealEnd);
            this.panelMain.Controls.Add(this.labelEnd);
            this.panelMain.Controls.Add(this.dateTimePickerDealBegin);
            this.panelMain.Controls.Add(this.labelDealDate);
            this.panelMain.Controls.Add(this.textBoxReference);
            this.panelMain.Controls.Add(this.labelRef);
            this.panelMain.Controls.Add(this.textBoxDealName);
            this.panelMain.Controls.Add(this.labelDeal);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.Location = new System.Drawing.Point(3, 3);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(810, 121);
            this.panelMain.TabIndex = 9;
            // 
            // commentUserControl
            // 
            this.commentUserControl.DataBindings.Add(new System.Windows.Forms.Binding("Rtf", this.bindingSourceDeal, "Comment", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.commentUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commentUserControl.Location = new System.Drawing.Point(3, 124);
            this.commentUserControl.Name = "commentUserControl";
            this.commentUserControl.ReadOnly = false;
            this.commentUserControl.Rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1036{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft S" +
    "ans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 trertre\\par\r\ntreterert\\par\r\n}\r\n";
            this.commentUserControl.Size = new System.Drawing.Size(810, 316);
            this.commentUserControl.TabIndex = 8;
            // 
            // tabControlDeal
            // 
            this.tabControlDeal.Controls.Add(this.tabPageDeal);
            this.tabControlDeal.Controls.Add(this.tabPageSummary);
            this.tabControlDeal.Controls.Add(this.tabPageScheduling);
            this.tabControlDeal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDeal.Location = new System.Drawing.Point(0, 0);
            this.tabControlDeal.Name = "tabControlDeal";
            this.tabControlDeal.SelectedIndex = 0;
            this.tabControlDeal.Size = new System.Drawing.Size(824, 469);
            this.tabControlDeal.TabIndex = 10;
            // 
            // tabPageDeal
            // 
            this.tabPageDeal.Controls.Add(this.commentUserControl);
            this.tabPageDeal.Controls.Add(this.panelMain);
            this.tabPageDeal.Location = new System.Drawing.Point(4, 22);
            this.tabPageDeal.Name = "tabPageDeal";
            this.tabPageDeal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDeal.Size = new System.Drawing.Size(816, 443);
            this.tabPageDeal.TabIndex = 0;
            this.tabPageDeal.Text = "Affaire";
            this.tabPageDeal.UseVisualStyleBackColor = true;
            // 
            // tabPageSummary
            // 
            this.tabPageSummary.Location = new System.Drawing.Point(4, 22);
            this.tabPageSummary.Name = "tabPageSummary";
            this.tabPageSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSummary.Size = new System.Drawing.Size(816, 443);
            this.tabPageSummary.TabIndex = 1;
            this.tabPageSummary.Text = "Récap matériels";
            this.tabPageSummary.UseVisualStyleBackColor = true;
            // 
            // tabPageScheduling
            // 
            this.tabPageScheduling.Controls.Add(this.calendarProjects);
            this.tabPageScheduling.Controls.Add(this.panelSelectDate);
            this.tabPageScheduling.Location = new System.Drawing.Point(4, 22);
            this.tabPageScheduling.Name = "tabPageScheduling";
            this.tabPageScheduling.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageScheduling.Size = new System.Drawing.Size(816, 443);
            this.tabPageScheduling.TabIndex = 2;
            this.tabPageScheduling.Text = "Planning";
            this.tabPageScheduling.UseVisualStyleBackColor = true;
            // 
            // calendarProjects
            // 
            this.calendarProjects.AllowItemEdit = false;
            this.calendarProjects.AllowItemResize = false;
            this.calendarProjects.AllowNew = false;
            this.calendarProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calendarProjects.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.calendarProjects.Font = new System.Drawing.Font("Segoe UI", 9F);
            calendarHighlightRange1.DayOfWeek = System.DayOfWeek.Monday;
            calendarHighlightRange1.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange1.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange2.DayOfWeek = System.DayOfWeek.Tuesday;
            calendarHighlightRange2.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange2.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange3.DayOfWeek = System.DayOfWeek.Wednesday;
            calendarHighlightRange3.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange3.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange4.DayOfWeek = System.DayOfWeek.Thursday;
            calendarHighlightRange4.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange4.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange5.DayOfWeek = System.DayOfWeek.Friday;
            calendarHighlightRange5.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange5.StartTime = System.TimeSpan.Parse("08:00:00");
            this.calendarProjects.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[] {
        calendarHighlightRange1,
        calendarHighlightRange2,
        calendarHighlightRange3,
        calendarHighlightRange4,
        calendarHighlightRange5};
            this.calendarProjects.Location = new System.Drawing.Point(218, 3);
            this.calendarProjects.Name = "calendarProjects";
            this.calendarProjects.Size = new System.Drawing.Size(595, 437);
            this.calendarProjects.TabIndex = 0;
            this.calendarProjects.Text = "calendar1";
            this.calendarProjects.LoadItems += new System.Windows.Forms.Calendar.Calendar.CalendarLoadEventHandler(this.calendar1_LoadItems);
            // 
            // monthView
            // 
            this.monthView.ArrowsColor = System.Drawing.SystemColors.Window;
            this.monthView.ArrowsSelectedColor = System.Drawing.Color.Gold;
            this.monthView.DayBackgroundColor = System.Drawing.Color.Empty;
            this.monthView.DayGrayedText = System.Drawing.SystemColors.GrayText;
            this.monthView.DaySelectedBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.monthView.DaySelectedColor = System.Drawing.SystemColors.WindowText;
            this.monthView.DaySelectedTextColor = System.Drawing.SystemColors.HighlightText;
            this.monthView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthView.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.monthView.ItemPadding = new System.Windows.Forms.Padding(2);
            this.monthView.Location = new System.Drawing.Point(0, 0);
            this.monthView.MonthTitleColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthView.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption;
            this.monthView.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.monthView.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText;
            this.monthView.Name = "monthView";
            this.monthView.Size = new System.Drawing.Size(215, 437);
            this.monthView.TabIndex = 0;
            this.monthView.TodayBorderColor = System.Drawing.Color.Maroon;
            this.monthView.SelectionChanged += new System.EventHandler(this.monthView_SelectionChanged);
            // 
            // panelSelectDate
            // 
            this.panelSelectDate.Controls.Add(this.monthView);
            this.panelSelectDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSelectDate.Location = new System.Drawing.Point(3, 3);
            this.panelSelectDate.Name = "panelSelectDate";
            this.panelSelectDate.Size = new System.Drawing.Size(215, 437);
            this.panelSelectDate.TabIndex = 1;
            // 
            // bindingSourceDeal
            // 
            this.bindingSourceDeal.DataSource = typeof(Chiffrage.Projects.Module.ViewModel.DealViewModel);
            // 
            // DealUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlDeal);
            this.Name = "DealUserControl";
            this.Size = new System.Drawing.Size(824, 469);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.tabControlDeal.ResumeLayout(false);
            this.tabPageDeal.ResumeLayout(false);
            this.tabPageScheduling.ResumeLayout(false);
            this.panelSelectDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDeal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerDealBegin;
        private System.Windows.Forms.Label labelDealDate;
        private System.Windows.Forms.TextBox textBoxDealName;
        private System.Windows.Forms.Label labelDeal;
        private System.Windows.Forms.DateTimePicker dateTimePickerDealEnd;
        private System.Windows.Forms.Label labelEnd;
        private System.Windows.Forms.TextBox textBoxReference;
        private System.Windows.Forms.Label labelRef;
        private Chiffrage.Common.Module.Views.CommentUserControl commentUserControl;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.BindingSource bindingSourceDeal;
        private System.Windows.Forms.TabControl tabControlDeal;
        private System.Windows.Forms.TabPage tabPageDeal;
        private System.Windows.Forms.TabPage tabPageSummary;
        private System.Windows.Forms.TabPage tabPageScheduling;
        private System.Windows.Forms.Calendar.Calendar calendarProjects;
        private System.Windows.Forms.Panel panelSelectDate;
        private System.Windows.Forms.Calendar.MonthView monthView;
    }
}
