using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chiffrage.Mvc
{
    public static class TreeViewUtils
    {
        public static TreeNode HitedNode(this TreeView treeView)
        {
            var hitTest = treeView.HitTest(treeView.PointToClient(Cursor.Position));
            return hitTest.Node;
        }
    }
}
