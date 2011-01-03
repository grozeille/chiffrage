using System.Windows.Forms;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.App.ViewModel
{
    public class CatalogTreeNode : TreeNode
    {
        public CatalogTreeNode(SupplierCatalog catalog)
        {
            Text = catalog.SupplierName;
            this.CatalogId = catalog.Id;
            ImageKey = "book_open.png";
            SelectedImageKey = "book_open.png";
        }

        public int CatalogId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CatalogTreeNode && (obj as CatalogTreeNode).CatalogId == this.CatalogId;
        }
    }
}