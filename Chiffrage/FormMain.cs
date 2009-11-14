using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Grozeille.Chiffrage.Core;
using Chiffrage.WizardPages;

namespace Chiffrage
{
    public partial class FormMain : Form
    {
        public Catalog Catalog { get; set; }

        public IList<Deal> Deals { get; set; }

        public FormMain()
        {
            Deals = new List<Deal>();
            InitializeComponent();
            RefreshDeals();
            RefreshPanel();
        }

        private void RefreshDeals()
        {
            this.treeView.BeginUpdate();
            this.treeView.Nodes.Clear();
            foreach(var deal in this.Deals)
            {
                var dealNode = this.treeView.Nodes.Add(deal.Name, deal.Name, 0, 0);
                dealNode.Tag = deal;
                foreach(var project in deal.Projects)
                {
                    var projectNode = dealNode.Nodes.Add(project.Name, project.Name, 2, 2);
                    projectNode.Tag = project;
                }
            }
            this.treeView.EndUpdate();
        }

        private void navigationBar_SelectedPaneChanged(object sender, EventArgs e)
        {
            RefreshPanel();
        }

        private void RefreshPanel()
        {
            if(navigationBar.SelectedPane == navigationPaneDeal)
            {
                this.DisplayDeal();
            }
            else if(navigationBar.SelectedPane == navigationPaneCatalog)
            {
                this.DisplayCatalog();
            }
        }

        private void DisplayDeal()
        {
            if (treeView.SelectedNode == null && treeView.Nodes.Count > 0)
                treeView.SelectedNode = treeView.Nodes[0];
            var selectedItem = treeView.SelectedNode != null ? treeView.SelectedNode.Tag : null;
            if (selectedItem == null)
            {
                this.DisplayNone();
                projetToolStripMenuItem2.Enabled = false;
                projetToolStripMenuItem.Enabled = false;
            }
            else
            {
                var deal = selectedItem as Deal;
                if (deal != null)
                {
                    this.DisplayDealDetails(deal);
                    projetToolStripMenuItem2.Enabled = true;
                    projetToolStripMenuItem.Enabled = true;
                }

                var project = selectedItem as Project;
                if (project != null)
                {
                    this.DisplayProjectDetails(project);
                    projetToolStripMenuItem2.Enabled = true;
                    projetToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void DisplayCatalog()
        {
            this.SuspendLayout();
            catalogUserControl.Visible = true;
            dealUserControl.Visible = false;
            projectUserControl.Visible = false;
            this.ResumeLayout(true);
        }

        private void DisplayProjectDetails(Project project)
        {
            this.SuspendLayout();
            catalogUserControl.Visible = false;
            dealUserControl.Visible = false;
            projectUserControl.Visible = true;
            projectUserControl.Catalog = Catalog;
            projectUserControl.Project = project;            
            this.ResumeLayout(true);
        }

        private void DisplayDealDetails(Deal deal)
        {
            this.SuspendLayout();
            catalogUserControl.Visible = false;
            dealUserControl.Visible = true;
            projectUserControl.Visible = false;
            this.ResumeLayout(true);
        }

        private void DisplayNone()
        {
            this.SuspendLayout();
            catalogUserControl.Visible = false;
            dealUserControl.Visible = false;
            projectUserControl.Visible = false;
            this.ResumeLayout(true);
        }

        private void affaireToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var page = new NewDealPage();
            var setting = new WizardSetting(page, "Nouvelle affaire", "Création d'une nouvelle affaire", true);
            if (new WizardForm().ShowDialog(setting) == System.Windows.Forms.DialogResult.OK)
            {
                var deal = new Deal();
                deal.Name = page.DealName;
                this.Deals.Add(deal);
                RefreshDeals();
                treeView.SelectedNode = FindNodeByTag(treeView, deal);
            }            
        }

        private void projetToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var deal = treeView.SelectedNode.Tag as Deal;
            var project = treeView.SelectedNode.Tag as Project;

            // find the parent deal of the selected project
            if(project != null)
            {
                foreach(TreeNode dealNode in this.treeView.Nodes)
                {
                    foreach(TreeNode projectNode in dealNode.Nodes)
                    {
                        if(projectNode.Tag == project)
                            deal = dealNode.Tag as Deal;
                    }
                }
            }

            var page = new NewProjectPage();
            var setting = new WizardSetting(page, "Nouveau projet", "Création d'un nouveau projet", true);
            if (new WizardForm().ShowDialog(setting) == System.Windows.Forms.DialogResult.OK)
            {
                project = new Project();
                project.Name = page.ProjectName;
                deal.Projects.Add(project);
                RefreshDeals();
                treeView.SelectedNode = FindNodeByTag(treeView, project);
            }
        }

        private TreeNode FindNodeByTag(TreeView treeView, Object obj)
        {
            return FindNodeByTag(treeView.Nodes, obj);
        }

        private TreeNode FindNodeByTag(TreeNodeCollection collection, Object obj)
        {
            if(collection == null)
                return null;

            foreach (TreeNode node in collection)
            {
                if(node.Tag != null && node.Tag.Equals(obj))
                {
                    return node;
                }
                else
                {
                    var child = FindNodeByTag(node.Nodes, obj);
                    if (child != null)
                        return child;
                }
            }

            return null;
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DisplayDeal();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
