using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Chiffrage.Mvc.Views;
using System.ComponentModel;

namespace Chiffrage.Mvc
{
    public partial class WizardPage : UserControl
    {
        public WizardPage()
        {
            this.InitializeComponent();
        }

        public IList<WizardView> Wizards { get; set; }

        public WizardView Selected
        {
            get
            {
                if (this.treeViewWizards.SelectedNode == null)
                {
                    return null;
                }
                else
                {
                    return this.Wizards[this.treeViewWizards.SelectedNode.Index];
                }
            }
        }

        private void WizardPage_Load(object sender, EventArgs e)
        {
            this.treeViewWizards.Nodes.Clear();
            this.imageList.Images.Clear();
            if (this.Wizards != null)
            {
                var cpt = 0;
                foreach (var wizard in this.Wizards)
                {
                    TreeNode node = new TreeNode(wizard.Name);
                    if (wizard.Icon != null)
                    {
                        this.imageList.Images.Add(wizard.Icon);
                        node.SelectedImageIndex = cpt;
                        node.StateImageIndex = cpt;
                        node.ImageIndex = cpt;
                        cpt++;
                    }
                    this.treeViewWizards.Nodes.Add(node);
                }
            }
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);
            e.Cancel = this.Selected == null;
        }
    }
}