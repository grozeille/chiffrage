using Chiffrage.Projects.Module.ViewModel;

namespace Chiffrage.Projects.Module.Views.Impl.WizardPages
{
    partial class NewProjectHardwarePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProjectHardwarePage));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.catalogHardwareViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCatalogs = new System.Windows.Forms.ComboBox();
            this.catalogViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelCatalog = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelInvisible = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.timerFilter = new System.Windows.Forms.Timer(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catalogIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CatalogNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogHardwareViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogViewModelBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.catalogIdDataGridViewTextBoxColumn,
            this.SelectedColumn,
            this.Quantity,
            this.dataGridViewTextBoxColumn1,
            this.CatalogNameColumn,
            this.dataGridViewTextBoxColumn2,
            this.categoryDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.catalogHardwareViewModelBindingSource;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView.Location = new System.Drawing.Point(0, 28);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(467, 322);
            this.dataGridView.TabIndex = 2;
            // 
            // catalogHardwareViewModelBindingSource
            // 
            this.catalogHardwareViewModelBindingSource.DataSource = typeof(Chiffrage.Projects.Module.ViewModel.CatalogHardwareSelectionViewModel);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearch.Location = new System.Drawing.Point(69, 3);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(398, 20);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rechercher:";
            // 
            // comboBoxCatalogs
            // 
            this.comboBoxCatalogs.DataSource = this.catalogViewModelBindingSource;
            this.comboBoxCatalogs.DisplayMember = "SupplierName";
            this.comboBoxCatalogs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCatalogs.FormattingEnabled = true;
            this.comboBoxCatalogs.Location = new System.Drawing.Point(81, 6);
            this.comboBoxCatalogs.Name = "comboBoxCatalogs";
            this.comboBoxCatalogs.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCatalogs.TabIndex = 1;
            this.comboBoxCatalogs.SelectedIndexChanged += new System.EventHandler(this.comboBoxCatalogs_SelectedIndexChanged);
            // 
            // catalogViewModelBindingSource
            // 
            this.catalogViewModelBindingSource.DataSource = typeof(Chiffrage.Catalogs.Module.ViewModel.CatalogViewModel);
            // 
            // labelCatalog
            // 
            this.labelCatalog.AutoSize = true;
            this.labelCatalog.Location = new System.Drawing.Point(9, 9);
            this.labelCatalog.Name = "labelCatalog";
            this.labelCatalog.Size = new System.Drawing.Size(58, 13);
            this.labelCatalog.TabIndex = 0;
            this.labelCatalog.Text = "Catalogue:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelInvisible);
            this.panel1.Controls.Add(this.labelCatalog);
            this.panel1.Controls.Add(this.comboBoxCatalogs);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 350);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 35);
            this.panel1.TabIndex = 8;
            // 
            // labelInvisible
            // 
            this.labelInvisible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInvisible.AutoSize = true;
            this.labelInvisible.Location = new System.Drawing.Point(447, 9);
            this.labelInvisible.Name = "labelInvisible";
            this.labelInvisible.Size = new System.Drawing.Size(0, 13);
            this.labelInvisible.TabIndex = 2;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.textBoxSearch);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(467, 28);
            this.panelHeader.TabIndex = 0;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // timerFilter
            // 
            this.timerFilter.Interval = 500;
            this.timerFilter.Tick += new System.EventHandler(this.timerFilter_Tick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // catalogIdDataGridViewTextBoxColumn
            // 
            this.catalogIdDataGridViewTextBoxColumn.DataPropertyName = "CatalogId";
            this.catalogIdDataGridViewTextBoxColumn.HeaderText = "CatalogId";
            this.catalogIdDataGridViewTextBoxColumn.Name = "catalogIdDataGridViewTextBoxColumn";
            this.catalogIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.catalogIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // SelectedColumn
            // 
            this.SelectedColumn.DataPropertyName = "Selected";
            this.SelectedColumn.FillWeight = 15F;
            this.SelectedColumn.HeaderText = " ";
            this.SelectedColumn.Name = "SelectedColumn";
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.FillWeight = 25F;
            this.Quantity.HeaderText = "Quantité";
            this.Quantity.Name = "Quantity";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.FillWeight = 98.47716F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Nom";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // CatalogNameColumn
            // 
            this.CatalogNameColumn.DataPropertyName = "CatalogName";
            this.CatalogNameColumn.FillWeight = 50F;
            this.CatalogNameColumn.HeaderText = "Catalogue";
            this.CatalogNameColumn.Name = "CatalogNameColumn";
            this.CatalogNameColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Reference";
            this.dataGridViewTextBoxColumn2.HeaderText = "Reference";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Categorie";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            this.categoryDataGridViewTextBoxColumn.Visible = false;
            // 
            // NewProjectHardwarePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelHeader);
            this.Name = "NewProjectHardwarePage";
            this.Size = new System.Drawing.Size(467, 385);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogHardwareViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogViewModelBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCatalogs;
        private System.Windows.Forms.Label labelCatalog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Timer timerFilter;
        private System.Windows.Forms.BindingSource catalogHardwareViewModelBindingSource;
        private System.Windows.Forms.Label labelInvisible;
        private System.Windows.Forms.BindingSource catalogViewModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn catalogIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CatalogNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
    }
}
