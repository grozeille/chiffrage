namespace Chiffrage
{
    partial class WizardForm
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panelProgression = new System.Windows.Forms.Panel();
            this.labelProgression = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panelContent = new System.Windows.Forms.Panel();
            this.labelFooterSeparator = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.job = new System.ComponentModel.BackgroundWorker();
            this.panelFooter = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonFinnish = new System.Windows.Forms.Button();
            this.labelHeaderSeparator = new System.Windows.Forms.Label();
            this.panelProgression.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.CausesValidation = false;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(368, 8);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // panelProgression
            // 
            this.panelProgression.Controls.Add(this.labelProgression);
            this.panelProgression.Controls.Add(this.progressBar);
            this.panelProgression.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelProgression.Location = new System.Drawing.Point(0, 347);
            this.panelProgression.Name = "panelProgression";
            this.panelProgression.Size = new System.Drawing.Size(454, 46);
            this.panelProgression.TabIndex = 8;
            this.panelProgression.Visible = false;
            // 
            // labelProgression
            // 
            this.labelProgression.AutoSize = true;
            this.labelProgression.Location = new System.Drawing.Point(11, 6);
            this.labelProgression.Name = "labelProgression";
            this.labelProgression.Size = new System.Drawing.Size(111, 13);
            this.labelProgression.TabIndex = 1;
            this.labelProgression.Text = "Progression : progress";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(11, 25);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(433, 12);
            this.progressBar.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 50);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(8);
            this.panelContent.Size = new System.Drawing.Size(454, 343);
            this.panelContent.TabIndex = 7;
            // 
            // labelFooterSeparator
            // 
            this.labelFooterSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelFooterSeparator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelFooterSeparator.Location = new System.Drawing.Point(0, 393);
            this.labelFooterSeparator.Name = "labelFooterSeparator";
            this.labelFooterSeparator.Size = new System.Drawing.Size(454, 2);
            this.labelFooterSeparator.TabIndex = 10;
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBack.Location = new System.Drawing.Point(125, 8);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 2;
            this.buttonBack.Text = "< Precedent";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.labelDescription);
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(454, 48);
            this.panelHeader.TabIndex = 9;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(19, 24);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = "Description";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(10, 7);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(32, 13);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Title";
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.Location = new System.Drawing.Point(206, 8);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.Text = "Suivant >";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // job
            // 
            this.job.WorkerReportsProgress = true;
            // 
            // panelFooter
            // 
            this.panelFooter.Controls.Add(this.buttonCancel);
            this.panelFooter.Controls.Add(this.buttonFinnish);
            this.panelFooter.Controls.Add(this.buttonNext);
            this.panelFooter.Controls.Add(this.buttonBack);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelFooter.Location = new System.Drawing.Point(0, 395);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Padding = new System.Windows.Forms.Padding(0, 5, 8, 5);
            this.panelFooter.Size = new System.Drawing.Size(454, 39);
            this.panelFooter.TabIndex = 11;
            // 
            // buttonFinnish
            // 
            this.buttonFinnish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFinnish.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonFinnish.Location = new System.Drawing.Point(287, 8);
            this.buttonFinnish.Name = "buttonFinnish";
            this.buttonFinnish.Size = new System.Drawing.Size(75, 23);
            this.buttonFinnish.TabIndex = 0;
            this.buttonFinnish.Text = "Terminer";
            this.buttonFinnish.UseVisualStyleBackColor = true;
            // 
            // labelHeaderSeparator
            // 
            this.labelHeaderSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHeaderSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelHeaderSeparator.Location = new System.Drawing.Point(0, 48);
            this.labelHeaderSeparator.Name = "labelHeaderSeparator";
            this.labelHeaderSeparator.Size = new System.Drawing.Size(454, 2);
            this.labelHeaderSeparator.TabIndex = 6;
            // 
            // WizardForm
            // 
            this.AcceptButton = this.buttonFinnish;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(454, 434);
            this.Controls.Add(this.panelProgression);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.labelFooterSeparator);
            this.Controls.Add(this.labelHeaderSeparator);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelFooter);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizardForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WizardForm";
            this.panelProgression.ResumeLayout(false);
            this.panelProgression.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panelProgression;
        private System.Windows.Forms.Label labelProgression;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label labelFooterSeparator;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonNext;
        private System.ComponentModel.BackgroundWorker job;
        private System.Windows.Forms.FlowLayoutPanel panelFooter;
        private System.Windows.Forms.Button buttonFinnish;
        private System.Windows.Forms.Label labelHeaderSeparator;
    }
}