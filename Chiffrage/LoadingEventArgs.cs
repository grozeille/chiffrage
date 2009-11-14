using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

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
