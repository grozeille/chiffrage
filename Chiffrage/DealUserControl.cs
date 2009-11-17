using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Core;

namespace Chiffrage
{
    public partial class DealUserControl : UserControl
    {
        public event EventHandler OnDealChanged;

        private Deal deal;
        public Deal Deal
        {
            get { return deal; }
            set
            {
                deal = value;
                RefreshDeal();
            }
        }

        private void RefreshDeal()
        {
            if (deal == null)
                return;
            if (this.deal.Comment == null)
                this.deal.Comment = string.Empty;
            if (!(this.deal.Comment.StartsWith("{\\rtf") && this.deal.Comment.EndsWith("}")))
                this.deal.Comment = "{\\rtf" + this.deal.Comment + "}";
            if (this.deal.StartDate == DateTime.MinValue)
                this.deal.StartDate = DateTime.Now;
            if (this.deal.EndDate == DateTime.MinValue)
                this.deal.EndDate = DateTime.Now;

            this.dealBindingSource.DataSource = deal;                   
        }

        public DealUserControl()
        {
            InitializeComponent();
        }

        private void textBoxDealName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dealBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            if(OnDealChanged != null)
                OnDealChanged(this, new EventArgs());
        }
    }
}
