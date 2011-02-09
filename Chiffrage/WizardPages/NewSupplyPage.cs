﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.App.ViewModel;

namespace Chiffrage.WizardPages
{
    public partial class NewSupplyPage : UserControl
    {
        private int catalogId;

        public NewSupplyPage()
        {
            InitializeComponent();
        }

        public CatalogSupplyViewModel ViewModel
        {
            get
            {
                return new CatalogSupplyViewModel
                {
                    CatalogId = this.catalogId,
                    Name = this.textBoxName.Text,
                };
            }
        }

        public int CatalogId
        {
            set { this.catalogId = value; }
        }
    }
}
