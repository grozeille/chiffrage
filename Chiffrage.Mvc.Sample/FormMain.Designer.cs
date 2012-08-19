namespace Chiffrage.Mvc.Sample
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
            this.chatUserControl1 = new Chiffrage.Mvc.Sample.Views.Impl.ChatUserControl();
            this.chatUserControl2 = new Chiffrage.Mvc.Sample.Views.Impl.ChatUserControl();
            this.SuspendLayout();
            // 
            // chatUserControl1
            // 
            this.chatUserControl1.Location = new System.Drawing.Point(12, 12);
            this.chatUserControl1.Name = "chatUserControl1";
            this.chatUserControl1.Size = new System.Drawing.Size(373, 488);
            this.chatUserControl1.TabIndex = 0;
            // 
            // chatUserControl2
            // 
            this.chatUserControl2.Location = new System.Drawing.Point(414, 12);
            this.chatUserControl2.Name = "chatUserControl2";
            this.chatUserControl2.Size = new System.Drawing.Size(373, 488);
            this.chatUserControl2.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 512);
            this.Controls.Add(this.chatUserControl2);
            this.Controls.Add(this.chatUserControl1);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Views.Impl.ChatUserControl chatUserControl1;
        private Views.Impl.ChatUserControl chatUserControl2;


    }
}

