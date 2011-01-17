using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Forms;
using AutoMapper;
using Chiffrage.App.ViewModel;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Catalogs.Domain.Repositories;
using Chiffrage.Projects.Dal.Repositories;
using Chiffrage.Projects.Domain;
using Chiffrage.Properties;
using Chiffrage.WizardPages;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.ByteCode.Spring;

namespace Chiffrage
{
    public partial class FormMain : Form
    {
        private bool catalogDirty = false;
        private bool dealsDirty = false;
        private ISessionFactory dealSessionFactory;
        private string filePath = null;
        private TreeNode treeNodeCatalogs;
        private TreeNode treeNodeDeals;

        public FormMain()
        {
            this.Deals = new List<Deal>();
            this.DealRepository = new DealRepository(null);
            this.ProjectRepository = new ProjectRepository(null);
            this.InitializeComponent();

            this.treeNodeDeals = new TreeNode("Affaires");
            this.treeNodeCatalogs = new TreeNode("Catalogues");

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

            this.treeView.Nodes.AddRange(new TreeNode[]
            {
                this.treeNodeDeals,
                this.treeNodeCatalogs
            });
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

                if (deal.Projects != null)
                {
                    foreach (var project in deal.Projects.OrderBy((p) => p.Name))
                    {
                        var projectNode = new ProjectTreeNode(project);
                        dealNode.Nodes.Add(projectNode);
                    }
                }
            }

            var node = this.FindNodeOldNode(this.treeView, oldSelected);
            if (node != null) this.treeView.SelectedNode = node;
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
                this.treeNodeCatalogs.Nodes.Add(new CatalogTreeNode(item));
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

            this.CatalogDirty = this.CatalogDirty;
            SuspendLayout();
            this.catalogUserControl.Visible = true;
            this.catalogUserControl.GlobalCatalog = this.Catalog;
            //this.catalogUserControl.Catalog = new CatalogController().BuildCatalogViewModel(catalog);
            this.dealUserControl.Visible = false;
            this.projectUserControl.Visible = false;
            ResumeLayout(true);
        }

        private void DisplayProjectDetails(int projectId)
        {
            var project = this.ProjectRepository.FindById(projectId);

            SuspendLayout();
            this.catalogUserControl.Visible = false;
            this.dealUserControl.Visible = false;
            this.projectUserControl.Visible = true;
            this.projectUserControl.Catalog = this.Catalog;
            this.projectUserControl.Project = project;
            ResumeLayout(true);
        }

        private void DisplayDealDetails(int dealId)
        {
            var deal = this.DealRepository.FindById(dealId);

            SuspendLayout();
            this.catalogUserControl.Visible = false;
            this.dealUserControl.Visible = true;
            //dealUserControl.Deal = DealViewModel.Build(deal);
            this.projectUserControl.Visible = false;
            ResumeLayout(true);
        }

        private void DisplayNone()
        {
            SuspendLayout();
            this.catalogUserControl.Visible = false;
            this.dealUserControl.Visible = false;
            this.projectUserControl.Visible = false;
            ResumeLayout(true);
        }

        #endregion

        #region helpers for treeview

        private TreeNode FindNodeOldNode(TreeView view, TreeNode old)
        {
            return this.FindNodeOldNode(this.treeView.Nodes, old);
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

        #endregion

        #region save methods

        private void SaveDealsAs()
        {
            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.LoadDealFile(this.saveFileDialog.FileName);
                this.BuildHistory();

                foreach (var deal in this.Deals)
                    this.DealRepository.Save(deal);

                this.RefreshDeals();

                this.DealsDirty = false;
            }
        }

        private void SaveCurrentProject(Project project)
        {
            this.ProjectRepository.Save(project);

            this.RefreshDeals();

            this.DealsDirty = false;
        }

        private void SaveCurrentDeals(DealViewModel dealViewModel)
        {
            var currentDeal = this.DealRepository.FindById(dealViewModel.Id);

            Mapper.CreateMap<DealViewModel, Deal>();
            Mapper.Map(dealViewModel, currentDeal);

            this.DealRepository.Save(currentDeal);

            this.RefreshDeals();

            this.DealsDirty = false;
        }

        private void SaveCatalog(CatalogViewModel catalogViewModel)
        {
            var catalog = this.CatalogRepository.FindById(catalogViewModel.Id);

            Mapper.CreateMap<CatalogHardwareViewModel, Hardware>();
            Mapper.CreateMap<CatalogHardwareSupplyViewModel, HardwareSupply>();
            Mapper.CreateMap<CatalogSupplyViewModel, Supply>();
            Mapper.CreateMap<CatalogViewModel, SupplierCatalog>()
                //.ForMember(dest => dest.Supplies, opt => opt.Ignore())
                //.ForMember(dest => dest.Hardwares, opt => opt.Ignore())
                .ForMember(dest => dest.Cables, opt => opt.Ignore());
            Mapper.Map(catalogViewModel, catalog);

            this.CatalogRepository.Save(catalog);

            this.RefreshCatalogs();

            this.CatalogDirty = false;
        }

        #endregion

        #region create methods

        private void newToolStripSplitButton_ButtonClick(object sender, EventArgs e)
        {
            var pageIndex = new WizardPage();
            var setting = new WizardSetting(pageIndex, "", "", true);
            if (new WizardForm().ShowDialog(setting) == DialogResult.OK)
            {
            }
        }

        private void CreateCatalog()
        {
            var page = new NewCatalogPage();
            var setting = new WizardSetting(page, "Nouveau catalogue founisseur",
                                            "Création d'un nouveau catalogue fournisseur", true);
            if (new WizardForm().ShowDialog(setting) == DialogResult.OK)
            {
                var catalog = new SupplierCatalog();
                catalog.SupplierName = page.SupplierName;
                this.Catalog.SupplierCatalogs.Add(catalog);

                this.CatalogRepository.Save(this.Catalog);

                this.RefreshCatalogs();
                this.treeView.SelectedNode = this.FindNodeOldNode(this.treeView, new CatalogTreeNode(catalog));
                this.CatalogDirty = true;
            }
        }

        private void CreateProject()
        {
            var dealNode = this.treeView.SelectedNode as DealTreeNode;
            var deal = this.DealRepository.FindById(dealNode.DealId);

            var page = new NewProjectPage();
            var setting = new WizardSetting(page, "Nouveau projet", "Création d'un nouveau projet", true);
            if (new WizardForm().ShowDialog(setting) == DialogResult.OK)
            {
                var project = new Project();
                project.Name = page.ProjectName;
                deal.Projects.Add(project);

                this.DealRepository.Save(deal);

                var oldDeal = this.Deals.Where(d => d.Id == deal.Id).FirstOrDefault();
                this.Deals[this.Deals.IndexOf(oldDeal)] = deal;

                this.RefreshDeals();
                this.treeView.SelectedNode = this.FindNodeOldNode(this.treeView, new ProjectTreeNode(project));
                this.DealsDirty = true;
            }
        }

        private void CreateDeal()
        {
            var page = new NewDealPage();
            var setting = new WizardSetting(page, "Nouvelle affaire", "Création d'une nouvelle affaire", true);
            if (new WizardForm().ShowDialog(setting) == DialogResult.OK)
            {
                var deal = new Deal();
                deal.Name = page.DealName;

                this.DealRepository.Save(deal);

                this.Deals.Add(deal);
                this.RefreshDeals();
                this.treeView.SelectedNode = this.FindNodeOldNode(this.treeView, new DealTreeNode(deal));
                this.DealsDirty = true;
            }
        }

        #endregion

        #region load methods

        private void BuildHistory()
        {
            this.historyToolStripMenuItem.DropDownItems.Clear();
            if (Settings.Default.DealsRecentPath != null)
            {
                foreach (var item in Settings.Default.DealsRecentPath)
                {
                    this.historyToolStripMenuItem.DropDownItems.Add(new ToolStripMenuItem(item));
                    this.historyToolStripMenuItem.DropDown = new ToolStripDropDown();
                }
            }
            this.historyToolStripMenuItem.Enabled = this.historyToolStripMenuItem.DropDownItems.Count > 0;

            this.historyToolStripMenuItem.DropDownItems.Clear();
        }

        public void LoadLastDealFile()
        {
            if (Settings.Default.DealsRecentPath != null && Settings.Default.DealsRecentPath.Count > 0)
            {
                this.LoadDealFile(Settings.Default.DealsRecentPath[Settings.Default.DealsRecentPath.Count - 1]);
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

            if (this.dealSessionFactory != null)
            {
                this.dealSessionFactory.Close();
                this.dealSessionFactory = null;
            }

            var configuration = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                              .UsingFile(this.filePath)
                              .ProxyFactoryFactory(typeof (ProxyFactoryFactory)))
                .Mappings(m => m.FluentMappings.AddFromAssembly(typeof (DealRepository).Assembly))
                .BuildConfiguration();

            configuration.Properties["hbm2ddl.auto"] = "update";

            this.dealSessionFactory = configuration.BuildSessionFactory();

            this.DealRepository = new DealRepository(this.dealSessionFactory);
            this.ProjectRepository = new ProjectRepository(this.dealSessionFactory);
        }

        private void LoadDeals()
        {
            if (this.DealsDirty)
            {
                if (
                    MessageBox.Show("Voulez-vous sauvegarder vos affaires avant de quitter?", "Sauvegarder",
                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    //SaveCurrentDeals(this.dealUserControl.Deal);                    
                }
            }

            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.LoadDealFile(this.openFileDialog.FileName);
                this.BuildHistory();
                this.Deals = this.DealRepository.FindAll();
                this.RefreshDeals();
            }
        }

        #endregion

        #region events

        private void affaireToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.CreateDeal();
        }

        private void projetToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.CreateProject();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sauvegarderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.catalogUserControl.Visible == true)
            {
                //this.SaveCatalog(this.catalogUserControl.Catalog);
            }
            else if (this.projectUserControl.Visible == true)
            {
                if (string.IsNullOrEmpty(this.filePath))
                    this.SaveDealsAs();

                this.SaveCurrentProject(this.projectUserControl.Project);
            }
            else if (this.dealUserControl.Visible == true)
            {
                if (string.IsNullOrEmpty(this.filePath))
                    this.SaveDealsAs();

                //SaveCurrentDeals(this.dealUserControl.Deal);
            }
        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadDeals();
        }

        private void projectUserControl_ProjectChanged(object sender, EventArgs e)
        {
            this.DealsDirty = true;
        }

        private void catalogueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.CreateCatalog();
        }

        private void catalogueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreateCatalog();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.BuildHistory();
            this.RefreshDeals();
            this.RefreshCatalogs();
            this.RefreshPanel();
        }

        private void catalogUserControl_CatalogChanged(object sender, EventArgs e)
        {
            this.DealsDirty = true;
        }

        protected override void OnClosed(EventArgs e)
        {
            if (this.dealSessionFactory != null)
            {
                this.dealSessionFactory.Close();
            }
            base.OnClosed(e);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SaveDealsAs();
        }

        private void dealUserControl_OnDealChanged(object sender, EventArgs e)
        {
            this.DealsDirty = true;
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshCatalogs();
            this.RefreshDeals();
        }

        private void treeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // ask to save before changing the catalog
            if (this.catalogUserControl.Visible && this.CatalogDirty)
            {
                if (
                    MessageBox.Show("Voulez-vous sauvegarder le catalogue avant de changer?", "Sauvegarder",
                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    //this.SaveCatalog(this.catalogUserControl.Catalog);
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
            this.RefreshPanel();
        }

        private void toolStripMenuItemCloseDeals_Click(object sender, EventArgs e)
        {
            if (this.DealsDirty)
            {
                var result = MessageBox.Show("Voulez-vous sauvegarder le catalogue avant de changer?", "Sauvegarder",
                                             MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //this.SaveCurrentDeals(this.dealUserControl.Deal);
                    this.DealsDirty = false;
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            this.Deals = new List<Deal>();
            this.filePath = null;
            this.RefreshDeals();
        }

        #endregion

        public DealRepository DealRepository { get; set; }

        public ProjectRepository ProjectRepository { get; set; }

        public bool DealsDirty
        {
            get { return this.dealsDirty; }
            set
            {
                this.dealsDirty = value;
                this.saveToolStripMenuItem.Enabled = this.dealsDirty;
                this.saveToolStripButton.Enabled = this.dealsDirty;
            }
        }

        public bool CatalogDirty
        {
            get { return this.catalogDirty; }
            set
            {
                this.catalogDirty = value;
                this.saveToolStripMenuItem.Enabled = this.catalogDirty;
                this.saveToolStripButton.Enabled = this.catalogDirty;
            }
        }

        public ICatalogRepository CatalogRepository { get; set; }

        public IList<Deal> Deals { get; set; }

        public Catalog Catalog { get; set; }
    }
}