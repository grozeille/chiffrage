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
    public partial class WizardPage : UserControl
    {
        public IDictionary<UserControl, Image> Pages { get; set; }

        public WizardPage()
        {
            InitializeComponent();
        }

        private void WizardPage_Load(object sender, EventArgs e)
        {
            this.treeViewWizards.Nodes.Clear();
            this.imageList.Images.Clear();
            if(this.Pages != null)
            {
                var cpt = 0;
                foreach(var page in this.Pages)
                {
                    this.imageList.Images.Add(page.Value);
                    this.treeViewWizards.Nodes.Add(page.Key.Text, page.Key.Text, cpt, cpt);
                    cpt++;
                }
            }
        }
    }
}
