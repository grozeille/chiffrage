using System.Collections.Generic;
using System.Linq;
using Chiffrage.Projects.Domain;
using Chiffrage.Projects.Domain.Repositories;
using NHibernate;
using NHibernate.Linq;
using Chiffrage.Catalogs.Dal.Repositories;
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
            OpenSessionIfRequired();
        }

        private ISession OpenSessionIfRequired()
        {
            if (!ProjectSessionContext.HasBind(sessionFactory))
            {
                ProjectSessionContext.Bind(sessionFactory.OpenSession());
                logger.Info("ProjectSessionContext.OpenSession");
            }

            return this.sessionFactory.GetCurrentSession();
        }

        #region IProjectRepository Members

        public IList<Project> FindAll()
        {
            var session = OpenSessionIfRequired();
            //using (var session = this.sessionFactory.OpenSession())
            {
                return session.Query<Project>().ToList();
            }
        }

        public void Save(Project project)
        {
            var session = OpenSessionIfRequired();
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
            var session = OpenSessionIfRequired();
            //using (var session = this.sessionFactory.OpenSession())
            {
                return session.Query<Project>().Where(x => x.Id == projectId).FirstOrDefault();
            }
        }

        #endregion
    }
}