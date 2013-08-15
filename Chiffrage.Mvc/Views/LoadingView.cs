using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chiffrage.Mvc.Views
{
    public partial class LoadingView : UserControlView, ILoadingView
    {
        public LoadingView()
        {
            InitializeComponent();
        }

        public bool Continuous
        {
            set 
            {
                this.InvokeIfRequired(() =>
                {
                    if(value)
                    {
                        this.progressBar.Style = ProgressBarStyle.Marquee;
                    }
                    else
                    {
                        this.progressBar.Style = ProgressBarStyle.Continuous;
                    }
                });
            }
        }

        public int Position
        {
            set
            {
                this.InvokeIfRequired(() =>
                {
                    this.progressBar.Style = ProgressBarStyle.Continuous;
                    this.progressBar.Value = value;
                });
            }
        }
    }
}
