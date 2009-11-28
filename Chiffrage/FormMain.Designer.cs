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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.affaireToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.projetToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nouveauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.affaireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCloseCatalog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorSave = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorHistory = new System.Windows.Forms.ToolStripSeparator();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorHelp = new System.Windows.Forms.ToolStripSeparator();
            this.aProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.projectUserControl = new Chiffrage.ProjectUserControl();
            this.dealUserControl = new Chiffrage.DealUserControl();
            this.catalogUserControl = new Chiffrage.CatalogUserControl();
            this.toolStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 564);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(981, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "status";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripSplitButton,
            this.saveToolStripButton,
            this.toolStripButtonRefresh,
            this.toolStripSeparator,
            this.helpToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(981, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "tool";
            // 
            // newToolStripSplitButton
            // 
            this.newToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.affaireToolStripMenuItem2,
            this.projetToolStripMenuItem2,
            this.catalogueToolStripMenuItem1});
            this.newToolStripSplitButton.Image = global::Chiffrage.Properties.Resources.page_white_add;
            this.newToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripSplitButton.Name = "newToolStripSplitButton";
            this.newToolStripSplitButton.Size = new System.Drawing.Size(87, 22);
            this.newToolStripSplitButton.Text = "Nouveau";
            this.newToolStripSplitButton.ButtonClick += new System.EventHandler(this.newToolStripSplitButton_ButtonClick);
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
            // catalogueToolStripMenuItem1
            // 
            this.catalogueToolStripMenuItem1.Image = global::Chiffrage.Properties.Resources.lorry;
            this.catalogueToolStripMenuItem1.Name = "catalogueToolStripMenuItem1";
            this.catalogueToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.catalogueToolStripMenuItem1.Text = "Catalogue";
            this.catalogueToolStripMenuItem1.Click += new System.EventHandler(this.catalogueToolStripMenuItem1_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.Enabled = false;
            this.saveToolStripButton.Image = global::Chiffrage.Properties.Resources.disk;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(92, 22);
            this.saveToolStripButton.Text = "Sauvegarder";
            this.saveToolStripButton.Click += new System.EventHandler(this.sauvegarderToolStripMenuItem_Click);
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.Image = global::Chiffrage.Properties.Resources.arrow_refresh;
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(77, 22);
            this.toolStripButtonRefresh.Text = "Rafraîchir";
            this.toolStripButtonRefresh.ToolTipText = "Rafraîchir";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
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
            this.menuStrip.Size = new System.Drawing.Size(981, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "Menu";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouveauToolStripMenuItem,
            this.ouvrirToolStripMenuItem,
            this.toolStripMenuItemCloseCatalog,
            this.toolStripSeparatorSave,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.historyToolStripMenuItem,
            this.toolStripSeparatorHistory,
            this.quitterToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(54, 20);
            this.toolStripMenuItem1.Text = "Fichier";
            // 
            // nouveauToolStripMenuItem
            // 
            this.nouveauToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.affaireToolStripMenuItem,
            this.projetToolStripMenuItem,
            this.catalogueToolStripMenuItem});
            this.nouveauToolStripMenuItem.Image = global::Chiffrage.Properties.Resources.page_white_add;
            this.nouveauToolStripMenuItem.Name = "nouveauToolStripMenuItem";
            this.nouveauToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.nouveauToolStripMenuItem.Text = "Nouveau";
            // 
            // affaireToolStripMenuItem
            // 
            this.affaireToolStripMenuItem.Image = global::Chiffrage.Properties.Resources.user_suit;
            this.affaireToolStripMenuItem.Name = "affaireToolStripMenuItem";
            this.affaireToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.affaireToolStripMenuItem.Text = "Affaire...";
            this.affaireToolStripMenuItem.Click += new System.EventHandler(this.affaireToolStripMenuItem2_Click);
            // 
            // projetToolStripMenuItem
            // 
            this.projetToolStripMenuItem.Image = global::Chiffrage.Properties.Resources.report;
            this.projetToolStripMenuItem.Name = "projetToolStripMenuItem";
            this.projetToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.projetToolStripMenuItem.Text = "Projet...";
            this.projetToolStripMenuItem.Click += new System.EventHandler(this.projetToolStripMenuItem2_Click);
            // 
            // catalogueToolStripMenuItem
            // 
            this.catalogueToolStripMenuItem.Image = global::Chiffrage.Properties.Resources.lorry;
            this.catalogueToolStripMenuItem.Name = "catalogueToolStripMenuItem";
            this.catalogueToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.catalogueToolStripMenuItem.Text = "Catalogue...";
            this.catalogueToolStripMenuItem.Click += new System.EventHandler(this.catalogueToolStripMenuItem_Click);
            // 
            // ouvrirToolStripMenuItem
            // 
            this.ouvrirToolStripMenuItem.Name = "ouvrirToolStripMenuItem";
            this.ouvrirToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.ouvrirToolStripMenuItem.Text = "Ouvrir";
            this.ouvrirToolStripMenuItem.Click += new System.EventHandler(this.ouvrirToolStripMenuItem_Click);
            // 
            // toolStripMenuItemCloseCatalog
            // 
            this.toolStripMenuItemCloseCatalog.Name = "toolStripMenuItemCloseCatalog";
            this.toolStripMenuItemCloseCatalog.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItemCloseCatalog.Text = "Fermer";
            this.toolStripMenuItemCloseCatalog.Click += new System.EventHandler(this.toolStripMenuItemCloseDeals_Click);
            // 
            // toolStripSeparatorSave
            // 
            this.toolStripSeparatorSave.Name = "toolStripSeparatorSave";
            this.toolStripSeparatorSave.Size = new System.Drawing.Size(176, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Image = global::Chiffrage.Properties.Resources.disk;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.saveToolStripMenuItem.Text = "Sauvegarder";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.sauvegarderToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.saveAsToolStripMenuItem.Text = "Sauvegarder sous...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(176, 6);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.historyToolStripMenuItem.Text = "Fichiers récents";
            // 
            // toolStripSeparatorHistory
            // 
            this.toolStripSeparatorHistory.Name = "toolStripSeparatorHistory";
            this.toolStripSeparatorHistory.Size = new System.Drawing.Size(176, 6);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Image = global::Chiffrage.Properties.Resources.door_out;
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
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
            this.panelMain.Size = new System.Drawing.Size(981, 515);
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
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.projectUserControl);
            this.splitContainer.Panel2.Controls.Add(this.dealUserControl);
            this.splitContainer.Panel2.Controls.Add(this.catalogUserControl);
            this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.splitContainer.Size = new System.Drawing.Size(975, 509);
            this.splitContainer.SplitterDistance = 172;
            this.splitContainer.TabIndex = 2;
            // 
            // treeView
            // 
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.HideSelection = false;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList;
            this.treeView.Location = new System.Drawing.Point(3, 3);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.ShowRootLines = false;
            this.treeView.Size = new System.Drawing.Size(169, 503);
            this.treeView.TabIndex = 3;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_BeforeSelect);
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
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Fichier d\'affaire (*.aff)|*.aff";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Fichier d\'affaire (*.aff)|*.aff";
            // 
            // projectUserControl
            // 
            this.projectUserControl.Catalog = null;
            this.projectUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectUserControl.Location = new System.Drawing.Point(0, 3);
            this.projectUserControl.Name = "projectUserControl";
            this.projectUserControl.Project = null;
            this.projectUserControl.Size = new System.Drawing.Size(796, 503);
            this.projectUserControl.TabIndex = 2;
            this.projectUserControl.ProjectChanged += new System.EventHandler(this.projectUserControl_ProjectChanged);
            // 
            // dealUserControl
            // 
            this.dealUserControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dealUserControl.Deal = null;
            this.dealUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dealUserControl.Location = new System.Drawing.Point(0, 3);
            this.dealUserControl.Name = "dealUserControl";
            this.dealUserControl.Size = new System.Drawing.Size(796, 503);
            this.dealUserControl.TabIndex = 1;
            this.dealUserControl.OnDealChanged += new System.EventHandler(this.dealUserControl_OnDealChanged);
            // 
            // catalogUserControl
            // 
            this.catalogUserControl.Catalog = null;
            this.catalogUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.catalogUserControl.Location = new System.Drawing.Point(0, 3);
            this.catalogUserControl.Name = "catalogUserControl";
            this.catalogUserControl.Size = new System.Drawing.Size(796, 503);
            this.catalogUserControl.TabIndex = 0;
            this.catalogUserControl.CatalogChanged += new System.EventHandler(this.catalogUserControl_CatalogChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 586);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Chiffrage";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
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
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TreeView treeView;
        private ProjectUserControl projectUserControl;
        private DealUserControl dealUserControl;
        private CatalogUserControl catalogUserControl;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem catalogueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catalogueToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorHistory;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCloseCatalog;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
    }
}

