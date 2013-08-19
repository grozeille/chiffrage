using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using NHibernate;
using NHibernate.Linq;
using Chiffrage.Catalogs.Domain.Repositories;

namespace Chiffrage.Catalogs.Dal.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private static ILog logger = LogManager.GetLogger(typeof(TaskRepository));

        private readonly ISessionFactory sessionFactory;

        public TaskRepository(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
            SessionManager.OpenSessionIfRequired(this.sessionFactory);
        }


        public void Save(Domain.Task task)
        {
            var session = SessionManager.OpenSessionIfRequired(this.sessionFactory);
            using (var transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(task);
                session.Transaction.Commit();
            }
        }

        public void Save(IEnumerable<Domain.Task> tasks)
        {
            var session = SessionManager.OpenSessionIfRequired(this.sessionFactory);
            using (var transaction = session.BeginTransaction())
            {
                foreach (var item in tasks)
                {
                    session.SaveOrUpdate(item);
                }
                session.Transaction.Commit();
            }
        }

        public IList<Domain.Task> FindAll()
        {
            var session = SessionManager.OpenSessionIfRequired(this.sessionFactory);
            return session.Query<Domain.Task>().ToList();
        }

        public Domain.Task FindById(int taskId)
        {
            var session = SessionManager.OpenSessionIfRequired(this.sessionFactory);
            return session.Query<Domain.Task>().Where(x => x.Id == taskId).FirstOrDefault();
        }

        public void Delete(Domain.Task task)
        {
            var session = SessionManager.OpenSessionIfRequired(this.sessionFactory);
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(task);
                session.Transaction.Commit();
            }
        }
    }
}
