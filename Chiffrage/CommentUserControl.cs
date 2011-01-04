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
            set
            {
                this.SetText(value);
            }
        }

        public string Rtf
        {
            get { return this.richTextBoxComment.Rtf; }
            set
            {
                this.SetRtf(value);                
            }
        }

        private void SetText(string value)
        {
            if(this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(this.SetText), value);
                return;
            }

            if (this.richTextBoxComment.InvokeRequired)
            {
                this.richTextBoxComment.BeginInvoke(new Action<string>(this.SetText), value);
                return;
            }

            this.richTextBoxComment.Text = value;
        }                

        private void SetRtf(string value)
        {
            if(this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(this.SetRtf), value);
                return;
            }

            if (this.richTextBoxComment.InvokeRequired)
            {
                this.richTextBoxComment.BeginInvoke(new Action<string>(this.SetRtf), value);
                return;
            }

            this.richTextBoxComment.Rtf = value;
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

        protected override void SetVisibleCore(bool value)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<bool>(base.SetVisibleCore), value);
                return;
            }

            if (this.richTextBoxComment.InvokeRequired)
            {
                this.richTextBoxComment.BeginInvoke(new Action<bool>(base.SetVisibleCore), value);
                return;
            }
            base.SetVisibleCore(value);
        }
    }
}