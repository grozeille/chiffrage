using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Views;

namespace Chiffrage
{
    public partial class ErrorLogView : UserControlView, IErrorLogView
    {
        public ErrorLogView()
        {
            InitializeComponent();
        }

        public void AppendLog(LogItemViewModel logItem)
        {
            string message = string.Format("[{0}] {1}: {2}", logItem.Date, logItem.Severity, logItem.Message);
            this.InvokeIfRequired(() => this.listBoxLog.Items.Insert(0, message));
        }
    }
}
