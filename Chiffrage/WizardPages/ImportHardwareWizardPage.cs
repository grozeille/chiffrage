using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chiffrage.WizardPages
{
    public partial class ImportHardwareWizardPage : UserControl
    {
        public ImportHardwareWizardPage()
        {
            InitializeComponent();
        }

        public string Filepath
        {
            get
            {
                return this.textBoxPath.Text;
            }
        }

        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            this.openFileDialog.FileName = this.textBoxPath.Text;
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBoxPath.Text = this.openFileDialog.FileName;
            }
        }
    }
}
