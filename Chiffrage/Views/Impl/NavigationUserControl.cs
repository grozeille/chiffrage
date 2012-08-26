using System.Windows.Forms;
using Chiffrage.App.Events;
using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Views;
using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Catalogs.Module.ViewModel;
using Chiffrage.Projects.Module.Actions;
using Chiffrage.Catalogs.Module.Actions;
using System.Drawing;

namespace Chiffrage
{
    public partial class NavigationUserControl : UserControlView, INavigationView
    {
        private readonly IEventBroker eventBroker;
        private readonly TreeNode treeNodeCatalogs;
        private readonly TreeNode treeNodeDeals;

        public NavigationUserControl(IEventBroker eventBroker)
            : this()
        {
            this.eventBroker = eventBroker;
            this.eventBroker.RegisterToolStripMenuItemClickEventSource(this.toolStripMenuItemNewCatalog, new RequestNewCatalogAction());
            this.eventBroker.RegisterToolStripMenuItemClickEventSource(this.toolStripMenuItemNewDeal, new RequestNewDealAction());
            this.eventBroker.RegisterToolStripMenuItemClickEventSource(this.toolStripMenuItemNewProject, () =>
            {
                if (this.treeView.SelectedNode != null)
                {
                    var deal = this.treeView.SelectedNode.Tag as DealItemViewModel;
                    if (deal != null)
                    {
                        return new RequestNewProjectAction(deal.Id);
                    }
                }

                return null;
            });
        }

        public NavigationUserControl()
        {
            this.InitializeComponent();

            this.treeNodeDeals = this.treeView.Nodes[0];
            this.treeNodeCatalogs = this.treeView.Nodes[1];
        }

        public void Display(NavigationItemViewModel viewModel)
        {
            InvokeIfRequired(() =>
            {
                this.treeView.BeginUpdate();

                this.treeNodeDeals.Nodes.Clear();
                this.treeNodeCatalogs.Nodes.Clear();

                foreach (var deal in viewModel.Deals)
                {
                    this.AddDeal(deal);
                }
                this.treeNodeDeals.ExpandAll();

                foreach (var catalog in viewModel.Catalogs)
                {
                    this.AddCatalog(catalog);
                }
                this.treeNodeCatalogs.ExpandAll();

                this.treeView.EndUpdate();
            });
        }

        public void UpdateCatalog(CatalogItemViewModel viewModel)
        {
            InvokeIfRequired(() =>
            {
                this.treeView.BeginUpdate();

                var node = this.GetCatalogTreeNode(viewModel.Id);
                node.Text = viewModel.SupplierName;
                node.Tag = viewModel;

                this.treeView.EndUpdate();
            });
        }

        public void UpdateDeal(DealItemViewModel viewModel)
        {
            InvokeIfRequired(() =>
            {
                this.treeView.BeginUpdate();

                var node = this.GetDealTreeNode(viewModel.Id);
                node.Text = viewModel.Name;
                node.Tag = viewModel;

                this.treeView.EndUpdate();
            });
        }

        public void UpdateProject(ProjectItemViewModel viewModel)
        {
            InvokeIfRequired(() =>
            {
                this.treeView.BeginUpdate();

                var node = this.GetProjectTreeNode(viewModel.Id);
                node.Text = viewModel.Name;
                node.Tag = viewModel;

                this.treeView.EndUpdate();
            });
        }

        public void AddDeal(DealItemViewModel viewModel)
        {
            InvokeIfRequired(() =>
            {
                var nodeDeal = this.treeNodeDeals.Nodes.Add("deal_" + viewModel.Id, viewModel.Name, "user_suit.png",
                                                            "user_suit.png");
                nodeDeal.Tag = viewModel;
                nodeDeal.ContextMenuStrip = this.contextMenuStripDeal;

                this.eventBroker.RegisterTreeNodeSelectEventSource(nodeDeal, new DealSelectedAction(viewModel.Id));
                this.eventBroker.RegisterTreeNodeUnselectEventSource(nodeDeal, new DealUnselectedAction(viewModel.Id));

                foreach (var project in viewModel.Projects)
                {
                    this.AddProject(nodeDeal, project);
                }
            });
        }

        public void AddCatalog(CatalogItemViewModel viewModel)
        {
            InvokeIfRequired(() =>
            {
                var nodeCatalog = this.treeNodeCatalogs.Nodes.Add("catalog_" + viewModel.Id, viewModel.SupplierName,
                                                                  "book_open.png", "book_open.png");
                nodeCatalog.Tag = viewModel;

                this.eventBroker.RegisterTreeNodeSelectEventSource(nodeCatalog, new CatalogSelectedAction(viewModel.Id));
                this.eventBroker.RegisterTreeNodeUnselectEventSource(nodeCatalog, new CatalogUnselectedAction(viewModel.Id));
            });
        }

        public void AddProject(int dealId, ProjectItemViewModel viewModel)
        {
            InvokeIfRequired(() =>
            {
                var node = this.GetDealTreeNode(dealId);
                this.AddProject(node, viewModel);
            });
        }

        public void SelectDeal(int dealId)
        {
            InvokeIfRequired(() =>
            {
                this.treeView.SelectedNode = this.GetDealTreeNode(dealId);
                if (this.treeView.SelectedNode != null)
                    this.treeView.SelectedNode.EnsureVisible();
            });
        }

        public void SelectCatalog(int catalogId)
        {
            InvokeIfRequired(() =>
            {
                this.treeView.SelectedNode = this.GetCatalogTreeNode(catalogId);
                if (this.treeView.SelectedNode != null)
                    this.treeView.SelectedNode.EnsureVisible();
            });
        }

        public void SelectProject(int projectId)
        {
            InvokeIfRequired(() =>
            {
                this.treeView.SelectedNode = this.GetProjectTreeNode(projectId);
                if (this.treeView.SelectedNode != null)
                    this.treeView.SelectedNode.EnsureVisible();
            });
        }

        private TreeNode GetProjectTreeNode(int projectId)
        {
            foreach (TreeNode item in this.treeNodeDeals.Nodes)
            {
                foreach (TreeNode subItem in item.Nodes)
                {
                    var project = subItem.Tag as ProjectItemViewModel;
                    if (project != null && project.Id == projectId)
                    {
                        return subItem;
                    }
                }
            }

            return null;
        }

        private TreeNode GetDealTreeNode(int dealId)
        {
            foreach (TreeNode item in this.treeNodeDeals.Nodes)
            {
                var deal = item.Tag as DealItemViewModel;
                if (deal != null && deal.Id == dealId)
                {
                    return item;
                }
            }

            return null;
        }

        private TreeNode GetCatalogTreeNode(int catalogId)
        {
            foreach (TreeNode item in this.treeNodeCatalogs.Nodes)
            {
                var catalog = item.Tag as CatalogItemViewModel;
                if (catalog != null && catalog.Id == catalogId)
                {
                    return item;
                }
            }

            return null;
        }

        protected void AddProject(TreeNode nodeDeal, ProjectItemViewModel viewModel)
        {
            InvokeIfRequired(() =>
            {
                var nodeProject = nodeDeal.Nodes.Add("project_" + viewModel.Id, viewModel.Name, "report.png",
                                                     "report.png");
                nodeProject.Tag = viewModel;

                this.eventBroker.RegisterTreeNodeSelectEventSource(nodeProject, new ProjectSelectedAction(viewModel.Id));
                this.eventBroker.RegisterTreeNodeUnselectEventSource(nodeProject, new ProjectUnselectedAction(viewModel.Id));
            });
        }

        private void NavigationUserControl_Load(object sender, System.EventArgs e)
        {
            this.SetDoubleBuffered();
        }
    }
}