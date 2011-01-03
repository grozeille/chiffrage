using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Chiffrage
{
    public partial class LoadingForm : Form
    {
        public EventHandler<LoadingEventArgs> OnLoadingApplication;

        public LoadingForm()
        {
            this.InitializeComponent();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.OnLoadingApplication != null)
                this.OnLoadingApplication(this, new LoadingEventArgs(this.backgroundWorker));
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            this.backgroundWorker.RunWorkerAsync();
        }
    }
}