using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.ViewModel
{
    public class CatalogTreeNode : TreeNode
    {
        public CatalogTreeNode(SupplierCatalog catalog)
        {
            this.Text = catalog.SupplierName;
            this.CatalogId = catalog.Id;
            this.ImageKey = "book_open.png";
            this.SelectedImageKey = "book_open.png";
        }

        public int CatalogId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CatalogTreeNode && (obj as CatalogTreeNode).CatalogId == this.CatalogId;
        }    
    }
}
