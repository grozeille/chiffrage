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
            this.components = new System.ComponentModel.Container();
            this.dealBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dateTimePickerDealEnd = new System.Windows.Forms.DateTimePicker();
            this.labelEnd = new System.Windows.Forms.Label();
            this.dateTimePickerDealBegin = new System.Windows.Forms.DateTimePicker();
            this.labelDealDate = new System.Windows.Forms.Label();
            this.textBoxReference = new System.Windows.Forms.TextBox();
            this.labelRef = new System.Windows.Forms.Label();
            this.textBoxDealName = new System.Windows.Forms.TextBox();
            this.labelDeal = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.commentUserControl = new Chiffrage.CommentUserControl();
            ((System.ComponentModel.ISupportInitialize)(this.dealBindingSource)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dealBindingSource
            // 
            this.dealBindingSource.DataSource = typeof(Chiffrage.Core.Deal);
            this.dealBindingSource.CurrentItemChanged += new System.EventHandler(this.dealBindingSource_CurrentItemChanged);
            // 
            // dateTimePickerDealEnd
            // 
            this.dateTimePickerDealEnd.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dealBindingSource, "EndDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            this.dateTimePickerDealBegin.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dealBindingSource, "StartDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            this.textBoxReference.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dealBindingSource, "Reference", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            this.textBoxDealName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dealBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxDealName.Location = new System.Drawing.Point(76, 10);
            this.textBoxDealName.Name = "textBoxDealName";
            this.textBoxDealName.Size = new System.Drawing.Size(200, 20);
            this.textBoxDealName.TabIndex = 1;
            this.textBoxDealName.TextChanged += new System.EventHandler(this.textBoxDealName_TextChanged);
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
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(445, 121);
            this.panelMain.TabIndex = 9;
            // 
            // commentUserControl
            // 
            this.commentUserControl.DataBindings.Add(new System.Windows.Forms.Binding("Rtf", this.dealBindingSource, "Comment", true));
            this.commentUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commentUserControl.Location = new System.Drawing.Point(0, 121);
            this.commentUserControl.Name = "commentUserControl";
            this.commentUserControl.Rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1036{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft S" +
                "ans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 trertre\\par\r\ntreterert\\par\r\n}\r\n";
            this.commentUserControl.Size = new System.Drawing.Size(445, 260);
            this.commentUserControl.TabIndex = 8;
            // 
            // DealUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.commentUserControl);
            this.Controls.Add(this.panelMain);
            this.Name = "DealUserControl";
            this.Size = new System.Drawing.Size(445, 381);
            ((System.ComponentModel.ISupportInitialize)(this.dealBindingSource)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
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
        private CommentUserControl commentUserControl;
        private System.Windows.Forms.BindingSource dealBindingSource;
        private System.Windows.Forms.Panel panelMain;
    }
}
