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
using Common.Logging;
using Chiffrage.Projects.Domain.Commands;
using Chiffrage.Catalogs.Domain.Commands;

namespace Chiffrage
{
    public partial class NavigationUserControl : UserControlView, INavigationView
    {
        private static ILog logger = LogManager.GetLogger(typeof(NavigationUserControl));

        private readonly IEventBroker eventBroker;
        private readonly TreeNode treeNodeCatalogs;
        private readonly TreeNode treeNodeTasks;
        private readonly TreeNode treeNodeDeals;

        public NavigationUserControl(IEventBroker eventBroker)
            : this()
        {
            this.eventBroker = eventBroker;
            this.eventBroker.RegisterToolStripMenuItemClickEventSource(this.toolStripMenuItemCatalogNew, new RequestNewCatalogAction(), "topic://UI");
            this.eventBroker.RegisterToolStripMenuItemClickEventSource(this.toolStripMenuItemDealNew, new RequestNewDealAction(), "topic://UI");
            this.eventBroker.RegisterTreeNodeSelectEventSource(this.treeNodeTasks, new TasksSelectedAction(), "topic://UI");
            this.eventBroker.RegisterTreeNodeUnselectEventSource(this.treeNodeTasks, new TasksUnselectedAction(), "topic://UI");
            this.eventBroker.RegisterToolStripMenuItemClickEventSource(this.toolStripMenuItemProjectNew, () =>
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
            }, "topic://UI");
            this.eventBroker.RegisterToolStripMenuItemClickEventSource(this.toolStripMenuItemDealClone, () =>
            {
                if (this.treeView.SelectedNode != null)
                {
                    var deal = this.treeView.SelectedNode.Tag as DealItemViewModel;
                    if (deal != null)
                    {
                        return new CloneDealCommand(deal.Id);
                    }
                }

                return null;
            }, "topic://commands");
            this.eventBroker.RegisterToolStripMenuItemClickEventSource(this.toolStripMenuItemDealDelete, () =>
            {
                if (this.treeView.SelectedNode != null)
                {
                    var deal = this.treeView.SelectedNode.Tag as DealItemViewModel;
                    if (deal != null)
                    {
                        if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette affaire?", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            return new DeleteDealCommand(deal.Id);
                        }
                    }
                }

                return null;
            }, "topic://commands");


            this.eventBroker.RegisterToolStripMenuItemClickEventSource(this.toolStripMenuItemProjectClone, () =>
            {
                if (this.treeView.SelectedNode != null)
                {
                    var deal = this.treeView.SelectedNode.Parent.Tag as DealItemViewModel;
                    var project = this.treeView.SelectedNode.Tag as ProjectItemViewModel;
                    if (deal != null && project != null)
                    {
                        return new CloneProjectCommand(deal.Id, project.Id);
                    }
                }

                return null;
            }, "topic://commands");
            this.eventBroker.RegisterToolStripMenuItemClickEventSource(this.toolStripMenuItemProjectDelete, () =>
            {
                if (this.treeView.SelectedNode != null)
                {
                    var deal = this.treeView.SelectedNode.Parent.Tag as DealItemViewModel;
                    var project = this.treeView.SelectedNode.Tag as ProjectItemViewModel;
                    if (deal != null && project != null)
                    {
                        if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet projet?", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            return new DeleteProjectCommand(deal.Id, project.Id);
                        }
                    }
                }

                return null;
            }, "topic://commands");

            this.eventBroker.RegisterToolStripMenuItemClickEventSource(this.toolStripMenuItemCatalogClone, () =>
            {
                if (this.treeView.SelectedNode != null)
                {
                    var catalog = this.treeView.SelectedNode.Tag as CatalogItemViewModel;
                    if (catalog != null)
                    {
                        return new CopyCatalogCommand(catalog.Id);
                    }
                }

                return null;
            }, "topic://commands");
            this.eventBroker.RegisterToolStripMenuItemClickEventSource(this.toolStripMenuItemCatalogDelete, () =>
            {
                if (this.treeView.SelectedNode != null)
                {
                    var catalog = this.treeView.SelectedNode.Tag as CatalogItemViewModel;
                    if (catalog != null)
                    {
                        if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce catalogue?", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            return new DeleteCatalogCommand(catalog.Id);
                        }
                    }
                }

                return null;
            }, "topic://commands");
            this.eventBroker.RegisterToolStripMenuItemClickEventSource(this.toolStripMenuItemProjectCopy, () =>
            {
                if (this.treeView.SelectedNode != null)
                {
                    var project = this.treeView.SelectedNode.Tag as ProjectItemViewModel;
                    if (project != null)
                    {
                        return new ProjectCopyAction(project.Id);
                    }
                }

                return null;
            }, "topic://UI");
            this.eventBroker.RegisterToolStripMenuItemClickEventSource(this.toolStripMenuItemProjectPaste, () =>
            {
                if (this.treeView.SelectedNode != null)
                {
                    var deal = this.treeView.SelectedNode.Tag as DealItemViewModel;
                    if (deal != null)
                    {
                        return new ProjectPasteAction(deal.Id);
                    }
                }

                return null;
            }, "topic://UI");
        }

        public NavigationUserControl()
        {
            this.InitializeComponent();

            this.treeNodeDeals = this.treeView.Nodes[0];
            this.treeNodeCatalogs = this.treeView.Nodes[1];
            this.treeNodeTasks = this.treeView.Nodes[2];
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

                this.eventBroker.RegisterTreeNodeSelectEventSource(nodeDeal, new DealSelectedAction(viewModel.Id), "topic://UI");
                this.eventBroker.RegisterTreeNodeUnselectEventSource(nodeDeal, new DealUnselectedAction(viewModel.Id), "topic://UI");

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
                nodeCatalog.ContextMenuStrip = this.contextMenuStripCatalog;

                this.eventBroker.RegisterTreeNodeSelectEventSource(nodeCatalog, new CatalogSelectedAction(viewModel.Id), "topic://UI");
                this.eventBroker.RegisterTreeNodeUnselectEventSource(nodeCatalog, new CatalogUnselectedAction(viewModel.Id), "topic://UI");
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
                nodeProject.ContextMenuStrip = this.contextMenuStripProject;

                this.eventBroker.RegisterTreeNodeSelectEventSource(nodeProject, new ProjectSelectedAction(viewModel.Id), "topic://UI");
                this.eventBroker.RegisterTreeNodeUnselectEventSource(nodeProject, new ProjectUnselectedAction(viewModel.Id), "topic://UI");
            });
        }

        public void RemoveDeal(int dealId)
        {
            InvokeIfRequired(() =>
            {
                this.treeView.BeginUpdate();

                var node = this.GetDealTreeNode(dealId);

                this.treeNodeDeals.Nodes.Remove(node);

                this.treeView.EndUpdate();
            });
        }

        public void RemoveProject(int dealId, int projectId)
        {
            InvokeIfRequired(() =>
            {
                this.treeView.BeginUpdate();

                var dealNode = this.GetDealTreeNode(dealId);

                var node = this.GetProjectTreeNode(projectId);

                dealNode.Nodes.Remove(node);

                this.treeView.EndUpdate();
            });
        }

        public void RemoveCatalog(int catalogId)
        {
            InvokeIfRequired(() =>
            {
                this.treeView.BeginUpdate();

                var node = this.GetCatalogTreeNode(catalogId);

                this.treeNodeCatalogs.Nodes.Remove(node);

                this.treeView.EndUpdate();
            });
        }

        private void NavigationUserControl_Load(object sender, System.EventArgs e)
        {
            this.SetDoubleBuffered();

            this.treeView.SetDoubleBuffered();
        }

        private void treeView_MouseDown(object sender, MouseEventArgs e)
        {
            /*var hitTest = this.treeView.HitTest(this.treeView.PointToClient(e.Location));
            if (hitTest.Node != null)
            {
                 this.treeView.SelectedNode = hitTest.Node;
            }*/
            var node = this.treeView.GetNodeAt(e.X, e.Y);
            if (node != null)
            {
                this.treeView.SelectedNode = node;
            }
        }
    }
}