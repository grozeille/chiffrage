using System.Collections.Generic;
using System.Linq;
using Chiffrage.Projects.Domain;
using Chiffrage.Projects.Domain.Repositories;
using NHibernate;
using NHibernate.Linq;
using Common.Logging;

namespace Chiffrage.Projects.Dal.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private static ILog logger = LogManager.GetLogger(typeof(ProjectRepository));

        private readonly ISessionFactory sessionFactory;

        public ProjectRepository(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
            SessionManager.OpenSessionIfRequired(this.sessionFactory);
        }

        #region IProjectRepository Members

        public IList<Project> FindAll()
        {
            var session = SessionManager.OpenSessionIfRequired(this.sessionFactory);
            return session.Query<Project>().ToList();
        }

        public void Save(Project project)
        {
            var session = SessionManager.OpenSessionIfRequired(this.sessionFactory);
            using (var transaction = session.BeginTransaction())
            {
                var otherBenefits = new List<OtherBenefit>(project.OtherBenefits);
                project.OtherBenefits.Clear();
                foreach (var item in otherBenefits)
                {
                    project.OtherBenefits.Add(session.Merge(item));
                }

                var tasks = new List<ProjectTask>(project.Tasks);
                project.Tasks.Clear();
                foreach (var item in tasks)
                {
                    project.Tasks.Add(session.Merge(item));
                }

                foreach (var item in project.Hardwares) 
                {
                    var hardwareTasks = new List<ProjectHardwareTask>(item.Tasks);
                    item.Tasks.Clear();
                    foreach(var t in hardwareTasks)
                    {
                        item.Tasks.Add(session.Merge(t));
                    }
                }

                session.SaveOrUpdate(project);
                session.Transaction.Commit();
            }
        }

        public Project FindById(int projectId)
        {
            var session = SessionManager.OpenSessionIfRequired(this.sessionFactory);
            return session.Query<Project>().Where(x => x.Id == projectId).FirstOrDefault();
        }

        #endregion


        public void Delete(Project project)
        {
            var session = SessionManager.OpenSessionIfRequired(this.sessionFactory);
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(project);
                session.Transaction.Commit();
            }
        }
    }
}