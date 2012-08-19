using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Mvc.Sample.Views;

namespace Chiffrage.Mvc.Sample
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        public IChatView ChatView1
        {
            get { return this.chatUserControl1; }
        }

        public IChatView ChatView2
        {
            get { return this.chatUserControl2; }
        }
    }
}
