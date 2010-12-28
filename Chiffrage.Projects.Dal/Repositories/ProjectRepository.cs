using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Core;
using Chiffrage.Projects.Domain;
using Chiffrage.Projects.Domain.Repositories;
using NHibernate;
using NHibernate.Linq;

namespace Chiffrage.Projects.Dal.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ISessionFactory sessionFactory;

        public ProjectRepository(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        public IList<Project> FindAll()
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                return session.Query<Project>().ToList();
            }
        }

        public void Save(Project project)
        {
            using (var session = this.sessionFactory.OpenSession())
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
            using (var session = this.sessionFactory.OpenSession())
            {
                return session.Query<Project>().Where(x => x.Id == projectId).FirstOrDefault();
            }
        }
    }
}