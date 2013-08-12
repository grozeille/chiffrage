using System.Collections.Generic;
using System.Linq;
using Chiffrage.Projects.Domain;
using Chiffrage.Projects.Domain.Repositories;
using NHibernate;
using NHibernate.Linq;
using Common.Logging;
using NHibernate.Context;
using Chiffrage.Catalogs.Dal.Repositories;

namespace Chiffrage.Projects.Dal.Repositories
{
    public class DealRepository : IDealRepository
    {
        private static ILog logger = LogManager.GetLogger(typeof(DealRepository));

        private readonly ISessionFactory sessionFactory;

        public DealRepository(ISessionFactory sessionFactory)
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

        #region IDealRepository Members

        public IList<Deal> FindAll()
        {

            var session = OpenSessionIfRequired();
            //using (var session = this.sessionFactory.OpenSession())
            {
                return session.Query<Deal>().ToList();
            }
        }

        public void Save(Deal deal)
        {
            var session = OpenSessionIfRequired();
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
            var session = OpenSessionIfRequired();

            //using (var session = this.sessionFactory.OpenSession())
            {   
                return session.Query<Deal>().Where(x => x.Id == dealId).FirstOrDefault();
            }
        }

        #endregion
    }
}