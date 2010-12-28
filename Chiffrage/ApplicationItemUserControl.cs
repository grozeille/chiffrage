using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using Chiffrage.App.Events;

namespace Chiffrage
{
    public partial class ApplicationItemUserControl : UserControlView, IApplicationView        
    {
        private readonly TreeNode treeNodeDeals;

        private readonly TreeNode treeNodeCatalogs;

        private readonly IEventBroker eventBroker;

        public ApplicationItemUserControl(IEventBroker eventBroker)
            : this()
        {
            this.eventBroker = eventBroker;
        }

        public ApplicationItemUserControl()
        {
            InitializeComponent();

            this.treeNodeDeals = this.treeView.Nodes[0];
            this.treeNodeCatalogs = this.treeView.Nodes[1];
        }

        #region IApplicationView Members

        public void Display(Chiffrage.App.ViewModel.ApplicationItemViewModel viewModel)
        {
            if(this.InvokeRequired)
            {
                this.BeginInvoke(new Action<ApplicationItemViewModel>(this.Display), viewModel);
                return;
            }

            this.treeView.BeginUpdate();

            this.treeNodeDeals.Nodes.Clear();
            this.treeNodeCatalogs.Nodes.Clear();

            foreach(var deal in viewModel.Deals)
            {
                var nodeDeal = this.treeNodeDeals.Nodes.Add("deal_" + deal.Id, deal.Name, "user_suit.png", "user_suit.png");
                nodeDeal.Tag = deal;
                this.eventBroker.RegisterTreeNodeSelectEventSource(nodeDeal, new DealSelectedEvent(deal.Id));
                this.eventBroker.RegisterTreeNodeUnselectEventSource(nodeDeal, new DealUnselectedEvent(deal.Id));

                foreach(var project in deal.Projects)
                {
                    var nodeProject = nodeDeal.Nodes.Add("project_" + project.Id, project.Name, "book_open.png", "book_open.png");
                    nodeProject.Tag = project;
                    this.eventBroker.RegisterTreeNodeSelectEventSource(nodeDeal, new ProjectSelectedEvent(project.Id));
                    this.eventBroker.RegisterTreeNodeUnselectEventSource(nodeDeal, new ProjectUnselectedEvent(project.Id));
                }
            }
            this.treeNodeDeals.ExpandAll();

            foreach (var catalog in viewModel.Catalogs)
            {
                var nodeCatalog = this.treeNodeCatalogs.Nodes.Add("catalog_" + catalog.Id, catalog.SupplierName, "table.png", "table.png");
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
