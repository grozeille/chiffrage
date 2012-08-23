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
        private IWizardSettingIterator wizardSettings;

        private EventHandler pageValidatedEventHandler;

        private CancelEventHandler pageValidatingEventHandler;

        public WizardForm()
        {
            this.InitializeComponent();

            this.pageValidatedEventHandler = new EventHandler(this.Page_Validated);

            this.pageValidatingEventHandler = new CancelEventHandler(this.Page_Validating);

            this.buttonCancel.CausesValidation = false;
        }

        public IWizardSettingIterator WizardSettings
        {
            set { this.wizardSettings = value; }
        }

        protected WizardSetting CurrentSetting
        {
            get { return this.wizardSettings.Current; }
        }

        protected override void OnLoad(EventArgs e)
        {
            
            base.OnLoad(e);
            if (this.wizardSettings != null)
            {
                //foreach (var page in this.wizardSettings)
                //{
                //    page.Page.Validated += new EventHandler(this.Page_Validated);
                //    page.Page.Validating += new CancelEventHandler(this.Page_Validating);
                //}

                this.wizardSettings.Reset();
                if (this.wizardSettings.IsLast && this.wizardSettings.IsFirst)
                {
                    this.HideNavigation(); 
                }
                else
                {
                    this.DisplayNavigation();
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
            this.CurrentSetting.Page.Select();
            this.ActiveControl = this.CurrentSetting.Page;
            this.labelTitle.Text = this.CurrentSetting.Title;
            this.labelDescription.Text = this.CurrentSetting.Description;

            this.RefreshNavigation();
        }

        private void RefreshNavigation()
        {
            this.buttonFinish.Enabled = (this.CurrentSetting.CanFinish || this.wizardSettings.IsLast);
            // && this.CurrentSetting.Validated;
            this.buttonBack.Enabled = !this.wizardSettings.IsFirst;
            this.buttonNext.Enabled = !this.wizardSettings.IsLast;
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
                this.wizardSettings.Current.Page.Validated -= this.pageValidatedEventHandler;
                this.wizardSettings.Current.Page.Validating -= this.pageValidatingEventHandler;
                this.wizardSettings.MovePrevious();
                this.wizardSettings.Current.Page.Validated += this.pageValidatedEventHandler;
                this.wizardSettings.Current.Page.Validating += this.pageValidatingEventHandler;
                this.DisplayCurrentPage();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                this.wizardSettings.Current.Page.Validated -= this.pageValidatedEventHandler;
                this.wizardSettings.Current.Page.Validating -= this.pageValidatingEventHandler;
                this.wizardSettings.MoveNext();
                this.wizardSettings.Current.Page.Validated += this.pageValidatedEventHandler;
                this.wizardSettings.Current.Page.Validating += this.pageValidatingEventHandler;
                this.DisplayCurrentPage();
            }
        }
    }
}