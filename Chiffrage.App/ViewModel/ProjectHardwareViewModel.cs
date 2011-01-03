using Chiffrage.Projects.Domain;

namespace Chiffrage.App.ViewModel
{
    public class ProjectHardwareViewModel : AbstractProjectItemViewModel<ProjectHardware>
    {
        public double Milestone
        {
            get { return item.Milestone; }
            set { item.Milestone = value; }
        }
    }
}