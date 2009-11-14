using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chiffrage
{
    public partial class WizardForm : Form
    {
        private WizardSetting[] wizardSettings;

        private int currentPosition = 0;

        protected WizardSetting CurrentSetting
        {
            get
            {
                return this.wizardSettings[this.currentPosition];
            }
        }

        public WizardForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.SuspendLayout();
            if (wizardSettings != null)
            {
                foreach (var page in wizardSettings)
                {
                    page.Page.Validated += new EventHandler(Page_Validated);
                    page.Page.Validating += new CancelEventHandler(Page_Validating);
                }
                this.ResumeLayout(true);

                if (wizardSettings.Count() > 1)
                {
                    DisplayNavigation();
                }
                else
                {
                    HideNavigation();
                }            
                DisplayCurrentPage();
            }
        }

        void Page_Validating(object sender, CancelEventArgs e)
        {
            this.CurrentSetting.Validated = false;
            RefreshNavigation();
        }

        void Page_Validated(object sender, EventArgs e)
        {
            this.CurrentSetting.Validated = true;
            RefreshNavigation();
        }

        private void DisplayCurrentPage()
        {
            this.CurrentSetting.Validated = false;
            this.SuspendLayout();
            this.panelContent.Controls.Clear();
            this.CurrentSetting.Page.Dock = DockStyle.Fill;
            this.panelContent.Controls.Add(this.CurrentSetting.Page);
            this.labelTitle.Text = this.CurrentSetting.Title;
            this.labelDescription.Text = this.CurrentSetting.Description;
            RefreshNavigation();
            this.ResumeLayout(true);
        }

        private void RefreshNavigation()
        {
            this.buttonFinnish.Enabled = (this.CurrentSetting.CanFinish || currentPosition == this.wizardSettings.Length - 1);// && this.CurrentSetting.Validated;
            this.buttonBack.Enabled = currentPosition > 0;
            this.buttonNext.Enabled = currentPosition < this.wizardSettings.Length - 1 && this.CurrentSetting.Validated;
        }

        private void HideNavigation()
        {
            this.buttonNext.Visible = false;
            this.buttonBack.Visible = false;
        }

        private void DisplayNavigation()
        {
            this.buttonNext.Visible = true;
            this.buttonBack.Visible = true;
        }

        public DialogResult ShowDialog(WizardSetting wizardSetting)
        {
            this.wizardSettings = new WizardSetting[] {wizardSetting};
            return this.ShowDialog();
        }

        public DialogResult ShowDialog(IEnumerable<WizardSetting> wizardSettings)
        {
            this.wizardSettings = wizardSettings.ToArray();
            return this.ShowDialog();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            currentPosition--;
            this.DisplayCurrentPage();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            currentPosition++;
            this.DisplayCurrentPage();
        }
    }
}
