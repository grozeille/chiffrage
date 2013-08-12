namespace Chiffrage
{
    partial class NavigationUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavigationUserControl));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Affaires");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Catalogues");
            this.contextMenuStripDealsRoot = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripCatalogsRoot = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripDeal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.treeView = new System.Windows.Forms.TreeView();
            this.toolStripMenuItemNewDeal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNewCatalog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNewProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDealCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripProject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemProjectCopy = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.contextMenuStripDealsRoot.SuspendLayout();
            this.contextMenuStripCatalogsRoot.SuspendLayout();
            this.contextMenuStripDeal.SuspendLayout();
            this.contextMenuStripProject.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripDealsRoot
            // 
            this.contextMenuStripDealsRoot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemNewDeal});
            this.contextMenuStripDealsRoot.Name = "contextMenuStripDealsRoot";
            this.contextMenuStripDealsRoot.Size = new System.Drawing.Size(160, 26);
            // 
            // contextMenuStripCatalogsRoot
            // 
            this.contextMenuStripCatalogsRoot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemNewCatalog});
            this.contextMenuStripCatalogsRoot.Name = "contextMenuStripCatalogsRoot";
            this.contextMenuStripCatalogsRoot.Size = new System.Drawing.Size(180, 26);
            // 
            // contextMenuStripDeal
            // 
            this.contextMenuStripDeal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemNewProject,
            this.toolStripMenuItemDealCopy});
            this.contextMenuStripDeal.Name = "contextMenuStripDeal";
            this.contextMenuStripDeal.Size = new System.Drawing.Size(157, 48);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "user_suit.png");
            this.imageList.Images.SetKeyName(1, "table.png");
            this.imageList.Images.SetKeyName(2, "report.png");
            this.imageList.Images.SetKeyName(3, "book_open.png");
            this.imageList.Images.SetKeyName(4, "lorry.png");
            this.imageList.Images.SetKeyName(5, "folder_user.png");
            this.imageList.Images.SetKeyName(6, "folder_table.png");
            // 
            // treeView
            // 
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.HideSelection = false;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList;
            this.treeView.Location = new System.Drawing.Point(1, 1);
            this.treeView.Name = "treeView";
            treeNode1.ContextMenuStrip = this.contextMenuStripDealsRoot;
            treeNode1.ImageKey = "folder_user.png";
            treeNode1.Name = "TreeNodeDeals";
            treeNode1.SelectedImageKey = "folder_user.png";
            treeNode1.Text = "Affaires";
            treeNode2.ContextMenuStrip = this.contextMenuStripCatalogsRoot;
            treeNode2.ImageKey = "folder_table.png";
            treeNode2.Name = "TreeNodeCatalogs";
            treeNode2.SelectedImageKey = "folder_table.png";
            treeNode2.Text = "Catalogues";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.treeView.SelectedImageIndex = 0;
            this.treeView.ShowRootLines = false;
            this.treeView.Size = new System.Drawing.Size(203, 369);
            this.treeView.TabIndex = 4;
            // 
            // toolStripMenuItemNewDeal
            // 
            this.toolStripMenuItemNewDeal.Image = global::Chiffrage.App.Properties.Resources.user_suit;
            this.toolStripMenuItemNewDeal.Name = "toolStripMenuItemNewDeal";
            this.toolStripMenuItemNewDeal.Size = new System.Drawing.Size(159, 22);
            this.toolStripMenuItemNewDeal.Text = "Nouvelle Affaire";
            // 
            // toolStripMenuItemNewCatalog
            // 
            this.toolStripMenuItemNewCatalog.Image = global::Chiffrage.App.Properties.Resources.book_open;
            this.toolStripMenuItemNewCatalog.Name = "toolStripMenuItemNewCatalog";
            this.toolStripMenuItemNewCatalog.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItemNewCatalog.Text = "Nouveau Catalogue";
            // 
            // toolStripMenuItemNewProject
            // 
            this.toolStripMenuItemNewProject.Image = global::Chiffrage.App.Properties.Resources.report;
            this.toolStripMenuItemNewProject.Name = "toolStripMenuItemNewProject";
            this.toolStripMenuItemNewProject.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItemNewProject.Text = "Nouveau Projet";
            // 
            // toolStripMenuItemDealCopy
            // 
            this.toolStripMenuItemDealCopy.Image = global::Chiffrage.App.Properties.Resources.page_paste;
            this.toolStripMenuItemDealCopy.Name = "toolStripMenuItemDealCopy";
            this.toolStripMenuItemDealCopy.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItemDealCopy.Text = "Dupliquer";
            // 
            // contextMenuStripProject
            // 
            this.contextMenuStripProject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemProjectCopy});
            this.contextMenuStripProject.Name = "contextMenuStripDeal";
            this.contextMenuStripProject.Size = new System.Drawing.Size(153, 48);
            // 
            // toolStripMenuItemProjectCopy
            // 
            this.toolStripMenuItemProjectCopy.Image = global::Chiffrage.App.Properties.Resources.page_paste;
            this.toolStripMenuItemProjectCopy.Name = "toolStripMenuItemProjectCopy";
            this.toolStripMenuItemProjectCopy.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemProjectCopy.Text = "Dupliquer";
            // 
            // NavigationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.treeView);
            this.Name = "NavigationUserControl";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(205, 371);
            this.Load += new System.EventHandler(this.NavigationUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.contextMenuStripDealsRoot.ResumeLayout(false);
            this.contextMenuStripCatalogsRoot.ResumeLayout(false);
            this.contextMenuStripDeal.ResumeLayout(false);
            this.contextMenuStripProject.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripDealsRoot;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNewDeal;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDeal;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNewProject;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCatalogsRoot;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNewCatalog;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDealCopy;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripProject;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemProjectCopy;
    }
}
