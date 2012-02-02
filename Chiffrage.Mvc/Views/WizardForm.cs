using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Chiffrage.Mvc.Views;

namespace Chiffrage.Mvc.Views
{
    public partial class WizardForm : Form
    {
        private int currentPosition = 0;
        private WizardSetting[] wizardSettings;

        public WizardForm()
        {
            this.InitializeComponent();

            this.buttonCancel.CausesValidation = false;
        }

        public WizardSetting[] WizardSettings
        {
            set { this.wizardSettings = value; }
        }

        protected WizardSetting CurrentSetting
        {
            get { return this.wizardSettings[this.currentPosition]; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.wizardSettings != null)
            {
                this.currentPosition = 0;
                foreach (var page in this.wizardSettings)
                {
                    page.Page.Validated += new EventHandler(this.Page_Validated);
                    page.Page.Validating += new CancelEventHandler(this.Page_Validating);
                }

                if (this.wizardSettings.Count() > 1)
                {
                    this.DisplayNavigation();
                }
                else
                {
                    this.HideNavigation();
                }
                this.DisplayCurrentPage();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = !this.ValidateChildren();
            }
        }

        private void Page_Validating(object sender, CancelEventArgs e)
        {
            this.CurrentSetting.Validated = false;
            this.RefreshNavigation();
        }

        private void Page_Validated(object sender, EventArgs e)
        {
            this.CurrentSetting.Validated = true;
            this.RefreshNavigation();
        }

        private void DisplayCurrentPage()
        {
            this.CurrentSetting.Validated = false;
            this.panelContent.Controls.Clear();
            this.CurrentSetting.Page.Dock = DockStyle.Fill;
            this.panelContent.Controls.Add(this.CurrentSetting.Page);
            this.CurrentSetting.Page.Focus();
            this.labelTitle.Text = this.CurrentSetting.Title;
            this.labelDescription.Text = this.CurrentSetting.Description;

            this.RefreshNavigation();
        }

        private void RefreshNavigation()
        {
            this.buttonFinish.Enabled = (this.CurrentSetting.CanFinish ||
                                          this.currentPosition == this.wizardSettings.Length - 1);
            // && this.CurrentSetting.Validated;
            this.buttonBack.Enabled = this.currentPosition > 0;
            this.buttonNext.Enabled = this.currentPosition < this.wizardSettings.Length - 1;
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

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                this.currentPosition--;
                this.DisplayCurrentPage();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                this.currentPosition++;
                this.DisplayCurrentPage();
            }
        }
    }
}