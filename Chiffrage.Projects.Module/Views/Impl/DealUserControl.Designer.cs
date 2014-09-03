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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange6 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange7 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange8 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange9 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange10 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dateTimePickerDealEnd = new System.Windows.Forms.DateTimePicker();
            this.bindingSourceDeal = new System.Windows.Forms.BindingSource(this.components);
            this.labelEnd = new System.Windows.Forms.Label();
            this.dateTimePickerDealBegin = new System.Windows.Forms.DateTimePicker();
            this.labelDealDate = new System.Windows.Forms.Label();
            this.textBoxReference = new System.Windows.Forms.TextBox();
            this.labelRef = new System.Windows.Forms.Label();
            this.textBoxDealName = new System.Windows.Forms.TextBox();
            this.labelDeal = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.labelTotalDays = new System.Windows.Forms.Label();
            this.labelTotalPrice = new System.Windows.Forms.Label();
            this.textBoxTotalDays = new System.Windows.Forms.TextBox();
            this.textBoxTotalPrice = new System.Windows.Forms.TextBox();
            this.commentUserControl = new Chiffrage.Common.Module.Views.CommentUserControl();
            this.tabControlDeal = new System.Windows.Forms.TabControl();
            this.tabPageDeal = new System.Windows.Forms.TabPage();
            this.tabPageSummaryItems = new System.Windows.Forms.TabPage();
            this.dataGridViewItemSummary = new System.Windows.Forms.DataGridView();
            this.itemTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectItemsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dealSummaryItemViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPageScheduling = new System.Windows.Forms.TabPage();
            this.calendarProjects = new System.Windows.Forms.Calendar.Calendar();
            this.panelSelectDate = new System.Windows.Forms.Panel();
            this.monthView = new System.Windows.Forms.Calendar.MonthView();
            this.comboBoxProjects = new System.Windows.Forms.ComboBox();
            this.tabPageCostSummary = new System.Windows.Forms.TabPage();
            this.chartProjectCost = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPageSummary = new System.Windows.Forms.TabPage();
            this.dataGridViewSummary = new System.Windows.Forms.DataGridView();
            this.ColumnCostImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnCostType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCostTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCostTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDeal)).BeginInit();
            this.panelMain.SuspendLayout();
            this.tabControlDeal.SuspendLayout();
            this.tabPageDeal.SuspendLayout();
            this.tabPageSummaryItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealSummaryItemViewModelBindingSource)).BeginInit();
            this.tabPageScheduling.SuspendLayout();
            this.panelSelectDate.SuspendLayout();
            this.tabPageSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartProjectCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSummary)).BeginInit();
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
            // bindingSourceDeal
            // 
            this.bindingSourceDeal.DataSource = typeof(Chiffrage.Projects.Module.ViewModel.DealViewModel);
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
            this.panelMain.Controls.Add(this.labelTotalDays);
            this.panelMain.Controls.Add(this.labelTotalPrice);
            this.panelMain.Controls.Add(this.dateTimePickerDealEnd);
            this.panelMain.Controls.Add(this.textBoxTotalDays);
            this.panelMain.Controls.Add(this.labelEnd);
            this.panelMain.Controls.Add(this.textBoxTotalPrice);
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
            // labelTotalDays
            // 
            this.labelTotalDays.AutoSize = true;
            this.labelTotalDays.Location = new System.Drawing.Point(294, 13);
            this.labelTotalDays.Name = "labelTotalDays";
            this.labelTotalDays.Size = new System.Drawing.Size(69, 13);
            this.labelTotalDays.TabIndex = 20;
            this.labelTotalDays.Text = "Temps Total:";
            // 
            // labelTotalPrice
            // 
            this.labelTotalPrice.AutoSize = true;
            this.labelTotalPrice.Location = new System.Drawing.Point(294, 39);
            this.labelTotalPrice.Name = "labelTotalPrice";
            this.labelTotalPrice.Size = new System.Drawing.Size(59, 13);
            this.labelTotalPrice.TabIndex = 19;
            this.labelTotalPrice.Text = "Coût Total:";
            // 
            // textBoxTotalDays
            // 
            this.textBoxTotalDays.Location = new System.Drawing.Point(369, 10);
            this.textBoxTotalDays.Name = "textBoxTotalDays";
            this.textBoxTotalDays.ReadOnly = true;
            this.textBoxTotalDays.Size = new System.Drawing.Size(88, 20);
            this.textBoxTotalDays.TabIndex = 21;
            // 
            // textBoxTotalPrice
            // 
            this.textBoxTotalPrice.Location = new System.Drawing.Point(369, 36);
            this.textBoxTotalPrice.Name = "textBoxTotalPrice";
            this.textBoxTotalPrice.ReadOnly = true;
            this.textBoxTotalPrice.Size = new System.Drawing.Size(88, 20);
            this.textBoxTotalPrice.TabIndex = 22;
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
            this.tabControlDeal.Controls.Add(this.tabPageSummaryItems);
            this.tabControlDeal.Controls.Add(this.tabPageSummary);
            this.tabControlDeal.Controls.Add(this.tabPageScheduling);
            this.tabControlDeal.Controls.Add(this.tabPageCostSummary);
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
            // tabPageSummaryItems
            // 
            this.tabPageSummaryItems.Controls.Add(this.dataGridViewItemSummary);
            this.tabPageSummaryItems.Location = new System.Drawing.Point(4, 22);
            this.tabPageSummaryItems.Name = "tabPageSummaryItems";
            this.tabPageSummaryItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSummaryItems.Size = new System.Drawing.Size(816, 443);
            this.tabPageSummaryItems.TabIndex = 1;
            this.tabPageSummaryItems.Text = "Récap matériels";
            this.tabPageSummaryItems.UseVisualStyleBackColor = true;
            // 
            // dataGridViewItemSummary
            // 
            this.dataGridViewItemSummary.AllowUserToAddRows = false;
            this.dataGridViewItemSummary.AllowUserToDeleteRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.AliceBlue;
            this.dataGridViewItemSummary.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewItemSummary.AutoGenerateColumns = false;
            this.dataGridViewItemSummary.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewItemSummary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewItemSummary.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewItemSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewItemSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemTypeDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.projectItemsDataGridViewTextBoxColumn});
            this.dataGridViewItemSummary.DataSource = this.dealSummaryItemViewModelBindingSource;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewItemSummary.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewItemSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewItemSummary.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewItemSummary.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewItemSummary.Name = "dataGridViewItemSummary";
            this.dataGridViewItemSummary.ReadOnly = true;
            this.dataGridViewItemSummary.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewItemSummary.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewItemSummary.RowHeadersVisible = false;
            this.dataGridViewItemSummary.Size = new System.Drawing.Size(810, 437);
            this.dataGridViewItemSummary.TabIndex = 3;
            this.dataGridViewItemSummary.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewItemSummary_CellPainting);
            // 
            // itemTypeDataGridViewTextBoxColumn
            // 
            this.itemTypeDataGridViewTextBoxColumn.DataPropertyName = "ItemType";
            this.itemTypeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.itemTypeDataGridViewTextBoxColumn.Name = "itemTypeDataGridViewTextBoxColumn";
            this.itemTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Nom";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 200;
            // 
            // projectItemsDataGridViewTextBoxColumn
            // 
            this.projectItemsDataGridViewTextBoxColumn.DataPropertyName = "ProjectItems";
            this.projectItemsDataGridViewTextBoxColumn.HeaderText = "ProjectItems";
            this.projectItemsDataGridViewTextBoxColumn.Name = "projectItemsDataGridViewTextBoxColumn";
            this.projectItemsDataGridViewTextBoxColumn.ReadOnly = true;
            this.projectItemsDataGridViewTextBoxColumn.Visible = false;
            // 
            // dealSummaryItemViewModelBindingSource
            // 
            this.dealSummaryItemViewModelBindingSource.DataSource = typeof(Chiffrage.Projects.Module.ViewModel.DealSummaryItemViewModel);
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
            this.calendarProjects.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            calendarHighlightRange6.DayOfWeek = System.DayOfWeek.Monday;
            calendarHighlightRange6.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange6.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange7.DayOfWeek = System.DayOfWeek.Tuesday;
            calendarHighlightRange7.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange7.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange8.DayOfWeek = System.DayOfWeek.Wednesday;
            calendarHighlightRange8.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange8.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange9.DayOfWeek = System.DayOfWeek.Thursday;
            calendarHighlightRange9.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange9.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange10.DayOfWeek = System.DayOfWeek.Friday;
            calendarHighlightRange10.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange10.StartTime = System.TimeSpan.Parse("08:00:00");
            this.calendarProjects.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[] {
        calendarHighlightRange6,
        calendarHighlightRange7,
        calendarHighlightRange8,
        calendarHighlightRange9,
        calendarHighlightRange10};
            this.calendarProjects.Location = new System.Drawing.Point(218, 3);
            this.calendarProjects.Name = "calendarProjects";
            this.calendarProjects.Size = new System.Drawing.Size(595, 437);
            this.calendarProjects.TabIndex = 0;
            this.calendarProjects.Text = "calendar1";
            this.calendarProjects.LoadItems += new System.Windows.Forms.Calendar.Calendar.CalendarLoadEventHandler(this.calendar1_LoadItems);
            // 
            // panelSelectDate
            // 
            this.panelSelectDate.Controls.Add(this.monthView);
            this.panelSelectDate.Controls.Add(this.comboBoxProjects);
            this.panelSelectDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSelectDate.Location = new System.Drawing.Point(3, 3);
            this.panelSelectDate.Name = "panelSelectDate";
            this.panelSelectDate.Size = new System.Drawing.Size(215, 437);
            this.panelSelectDate.TabIndex = 1;
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
            this.monthView.Location = new System.Drawing.Point(0, 21);
            this.monthView.MonthTitleColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthView.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption;
            this.monthView.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.monthView.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText;
            this.monthView.Name = "monthView";
            this.monthView.Size = new System.Drawing.Size(215, 416);
            this.monthView.TabIndex = 0;
            this.monthView.TodayBorderColor = System.Drawing.Color.Maroon;
            this.monthView.SelectionChanged += new System.EventHandler(this.monthView_SelectionChanged);
            // 
            // comboBoxProjects
            // 
            this.comboBoxProjects.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProjects.FormattingEnabled = true;
            this.comboBoxProjects.Location = new System.Drawing.Point(0, 0);
            this.comboBoxProjects.Name = "comboBoxProjects";
            this.comboBoxProjects.Size = new System.Drawing.Size(215, 21);
            this.comboBoxProjects.TabIndex = 0;
            this.comboBoxProjects.SelectedIndexChanged += new System.EventHandler(this.comboBoxProjects_SelectedIndexChanged);
            // 
            // tabPageCostSummary
            // 
            this.tabPageCostSummary.Controls.Add(this.chartProjectCost);
            this.tabPageCostSummary.Location = new System.Drawing.Point(4, 22);
            this.tabPageCostSummary.Name = "tabPageCostSummary";
            this.tabPageCostSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCostSummary.Size = new System.Drawing.Size(816, 443);
            this.tabPageCostSummary.TabIndex = 3;
            this.tabPageCostSummary.Text = "Coût par projet";
            this.tabPageCostSummary.UseVisualStyleBackColor = true;
            // 
            // chartProjectCost
            // 
            chartArea1.Name = "ChartArea1";
            this.chartProjectCost.ChartAreas.Add(chartArea1);
            this.chartProjectCost.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            legend1.TextWrapThreshold = 70;
            this.chartProjectCost.Legends.Add(legend1);
            this.chartProjectCost.Location = new System.Drawing.Point(3, 3);
            this.chartProjectCost.Name = "chartProjectCost";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartProjectCost.Series.Add(series1);
            this.chartProjectCost.Size = new System.Drawing.Size(810, 437);
            this.chartProjectCost.TabIndex = 0;
            this.chartProjectCost.Text = "chartProjectCost";
            // 
            // tabPageSummary
            // 
            this.tabPageSummary.Controls.Add(this.dataGridViewSummary);
            this.tabPageSummary.Location = new System.Drawing.Point(4, 22);
            this.tabPageSummary.Name = "tabPageSummary";
            this.tabPageSummary.Size = new System.Drawing.Size(816, 443);
            this.tabPageSummary.TabIndex = 4;
            this.tabPageSummary.Text = "Récap coût";
            this.tabPageSummary.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSummary
            // 
            this.dataGridViewSummary.AllowUserToAddRows = false;
            this.dataGridViewSummary.AllowUserToDeleteRows = false;
            this.dataGridViewSummary.AllowUserToResizeRows = false;
            this.dataGridViewSummary.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewSummary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewSummary.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewSummary.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCostImg,
            this.ColumnCostType,
            this.ColumnCostTime,
            this.ColumnCostTotal});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSummary.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSummary.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewSummary.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSummary.Name = "dataGridViewSummary";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSummary.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewSummary.RowHeadersVisible = false;
            this.dataGridViewSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSummary.Size = new System.Drawing.Size(816, 443);
            this.dataGridViewSummary.TabIndex = 7;
            // 
            // ColumnCostImg
            // 
            this.ColumnCostImg.HeaderText = "";
            this.ColumnCostImg.Name = "ColumnCostImg";
            this.ColumnCostImg.ReadOnly = true;
            this.ColumnCostImg.Width = 30;
            // 
            // ColumnCostType
            // 
            this.ColumnCostType.HeaderText = "Type";
            this.ColumnCostType.Name = "ColumnCostType";
            this.ColumnCostType.Width = 200;
            // 
            // ColumnCostTime
            // 
            this.ColumnCostTime.HeaderText = "Temps";
            this.ColumnCostTime.Name = "ColumnCostTime";
            // 
            // ColumnCostTotal
            // 
            this.ColumnCostTotal.HeaderText = "Coût";
            this.ColumnCostTotal.Name = "ColumnCostTotal";
            // 
            // DealUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlDeal);
            this.Name = "DealUserControl";
            this.Size = new System.Drawing.Size(824, 469);
            this.Load += new System.EventHandler(this.DealUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDeal)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.tabControlDeal.ResumeLayout(false);
            this.tabPageDeal.ResumeLayout(false);
            this.tabPageSummaryItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealSummaryItemViewModelBindingSource)).EndInit();
            this.tabPageScheduling.ResumeLayout(false);
            this.panelSelectDate.ResumeLayout(false);
            this.tabPageSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartProjectCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSummary)).EndInit();
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
        private System.Windows.Forms.TabPage tabPageSummaryItems;
        private System.Windows.Forms.TabPage tabPageScheduling;
        private System.Windows.Forms.Calendar.Calendar calendarProjects;
        private System.Windows.Forms.Panel panelSelectDate;
        private System.Windows.Forms.Calendar.MonthView monthView;
        private System.Windows.Forms.ComboBox comboBoxProjects;
        private System.Windows.Forms.TabPage tabPageCostSummary;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProjectCost;
        private System.Windows.Forms.DataGridView dataGridViewItemSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectItemsDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource dealSummaryItemViewModelBindingSource;
        private System.Windows.Forms.Label labelTotalDays;
        private System.Windows.Forms.Label labelTotalPrice;
        private System.Windows.Forms.TextBox textBoxTotalDays;
        private System.Windows.Forms.TextBox textBoxTotalPrice;
        private System.Windows.Forms.TabPage tabPageSummary;
        private System.Windows.Forms.DataGridView dataGridViewSummary;
        private System.Windows.Forms.DataGridViewImageColumn ColumnCostImg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCostType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCostTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCostTotal;
    }
}