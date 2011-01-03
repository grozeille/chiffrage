using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chiffrage
{
    public partial class CommentUserControl : UserControl
    {
        private bool updateToolbar = false;

        public CommentUserControl()
        {
            this.InitializeComponent();
        }

        public override string Text
        {
            get { return this.richTextBoxComment.Text; }
            set { this.richTextBoxComment.Text = value; }
        }

        public string Rtf
        {
            get { return this.richTextBoxComment.Rtf; }
            set { this.richTextBoxComment.Rtf = value; }
        }

        private void richTextBoxComment_SelectionChanged(object sender, EventArgs e)
        {
            this.updateToolbar = true;
            this.toolStripButtonBold.Checked = this.richTextBoxComment.SelectionFont.Bold;
            this.updateToolbar = false;
        }

        private void toolStripButtonBold_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.updateToolbar)
            {
                if (this.toolStripButtonBold.Checked)
                {
                    this.richTextBoxComment.SelectionFont = new Font(this.richTextBoxComment.SelectionFont,
                                                                     FontStyle.Bold);
                }
                else
                {
                    this.richTextBoxComment.SelectionFont = new Font(this.richTextBoxComment.SelectionFont,
                                                                     FontStyle.Regular);
                }
            }
        }
    }
}