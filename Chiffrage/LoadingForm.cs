using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chiffrage
{
    public partial class LoadingForm : Form
    {
        public EventHandler<LoadingEventArgs> OnLoadingApplication;

        public LoadingForm()
        {
            InitializeComponent();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if(OnLoadingApplication != null)
                OnLoadingApplication(this, new LoadingEventArgs(this.backgroundWorker));
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            this.backgroundWorker.RunWorkerAsync();
        }
    }
}
