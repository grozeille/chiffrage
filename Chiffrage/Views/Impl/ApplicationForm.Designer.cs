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
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripMenuItemNewCatalog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItemNewDeal = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nouveauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNewDeal2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNewCatalog2 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripSeparatorHelp.Size = new System.Drawing.Size(149, 6);
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
            this.aProposToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aProposToolStripMenuItem.Text = "A propos";
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.Image = global::Chiffrage.App.Properties.Resources.help;
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            this.splitContainer.Size = new System.Drawing.Size(1227, 681);
            this.splitContainer.SplitterDistance = 254;
            this.splitContainer.TabIndex = 2;
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
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Image = global::Chiffrage.App.Properties.Resources.door_out;
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Fichier d\'affaire (*.aff)|*.aff";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Fichier d\'affaire (*.aff)|*.aff";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.Image = global::Chiffrage.App.Properties.Resources.disk;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(92, 22);
            this.saveToolStripButton.Text = "Sauvegarder";
            // 
            // toolStripMenuItemNewCatalog
            // 
            this.toolStripMenuItemNewCatalog.Image = global::Chiffrage.App.Properties.Resources.book_open;
            this.toolStripMenuItemNewCatalog.Name = "toolStripMenuItemNewCatalog";
            this.toolStripMenuItemNewCatalog.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemNewCatalog.Text = "Catalogue";
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
            this.toolStripMenuItemNewDeal,
            this.toolStripMenuItemNewCatalog});
            this.newToolStripSplitButton.Image = global::Chiffrage.App.Properties.Resources.page_white_add;
            this.newToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripSplitButton.Name = "newToolStripSplitButton";
            this.newToolStripSplitButton.Size = new System.Drawing.Size(87, 22);
            this.newToolStripSplitButton.Text = "Nouveau";
            // 
            // toolStripMenuItemNewDeal
            // 
            this.toolStripMenuItemNewDeal.Image = global::Chiffrage.App.Properties.Resources.user_suit;
            this.toolStripMenuItemNewDeal.Name = "toolStripMenuItemNewDeal";
            this.toolStripMenuItemNewDeal.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemNewDeal.Text = "Affaire";
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.Image = global::Chiffrage.App.Properties.Resources.help;
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
            this.menuStrip.Size = new System.Drawing.Size(1227, 24);
            this.menuStrip.TabIndex = 7;
            this.menuStrip.Text = "Menu";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouveauToolStripMenuItem,
            this.toolStripSeparatorSave,
            this.quitterToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(54, 20);
            this.toolStripMenuItem1.Text = "Fichier";
            // 
            // nouveauToolStripMenuItem
            // 
            this.nouveauToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemNewDeal2,
            this.toolStripMenuItemNewCatalog2});
            this.nouveauToolStripMenuItem.Image = global::Chiffrage.App.Properties.Resources.page_white_add;
            this.nouveauToolStripMenuItem.Name = "nouveauToolStripMenuItem";
            this.nouveauToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.nouveauToolStripMenuItem.Text = "Nouveau";
            // 
            // toolStripMenuItemNewDeal2
            // 
            this.toolStripMenuItemNewDeal2.Image = global::Chiffrage.App.Properties.Resources.user_suit;
            this.toolStripMenuItemNewDeal2.Name = "toolStripMenuItemNewDeal2";
            this.toolStripMenuItemNewDeal2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemNewDeal2.Text = "Affaire...";
            // 
            // toolStripMenuItemNewCatalog2
            // 
            this.toolStripMenuItemNewCatalog2.Image = global::Chiffrage.App.Properties.Resources.lorry;
            this.toolStripMenuItemNewCatalog2.Name = "toolStripMenuItemNewCatalog2";
            this.toolStripMenuItemNewCatalog2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemNewCatalog2.Text = "Catalogue...";
            // 
            // toolStripSeparatorSave
            // 
            this.toolStripSeparatorSave.Name = "toolStripSeparatorSave";
            this.toolStripSeparatorSave.Size = new System.Drawing.Size(150, 6);
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
            this.splitContainerMain.SplitterDistance = 681;
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNewCatalog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripSplitButton newToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNewDeal;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nouveauToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNewDeal2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNewCatalog2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorSave;
        private System.Windows.Forms.SplitContainer splitContainerMain;
    }
}