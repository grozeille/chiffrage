using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Module.Actions
{
    public class ProjectSelectedAction
    {
        public ProjectSelectedAction(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }

        public override string ToString()
        {
            return "ProjectSelectedAction[id=" + this.Id + "]";
        }
    }
}