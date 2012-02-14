using System;
using System.ComponentModel;

namespace Chiffrage
{
    public class LoadingEventArgs : EventArgs
    {
        private BackgroundWorker worker;

        public LoadingEventArgs(BackgroundWorker worker)
        {
            this.worker = worker;
        }

        public void ReportProgress(int percentProgress)
        {
            this.worker.ReportProgress(percentProgress);
        }
    }
}