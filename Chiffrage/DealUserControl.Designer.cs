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
            this.headerControlDeal = new TD.Eyefinder.HeaderControl();
            this.commentUserControl = new Chiffrage.CommentUserControl();
            this.dealBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelComment = new System.Windows.Forms.Label();
            this.dateTimePickerDealEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerDealBegin = new System.Windows.Forms.DateTimePicker();
            this.labelDealDate = new System.Windows.Forms.Label();
            this.textBoxReference = new System.Windows.Forms.TextBox();
            this.labelRef = new System.Windows.Forms.Label();
            this.textBoxDealName = new System.Windows.Forms.TextBox();
            this.labelDeal = new System.Windows.Forms.Label();
            this.headerControlDeal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dealBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // headerControlDeal
            // 
            this.headerControlDeal.Controls.Add(this.commentUserControl);
            this.headerControlDeal.Controls.Add(this.labelComment);
            this.headerControlDeal.Controls.Add(this.dateTimePickerDealEnd);
            this.headerControlDeal.Controls.Add(this.label1);
            this.headerControlDeal.Controls.Add(this.dateTimePickerDealBegin);
            this.headerControlDeal.Controls.Add(this.labelDealDate);
            this.headerControlDeal.Controls.Add(this.textBoxReference);
            this.headerControlDeal.Controls.Add(this.labelRef);
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
            // commentUserControl
            // 
            this.commentUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.commentUserControl.DataBindings.Add(new System.Windows.Forms.Binding("Rtf", this.dealBindingSource, "Comment", true));
            this.commentUserControl.Location = new System.Drawing.Point(16, 159);
            this.commentUserControl.Name = "commentUserControl";
            this.commentUserControl.Rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1036{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft S" +
                "ans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 trertre\\par\r\ntreterert\\par\r\n}\r\n";
            this.commentUserControl.Size = new System.Drawing.Size(412, 208);
            this.commentUserControl.TabIndex = 8;
            // 
            // dealBindingSource
            // 
            this.dealBindingSource.DataSource = typeof(Chiffrage.Core.Deal);
            this.dealBindingSource.CurrentItemChanged += new System.EventHandler(this.dealBindingSource_CurrentItemChanged);
            // 
            // labelComment
            // 
            this.labelComment.AutoSize = true;
            this.labelComment.Location = new System.Drawing.Point(13, 143);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(71, 13);
            this.labelComment.TabIndex = 5;
            this.labelComment.Text = "Commentaire:";
            // 
            // dateTimePickerDealEnd
            // 
            this.dateTimePickerDealEnd.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dealBindingSource, "EndDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dateTimePickerDealEnd.Location = new System.Drawing.Point(79, 108);
            this.dateTimePickerDealEnd.Name = "dateTimePickerDealEnd";
            this.dateTimePickerDealEnd.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDealEnd.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fin:";
            // 
            // dateTimePickerDealBegin
            // 
            this.dateTimePickerDealBegin.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dealBindingSource, "StartDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dateTimePickerDealBegin.Location = new System.Drawing.Point(79, 82);
            this.dateTimePickerDealBegin.Name = "dateTimePickerDealBegin";
            this.dateTimePickerDealBegin.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDealBegin.TabIndex = 3;
            // 
            // labelDealDate
            // 
            this.labelDealDate.AutoSize = true;
            this.labelDealDate.Location = new System.Drawing.Point(13, 88);
            this.labelDealDate.Name = "labelDealDate";
            this.labelDealDate.Size = new System.Drawing.Size(39, 13);
            this.labelDealDate.TabIndex = 2;
            this.labelDealDate.Text = "Début:";
            // 
            // textBoxReference
            // 
            this.textBoxReference.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dealBindingSource, "Reference", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxReference.Location = new System.Drawing.Point(79, 57);
            this.textBoxReference.Name = "textBoxReference";
            this.textBoxReference.Size = new System.Drawing.Size(200, 20);
            this.textBoxReference.TabIndex = 1;
            // 
            // labelRef
            // 
            this.labelRef.AutoSize = true;
            this.labelRef.Location = new System.Drawing.Point(13, 60);
            this.labelRef.Name = "labelRef";
            this.labelRef.Size = new System.Drawing.Size(60, 13);
            this.labelRef.TabIndex = 0;
            this.labelRef.Text = "Référence:";
            // 
            // textBoxDealName
            // 
            this.textBoxDealName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dealBindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxDealName.Location = new System.Drawing.Point(79, 31);
            this.textBoxDealName.Name = "textBoxDealName";
            this.textBoxDealName.Size = new System.Drawing.Size(200, 20);
            this.textBoxDealName.TabIndex = 1;
            this.textBoxDealName.TextChanged += new System.EventHandler(this.textBoxDealName_TextChanged);
            // 
            // labelDeal
            // 
            this.labelDeal.AutoSize = true;
            this.labelDeal.Location = new System.Drawing.Point(13, 34);
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
            ((System.ComponentModel.ISupportInitialize)(this.dealBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TD.Eyefinder.HeaderControl headerControlDeal;
        private System.Windows.Forms.DateTimePicker dateTimePickerDealBegin;
        private System.Windows.Forms.Label labelDealDate;
        private System.Windows.Forms.TextBox textBoxDealName;
        private System.Windows.Forms.Label labelDeal;
        private System.Windows.Forms.DateTimePicker dateTimePickerDealEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxReference;
        private System.Windows.Forms.Label labelRef;
        private System.Windows.Forms.Label labelComment;
        private CommentUserControl commentUserControl;
        private System.Windows.Forms.BindingSource dealBindingSource;
    }
}
