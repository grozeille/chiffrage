﻿using System;
using System.Windows.Forms;
using Chiffrage.Core;

namespace Chiffrage
{
    public partial class DealUserControl : UserControl
    {
        private Deal deal;

        public DealUserControl()
        {
            InitializeComponent();
        }

        public Deal Deal
        {
            get { return deal; }
            set
            {
                deal = value;
                RefreshDeal();
            }
        }

        public event EventHandler OnDealChanged;

        private void RefreshDeal()
        {
            if (deal == null)
                return;
            if (deal.Comment == null)
                deal.Comment = string.Empty;
            if (!(deal.Comment.StartsWith("{\\rtf") && deal.Comment.EndsWith("}")))
                deal.Comment = "{\\rtf" + deal.Comment + "}";
            if (deal.StartDate == DateTime.MinValue)
                deal.StartDate = DateTime.Now;
            if (deal.EndDate == DateTime.MinValue)
                deal.EndDate = DateTime.Now;

            dealBindingSource.DataSource = deal;
        }

        private void textBoxDealName_TextChanged(object sender, EventArgs e)
        {
        }

        private void dealBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            if (OnDealChanged != null)
                OnDealChanged(this, new EventArgs());
        }
    }
}