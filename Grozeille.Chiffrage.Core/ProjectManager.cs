namespace Grozeille.Chiffrage.Core
{
    public class ProjectManager
    {
        private static ProjectManager instance;

        public static ProjectManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProjectManager();
                return instance;
            }
        }

        public Project CurrentProject { get; set; }
    }
}