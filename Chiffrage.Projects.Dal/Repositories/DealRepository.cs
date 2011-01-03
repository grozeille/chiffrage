using System.Collections.Generic;
using System.Linq;
using Chiffrage.Projects.Domain;
using Chiffrage.Projects.Domain.Repositories;
using NHibernate;
using NHibernate.Linq;

namespace Chiffrage.Projects.Dal.Repositories
{
    public class DealRepository : IDealRepository
    {
        private readonly ISessionFactory sessionFactory;

        public DealRepository(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        #region IDealRepository Members

        public IList<Deal> FindAll()
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                return session.Query<Deal>().ToList();
            }
        }

        public void Save(Deal deal)
        {
            using (var session = this.sessionFactory.OpenSession())
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
            using (var session = this.sessionFactory.OpenSession())
            {
                return session.Query<Deal>().Where(x => x.Id == dealId).FirstOrDefault();
            }
        }

        #endregion
    }
}