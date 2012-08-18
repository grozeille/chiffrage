using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using Chiffrage.Mvc.Views;

namespace Chiffrage
{
    public partial class CommentUserControl : UserControl, INotifyPropertyChanged
    {
        private bool updateToolbar = false;

        public CommentUserControl()
        {
            this.InitializeComponent();
            //this.richTextBoxComment.DataBindings.Add("Text", this, "Text", false, DataSourceUpdateMode.OnPropertyChanged);
            this.richTextBoxComment.DataBindings.Add("Rtf", this, "Rtf", false, DataSourceUpdateMode.OnPropertyChanged);
            // not possible to bind Rtf and Text in the same time!
            this.richTextBoxComment.SetDoubleBuffered();
            this.toolStripText.SetDoubleBuffered();
        }

        private readonly RichTextBox fake = new RichTextBox();

        private string rtf;

        public override string Text
        {
            get 
            {
                fake.Rtf = this.rtf;
                return fake.Text;
            }
            set
            {
                fake.Text = value;
                this.Rtf = fake.Rtf;
            }
        }

        public string Rtf
        {
            get 
            {
                return this.rtf; 
            }
            set
            {
                this.rtf = value;
                FirePropertyChanged("Rtf");
            }
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

        private void FirePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}