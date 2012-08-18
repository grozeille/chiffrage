using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Mvc.Views;

namespace Chiffrage.Projects.Module.Views.Impl.WizardPages
{
    public partial class ProjectFramePage : WithValidationUserControl
    {
        public ProjectFramePage()
        {
            InitializeComponent();
            this.textBoxQuantity.Validating += this.ValidateIsRequiredTextBox;
            this.textBoxQuantity.Validating += this.ValidateIsIntegerTextBox;

            this.textBoxSize.Validating += this.ValidateIsRequiredTextBox;
            this.textBoxSize.Validating += this.ValidateIsIntegerTextBox;
        }

        public int FrameSize
        {
            get
            {
                return int.Parse(this.textBoxSize.Text);
            }
            set
            {
                this.textBoxSize.Text = value.ToString();
            }
        }

        public int FrameCount
        {
            get
            {
                return int.Parse(this.textBoxQuantity.Text);
            }
            set
            {
                this.textBoxQuantity.Text = value.ToString();
            }
        }
    }
}
