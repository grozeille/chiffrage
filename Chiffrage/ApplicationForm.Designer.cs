namespace Chiffrage
{
    partial class ApplicationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationForm));
            this.toolStripSeparatorHelp = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.aProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorHistory = new System.Windows.Forms.ToolStripSeparator();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.catalogueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.affaireToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.projetToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ouvrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nouveauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.affaireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCloseCatalog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorSave = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainer.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparatorHelp
            // 
            this.toolStripSeparatorHelp.Name = "toolStripSeparatorHelp";
            this.toolStripSeparatorHelp.Size = new System.Drawing.Size(119, 6);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 759);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1227, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "status";
            // 
            // aProposToolStripMenuItem
            // 
            this.aProposToolStripMenuItem.Name = "aProposToolStripMenuItem";
            this.aProposToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aProposToolStripMenuItem.Text = "A propos";
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.Image = global::Chiffrage.Properties.Resources.help;
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aideToolStripMenuItem.Text = "Aide";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.splitContainer.Size = new System.Drawing.Size(1227, 603);
            this.splitContainer.SplitterDistance = 254;
            this.splitContainer.TabIndex = 2;
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.historyToolStripMenuItem.Text = "Fichiers récents";
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
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Fichier d\'affaire (*.aff)|*.aff";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(176, 6);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Fichier d\'affaire (*.aff)|*.aff";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.saveAsToolStripMenuItem.Text = "Sauvegarder sous...";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.Image = global::Chiffrage.Properties.Resources.disk;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(92, 22);
            this.saveToolStripButton.Text = "Sauvegarder";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Image = global::Chiffrage.Properties.Resources.disk;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.saveToolStripMenuItem.Text = "Sauvegarder";
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.Image = global::Chiffrage.Properties.Resources.arrow_refresh;
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(77, 22);
            this.toolStripButtonRefresh.Text = "Rafraîchir";
            this.toolStripButtonRefresh.ToolTipText = "Rafraîchir";
            // 
            // catalogueToolStripMenuItem1
            // 
            this.catalogueToolStripMenuItem1.Image = global::Chiffrage.Properties.Resources.book_open;
            this.catalogueToolStripMenuItem1.Name = "catalogueToolStripMenuItem1";
            this.catalogueToolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.catalogueToolStripMenuItem1.Text = "Catalogue";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
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
            this.toolStrip.Size = new System.Drawing.Size(1227, 25);
            this.toolStrip.TabIndex = 6;
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
            // 
            // affaireToolStripMenuItem2
            // 
            this.affaireToolStripMenuItem2.Image = global::Chiffrage.Properties.Resources.user_suit;
            this.affaireToolStripMenuItem2.Name = "affaireToolStripMenuItem2";
            this.affaireToolStripMenuItem2.Size = new System.Drawing.Size(128, 22);
            this.affaireToolStripMenuItem2.Text = "Affaire";
            // 
            // projetToolStripMenuItem2
            // 
            this.projetToolStripMenuItem2.Image = global::Chiffrage.Properties.Resources.report;
            this.projetToolStripMenuItem2.Name = "projetToolStripMenuItem2";
            this.projetToolStripMenuItem2.Size = new System.Drawing.Size(128, 22);
            this.projetToolStripMenuItem2.Text = "Projet";
            this.projetToolStripMenuItem2.Visible = false;
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.Image = global::Chiffrage.Properties.Resources.help;
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(51, 22);
            this.helpToolStripButton.Text = "Aide";
            // 
            // ouvrirToolStripMenuItem
            // 
            this.ouvrirToolStripMenuItem.Name = "ouvrirToolStripMenuItem";
            this.ouvrirToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.ouvrirToolStripMenuItem.Text = "Ouvrir";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1227, 24);
            this.menuStrip.TabIndex = 7;
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
            this.affaireToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.affaireToolStripMenuItem.Text = "Affaire...";
            // 
            // projetToolStripMenuItem
            // 
            this.projetToolStripMenuItem.Image = global::Chiffrage.Properties.Resources.report;
            this.projetToolStripMenuItem.Name = "projetToolStripMenuItem";
            this.projetToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.projetToolStripMenuItem.Text = "Projet...";
            // 
            // catalogueToolStripMenuItem
            // 
            this.catalogueToolStripMenuItem.Image = global::Chiffrage.Properties.Resources.lorry;
            this.catalogueToolStripMenuItem.Name = "catalogueToolStripMenuItem";
            this.catalogueToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.catalogueToolStripMenuItem.Text = "Catalogue...";
            // 
            // toolStripMenuItemCloseCatalog
            // 
            this.toolStripMenuItemCloseCatalog.Name = "toolStripMenuItemCloseCatalog";
            this.toolStripMenuItemCloseCatalog.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItemCloseCatalog.Text = "Fermer";
            // 
            // toolStripSeparatorSave
            // 
            this.toolStripSeparatorSave.Name = "toolStripSeparatorSave";
            this.toolStripSeparatorSave.Size = new System.Drawing.Size(176, 6);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 49);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainer);
            this.splitContainerMain.Size = new System.Drawing.Size(1227, 710);
            this.splitContainerMain.SplitterDistance = 603;
            this.splitContainerMain.TabIndex = 8;
            // 
            // ApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 781);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ApplicationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chiffrage";
            this.splitContainer.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorHelp;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem aProposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorHistory;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripMenuItem catalogueToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripSplitButton newToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem affaireToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem projetToolStripMenuItem2;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem ouvrirToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nouveauToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem affaireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catalogueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCloseCatalog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorSave;
        private System.Windows.Forms.SplitContainer splitContainerMain;
    }
}