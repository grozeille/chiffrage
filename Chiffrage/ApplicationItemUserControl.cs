using System;
using System.Windows.Forms;
using Chiffrage.App.Events;
using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Views;

namespace Chiffrage
{
    public partial class ApplicationItemUserControl : UserControlView, IApplicationView
    {
        private readonly IEventBroker eventBroker;
        private readonly TreeNode treeNodeCatalogs;
        private readonly TreeNode treeNodeDeals;

        public ApplicationItemUserControl(IEventBroker eventBroker)
            : this()
        {
            this.eventBroker = eventBroker;
        }

        public ApplicationItemUserControl()
        {
            this.InitializeComponent();

            this.treeNodeDeals = this.treeView.Nodes[0];
            this.treeNodeCatalogs = this.treeView.Nodes[1];
        }

        #region IApplicationView Members

        public void Display(ApplicationItemViewModel viewModel)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<ApplicationItemViewModel>(this.Display), viewModel);
                return;
            }

            this.treeView.BeginUpdate();

            this.treeNodeDeals.Nodes.Clear();
            this.treeNodeCatalogs.Nodes.Clear();

            foreach (var deal in viewModel.Deals)
            {
                var nodeDeal = this.treeNodeDeals.Nodes.Add("deal_" + deal.Id, deal.Name, "user_suit.png",
                                                            "user_suit.png");
                nodeDeal.Tag = deal;
                this.eventBroker.RegisterTreeNodeSelectEventSource(nodeDeal, new DealSelectedEvent(deal.Id));
                this.eventBroker.RegisterTreeNodeUnselectEventSource(nodeDeal, new DealUnselectedEvent(deal.Id));

                foreach (var project in deal.Projects)
                {
                    var nodeProject = nodeDeal.Nodes.Add("project_" + project.Id, project.Name, "book_open.png",
                                                         "book_open.png");
                    nodeProject.Tag = project;
                    this.eventBroker.RegisterTreeNodeSelectEventSource(nodeDeal, new ProjectSelectedEvent(project.Id));
                    this.eventBroker.RegisterTreeNodeUnselectEventSource(nodeDeal,
                                                                         new ProjectUnselectedEvent(project.Id));
                }
            }
            this.treeNodeDeals.ExpandAll();

            foreach (var catalog in viewModel.Catalogs)
            {
                var nodeCatalog = this.treeNodeCatalogs.Nodes.Add("catalog_" + catalog.Id, catalog.SupplierName,
                                                                  "table.png", "table.png");
                nodeCatalog.Tag = catalog;
                this.eventBroker.RegisterTreeNodeSelectEventSource(nodeCatalog, new CatalogSelectedEvent(catalog.Id));
                this.eventBroker.RegisterTreeNodeUnselectEventSource(nodeCatalog, new CatalogUnselectedEvent(catalog.Id));
            }
            this.treeNodeCatalogs.ExpandAll();

            this.treeView.EndUpdate();
        }

        #endregion
    }
}