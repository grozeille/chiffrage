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
            this.contextMenuStripCatalogsRoot = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripDeal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.treeView = new System.Windows.Forms.TreeView();
            this.contextMenuStripProject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStripCatalog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemDealNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCatalogNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemProjectNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemProjectPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDealClone = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDealDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemProjectClone = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemProjectCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemProjectDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCatalogClone = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripMenuItemDealNew});
            this.contextMenuStripDealsRoot.Name = "contextMenuStripDealsRoot";
            this.contextMenuStripDealsRoot.Size = new System.Drawing.Size(160, 48);
            // 
            // contextMenuStripCatalogsRoot
            // 
            this.contextMenuStripCatalogsRoot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCatalogNew});
            this.contextMenuStripCatalogsRoot.Name = "contextMenuStripCatalogsRoot";
            this.contextMenuStripCatalogsRoot.Size = new System.Drawing.Size(180, 26);
            // 
            // contextMenuStripDeal
            // 
            this.contextMenuStripDeal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemProjectNew,
            this.toolStripMenuItemProjectPaste,
            this.toolStripMenuItemDealClone,
            this.toolStripMenuItem2,
            this.toolStripMenuItemDealDelete});
            this.contextMenuStripDeal.Name = "contextMenuStripDeal";
            this.contextMenuStripDeal.Size = new System.Drawing.Size(157, 98);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(153, 6);
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
            this.toolStripMenuItemProjectClone,
            this.toolStripMenuItemProjectCopy,
            this.toolStripSeparator1,
            this.toolStripMenuItemProjectDelete});
            this.contextMenuStripProject.Name = "contextMenuStripDeal";
            this.contextMenuStripProject.Size = new System.Drawing.Size(130, 76);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(126, 6);
            // 
            // contextMenuStripCatalog
            // 
            this.contextMenuStripCatalog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCatalogClone,
            this.toolStripSeparator2,
            this.toolStripMenuItemCatalogDelete});
            this.contextMenuStripCatalog.Name = "contextMenuStripDeal";
            this.contextMenuStripCatalog.Size = new System.Drawing.Size(130, 54);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(126, 6);
            // 
            // toolStripMenuItemDealNew
            // 
            this.toolStripMenuItemDealNew.Image = global::Chiffrage.App.Properties.Resources.user_suit;
            this.toolStripMenuItemDealNew.Name = "toolStripMenuItemDealNew";
            this.toolStripMenuItemDealNew.Size = new System.Drawing.Size(159, 22);
            this.toolStripMenuItemDealNew.Text = "Nouvelle Affaire";
            // 
            // toolStripMenuItemCatalogNew
            // 
            this.toolStripMenuItemCatalogNew.Image = global::Chiffrage.App.Properties.Resources.book_open;
            this.toolStripMenuItemCatalogNew.Name = "toolStripMenuItemCatalogNew";
            this.toolStripMenuItemCatalogNew.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItemCatalogNew.Text = "Nouveau Catalogue";
            // 
            // toolStripMenuItemProjectNew
            // 
            this.toolStripMenuItemProjectNew.Image = global::Chiffrage.App.Properties.Resources.report;
            this.toolStripMenuItemProjectNew.Name = "toolStripMenuItemProjectNew";
            this.toolStripMenuItemProjectNew.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItemProjectNew.Text = "Nouveau Projet";
            // 
            // toolStripMenuItemProjectPaste
            // 
            this.toolStripMenuItemProjectPaste.Image = global::Chiffrage.App.Properties.Resources.page_paste;
            this.toolStripMenuItemProjectPaste.Name = "toolStripMenuItemProjectPaste";
            this.toolStripMenuItemProjectPaste.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItemProjectPaste.Text = "&Coller Projet";
            // 
            // toolStripMenuItemDealClone
            // 
            this.toolStripMenuItemDealClone.Image = global::Chiffrage.App.Properties.Resources.page_copy;
            this.toolStripMenuItemDealClone.Name = "toolStripMenuItemDealClone";
            this.toolStripMenuItemDealClone.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItemDealClone.Text = "Dupliquer";
            // 
            // toolStripMenuItemDealDelete
            // 
            this.toolStripMenuItemDealDelete.Image = global::Chiffrage.App.Properties.Resources.cross;
            this.toolStripMenuItemDealDelete.Name = "toolStripMenuItemDealDelete";
            this.toolStripMenuItemDealDelete.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItemDealDelete.Text = "Supprimer";
            // 
            // toolStripMenuItemProjectClone
            // 
            this.toolStripMenuItemProjectClone.Image = global::Chiffrage.App.Properties.Resources.page_copy;
            this.toolStripMenuItemProjectClone.Name = "toolStripMenuItemProjectClone";
            this.toolStripMenuItemProjectClone.Size = new System.Drawing.Size(129, 22);
            this.toolStripMenuItemProjectClone.Text = "Dupliquer";
            // 
            // toolStripMenuItemProjectCopy
            // 
            this.toolStripMenuItemProjectCopy.Image = global::Chiffrage.App.Properties.Resources.page_copy;
            this.toolStripMenuItemProjectCopy.Name = "toolStripMenuItemProjectCopy";
            this.toolStripMenuItemProjectCopy.Size = new System.Drawing.Size(129, 22);
            this.toolStripMenuItemProjectCopy.Text = "&Copier";
            // 
            // toolStripMenuItemProjectDelete
            // 
            this.toolStripMenuItemProjectDelete.Image = global::Chiffrage.App.Properties.Resources.cross;
            this.toolStripMenuItemProjectDelete.Name = "toolStripMenuItemProjectDelete";
            this.toolStripMenuItemProjectDelete.Size = new System.Drawing.Size(129, 22);
            this.toolStripMenuItemProjectDelete.Text = "Supprimer";
            // 
            // toolStripMenuItemCatalogClone
            // 
            this.toolStripMenuItemCatalogClone.Image = global::Chiffrage.App.Properties.Resources.page_paste;
            this.toolStripMenuItemCatalogClone.Name = "toolStripMenuItemCatalogClone";
            this.toolStripMenuItemCatalogClone.Size = new System.Drawing.Size(129, 22);
            this.toolStripMenuItemCatalogClone.Text = "Dupliquer";
            // 
            // toolStripMenuItemCatalogDelete
            // 
            this.toolStripMenuItemCatalogDelete.Image = global::Chiffrage.App.Properties.Resources.cross;
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDealNew;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDeal;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemProjectNew;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCatalogsRoot;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCatalogNew;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDealClone;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripProject;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemProjectClone;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDealDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemProjectDelete;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCatalog;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCatalogClone;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCatalogDelete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemProjectCopy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemProjectPaste;
    }
}
