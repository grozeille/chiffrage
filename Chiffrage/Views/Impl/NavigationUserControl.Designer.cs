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
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Tâches");
            this.contextMenuStripDealsRoot = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemNewDeal = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripCatalogsRoot = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemNewCatalog = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripDeal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemNewProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDealCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemDeleteDeal = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.treeView = new System.Windows.Forms.TreeView();
            this.contextMenuStripProject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemProjectCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemDeleteProject = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripCatalog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemCatalogCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemCatalogDelete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.contextMenuStripDealsRoot.SuspendLayout();
            this.contextMenuStripCatalogsRoot.SuspendLayout();
            this.contextMenuStripDeal.SuspendLayout();
            this.contextMenuStripProject.SuspendLayout();
            this.contextMenuStripCatalog.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripDealsRoot
            // 
            this.contextMenuStripDealsRoot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemNewDeal});
            this.contextMenuStripDealsRoot.Name = "contextMenuStripDealsRoot";
            this.contextMenuStripDealsRoot.Size = new System.Drawing.Size(160, 26);
            // 
            // toolStripMenuItemNewDeal
            // 
            this.toolStripMenuItemNewDeal.Image = global::Chiffrage.App.Properties.Resources.user_suit;
            this.toolStripMenuItemNewDeal.Name = "toolStripMenuItemNewDeal";
            this.toolStripMenuItemNewDeal.Size = new System.Drawing.Size(159, 22);
            this.toolStripMenuItemNewDeal.Text = "Nouvelle Affaire";
            // 
            // contextMenuStripCatalogsRoot
            // 
            this.contextMenuStripCatalogsRoot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemNewCatalog});
            this.contextMenuStripCatalogsRoot.Name = "contextMenuStripCatalogsRoot";
            this.contextMenuStripCatalogsRoot.Size = new System.Drawing.Size(180, 26);
            // 
            // toolStripMenuItemNewCatalog
            // 
            this.toolStripMenuItemNewCatalog.Image = global::Chiffrage.App.Properties.Resources.book_open;
            this.toolStripMenuItemNewCatalog.Name = "toolStripMenuItemNewCatalog";
            this.toolStripMenuItemNewCatalog.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItemNewCatalog.Text = "Nouveau Catalogue";
            // 
            // contextMenuStripDeal
            // 
            this.contextMenuStripDeal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemNewProject,
            this.toolStripMenuItemDealCopy,
            this.toolStripMenuItem2,
            this.toolStripMenuItemDeleteDeal});
            this.contextMenuStripDeal.Name = "contextMenuStripDeal";
            this.contextMenuStripDeal.Size = new System.Drawing.Size(157, 76);
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
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(153, 6);
            // 
            // toolStripMenuItemDeleteDeal
            // 
            this.toolStripMenuItemDeleteDeal.Image = global::Chiffrage.App.Properties.Resources.cancel;
            this.toolStripMenuItemDeleteDeal.Name = "toolStripMenuItemDeleteDeal";
            this.toolStripMenuItemDeleteDeal.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItemDeleteDeal.Text = "Supprimer";
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
            this.imageList.Images.SetKeyName(7, "note.png");
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
            treeNode3.ImageKey = "note.png";
            treeNode3.Name = "TreeNodeTasks";
            treeNode3.SelectedImageKey = "note.png";
            treeNode3.Text = "Tâches";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.treeView.SelectedImageIndex = 0;
            this.treeView.ShowRootLines = false;
            this.treeView.Size = new System.Drawing.Size(203, 369);
            this.treeView.TabIndex = 4;
            this.treeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseDown);
            // 
            // contextMenuStripProject
            // 
            this.contextMenuStripProject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemProjectCopy,
            this.toolStripSeparator1,
            this.toolStripMenuItemDeleteProject});
            this.contextMenuStripProject.Name = "contextMenuStripDeal";
            this.contextMenuStripProject.Size = new System.Drawing.Size(130, 54);
            // 
            // toolStripMenuItemProjectCopy
            // 
            this.toolStripMenuItemProjectCopy.Image = global::Chiffrage.App.Properties.Resources.page_paste;
            this.toolStripMenuItemProjectCopy.Name = "toolStripMenuItemProjectCopy";
            this.toolStripMenuItemProjectCopy.Size = new System.Drawing.Size(129, 22);
            this.toolStripMenuItemProjectCopy.Text = "Dupliquer";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(126, 6);
            // 
            // toolStripMenuItemDeleteProject
            // 
            this.toolStripMenuItemDeleteProject.Image = global::Chiffrage.App.Properties.Resources.cancel;
            this.toolStripMenuItemDeleteProject.Name = "toolStripMenuItemDeleteProject";
            this.toolStripMenuItemDeleteProject.Size = new System.Drawing.Size(129, 22);
            this.toolStripMenuItemDeleteProject.Text = "Supprimer";
            // 
            // contextMenuStripCatalog
            // 
            this.contextMenuStripCatalog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCatalogCopy,
            this.toolStripSeparator2,
            this.toolStripMenuItemCatalogDelete});
            this.contextMenuStripCatalog.Name = "contextMenuStripDeal";
            this.contextMenuStripCatalog.Size = new System.Drawing.Size(130, 54);
            // 
            // toolStripMenuItemCatalogCopy
            // 
            this.toolStripMenuItemCatalogCopy.Image = global::Chiffrage.App.Properties.Resources.page_paste;
            this.toolStripMenuItemCatalogCopy.Name = "toolStripMenuItemCatalogCopy";
            this.toolStripMenuItemCatalogCopy.Size = new System.Drawing.Size(129, 22);
            this.toolStripMenuItemCatalogCopy.Text = "Dupliquer";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(126, 6);
            // 
            // toolStripMenuItemCatalogDelete
            // 
            this.toolStripMenuItemCatalogDelete.Image = global::Chiffrage.App.Properties.Resources.cancel;
            this.toolStripMenuItemCatalogDelete.Name = "toolStripMenuItemCatalogDelete";
            this.toolStripMenuItemCatalogDelete.Size = new System.Drawing.Size(129, 22);
            this.toolStripMenuItemCatalogDelete.Text = "Supprimer";
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
            this.contextMenuStripCatalog.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteDeal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteProject;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCatalog;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCatalogCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCatalogDelete;
    }
}
