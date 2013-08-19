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
            //using (var session = this.sessionFactory.OpenSession())
            {
                return session.Query<Project>().ToList();
            }
        }

        public void Save(Project project)
        {
            var session = SessionManager.OpenSessionIfRequired(this.sessionFactory);
            //using (var session = this.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(project);
                    session.Transaction.Commit();
                }
            }
        }

        public Project FindById(int projectId)
        {
            var session = SessionManager.OpenSessionIfRequired(this.sessionFactory);
            //using (var session = this.sessionFactory.OpenSession())
            {
                return session.Query<Project>().Where(x => x.Id == projectId).FirstOrDefault();
            }
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