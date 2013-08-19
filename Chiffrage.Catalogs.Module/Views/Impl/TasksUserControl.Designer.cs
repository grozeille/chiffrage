namespace Chiffrage.Catalogs.Module.Views.Impl
{
    partial class TasksUserControl
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
            this.dataGridViewTasks = new System.Windows.Forms.DataGridView();
            this.CategoryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.labelCategory = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.labelType = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.toolStripButtonAddSupply = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemoveSupply = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSupplies = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonDown = new System.Windows.Forms.ToolStripButton();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelDetails.SuspendLayout();
            this.toolStripSupplies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTasks
            // 
            this.dataGridViewTasks.AllowUserToAddRows = false;
            this.dataGridViewTasks.AllowUserToDeleteRows = false;
            this.dataGridViewTasks.AllowUserToOrderColumns = true;
            this.dataGridViewTasks.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dataGridViewTasks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTasks.AutoGenerateColumns = false;
            this.dataGridViewTasks.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewTasks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewTasks.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewTasks.ColumnHeadersVisible = false;
            this.dataGridViewTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.CategoryColumn,
            this.typeDataGridViewTextBoxColumn,
            this.OrderId});
            this.dataGridViewTasks.DataSource = this.taskViewModelBindingSource;
            this.dataGridViewTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTasks.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewTasks.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTasks.Name = "dataGridViewTasks";
            this.dataGridViewTasks.ReadOnly = true;
            this.dataGridViewTasks.RowHeadersVisible = false;
            this.dataGridViewTasks.Size = new System.Drawing.Size(280, 429);
            this.dataGridViewTasks.TabIndex = 9;
            // 
            // CategoryColumn
            // 
            this.CategoryColumn.DataPropertyName = "Category";
            this.CategoryColumn.HeaderText = "Category";
            this.CategoryColumn.Name = "CategoryColumn";
            this.CategoryColumn.ReadOnly = true;
            // 
            // OrderId
            // 
            this.OrderId.DataPropertyName = "OrderId";
            this.OrderId.HeaderText = "OrderId";
            this.OrderId.Name = "OrderId";
            this.OrderId.ReadOnly = true;
            this.OrderId.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewTasks);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelDetails);
            this.splitContainer1.Size = new System.Drawing.Size(793, 429);
            this.splitContainer1.SplitterDistance = 280;
            this.splitContainer1.TabIndex = 11;
            // 
            // panelDetails
            // 
            this.panelDetails.Controls.Add(this.comboBoxCategory);
            this.panelDetails.Controls.Add(this.labelCategory);
            this.panelDetails.Controls.Add(this.comboBoxType);
            this.panelDetails.Controls.Add(this.labelType);
            this.panelDetails.Controls.Add(this.textBoxName);
            this.panelDetails.Controls.Add(this.labelName);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(0, 0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(509, 429);
            this.panelDetails.TabIndex = 0;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.taskViewModelBindingSource, "Category", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(83, 80);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(180, 21);
            this.comboBoxCategory.TabIndex = 5;
            this.comboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategory_SelectedIndexChanged);
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(22, 83);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(55, 13);
            this.labelCategory.TabIndex = 4;
            this.labelCategory.Text = "Categorie:";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.taskViewModelBindingSource, "Type", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(83, 53);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(180, 21);
            this.comboBoxType.TabIndex = 3;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(22, 56);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(34, 13);
            this.labelType.TabIndex = 2;
            this.labelType.Text = "Type:";
            // 
            // textBoxName
            // 
            this.textBoxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.taskViewModelBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxName.Location = new System.Drawing.Point(83, 23);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(180, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(22, 26);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(32, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Nom:";
            // 
            // toolStripButtonAddSupply
            // 
            this.toolStripButtonAddSupply.Image = global::Chiffrage.Catalogs.Module.Properties.Resources.add;
            this.toolStripButtonAddSupply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddSupply.Name = "toolStripButtonAddSupply";
            this.toolStripButtonAddSupply.Size = new System.Drawing.Size(66, 22);
            this.toolStripButtonAddSupply.Text = "Ajouter";
            // 
            // toolStripButtonRemoveSupply
            // 
            this.toolStripButtonRemoveSupply.Image = global::Chiffrage.Catalogs.Module.Properties.Resources.cross;
            this.toolStripButtonRemoveSupply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemoveSupply.Name = "toolStripButtonRemoveSupply";
            this.toolStripButtonRemoveSupply.Size = new System.Drawing.Size(82, 22);
            this.toolStripButtonRemoveSupply.Text = "Supprimer";
            // 
            // toolStripButtonUp
            // 
            this.toolStripButtonUp.Image = global::Chiffrage.Catalogs.Module.Properties.Resources.arrow_up;
            this.toolStripButtonUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUp.Name = "toolStripButtonUp";
            this.toolStripButtonUp.Size = new System.Drawing.Size(66, 22);
            this.toolStripButtonUp.Text = "Monter";
            this.toolStripButtonUp.Click += new System.EventHandler(this.toolStripButtonUp_Click);
            // 
            // toolStripSupplies
            // 
            this.toolStripSupplies.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripSupplies.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddSupply,
            this.toolStripButtonRemoveSupply,
            this.toolStripButtonUp,
            this.toolStripButtonDown});
            this.toolStripSupplies.Location = new System.Drawing.Point(0, 0);
            this.toolStripSupplies.Name = "toolStripSupplies";
            this.toolStripSupplies.Size = new System.Drawing.Size(793, 25);
            this.toolStripSupplies.TabIndex = 10;
            this.toolStripSupplies.Text = "Projet";
            // 
            // toolStripButtonDown
            // 
            this.toolStripButtonDown.Image = global::Chiffrage.Catalogs.Module.Properties.Resources.arrow_down;
            this.toolStripButtonDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDown.Name = "toolStripButtonDown";
            this.toolStripButtonDown.Size = new System.Drawing.Size(82, 22);
            this.toolStripButtonDown.Text = "Déscendre";
            this.toolStripButtonDown.Click += new System.EventHandler(this.toolStripButtonDown_Click);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.FillWeight = 200F;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Nom";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeDataGridViewTextBoxColumn.Visible = false;
            // 
            // taskViewModelBindingSource
            // 
            this.taskViewModelBindingSource.AllowNew = false;
            this.taskViewModelBindingSource.DataSource = typeof(Chiffrage.Catalogs.Module.ViewModel.TaskViewModel);
            this.taskViewModelBindingSource.Sort = "OrderId ASC";
            this.taskViewModelBindingSource.CurrentChanged += new System.EventHandler(this.taskViewModelBindingSource_CurrentChanged);
            // 
            // TasksUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripSupplies);
            this.Name = "TasksUserControl";
            this.Size = new System.Drawing.Size(793, 454);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.toolStripSupplies.ResumeLayout(false);
            this.toolStripSupplies.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTasks;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.BindingSource taskViewModelBindingSource;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddSupply;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemoveSupply;
        private System.Windows.Forms.ToolStripButton toolStripButtonUp;
        private System.Windows.Forms.ToolStrip toolStripSupplies;
        private System.Windows.Forms.ToolStripButton toolStripButtonDown;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderId;
    }
}
