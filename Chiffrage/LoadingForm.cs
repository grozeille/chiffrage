using System;
using System.ComponentModel;
using System.Windows.Forms;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Views;
using System.Threading;

namespace Chiffrage
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            this.InitializeComponent();
        }

        public void Start()
        {
            new Thread(() => Application.Run(this)).Start();
        }

        public void Stop()
        {
            this.BeginInvoke(new Action(this.Close));
        }

        public void UpdateProgress(int position, int max, string status)
        {
            this.BeginInvoke(new Action(()=>
            {
                this.progressBar.Value = position;
                this.progressBar.Maximum = max;
                this.label.Text = status;
            }));
        }
    }
}