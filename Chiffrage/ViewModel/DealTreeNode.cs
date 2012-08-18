using System.Windows.Forms;
using Chiffrage.Projects.Domain;

namespace Chiffrage.ViewModel
{
    public class DealTreeNode : TreeNode
    {
        public DealTreeNode(Deal deal)
        {
            Text = deal.Name;
            this.DealId = deal.Id;
            ImageKey = "user_suit.png";
            SelectedImageKey = "user_suit.png";
        }

        public int DealId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DealTreeNode && (obj as DealTreeNode).DealId == this.DealId;
        }
    }
}