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
using Chiffrage.Catalogs.Domain;
using Chiffrage.Catalogs.Domain.Repositories;
using Chiffrage.Core;
using Chiffrage.Projects.Domain;
using Chiffrage.Repositories;
using Chiffrage.WizardPages;
using NHibernate;
using NHibernate.Cfg;
using Settings = Chiffrage.Properties.Settings;
using Chiffrage.ViewModel;

namespace Chiffrage
{
    public partial class FormMain : Form
    {
        public Configuration Configuration { get; set; }

        public DealRepository DealRepository { get; set; }

        public ProjectRepository ProjectRepository { get; set; }

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
        private TreeNode treeNodeCatalogs;
        private TreeNode treeNodeDeals;

        public IList<Deal> Deals { get; set; }

        public FormMain()
        {
            Deals = new List<Deal>();
            this.DealRepository = new DealRepository();
            this.ProjectRepository = new ProjectRepository();
            InitializeComponent();

            this.treeNodeDeals = new System.Windows.Forms.TreeNode("Affaires");
            this.treeNodeCatalogs = new System.Windows.Forms.TreeNode("Catalogues");

            this.treeNodeDeals.ImageKey = "folder_user.png";
            this.treeNodeDeals.Name = "NodeDeals";
            this.treeNodeDeals.SelectedImageKey = "folder_user.png";
            this.treeNodeDeals.Text = "Affaires";
            this.treeNodeDeals.ContextMenuStrip = this.contextMenuStripDealsRoot;

            this.treeNodeCatalogs.ImageKey = "folder_table.png";
            this.treeNodeCatalogs.Name = "NodeCatalogs";
            this.treeNodeCatalogs.SelectedImageKey = "folder_table.png";
            this.treeNodeCatalogs.Text = "Catalogues";
            this.treeNodeCatalogs.ContextMenuStrip = this.contextMenuStripCatalogsRoot;

            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            this.treeNodeDeals,
            this.treeNodeCatalogs});
        }

        #region refresh data in treeview
        private void RefreshDeals()
        {
            this.treeView.BeginUpdate();
            
            // keep in memory the selected node
            var oldSelected = this.treeView.SelectedNode;

            // delete all deals
            this.treeNodeDeals.Nodes.Clear();

            // load all deals
            foreach (var deal in this.Deals.OrderBy((d) => d.Name))
            {
                var dealNode = new DealTreeNode(deal);
                this.treeNodeDeals.Nodes.Add(dealNode);
                dealNode.ContextMenuStrip = this.contextMenuStripDeal;

                foreach (var project in deal.Projects.OrderBy((p) => p.Name))
                {
                    var projectNode = new ProjectTreeNode(project);
                    dealNode.Nodes.Add(projectNode);                    
                }
            }

            var node = this.FindNodeOldNode(this.treeView, oldSelected);
            if(node != null) this.treeView.SelectedNode = node;
            this.treeNodeDeals.Expand();
            this.treeView.EndUpdate();
        }       

        private void RefreshCatalogs()
        {
            this.treeView.BeginUpdate();

            // keep in memory the selected node
            var oldSelected = this.treeView.SelectedNode;

            // delete all catalogs
            this.treeNodeCatalogs.Nodes.Clear();

            // load all catalogs
            foreach (var item in this.Catalog.SupplierCatalogs)
            {
                treeNodeCatalogs.Nodes.Add(new CatalogTreeNode(item));
            }

            var node = this.FindNodeOldNode(this.treeView, oldSelected);
            if (node != null) this.treeView.SelectedNode = node;            
            this.treeNodeCatalogs.Expand();
            this.treeView.EndUpdate();
        }

        private void RefreshPanel()
        {
            if (this.treeView.SelectedNode == null)
                this.DisplayNone();
            else if (this.treeView.SelectedNode == this.treeNodeDeals)
                this.DisplayNone();
            else if (this.treeView.SelectedNode == this.treeNodeCatalogs)
                this.DisplayNone();
            else
            {
                if (this.treeView.SelectedNode is DealTreeNode)
                    this.DisplayDealDetails((this.treeView.SelectedNode as DealTreeNode).DealId);
                else if (this.treeView.SelectedNode is ProjectTreeNode)
                    this.DisplayProjectDetails((this.treeView.SelectedNode as ProjectTreeNode).ProjectId);
                else if (this.treeView.SelectedNode is CatalogTreeNode)
                    this.DisplayCatalog((this.treeView.SelectedNode as CatalogTreeNode).CatalogId);
            }
        }
        #endregion

        #region display details in panel
        private void DisplayCatalog(int catalogId)
        {
            var catalog = this.CatalogRepository.FindById(catalogId);

            CatalogDirty = CatalogDirty;
            this.SuspendLayout();
            catalogUserControl.Visible = true;
            catalogUserControl.Catalog = catalog;
            dealUserControl.Visible = false;
            projectUserControl.Visible = false;
            this.ResumeLayout(true);
        }

        private void DisplayProjectDetails(int projectId)
        {
            var project = this.ProjectRepository.FindById(projectId);

            this.SuspendLayout();
            catalogUserControl.Visible = false;
            dealUserControl.Visible = false;
            projectUserControl.Visible = true;
            projectUserControl.Catalog = Catalog;
            projectUserControl.Project = project;
            this.ResumeLayout(true);
        }

        private void DisplayDealDetails(int dealId)
        {
            var deal = this.DealRepository.FindById(dealId);

            this.SuspendLayout();
            catalogUserControl.Visible = false;
            dealUserControl.Visible = true;
            dealUserControl.Deal = DealViewModel.Build(deal);
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
        #endregion

        #region Getter for selected object
        private Project SelectedProject
        {
            get
            {
                return treeView.SelectedNode == null ? null : treeView.SelectedNode.Tag as Project;
            }
        }

        private SupplierCatalog SelectedSupplierCatalog
        {
            get
            {
                return treeView.SelectedNode == null ? null : treeView.SelectedNode.Tag as SupplierCatalog;
            }
        }

        private Deal SelectedDeal
        {
            get
            {
                var deal = treeView.SelectedNode == null ? null : treeView.SelectedNode.Tag as Deal;
                var project = treeView.SelectedNode == null ? null : treeView.SelectedNode.Tag as Project;

                // find the parent deal of the selected project
                if (project != null)
                {
                    foreach (TreeNode dealNode in this.treeNodeDeals.Nodes)
                    {
                        foreach (TreeNode projectNode in dealNode.Nodes)
                        {
                            if (projectNode.Tag == project)
                                deal = dealNode.Tag as Deal;
                        }
                    }
                }
                return deal;
            }
        }
        #endregion

        #region helpers for treeview
        private void SelectNode(object o)
        {
            var node = this.FindNodeByTag(this.treeView, o);
            if (node != null)
                this.treeView.SelectedNode = node;
        }

        private TreeNode FindNodeOldNode(TreeView view, TreeNode old)
        {
            return FindNodeOldNode(treeView.Nodes, old);
        }

        private TreeNode FindNodeOldNode(TreeNodeCollection collection, TreeNode old)
        {
            if (collection == null)
                return null;

            foreach (TreeNode node in collection)
            {
                if (node.Equals(old))
                {
                    return node;
                }
                else
                {
                    var child = FindNodeOldNode(node.Nodes, old);
                    if (child != null)
                        return child;
                }
            }

            return null;
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
        #endregion
       
        #region save methods
        private bool SaveDeals(IEnumerable<Deal> deals)
        {
            foreach (var item in deals)
                this.DealRepository.Save(item);
            // get the selected id
            int? selectedProjectId = this.SelectedProject != null ? (int?)this.SelectedProject.Id : null;
            int? selectedDealId = this.SelectedDeal != null ? (int?)this.SelectedDeal.Id : null;
            this.Deals = this.DealRepository.FindAll();

            RefreshDeals();

            if(selectedProjectId.HasValue)
            {
                var selectedProject = this.Deals.SelectMany((d) => d.Projects).Where((p) => p.Id == selectedProjectId.Value).FirstOrDefault();

                this.SelectNode(selectedProject);
            }
            else if(selectedDealId.HasValue)
            {
                var selectedDeal = this.Deals.Where((d) => d.Id == selectedDealId.Value).FirstOrDefault();

                this.SelectNode(selectedDeal);
            }
            
            DealsDirty = false;
            return true;
        }

        private bool SaveDealsAs()
        {
            if (this.saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.LoadDealFile(this.saveFileDialog.FileName);
                BuildHistory();
                return this.SaveDeals(this.Deals);
            }

            return false;
        }

        private bool SaveCurrentDeals()
        {
            Deal currentDeal = treeView.SelectedNode.Tag as Deal;
            if (currentDeal == null)
            {
                Project currentProject = treeView.SelectedNode.Tag as Project;
                if (currentProject != null)
                {
                    currentDeal = treeView.SelectedNode.Parent.Tag as Deal;
                }
            }
            return this.SaveDeals(new Deal[] { currentDeal });
        }

        private void SaveCatalog(SupplierCatalog catalog)
        {
            this.CatalogRepository.Save(catalog);

            RefreshCatalogs();

            var selectedCatalog = this.Catalog.SupplierCatalogs.Where((c) => c.Id == catalog.Id).FirstOrDefault();
            this.SelectNode(selectedCatalog);
            
            CatalogDirty = false;            
        }
        #endregion

        #region create methods



        private void newToolStripSplitButton_ButtonClick(object sender, EventArgs e)
        {
            var pageIndex = new WizardPage();
            var setting = new WizardSetting(pageIndex, "", "", true);
            if (new WizardForm().ShowDialog(setting) == System.Windows.Forms.DialogResult.OK)
            {
            }
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
                treeView.SelectedNode = FindNodeByTag(treeView, catalog);
            }
        }

        private void CreateProject()
        {
            Deal deal = this.SelectedDeal;

            var page = new NewProjectPage();
            var setting = new WizardSetting(page, "Nouveau projet", "Création d'un nouveau projet", true);
            if (new WizardForm().ShowDialog(setting) == System.Windows.Forms.DialogResult.OK)
            {
                Project project = new Project();
                project.Name = page.ProjectName;
                deal.Projects.Add(project);
                RefreshDeals();
                treeView.SelectedNode = FindNodeByTag(treeView, project);
                DealsDirty = true;
            }
        }

        private void CreateDeal()
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
                DealsDirty = true;
            }
        }
        #endregion

        #region load methods
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
                LoadDealFile(Settings.Default.DealsRecentPath[Settings.Default.DealsRecentPath.Count - 1]);
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

        private void LoadDealFile(string filePath)
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
                this.ProjectRepository.Session = sf.OpenSession(connection);
            }
        }

        private void LoadDeal()
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
                this.LoadDealFile(openFileDialog.FileName);
                BuildHistory();
                this.Deals = this.DealRepository.FindAll();
                RefreshDeals();
            }
        }
        #endregion

        #region events

        private void affaireToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CreateDeal();
        }

        private void projetToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CreateProject();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sauvegarderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SelectedSupplierCatalog != null)
            {
                SaveCatalog(this.SelectedSupplierCatalog);
            }
            else if (this.SelectedDeal != null)
            {
                if (string.IsNullOrEmpty(filePath))
                    SaveDealsAs();
                else
                {
                    SaveCurrentDeals();
                }
            }
        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDeal();            
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

        private void FormMain_Load(object sender, EventArgs e)
        {
            BuildHistory();
            RefreshDeals();
            RefreshCatalogs();
            RefreshPanel();
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

        private void dealUserControl_OnDealChanged(object sender, EventArgs e)
        {
            this.DealsDirty = true;
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            if (this.SelectedSupplierCatalog != null)
            {
                RefreshCatalogs();
            }
            else if (this.SelectedDeal != null)
            {
                RefreshDeals();
            }
        }

        private void treeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // ask to save before changing the catalog
            if (this.SelectedSupplierCatalog != null && this.CatalogDirty)
            {
                if (MessageBox.Show("Voulez-vous sauvegarder le catalogue avant de changer?", "Sauvegarder", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    SaveCatalog(this.SelectedSupplierCatalog);
                    this.CatalogDirty = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RefreshPanel();
        }

        private void toolStripMenuItemCloseDeals_Click(object sender, EventArgs e)
        {
            if (this.DealsDirty)
            {
                var result = MessageBox.Show("Voulez-vous sauvegarder le catalogue avant de changer?", "Sauvegarder",
                                             MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    this.SaveCurrentDeals();
                    this.DealsDirty = false;
                }
                else if(result == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

            }
            this.Deals = new List<Deal>();
            this.filePath = null;
            RefreshDeals();
        }
        #endregion
    }
}
