namespace Chiffrage
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
            this.headerControlDeal = new TD.Eyefinder.HeaderControl();
            this.dateTimePickerDeal = new System.Windows.Forms.DateTimePicker();
            this.labelDealDate = new System.Windows.Forms.Label();
            this.textBoxDealName = new System.Windows.Forms.TextBox();
            this.labelDeal = new System.Windows.Forms.Label();
            this.headerControlDeal.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerControlDeal
            // 
            this.headerControlDeal.Controls.Add(this.dateTimePickerDeal);
            this.headerControlDeal.Controls.Add(this.labelDealDate);
            this.headerControlDeal.Controls.Add(this.textBoxDealName);
            this.headerControlDeal.Controls.Add(this.labelDeal);
            this.headerControlDeal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerControlDeal.HeaderFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.headerControlDeal.Location = new System.Drawing.Point(0, 0);
            this.headerControlDeal.Name = "headerControlDeal";
            this.headerControlDeal.Padding = new System.Windows.Forms.Padding(2);
            this.headerControlDeal.Size = new System.Drawing.Size(445, 381);
            this.headerControlDeal.TabIndex = 6;
            this.headerControlDeal.Text = "Affaire";
            // 
            // dateTimePickerDeal
            // 
            this.dateTimePickerDeal.Location = new System.Drawing.Point(56, 59);
            this.dateTimePickerDeal.Name = "dateTimePickerDeal";
            this.dateTimePickerDeal.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDeal.TabIndex = 3;
            // 
            // labelDealDate
            // 
            this.labelDealDate.AutoSize = true;
            this.labelDealDate.Location = new System.Drawing.Point(12, 64);
            this.labelDealDate.Name = "labelDealDate";
            this.labelDealDate.Size = new System.Drawing.Size(33, 13);
            this.labelDealDate.TabIndex = 2;
            this.labelDealDate.Text = "Date:";
            // 
            // textBoxDealName
            // 
            this.textBoxDealName.Location = new System.Drawing.Point(56, 31);
            this.textBoxDealName.Name = "textBoxDealName";
            this.textBoxDealName.Size = new System.Drawing.Size(200, 20);
            this.textBoxDealName.TabIndex = 1;
            // 
            // labelDeal
            // 
            this.labelDeal.AutoSize = true;
            this.labelDeal.Location = new System.Drawing.Point(12, 36);
            this.labelDeal.Name = "labelDeal";
            this.labelDeal.Size = new System.Drawing.Size(40, 13);
            this.labelDeal.TabIndex = 0;
            this.labelDeal.Text = "Affaire:";
            // 
            // DealUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerControlDeal);
            this.Name = "DealUserControl";
            this.Size = new System.Drawing.Size(445, 381);
            this.headerControlDeal.ResumeLayout(false);
            this.headerControlDeal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TD.Eyefinder.HeaderControl headerControlDeal;
        private System.Windows.Forms.DateTimePicker dateTimePickerDeal;
        private System.Windows.Forms.Label labelDealDate;
        private System.Windows.Forms.TextBox textBoxDealName;
        private System.Windows.Forms.Label labelDeal;
    }
}
