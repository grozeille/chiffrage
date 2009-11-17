using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chiffrage
{
    public partial class CommentUserControl : UserControl
    {
        public override string Text
        {
            get
            {
                return richTextBoxComment.Text;
            }
            set
            {
                richTextBoxComment.Text = value;
            }
        }

        public string Rtf
        {
            get { return richTextBoxComment.Rtf; }
            set { richTextBoxComment.Rtf = value; }
        }

        private bool updateToolbar = false;

        public CommentUserControl()
        {
            InitializeComponent();
        }

        private void richTextBoxComment_SelectionChanged(object sender, EventArgs e)
        {
            updateToolbar = true;
            toolStripButtonBold.Checked = this.richTextBoxComment.SelectionFont.Bold;
            updateToolbar = false;
        }

        private void toolStripButtonBold_CheckedChanged(object sender, EventArgs e)
        {
            if (!updateToolbar)
            {
                if (toolStripButtonBold.Checked)
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
