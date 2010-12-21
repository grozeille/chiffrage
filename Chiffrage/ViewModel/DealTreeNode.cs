using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Projects.Domain;

namespace Chiffrage.ViewModel
{
    public class DealTreeNode : TreeNode
    {
        public DealTreeNode(Deal deal)
        {
            this.Text = deal.Name;
            this.DealId = deal.Id;
            this.ImageKey = "user_suit.png";
            this.SelectedImageKey = "user_suit.png";
        }

        public int DealId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DealTreeNode && (obj as DealTreeNode).DealId == this.DealId;
        }
    }
}
