using System.Collections.Generic;
using System.Linq;
using Chiffrage.Projects.Domain;
using Chiffrage.Projects.Domain.Repositories;
using NHibernate;
using NHibernate.Linq;
using Common.Logging;

namespace Chiffrage.Projects.Dal.Repositories
{
    public class DealRepository : IDealRepository
    {
        private static ILog logger = LogManager.GetLogger(typeof(DealRepository));

        private readonly ISessionFactory sessionFactory;

        public DealRepository(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
            SessionManager.OpenSessionIfRequired(this.sessionFactory);
        }

        #region IDealRepository Members

        public IList<Deal> FindAll()
        {

            var session = SessionManager.OpenSessionIfRequired(this.sessionFactory);
            //using (var session = this.sessionFactory.OpenSession())
            {
                return session.Query<Deal>().ToList();
            }
        }

        public void Save(Deal deal)
        {
            var session = SessionManager.OpenSessionIfRequired(this.sessionFactory);
            //using (var session = this.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(deal);
                    session.Transaction.Commit();
                }
            }
        }

        public Deal FindById(int dealId)
        {
            var session = SessionManager.OpenSessionIfRequired(this.sessionFactory);

            //using (var session = this.sessionFactory.OpenSession())
            {   
                return session.Query<Deal>().Where(x => x.Id == dealId).FirstOrDefault();
            }
        }

        public void Delete(Deal deal)
        {
            var session = SessionManager.OpenSessionIfRequired(this.sessionFactory);
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(deal);
                session.Transaction.Commit();
            }
        }
        #endregion
    }
}