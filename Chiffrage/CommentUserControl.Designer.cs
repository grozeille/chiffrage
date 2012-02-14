namespace Chiffrage
{
    partial class CommentUserControl
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
            this.textBoxCommentFake = new System.Windows.Forms.TextBox();
            this.richTextBoxComment = new System.Windows.Forms.RichTextBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.toolStripText = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonBold = new System.Windows.Forms.ToolStripButton();
            this.panelMain.SuspendLayout();
            this.toolStripText.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCommentFake
            // 
            this.textBoxCommentFake.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCommentFake.Location = new System.Drawing.Point(0, 0);
            this.textBoxCommentFake.Multiline = true;
            this.textBoxCommentFake.Name = "textBoxCommentFake";
            this.textBoxCommentFake.Size = new System.Drawing.Size(505, 288);
            this.textBoxCommentFake.TabIndex = 7;
            // 
            // richTextBoxComment
            // 
            this.richTextBoxComment.AcceptsTab = true;
            this.richTextBoxComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxComment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxComment.Location = new System.Drawing.Point(2, 2);
            this.richTextBoxComment.Name = "richTextBoxComment";
            this.richTextBoxComment.Size = new System.Drawing.Size(501, 284);
            this.richTextBoxComment.TabIndex = 8;
            this.richTextBoxComment.Text = "trertre\ntreterert";
            this.richTextBoxComment.SelectionChanged += new System.EventHandler(this.richTextBoxComment_SelectionChanged);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.richTextBoxComment);
            this.panelMain.Controls.Add(this.textBoxCommentFake);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 25);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(505, 288);
            this.panelMain.TabIndex = 9;
            // 
            // toolStripText
            // 
            this.toolStripText.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripText.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonBold});
            this.toolStripText.Location = new System.Drawing.Point(0, 0);
            this.toolStripText.Name = "toolStripText";
            this.toolStripText.Size = new System.Drawing.Size(505, 25);
            this.toolStripText.TabIndex = 9;
            this.toolStripText.Text = "toolStrip1";
            // 
            // toolStripButtonBold
            // 
            this.toolStripButtonBold.CheckOnClick = true;
            this.toolStripButtonBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBold.Image = global::Chiffrage.Properties.Resources.text_bold;
            this.toolStripButtonBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBold.Name = "toolStripButtonBold";
            this.toolStripButtonBold.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonBold.Text = "Gras";
            this.toolStripButtonBold.CheckedChanged += new System.EventHandler(this.toolStripButtonBold_CheckedChanged);
            // 
            // CommentUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.toolStripText);
            this.Name = "CommentUserControl";
            this.Size = new System.Drawing.Size(505, 313);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.toolStripText.ResumeLayout(false);
            this.toolStripText.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCommentFake;
        private System.Windows.Forms.RichTextBox richTextBoxComment;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ToolStrip toolStripText;
        private System.Windows.Forms.ToolStripButton toolStripButtonBold;
    }
}
