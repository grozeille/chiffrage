namespace Chiffrage
{
    partial class FormMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Fournisseur A");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Fournisseur B");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Projet B", 2, 2);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Affaire A", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Tramway", 2, 2);
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Templates", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.affaireToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.projetToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nouveauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.affaireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sauvegarderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorHelp = new System.Windows.Forms.ToolStripSeparator();
            this.aProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.navigationBar = new TD.Eyefinder.NavigationBar();
            this.navigationPaneCatalog = new TD.Eyefinder.NavigationPane();
            this.treeViewProviders = new System.Windows.Forms.TreeView();
            this.imageListCatalog = new System.Windows.Forms.ImageList(this.components);
            this.navigationPaneDeal = new TD.Eyefinder.NavigationPane();
            this.treeView = new System.Windows.Forms.TreeView();
            this.imageListDeal = new System.Windows.Forms.ImageList(this.components);
            this.projectUserControl = new Chiffrage.ProjectUserControl();
            this.dealUserControl = new Chiffrage.DealUserControl();
            this.catalogUserControl = new Chiffrage.CatalogUserControl();
            this.toolStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.navigationBar.SuspendLayout();
            this.navigationPaneCatalog.SuspendLayout();
            this.navigationPaneDeal.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 440);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(648, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "status";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripSplitButton,
            this.saveToolStripButton,
            this.toolStripSeparator,
            this.helpToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(648, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "tool";
            // 
            // newToolStripSplitButton
            // 
            this.newToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.affaireToolStripMenuItem2,
            this.projetToolStripMenuItem2});
            this.newToolStripSplitButton.Image = global::Chiffrage.Properties.Resources.page_white_add;
            this.newToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripSplitButton.Name = "newToolStripSplitButton";
            this.newToolStripSplitButton.Size = new System.Drawing.Size(87, 22);
            this.newToolStripSplitButton.Text = "Nouveau";
            // 
            // affaireToolStripMenuItem2
            // 
            this.affaireToolStripMenuItem2.Image = global::Chiffrage.Properties.Resources.user_suit;
            this.affaireToolStripMenuItem2.Name = "affaireToolStripMenuItem2";
            this.affaireToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.affaireToolStripMenuItem2.Text = "Affaire";
            this.affaireToolStripMenuItem2.Click += new System.EventHandler(this.affaireToolStripMenuItem2_Click);
            // 
            // projetToolStripMenuItem2
            // 
            this.projetToolStripMenuItem2.Image = global::Chiffrage.Properties.Resources.report;
            this.projetToolStripMenuItem2.Name = "projetToolStripMenuItem2";
            this.projetToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.projetToolStripMenuItem2.Text = "Projet";
            this.projetToolStripMenuItem2.Click += new System.EventHandler(this.projetToolStripMenuItem2_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.Image = global::Chiffrage.Properties.Resources.disk;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(92, 22);
            this.saveToolStripButton.Text = "Sauvegarder";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.Image = global::Chiffrage.Properties.Resources.help;
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(51, 22);
            this.helpToolStripButton.Text = "Aide";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(648, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "Menu";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouveauToolStripMenuItem,
            this.ouvrirToolStripMenuItem,
            this.sauvegarderToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitterToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(54, 20);
            this.toolStripMenuItem1.Text = "Fichier";
            // 
            // nouveauToolStripMenuItem
            // 
            this.nouveauToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.affaireToolStripMenuItem,
            this.projetToolStripMenuItem});
            this.nouveauToolStripMenuItem.Image = global::Chiffrage.Properties.Resources.page_white_add;
            this.nouveauToolStripMenuItem.Name = "nouveauToolStripMenuItem";
            this.nouveauToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.nouveauToolStripMenuItem.Text = "Nouveau";
            // 
            // affaireToolStripMenuItem
            // 
            this.affaireToolStripMenuItem.Image = global::Chiffrage.Properties.Resources.user_suit;
            this.affaireToolStripMenuItem.Name = "affaireToolStripMenuItem";
            this.affaireToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.affaireToolStripMenuItem.Text = "Affaire...";
            this.affaireToolStripMenuItem.Click += new System.EventHandler(this.affaireToolStripMenuItem2_Click);
            // 
            // projetToolStripMenuItem
            // 
            this.projetToolStripMenuItem.Image = global::Chiffrage.Properties.Resources.report;
            this.projetToolStripMenuItem.Name = "projetToolStripMenuItem";
            this.projetToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.projetToolStripMenuItem.Text = "Projet...";
            this.projetToolStripMenuItem.Click += new System.EventHandler(this.projetToolStripMenuItem2_Click);
            // 
            // ouvrirToolStripMenuItem
            // 
            this.ouvrirToolStripMenuItem.Name = "ouvrirToolStripMenuItem";
            this.ouvrirToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.ouvrirToolStripMenuItem.Text = "Ouvrir";
            // 
            // sauvegarderToolStripMenuItem
            // 
            this.sauvegarderToolStripMenuItem.Image = global::Chiffrage.Properties.Resources.disk;
            this.sauvegarderToolStripMenuItem.Name = "sauvegarderToolStripMenuItem";
            this.sauvegarderToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.sauvegarderToolStripMenuItem.Text = "Sauvegarder";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Image = global::Chiffrage.Properties.Resources.door_out;
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aideToolStripMenuItem,
            this.toolStripSeparatorHelp,
            this.aProposToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem2.Text = "?";
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.Image = global::Chiffrage.Properties.Resources.help;
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aideToolStripMenuItem.Text = "Aide";
            // 
            // toolStripSeparatorHelp
            // 
            this.toolStripSeparatorHelp.Name = "toolStripSeparatorHelp";
            this.toolStripSeparatorHelp.Size = new System.Drawing.Size(119, 6);
            // 
            // aProposToolStripMenuItem
            // 
            this.aProposToolStripMenuItem.Name = "aProposToolStripMenuItem";
            this.aProposToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aProposToolStripMenuItem.Text = "A propos";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.splitContainer);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 49);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(3);
            this.panelMain.Size = new System.Drawing.Size(648, 391);
            this.panelMain.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(3, 3);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Panel1.Controls.Add(this.navigationBar);
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.projectUserControl);
            this.splitContainer.Panel2.Controls.Add(this.dealUserControl);
            this.splitContainer.Panel2.Controls.Add(this.catalogUserControl);
            this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.splitContainer.Size = new System.Drawing.Size(642, 385);
            this.splitContainer.SplitterDistance = 172;
            this.splitContainer.TabIndex = 2;
            // 
            // navigationBar
            // 
            this.navigationBar.Controls.Add(this.navigationPaneCatalog);
            this.navigationBar.Controls.Add(this.navigationPaneDeal);
            this.navigationBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationBar.HeaderFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.navigationBar.Location = new System.Drawing.Point(3, 3);
            this.navigationBar.Name = "navigationBar";
            this.navigationBar.PaneFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.navigationBar.SelectedPane = this.navigationPaneDeal;
            this.navigationBar.ShowPanes = 2;
            this.navigationBar.Size = new System.Drawing.Size(169, 379);
            this.navigationBar.TabIndex = 0;
            this.navigationBar.Text = "navigationBar1";
            this.navigationBar.SelectedPaneChanged += new System.EventHandler(this.navigationBar_SelectedPaneChanged);
            // 
            // navigationPaneCatalog
            // 
            this.navigationPaneCatalog.Controls.Add(this.treeViewProviders);
            this.navigationPaneCatalog.LargeImage = global::Chiffrage.Properties.Resources.book_open;
            this.navigationPaneCatalog.Location = new System.Drawing.Point(1, 26);
            this.navigationPaneCatalog.Name = "navigationPaneCatalog";
            this.navigationPaneCatalog.Size = new System.Drawing.Size(167, 274);
            this.navigationPaneCatalog.SmallImage = global::Chiffrage.Properties.Resources.book_open;
            this.navigationPaneCatalog.TabIndex = 0;
            this.navigationPaneCatalog.Text = "Catalogue";
            // 
            // treeViewProviders
            // 
            this.treeViewProviders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewProviders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewProviders.FullRowSelect = true;
            this.treeViewProviders.ImageIndex = 0;
            this.treeViewProviders.ImageList = this.imageListCatalog;
            this.treeViewProviders.Location = new System.Drawing.Point(0, 0);
            this.treeViewProviders.Name = "treeViewProviders";
            treeNode7.Name = "Node0";
            treeNode7.Text = "Fournisseur A";
            treeNode8.Name = "Node1";
            treeNode8.Text = "Fournisseur B";
            this.treeViewProviders.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            this.treeViewProviders.SelectedImageIndex = 0;
            this.treeViewProviders.ShowRootLines = false;
            this.treeViewProviders.Size = new System.Drawing.Size(167, 274);
            this.treeViewProviders.TabIndex = 1;
            // 
            // imageListCatalog
            // 
            this.imageListCatalog.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListCatalog.ImageStream")));
            this.imageListCatalog.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListCatalog.Images.SetKeyName(0, "lorry.png");
            // 
            // navigationPaneDeal
            // 
            this.navigationPaneDeal.Controls.Add(this.treeView);
            this.navigationPaneDeal.LargeImage = global::Chiffrage.Properties.Resources.report;
            this.navigationPaneDeal.Location = new System.Drawing.Point(1, 26);
            this.navigationPaneDeal.Name = "navigationPaneDeal";
            this.navigationPaneDeal.Size = new System.Drawing.Size(167, 274);
            this.navigationPaneDeal.SmallImage = global::Chiffrage.Properties.Resources.report;
            this.navigationPaneDeal.TabIndex = 1;
            this.navigationPaneDeal.Text = "Affaires";
            // 
            // treeView
            // 
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.HideSelection = false;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageListDeal;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            treeNode1.ImageIndex = 2;
            treeNode1.Name = "Node1";
            treeNode1.SelectedImageIndex = 2;
            treeNode1.Text = "Projet B";
            treeNode2.ImageIndex = 0;
            treeNode2.Name = "Node0";
            treeNode2.SelectedImageIndex = 0;
            treeNode2.Text = "Affaire A";
            treeNode9.ImageIndex = 2;
            treeNode9.Name = "Node3";
            treeNode9.SelectedImageIndex = 2;
            treeNode9.Text = "Tramway";
            treeNode10.ImageIndex = 0;
            treeNode10.Name = "Node2";
            treeNode10.SelectedImageIndex = 0;
            treeNode10.Text = "Templates";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode10});
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(167, 274);
            this.treeView.TabIndex = 3;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // imageListDeal
            // 
            this.imageListDeal.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListDeal.ImageStream")));
            this.imageListDeal.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListDeal.Images.SetKeyName(0, "user_suit.png");
            this.imageListDeal.Images.SetKeyName(1, "table.png");
            this.imageListDeal.Images.SetKeyName(2, "report.png");
            // 
            // projectUserControl
            // 
            this.projectUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectUserControl.Location = new System.Drawing.Point(0, 3);
            this.projectUserControl.Name = "projectUserControl";
            this.projectUserControl.Project = null;
            this.projectUserControl.Size = new System.Drawing.Size(463, 379);
            this.projectUserControl.TabIndex = 2;
            // 
            // dealUserControl
            // 
            this.dealUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dealUserControl.Location = new System.Drawing.Point(0, 3);
            this.dealUserControl.Name = "dealUserControl";
            this.dealUserControl.Size = new System.Drawing.Size(463, 379);
            this.dealUserControl.TabIndex = 1;
            // 
            // catalogUserControl
            // 
            this.catalogUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.catalogUserControl.Location = new System.Drawing.Point(0, 3);
            this.catalogUserControl.Name = "catalogUserControl";
            this.catalogUserControl.Size = new System.Drawing.Size(463, 379);
            this.catalogUserControl.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 462);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Chiffrage";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.navigationBar.ResumeLayout(false);
            this.navigationPaneCatalog.ResumeLayout(false);
            this.navigationPaneDeal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nouveauToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem affaireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ouvrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sauvegarderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorHelp;
        private System.Windows.Forms.ToolStripMenuItem aProposToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton newToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem affaireToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem projetToolStripMenuItem2;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.SplitContainer splitContainer;
        private TD.Eyefinder.NavigationBar navigationBar;
        private TD.Eyefinder.NavigationPane navigationPaneCatalog;
        private TD.Eyefinder.NavigationPane navigationPaneDeal;
        private System.Windows.Forms.ImageList imageListDeal;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.TreeView treeViewProviders;
        private System.Windows.Forms.ImageList imageListCatalog;
        private ProjectUserControl projectUserControl;
        private DealUserControl dealUserControl;
        private CatalogUserControl catalogUserControl;
    }
}

