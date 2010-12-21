using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Projects.Domain;

namespace Chiffrage.ViewModel
{
    public class ProjectTreeNode : TreeNode
    {
        public ProjectTreeNode(Project project)
        {
            this.Text = project.Name;
            this.ProjectId = project.Id;
            this.ImageKey = "report.png";
            this.SelectedImageKey = "report.png";
        }

        public int ProjectId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ProjectTreeNode && (obj as ProjectTreeNode).ProjectId == this.ProjectId;
        }
    }
}
