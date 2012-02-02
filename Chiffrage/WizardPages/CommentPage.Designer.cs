namespace Chiffrage.WizardPages
{
    partial class CommentPage
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
            this.commentUserContrl = new Chiffrage.CommentUserControl();
            this.labelComment = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // commentUserContrl
            // 
            this.commentUserContrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.commentUserContrl.Location = new System.Drawing.Point(3, 27);
            this.commentUserContrl.Name = "commentUserContrl";
            this.commentUserContrl.Rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1036{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft S" +
                "ans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 trertre\\par\r\ntreterert\\par\r\n}\r\n";
            this.commentUserContrl.Size = new System.Drawing.Size(418, 251);
            this.commentUserContrl.TabIndex = 0;
            // 
            // labelComment
            // 
            this.labelComment.AutoSize = true;
            this.labelComment.Location = new System.Drawing.Point(3, 7);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(71, 13);
            this.labelComment.TabIndex = 1;
            this.labelComment.Text = "Commentaire:";
            // 
            // CommentPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelComment);
            this.Controls.Add(this.commentUserContrl);
            this.Name = "CommentPage";
            this.Size = new System.Drawing.Size(424, 281);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommentUserControl commentUserContrl;
        private System.Windows.Forms.Label labelComment;
    }
}
