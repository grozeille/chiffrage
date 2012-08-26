using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Chiffrage.Mvc.Views
{
    public partial class WithValidationUserControl : UserControl
    {
        public WithValidationUserControl()
        {
            InitializeComponent();
        }

        protected void ValidateIsRequiredTextBox(object sender, CancelEventArgs args)
        {
            args.Cancel = !ValidateIsRequired((TextBox)sender);
        }

        protected void ValidateIsIntegerTextBox(object sender, CancelEventArgs args)
        {
            args.Cancel = !ValidateIsInteger((TextBox)sender);
        }

        protected void ValidateIsDoubleTextBox(object sender, CancelEventArgs args)
        {
            args.Cancel = !ValidateIsDouble((TextBox)sender);
        }

        protected bool ValidateIsRequired(Control control)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                this.errorProvider.SetError(control, "Obligatoire");
                return false;
            }
            return true;
        }

        protected bool ValidateIsInteger(Control control)
        {
            int temp;
            if (!int.TryParse(control.Text, out temp))
            {
                this.errorProvider.SetError(control, "Doit être un nombre");
                return false;
            }
            return true;
        }

        protected bool ValidateIsDouble(Control control)
        {
            double temp;
            if (!double.TryParse(control.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out temp))
            {
                this.errorProvider.SetError(control, "Doit être un nombre");
                return false;
            }
            return true;
        }

        protected bool ValidateRegex(Control control, string regexPattern, string errorMessage)
        {
            if (!Regex.Match(control.Text, regexPattern).Success)
            {
                this.errorProvider.SetError(control, errorMessage);
                return false;
            }
            return true;
        }
    }
}
