using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Core;
using Chiffrage.Repositories;
using Chiffrage.WizardPages;
using Chiffrage.Core.Repositories;
using NHibernate;
using NHibernate.Cfg;
using Settings = Chiffrage.Properties.Settings;

namespace Chiffrage
{
    public partial class FormMain : Form
    {
        public Configuration Configuration { get; set; }

        public DealRepository DealRepository { get; set; }

        public bool DealsDirty
        {
            get { return dealsDirty; }
            set
            {
                dealsDirty = value;
                saveToolStripMenuItem.Enabled = dealsDirty;
                saveToolStripButton.Enabled = dealsDirty;
            }
        }

        public bool CatalogDirty
        {
            get { return catalogDirty; }
            set
            {
                catalogDirty = value;
                saveToolStripMenuItem.Enabled = catalogDirty;
                saveToolStripButton.Enabled = catalogDirty;
            }
        }

        public ICatalogRepository CatalogRepository { get; set; }

        public Catalog Catalog { get; set; }

        private string filePath = null;

        private bool dealsDirty = false;
        private bool catalogDirty = false;

        public IList<Deal> Deals { get; set; }

        public FormMain()
        {
            Deals = new List<Deal>();
            this.DealRepository = new DealRepository();
            InitializeComponent();
        }

        private void RefreshDeals()
        {
            this.treeViewDeals.BeginUpdate();
            var oldSelected = this.treeViewDeals.SelectedNode != null ? this.treeViewDeals.SelectedNode.Tag : null;
            this.treeViewDeals.Nodes.Clear();
            foreach (var deal in this.Deals.OrderBy((d) => d.Name))
            {
                var dealNode = this.treeViewDeals.Nodes.Add(deal.Name, deal.Name, 0, 0);
                dealNode.Tag = deal;
                if (deal.Equals(oldSelected))
                    this.treeViewDeals.SelectedNode = dealNode;
                foreach (var project in deal.Projects.OrderBy((p) => p.Name))
                {
                    var projectNode = dealNode.Nodes.Add(project.Name, project.Name, 2, 2);
                    projectNode.Tag = project;
                    if (project.Equals(oldSelected))
                        this.treeViewDeals.SelectedNode = projectNode;
                }
            }
            this.treeViewDeals.EndUpdate();
        }

        private void navigationBar_SelectedPaneChanged(object sender, EventArgs e)
        {
            RefreshPanel();
        }

        private void RefreshPanel()
        {
            if (navigationBar.SelectedPane == navigationPaneDeal)
            {
                this.DisplayDeal();
            }
            else if (navigationBar.SelectedPane == navigationPaneCatalog)
            {
                if (this.CatalogDirty)
                {
                    if (MessageBox.Show("Voulez-vous sauvegarder le catalogue avant de changer?", "Sauvegarder", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                    {
                        SaveCatalog();
                        this.DealsDirty = false;
                    }
                }
                this.DisplayCatalog();
            }
        }

        private void DisplayDeal()
        {
            var oldState = DealsDirty;
            if (treeViewDeals.SelectedNode == null && treeViewDeals.Nodes.Count > 0)
                treeViewDeals.SelectedNode = treeViewDeals.Nodes[0];
            var selectedItem = treeViewDeals.SelectedNode != null ? treeViewDeals.SelectedNode.Tag : null;
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
            DealsDirty = oldState;
        }

        private void DisplayCatalog()
        {
            if (treeViewProviders.SelectedNode == null && treeViewProviders.Nodes.Count > 0)
                treeViewProviders.SelectedNode = treeViewProviders.Nodes[0];
            var selectedItem = treeViewProviders.SelectedNode != null ? treeViewProviders.SelectedNode.Tag : null;
            if (selectedItem != null)
            {
                CatalogDirty = CatalogDirty;
                var catalog = treeViewProviders.SelectedNode.Tag as SupplierCatalog;
                this.SuspendLayout();
                catalogUserControl.Visible = true;
                catalogUserControl.Catalog = catalog;
                dealUserControl.Visible = false;
                projectUserControl.Visible = false;
                this.ResumeLayout(true);
            }
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
            dealUserControl.Deal = deal;
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
                treeViewDeals.SelectedNode = FindNodeByTag(treeViewDeals, deal);
                this.navigationBar.SelectedPane = navigationPaneDeal;
                DealsDirty = true;
            }
        }

        private void projetToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var deal = treeViewDeals.SelectedNode.Tag as Deal;
            var project = treeViewDeals.SelectedNode.Tag as Project;

            // find the parent deal of the selected project
            if (project != null)
            {
                foreach (TreeNode dealNode in this.treeViewDeals.Nodes)
                {
                    foreach (TreeNode projectNode in dealNode.Nodes)
                    {
                        if (projectNode.Tag == project)
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
                treeViewDeals.SelectedNode = FindNodeByTag(treeViewDeals, project);
                this.navigationBar.SelectedPane = navigationPaneDeal;
                DealsDirty = true;
            }
        }

        private TreeNode FindNodeByTag(TreeView treeView, Object obj)
        {
            return FindNodeByTag(treeView.Nodes, obj);
        }

        private TreeNode FindNodeByTag(TreeNodeCollection collection, Object obj)
        {
            if (collection == null)
                return null;

            foreach (TreeNode node in collection)
            {
                if (node.Tag != null && node.Tag.Equals(obj))
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

        private void sauvegarderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
                SaveDealsAs();
            else
            {
                SaveCurrentDeals();
            }
        }

        private void OpenDealFile(string filePath)
        {
            if (Settings.Default.DealsRecentPath == null)
                Settings.Default.DealsRecentPath = new StringCollection();
            Settings.Default.DealsRecentPath.Remove(filePath);
            Settings.Default.DealsRecentPath.Add(filePath);
            Settings.Default.Save();

            this.filePath = filePath;
            if (this.DealRepository.Session != null)
            {
                this.DealRepository.Session.Close();
                this.DealRepository.Session = null;
            }

            if (this.DealRepository.Session == null)
            {
                var connection = new SQLiteConnection(string.Format("Data Source={0};FailIfMissing=false", this.filePath));
                connection.Open();

                if (!File.Exists(this.filePath))
                {
                    this.Configuration.Properties["hbm2ddl.auto"] = "create";
                }
                else
                {
                    this.Configuration.Properties["hbm2ddl.auto"] = "update";
                }
                this.Configuration.Properties["connection.connection_string"] = connection.ConnectionString;
                ISessionFactory sf = this.Configuration.BuildSessionFactory();
                this.DealRepository.Session = sf.OpenSession(connection);
            }
        }

        private bool SaveDeals(IEnumerable<Deal> deals)
        {
            foreach (var item in deals)
                this.DealRepository.Save(item);
            this.Deals = this.DealRepository.FindAll();

            RefreshDeals();
            DealsDirty = false;
            return true;
        }

        private bool SaveDealsAs()
        {
            if (this.saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.OpenDealFile(this.saveFileDialog.FileName);
                BuildHistory();
                return this.SaveDeals(this.Deals);
            }

            return false;
        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DealsDirty)
            {
                if (MessageBox.Show("Voulez-vous sauvegarder vos affaires avant de quitter?", "Sauvegarder", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    var saved = SaveCurrentDeals();
                    if (!saved)
                        return;
                }
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.OpenDealFile(openFileDialog.FileName);
                BuildHistory();
                this.Deals = this.DealRepository.FindAll();
                RefreshDeals();
            }
        }

        private bool SaveCurrentDeals()
        {
            Deal currentDeal = treeViewDeals.SelectedNode.Tag as Deal;
            if (currentDeal == null)
            {
                Project currentProject = treeViewDeals.SelectedNode.Tag as Project;
                if (currentProject != null)
                {
                    currentDeal = treeViewDeals.SelectedNode.Parent.Tag as Deal;
                }
            }
            return this.SaveDeals(new Deal[] { currentDeal });
        }

        private void projectUserControl_ProjectChanged(object sender, EventArgs e)
        {
            DealsDirty = true;
        }

        private void catalogueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateCatalog();
        }

        private void catalogueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateCatalog();
        }

        private void CreateCatalog()
        {
            var page = new NewCatalogPage();
            var setting = new WizardSetting(page, "Nouveau catalogue founisseur", "Création d'un nouveau catalogue fournisseur", true);
            if (new WizardForm().ShowDialog(setting) == System.Windows.Forms.DialogResult.OK)
            {
                var catalog = new SupplierCatalog();
                catalog.SupplierName = page.SupplierName;
                this.Catalog.SupplierCatalogs.Add(catalog);
                this.CatalogRepository.Save(this.Catalog);
                RefreshCatalogs();
                treeViewProviders.SelectedNode = FindNodeByTag(treeViewProviders, catalog);
                this.navigationBar.SelectedPane = navigationPaneCatalog;
            }
        }

        private void RefreshCatalogs()
        {
            treeViewProviders.BeginUpdate();
            treeViewProviders.Nodes.Clear();
            foreach (var item in this.Catalog.SupplierCatalogs)
            {
                treeViewProviders.Nodes.Add(item.SupplierName, item.SupplierName, 0, 0).Tag = item;
            }
            treeViewProviders.EndUpdate();
        }

        private void treeViewProviders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DisplayCatalog();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            BuildHistory();
            RefreshDeals();
            RefreshCatalogs();
            RefreshPanel();
        }

        private void BuildHistory()
        {
            historyToolStripMenuItem.DropDownItems.Clear();
            if (Settings.Default.DealsRecentPath != null)
            {                
                foreach (var item in Settings.Default.DealsRecentPath)
                {
                    historyToolStripMenuItem.DropDownItems.Add(new ToolStripMenuItem(item));
                    historyToolStripMenuItem.DropDown = new ToolStripDropDown();
                }
            }
            historyToolStripMenuItem.Enabled = historyToolStripMenuItem.DropDownItems.Count > 0;

            historyToolStripMenuItem.DropDownItems.Clear();
        }

        public void LoadLastDealFile()
        {
            if (Settings.Default.DealsRecentPath != null && Settings.Default.DealsRecentPath.Count > 0)
            {
                OpenDealFile(Settings.Default.DealsRecentPath[Settings.Default.DealsRecentPath.Count-1]);
                try
                {
                    this.Deals = this.DealRepository.FindAll();
                }
                catch
                {
                    this.Deals = new List<Deal>();
                }
            }
            else
            {
                this.Deals = new List<Deal>();
            }


        }

        private void treeViewProviders_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (this.DealsDirty)
            {
                if (MessageBox.Show("Voulez-vous sauvegarder le catalogue avant de changer?", "Sauvegarder", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    SaveCatalog();
                    this.DealsDirty = false;
                }
            }
        }

        private void SaveCatalog()
        {
            var found = this.catalogUserControl.Catalog;
            this.Catalog.SupplierCatalogs.Remove(found);
            this.Catalog.SupplierCatalogs.Add(this.CatalogRepository.Save(this.catalogUserControl.Catalog));
        }

        private void catalogUserControl_CatalogChanged(object sender, EventArgs e)
        {
            this.DealsDirty = true;
        }

        protected override void OnClosed(EventArgs e)
        {
            if (this.DealRepository.Session != null)
            {
                this.DealRepository.Session.Close();
            }
            base.OnClosed(e);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDealsAs();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (this.DealsDirty)
            {
                if (MessageBox.Show("Voulez-vous sauvegarder le catalogue avant de changer?", "Sauvegarder", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    SaveCatalog();
                    this.DealsDirty = false;
                }
                else
                {
                    return;
                }
            }
            this.Deals = new List<Deal>();
            this.filePath = null;
            RefreshDeals();
        }

        private void dealUserControl_OnDealChanged(object sender, EventArgs e)
        {
            this.DealsDirty = true;
        }
    }
}
