using System.Windows.Forms;
using Chiffrage.Projects.Domain;

namespace Chiffrage.App.ViewModel
{
    public class ProjectTreeNode : TreeNode
    {
        public ProjectTreeNode(Project project)
        {
            Text = project.Name;
            this.ProjectId = project.Id;
            ImageKey = "report.png";
            SelectedImageKey = "report.png";
        }

        public int ProjectId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ProjectTreeNode && (obj as ProjectTreeNode).ProjectId == this.ProjectId;
        }
    }
}