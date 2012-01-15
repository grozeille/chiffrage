namespace Chiffrage.WizardPages
{
    partial class NewHardwarePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewHardwarePage));
            this.textBoxHardwareName = new System.Windows.Forms.TextBox();
            this.labelHardware = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxHardwareName
            // 
            this.textBoxHardwareName.Location = new System.Drawing.Point(60, 3);
            this.textBoxHardwareName.Name = "textBoxHardwareName";
            this.textBoxHardwareName.Size = new System.Drawing.Size(200, 20);
            this.textBoxHardwareName.TabIndex = 5;
            // 
            // labelHardware
            // 
            this.labelHardware.AutoSize = true;
            this.labelHardware.Location = new System.Drawing.Point(7, 6);
            this.labelHardware.Name = "labelHardware";
            this.labelHardware.Size = new System.Drawing.Size(47, 13);
            this.labelHardware.TabIndex = 4;
            this.labelHardware.Text = "Matériel:";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // NewHardwarePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxHardwareName);
            this.Controls.Add(this.labelHardware);
            this.Name = "NewHardwarePage";
            this.Size = new System.Drawing.Size(276, 30);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxHardwareName;
        private System.Windows.Forms.Label labelHardware;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
