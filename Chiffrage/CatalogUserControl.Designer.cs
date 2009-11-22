namespace Chiffrage
{
    partial class CatalogUserControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.headerControlCatalog = new TD.Eyefinder.HeaderControl();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageMainInfo = new System.Windows.Forms.TabPage();
            this.commentUserControl = new Chiffrage.CommentUserControl();
            this.supplierCatalogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelComment = new System.Windows.Forms.Label();
            this.textBoxCatalogName = new System.Windows.Forms.TextBox();
            this.labelCatalogue = new System.Windows.Forms.Label();
            this.tabPageSupplies = new System.Windows.Forms.TabPage();
            this.dataGridViewCatalog = new System.Windows.Forms.DataGridView();
            this.supplyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.labelCategory = new System.Windows.Forms.Label();
            this.tabPageHardware = new System.Windows.Forms.TabPage();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moduleSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studyDaysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenceDaysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workDaysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.executiveWorkDaysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testsDaysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.headerControlCatalog.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageMainInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplierCatalogBindingSource)).BeginInit();
            this.tabPageSupplies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCatalog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).BeginInit();
            this.bindingNavigator.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerControlCatalog
            // 
            this.headerControlCatalog.Controls.Add(this.tabControl);
            this.headerControlCatalog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerControlCatalog.HeaderFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.headerControlCatalog.Location = new System.Drawing.Point(0, 0);
            this.headerControlCatalog.Name = "headerControlCatalog";
            this.headerControlCatalog.Padding = new System.Windows.Forms.Padding(2);
            this.headerControlCatalog.Size = new System.Drawing.Size(572, 373);
            this.headerControlCatalog.TabIndex = 5;
            this.headerControlCatalog.Text = "Catalogue";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageMainInfo);
            this.tabControl.Controls.Add(this.tabPageSupplies);
            this.tabControl.Controls.Add(this.tabPageHardware);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 28);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(566, 342);
            this.tabControl.TabIndex = 7;
            // 
            // tabPageMainInfo
            // 
            this.tabPageMainInfo.Controls.Add(this.commentUserControl);
            this.tabPageMainInfo.Controls.Add(this.labelComment);
            this.tabPageMainInfo.Controls.Add(this.textBoxCatalogName);
            this.tabPageMainInfo.Controls.Add(this.labelCatalogue);
            this.tabPageMainInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageMainInfo.Name = "tabPageMainInfo";
            this.tabPageMainInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMainInfo.Size = new System.Drawing.Size(558, 316);
            this.tabPageMainInfo.TabIndex = 1;
            this.tabPageMainInfo.Text = "Catalogue";
            this.tabPageMainInfo.UseVisualStyleBackColor = true;
            // 
            // commentUserControl
            // 
            this.commentUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.commentUserControl.DataBindings.Add(new System.Windows.Forms.Binding("Rtf", this.supplierCatalogBindingSource, "Comment", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.commentUserControl.Location = new System.Drawing.Point(12, 58);
            this.commentUserControl.Name = "commentUserControl";
            this.commentUserControl.Rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1036{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft S" +
                "ans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 trertre\\par\r\ntreterert\\par\r\n}\r\n";
            this.commentUserControl.Size = new System.Drawing.Size(533, 245);
            this.commentUserControl.TabIndex = 20;
            // 
            // supplierCatalogBindingSource
            // 
            this.supplierCatalogBindingSource.DataSource = typeof(Chiffrage.Core.SupplierCatalog);
            this.supplierCatalogBindingSource.CurrentItemChanged += new System.EventHandler(this.supplierCatalogBindingSource_CurrentItemChanged);
            // 
            // labelComment
            // 
            this.labelComment.AutoSize = true;
            this.labelComment.Location = new System.Drawing.Point(9, 36);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(71, 13);
            this.labelComment.TabIndex = 21;
            this.labelComment.Text = "Commentaire:";
            // 
            // textBoxCatalogName
            // 
            this.textBoxCatalogName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplierCatalogBindingSource, "SupplierName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxCatalogName.Location = new System.Drawing.Point(81, 6);
            this.textBoxCatalogName.Name = "textBoxCatalogName";
            this.textBoxCatalogName.Size = new System.Drawing.Size(200, 20);
            this.textBoxCatalogName.TabIndex = 18;
            // 
            // labelCatalogue
            // 
            this.labelCatalogue.AutoSize = true;
            this.labelCatalogue.Location = new System.Drawing.Point(9, 8);
            this.labelCatalogue.Name = "labelCatalogue";
            this.labelCatalogue.Size = new System.Drawing.Size(58, 13);
            this.labelCatalogue.TabIndex = 19;
            this.labelCatalogue.Text = "Catalogue:";
            // 
            // tabPageSupplies
            // 
            this.tabPageSupplies.Controls.Add(this.dataGridViewCatalog);
            this.tabPageSupplies.Controls.Add(this.bindingNavigator);
            this.tabPageSupplies.Controls.Add(this.panelHeader);
            this.tabPageSupplies.Location = new System.Drawing.Point(4, 22);
            this.tabPageSupplies.Name = "tabPageSupplies";
            this.tabPageSupplies.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSupplies.Size = new System.Drawing.Size(558, 316);
            this.tabPageSupplies.TabIndex = 0;
            this.tabPageSupplies.Text = "Fournitures";
            this.tabPageSupplies.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCatalog
            // 
            this.dataGridViewCatalog.AllowUserToOrderColumns = true;
            this.dataGridViewCatalog.AutoGenerateColumns = false;
            this.dataGridViewCatalog.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewCatalog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewCatalog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewCatalog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCatalog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.referenceDataGridViewTextBoxColumn,
            this.categoryDataGridViewTextBoxColumn,
            this.moduleSizeDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.studyDaysDataGridViewTextBoxColumn,
            this.referenceDaysDataGridViewTextBoxColumn,
            this.workDaysDataGridViewTextBoxColumn,
            this.executiveWorkDaysDataGridViewTextBoxColumn,
            this.testsDaysDataGridViewTextBoxColumn});
            this.dataGridViewCatalog.DataSource = this.supplyBindingSource;
            this.dataGridViewCatalog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCatalog.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewCatalog.Location = new System.Drawing.Point(3, 33);
            this.dataGridViewCatalog.Name = "dataGridViewCatalog";
            this.dataGridViewCatalog.RowHeadersVisible = false;
            this.dataGridViewCatalog.Size = new System.Drawing.Size(552, 255);
            this.dataGridViewCatalog.TabIndex = 3;
            this.dataGridViewCatalog.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCatalog_CellValueChanged);
            // 
            // supplyBindingSource
            // 
            this.supplyBindingSource.DataSource = typeof(Chiffrage.Core.Supply);
            this.supplyBindingSource.CurrentItemChanged += new System.EventHandler(this.supplyBindingSource_CurrentItemChanged);
            this.supplyBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.supplyBindingSource_ListChanged);
            // 
            // bindingNavigator
            // 
            this.bindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator.BindingSource = this.supplyBindingSource;
            this.bindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator.Location = new System.Drawing.Point(3, 288);
            this.bindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator.Name = "bindingNavigator";
            this.bindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator.Size = new System.Drawing.Size(552, 25);
            this.bindingNavigator.TabIndex = 6;
            this.bindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = global::Chiffrage.Properties.Resources.add;
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = global::Chiffrage.Properties.Resources.cross;
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = global::Chiffrage.Properties.Resources.resultset_first;
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = global::Chiffrage.Properties.Resources.resultset_previous;
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = global::Chiffrage.Properties.Resources.resultset_next;
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = global::Chiffrage.Properties.Resources.resultset_last;
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.comboBoxCategory);
            this.panelHeader.Controls.Add(this.labelCategory);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(3, 3);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(552, 30);
            this.panelHeader.TabIndex = 5;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Items.AddRange(new object[] {
            "Cable"});
            this.comboBoxCategory.Location = new System.Drawing.Point(64, 3);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCategory.TabIndex = 1;
            this.comboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategory_SelectedIndexChanged);
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(3, 6);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(55, 13);
            this.labelCategory.TabIndex = 0;
            this.labelCategory.Text = "Categorie:";
            // 
            // tabPageHardware
            // 
            this.tabPageHardware.Location = new System.Drawing.Point(4, 22);
            this.tabPageHardware.Name = "tabPageHardware";
            this.tabPageHardware.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHardware.Size = new System.Drawing.Size(558, 316);
            this.tabPageHardware.TabIndex = 2;
            this.tabPageHardware.Text = "Matériels";
            this.tabPageHardware.UseVisualStyleBackColor = true;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.DataPropertyName = "SupplyCategory";
            this.dataGridViewComboBoxColumn1.HeaderText = "SupplyCategory";
            this.dataGridViewComboBoxColumn1.Items.AddRange(new object[] {
            "0",
            "1"});
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Nom";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // referenceDataGridViewTextBoxColumn
            // 
            this.referenceDataGridViewTextBoxColumn.DataPropertyName = "Reference";
            this.referenceDataGridViewTextBoxColumn.HeaderText = "Référence";
            this.referenceDataGridViewTextBoxColumn.Name = "referenceDataGridViewTextBoxColumn";
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Categorie";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            // 
            // moduleSizeDataGridViewTextBoxColumn
            // 
            this.moduleSizeDataGridViewTextBoxColumn.DataPropertyName = "ModuleSize";
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.moduleSizeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.moduleSizeDataGridViewTextBoxColumn.HeaderText = "Modules";
            this.moduleSizeDataGridViewTextBoxColumn.Name = "moduleSizeDataGridViewTextBoxColumn";
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.priceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.priceDataGridViewTextBoxColumn.HeaderText = "Prix unitaire";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            // 
            // studyDaysDataGridViewTextBoxColumn
            // 
            this.studyDaysDataGridViewTextBoxColumn.DataPropertyName = "StudyDays";
            dataGridViewCellStyle3.Format = "#.## j;#.## j;\\0 j";
            this.studyDaysDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.studyDaysDataGridViewTextBoxColumn.HeaderText = "Etude";
            this.studyDaysDataGridViewTextBoxColumn.Name = "studyDaysDataGridViewTextBoxColumn";
            // 
            // referenceDaysDataGridViewTextBoxColumn
            // 
            this.referenceDaysDataGridViewTextBoxColumn.DataPropertyName = "ReferenceDays";
            dataGridViewCellStyle4.Format = "#.## j;#.## j;\\0 j";
            this.referenceDaysDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.referenceDaysDataGridViewTextBoxColumn.HeaderText = "Saisie";
            this.referenceDaysDataGridViewTextBoxColumn.Name = "referenceDaysDataGridViewTextBoxColumn";
            // 
            // workDaysDataGridViewTextBoxColumn
            // 
            this.workDaysDataGridViewTextBoxColumn.DataPropertyName = "WorkDays";
            dataGridViewCellStyle5.Format = "#.## j;#.## j;\\0 j";
            this.workDaysDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.workDaysDataGridViewTextBoxColumn.HeaderText = "Travaux ETAM";
            this.workDaysDataGridViewTextBoxColumn.Name = "workDaysDataGridViewTextBoxColumn";
            this.workDaysDataGridViewTextBoxColumn.Width = 120;
            // 
            // executiveWorkDaysDataGridViewTextBoxColumn
            // 
            this.executiveWorkDaysDataGridViewTextBoxColumn.DataPropertyName = "ExecutiveWorkDays";
            dataGridViewCellStyle6.Format = "#.## j;#.## j;\\0 j";
            this.executiveWorkDaysDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.executiveWorkDaysDataGridViewTextBoxColumn.HeaderText = "Travaux CRNO";
            this.executiveWorkDaysDataGridViewTextBoxColumn.Name = "executiveWorkDaysDataGridViewTextBoxColumn";
            this.executiveWorkDaysDataGridViewTextBoxColumn.Width = 120;
            // 
            // testsDaysDataGridViewTextBoxColumn
            // 
            this.testsDaysDataGridViewTextBoxColumn.DataPropertyName = "TestsDays";
            dataGridViewCellStyle7.Format = "#.## j;#.## j;\\0 j";
            this.testsDaysDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.testsDaysDataGridViewTextBoxColumn.HeaderText = "Essaie";
            this.testsDaysDataGridViewTextBoxColumn.Name = "testsDaysDataGridViewTextBoxColumn";
            // 
            // CatalogUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerControlCatalog);
            this.Name = "CatalogUserControl";
            this.Size = new System.Drawing.Size(572, 373);
            this.Load += new System.EventHandler(this.CatalogUserControl_Load);
            this.headerControlCatalog.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageMainInfo.ResumeLayout(false);
            this.tabPageMainInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplierCatalogBindingSource)).EndInit();
            this.tabPageSupplies.ResumeLayout(false);
            this.tabPageSupplies.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCatalog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).EndInit();
            this.bindingNavigator.ResumeLayout(false);
            this.bindingNavigator.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TD.Eyefinder.HeaderControl headerControlCatalog;
        private System.Windows.Forms.DataGridView dataGridViewCatalog;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.BindingNavigator bindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.BindingSource supplyBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageMainInfo;
        private System.Windows.Forms.TabPage tabPageSupplies;
        private CommentUserControl commentUserControl;
        private System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.TextBox textBoxCatalogName;
        private System.Windows.Forms.Label labelCatalogue;
        private System.Windows.Forms.BindingSource supplierCatalogBindingSource;
        private System.Windows.Forms.TabPage tabPageHardware;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduleSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studyDaysDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenceDaysDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workDaysDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn executiveWorkDaysDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testsDaysDataGridViewTextBoxColumn;
    }
}
