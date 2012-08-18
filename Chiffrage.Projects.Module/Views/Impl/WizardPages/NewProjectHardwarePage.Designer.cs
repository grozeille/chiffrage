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
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.labelCategory = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.labelSupply = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.timerFilter = new System.Windows.Forms.Timer(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catalogIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catalogPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studyDaysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenceDaysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catalogWorkDaysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catalogExecutiveWorkDaysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catalogTestsDaysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catalogHardwareViewModelBindingSource)).BeginInit();
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
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.catalogIdDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.categoryDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn3,
            this.catalogPriceDataGridViewTextBoxColumn,
            this.studyDaysDataGridViewTextBoxColumn,
            this.referenceDaysDataGridViewTextBoxColumn,
            this.catalogWorkDaysDataGridViewTextBoxColumn,
            this.catalogExecutiveWorkDaysDataGridViewTextBoxColumn,
            this.catalogTestsDaysDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.catalogHardwareViewModelBindingSource;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView.Location = new System.Drawing.Point(0, 53);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(467, 297);
            this.dataGridView.TabIndex = 6;
            this.dataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_ColumnHeaderMouseClick);
            // 
            // catalogHardwareViewModelBindingSource
            // 
            this.catalogHardwareViewModelBindingSource.DataSource = typeof(Chiffrage.Catalogs.Module.ViewModel.CatalogHardwareViewModel);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(292, 6);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(121, 20);
            this.textBoxSearch.TabIndex = 3;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rechercher:";
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Items.AddRange(new object[] {
            "Cable",
            "Autre"});
            this.comboBoxCategory.Location = new System.Drawing.Point(81, 6);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCategory.TabIndex = 1;
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(9, 9);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(55, 13);
            this.labelCategory.TabIndex = 0;
            this.labelCategory.Text = "Categorie:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelCategory);
            this.panel1.Controls.Add(this.textBoxSearch);
            this.panel1.Controls.Add(this.comboBoxCategory);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 350);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 35);
            this.panel1.TabIndex = 8;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.textBoxQuantity);
            this.panelHeader.Controls.Add(this.labelQuantity);
            this.panelHeader.Controls.Add(this.labelSupply);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(467, 53);
            this.panelHeader.TabIndex = 7;
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(76, 6);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(121, 20);
            this.textBoxQuantity.TabIndex = 7;
            this.textBoxQuantity.Text = "1";
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(4, 9);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(50, 13);
            this.labelQuantity.TabIndex = 6;
            this.labelQuantity.Text = "Quantité:";
            // 
            // labelSupply
            // 
            this.labelSupply.AutoSize = true;
            this.labelSupply.Location = new System.Drawing.Point(4, 31);
            this.labelSupply.Name = "labelSupply";
            this.labelSupply.Size = new System.Drawing.Size(57, 13);
            this.labelSupply.TabIndex = 5;
            this.labelSupply.Text = "Fourniture:";
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Nom";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Reference";
            this.dataGridViewTextBoxColumn2.HeaderText = "Reference";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Categorie";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ModuleSize";
            this.dataGridViewTextBoxColumn3.HeaderText = "Modules";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // catalogPriceDataGridViewTextBoxColumn
            // 
            this.catalogPriceDataGridViewTextBoxColumn.DataPropertyName = "CatalogPrice";
            this.catalogPriceDataGridViewTextBoxColumn.HeaderText = "Prix";
            this.catalogPriceDataGridViewTextBoxColumn.Name = "catalogPriceDataGridViewTextBoxColumn";
            this.catalogPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.catalogPriceDataGridViewTextBoxColumn.Visible = false;
            // 
            // studyDaysDataGridViewTextBoxColumn
            // 
            this.studyDaysDataGridViewTextBoxColumn.DataPropertyName = "StudyDays";
            this.studyDaysDataGridViewTextBoxColumn.HeaderText = "Etude";
            this.studyDaysDataGridViewTextBoxColumn.Name = "studyDaysDataGridViewTextBoxColumn";
            this.studyDaysDataGridViewTextBoxColumn.ReadOnly = true;
            this.studyDaysDataGridViewTextBoxColumn.Visible = false;
            // 
            // referenceDaysDataGridViewTextBoxColumn
            // 
            this.referenceDaysDataGridViewTextBoxColumn.DataPropertyName = "ReferenceDays";
            this.referenceDaysDataGridViewTextBoxColumn.HeaderText = "Saisie";
            this.referenceDaysDataGridViewTextBoxColumn.Name = "referenceDaysDataGridViewTextBoxColumn";
            this.referenceDaysDataGridViewTextBoxColumn.ReadOnly = true;
            this.referenceDaysDataGridViewTextBoxColumn.Visible = false;
            // 
            // catalogWorkDaysDataGridViewTextBoxColumn
            // 
            this.catalogWorkDaysDataGridViewTextBoxColumn.DataPropertyName = "CatalogWorkDays";
            this.catalogWorkDaysDataGridViewTextBoxColumn.HeaderText = "Travaux ETAM";
            this.catalogWorkDaysDataGridViewTextBoxColumn.Name = "catalogWorkDaysDataGridViewTextBoxColumn";
            this.catalogWorkDaysDataGridViewTextBoxColumn.ReadOnly = true;
            this.catalogWorkDaysDataGridViewTextBoxColumn.Visible = false;
            // 
            // catalogExecutiveWorkDaysDataGridViewTextBoxColumn
            // 
            this.catalogExecutiveWorkDaysDataGridViewTextBoxColumn.DataPropertyName = "CatalogExecutiveWorkDays";
            this.catalogExecutiveWorkDaysDataGridViewTextBoxColumn.HeaderText = "Travaux CNRO";
            this.catalogExecutiveWorkDaysDataGridViewTextBoxColumn.Name = "catalogExecutiveWorkDaysDataGridViewTextBoxColumn";
            this.catalogExecutiveWorkDaysDataGridViewTextBoxColumn.ReadOnly = true;
            this.catalogExecutiveWorkDaysDataGridViewTextBoxColumn.Visible = false;
            // 
            // catalogTestsDaysDataGridViewTextBoxColumn
            // 
            this.catalogTestsDaysDataGridViewTextBoxColumn.DataPropertyName = "CatalogTestsDays";
            this.catalogTestsDaysDataGridViewTextBoxColumn.HeaderText = "Tests";
            this.catalogTestsDaysDataGridViewTextBoxColumn.Name = "catalogTestsDaysDataGridViewTextBoxColumn";
            this.catalogTestsDaysDataGridViewTextBoxColumn.ReadOnly = true;
            this.catalogTestsDaysDataGridViewTextBoxColumn.Visible = false;
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
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduleSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label labelSupply;
        private System.Windows.Forms.Timer timerFilter;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.BindingSource catalogHardwareViewModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn catalogIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn catalogPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studyDaysDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenceDaysDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn catalogWorkDaysDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn catalogExecutiveWorkDaysDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn catalogTestsDaysDataGridViewTextBoxColumn;
    }
}
