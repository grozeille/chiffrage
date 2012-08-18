namespace Chiffrage.WizardPages
{
    partial class NewHardwarePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewHardwarePage));
            this.textBoxHardwareName = new System.Windows.Forms.TextBox();
            this.labelHardware = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxStudyDays = new System.Windows.Forms.TextBox();
            this.textBoxReferenceDays = new System.Windows.Forms.TextBox();
            this.textBoxCatalogWorkDays = new System.Windows.Forms.TextBox();
            this.textBoxCatalogExecutiveWorkDays = new System.Windows.Forms.TextBox();
            this.textBoxTestsDays = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxHardwareName
            // 
            this.textBoxHardwareName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHardwareName.Location = new System.Drawing.Point(92, 3);
            this.textBoxHardwareName.Name = "textBoxHardwareName";
            this.textBoxHardwareName.Size = new System.Drawing.Size(194, 20);
            this.textBoxHardwareName.TabIndex = 5;
            // 
            // labelHardware
            // 
            this.labelHardware.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHardware.AutoSize = true;
            this.labelHardware.Location = new System.Drawing.Point(3, 6);
            this.labelHardware.Name = "labelHardware";
            this.labelHardware.Size = new System.Drawing.Size(83, 13);
            this.labelHardware.TabIndex = 4;
            this.labelHardware.Text = "Matériel:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.labelHardware, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.textBoxHardwareName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.label9, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.textBoxStudyDays, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.textBoxReferenceDays, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.textBoxCatalogWorkDays, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.textBoxCatalogExecutiveWorkDays, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.textBoxTestsDays, 1, 6);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 8;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(319, 232);
            this.tableLayoutPanel.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Etudes:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Saisie:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Travaux ETAM:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Travaux CNRO:";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Tests:";
            // 
            // textBoxStudyDays
            // 
            this.textBoxStudyDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStudyDays.Location = new System.Drawing.Point(92, 49);
            this.textBoxStudyDays.Name = "textBoxStudyDays";
            this.textBoxStudyDays.Size = new System.Drawing.Size(194, 20);
            this.textBoxStudyDays.TabIndex = 16;
            this.textBoxStudyDays.Text = "0";
            // 
            // textBoxReferenceDays
            // 
            this.textBoxReferenceDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxReferenceDays.Location = new System.Drawing.Point(92, 75);
            this.textBoxReferenceDays.Name = "textBoxReferenceDays";
            this.textBoxReferenceDays.Size = new System.Drawing.Size(194, 20);
            this.textBoxReferenceDays.TabIndex = 17;
            this.textBoxReferenceDays.Text = "0";
            // 
            // textBoxCatalogWorkDays
            // 
            this.textBoxCatalogWorkDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCatalogWorkDays.Location = new System.Drawing.Point(92, 101);
            this.textBoxCatalogWorkDays.Name = "textBoxCatalogWorkDays";
            this.textBoxCatalogWorkDays.Size = new System.Drawing.Size(194, 20);
            this.textBoxCatalogWorkDays.TabIndex = 15;
            this.textBoxCatalogWorkDays.Text = "0";
            // 
            // textBoxCatalogExecutiveWorkDays
            // 
            this.textBoxCatalogExecutiveWorkDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCatalogExecutiveWorkDays.Location = new System.Drawing.Point(92, 127);
            this.textBoxCatalogExecutiveWorkDays.Name = "textBoxCatalogExecutiveWorkDays";
            this.textBoxCatalogExecutiveWorkDays.Size = new System.Drawing.Size(194, 20);
            this.textBoxCatalogExecutiveWorkDays.TabIndex = 13;
            this.textBoxCatalogExecutiveWorkDays.Text = "0";
            // 
            // textBoxTestsDays
            // 
            this.textBoxTestsDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTestsDays.Location = new System.Drawing.Point(92, 153);
            this.textBoxTestsDays.Name = "textBoxTestsDays";
            this.textBoxTestsDays.Size = new System.Drawing.Size(194, 20);
            this.textBoxTestsDays.TabIndex = 14;
            this.textBoxTestsDays.Text = "0";
            // 
            // NewHardwarePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "NewHardwarePage";
            this.Size = new System.Drawing.Size(319, 232);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxHardwareName;
        private System.Windows.Forms.Label labelHardware;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxStudyDays;
        private System.Windows.Forms.TextBox textBoxReferenceDays;
        private System.Windows.Forms.TextBox textBoxCatalogWorkDays;
        private System.Windows.Forms.TextBox textBoxCatalogExecutiveWorkDays;
        private System.Windows.Forms.TextBox textBoxTestsDays;
    }
}
