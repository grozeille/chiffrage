namespace Chiffrage.Mvc
{
    partial class WizardPage
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
            this.labelWizards = new System.Windows.Forms.Label();
            this.treeViewWizards = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // labelWizards
            // 
            this.labelWizards.AutoSize = true;
            this.labelWizards.Location = new System.Drawing.Point(9, 7);
            this.labelWizards.Name = "labelWizards";
            this.labelWizards.Size = new System.Drawing.Size(57, 13);
            this.labelWizards.TabIndex = 0;
            this.labelWizards.Text = "Assistants:";
            // 
            // treeViewWizards
            // 
            this.treeViewWizards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewWizards.FullRowSelect = true;
            this.treeViewWizards.HideSelection = false;
            this.treeViewWizards.ImageIndex = 0;
            this.treeViewWizards.ImageList = this.imageList;
            this.treeViewWizards.Location = new System.Drawing.Point(12, 26);
            this.treeViewWizards.Name = "treeViewWizards";
            this.treeViewWizards.SelectedImageIndex = 0;
            this.treeViewWizards.ShowLines = false;
            this.treeViewWizards.ShowRootLines = false;
            this.treeViewWizards.Size = new System.Drawing.Size(269, 254);
            this.treeViewWizards.TabIndex = 1;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // WizardPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeViewWizards);
            this.Controls.Add(this.labelWizards);
            this.Name = "WizardPage";
            this.Size = new System.Drawing.Size(294, 293);
            this.Load += new System.EventHandler(this.WizardPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWizards;
        private System.Windows.Forms.TreeView treeViewWizards;
        private System.Windows.Forms.ImageList imageList;
    }
}
