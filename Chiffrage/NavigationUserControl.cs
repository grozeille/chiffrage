using System.Linq;
using System;
using System.Windows.Forms;
using Chiffrage.App.Events;
using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Views;

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
            this.eventBroker.RegisterToolStripMenuItemClickEventSource(this.toolStripMenuItemNewCatalog, new NewCatalogEvent());
            this.eventBroker.RegisterToolStripMenuItemClickEventSource(this.toolStripMenuItemNewDeal, new NewDealEvent());
            this.eventBroker.RegisterToolStripMenuItemClickEventSource(this.toolStripMenuItemNewProject, () => 
                {
                    if(this.treeView.SelectedNode != null)
                    {
                        var deal = this.treeView.SelectedNode.Tag as DealItemViewModel;
                        if(deal != null)
                        {
                            return new NewProjectEvent(deal.Id);
                        }
                    }

                    return null;           
                } );
        }

        public NavigationUserControl()
        {
            this.InitializeComponent();

            this.treeNodeDeals = this.treeView.Nodes[0];
            this.treeNodeCatalogs = this.treeView.Nodes[1];
        }

        #region IApplicationView Members

        public void Display(NavigationItemViewModel viewModel)
        {
            this.InvokeIfRequired(() =>
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
                    var nodeCatalog = this.treeNodeCatalogs.Nodes.Add("catalog_" + catalog.Id, catalog.SupplierName,
                                                                      "book_open.png", "book_open.png");
                    nodeCatalog.Tag = catalog;

                    this.eventBroker.RegisterTreeNodeSelectEventSource(nodeCatalog, new CatalogSelectedEvent(catalog.Id));
                    this.eventBroker.RegisterTreeNodeUnselectEventSource(nodeCatalog, new CatalogUnselectedEvent(catalog.Id));
                }
                this.treeNodeCatalogs.ExpandAll();

                this.treeView.EndUpdate();
            });
        }

        public void UpdateCatalog(CatalogItemViewModel viewModel)
        {
            this.InvokeIfRequired(() =>
            {
                this.treeView.BeginUpdate();

                foreach(TreeNode node in this.treeNodeCatalogs.Nodes)
                {
                    var catalogViewModel = (CatalogItemViewModel)node.Tag;
                    if(catalogViewModel.Id == viewModel.Id)
                    {
                        node.Text = viewModel.SupplierName;
                        node.Tag = viewModel;
                        break;                        
                    }
                }

                this.treeView.EndUpdate();
            });
        }

        public void UpdateDeal(DealItemViewModel viewModel)
        {
            this.InvokeIfRequired(() =>
            {
                this.treeView.BeginUpdate();

                foreach (TreeNode node in this.treeNodeDeals.Nodes)
                {
                    var dealViewModel = (DealItemViewModel)node.Tag;
                    if (dealViewModel.Id == viewModel.Id)
                    {
                        node.Text = viewModel.Name;
                        node.Tag = viewModel;
                        break;
                    }
                }

                this.treeView.EndUpdate();
            });
        }

        public void AddDeal(DealItemViewModel viewModel)
        {
            this.InvokeIfRequired(() =>
            {
                var nodeDeal = this.treeNodeDeals.Nodes.Add("deal_" + viewModel.Id, viewModel.Name, "user_suit.png",
                                                            "user_suit.png");
                nodeDeal.Tag = viewModel;
                nodeDeal.ContextMenuStrip = this.contextMenuStripDeal;

                this.eventBroker.RegisterTreeNodeSelectEventSource(nodeDeal, new DealSelectedEvent(viewModel.Id));
                this.eventBroker.RegisterTreeNodeUnselectEventSource(nodeDeal, new DealUnselectedEvent(viewModel.Id));

                foreach (var project in viewModel.Projects)
                {
                    var nodeProject = nodeDeal.Nodes.Add("project_" + project.Id, project.Name, "report.png",
                                                         "report.png");
                    nodeProject.Tag = project;

                    this.eventBroker.RegisterTreeNodeSelectEventSource(nodeProject, new ProjectSelectedEvent(project.Id));
                    this.eventBroker.RegisterTreeNodeUnselectEventSource(nodeProject, new ProjectUnselectedEvent(project.Id));
                }
            });
        }

        #endregion
    }
}