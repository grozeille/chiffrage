using System.Collections.Generic;
using System.Linq;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Catalogs.Domain.Repositories;
using NHibernate;
using NHibernate.Linq;
using Common.Logging;

namespace Chiffrage.Catalogs.Dal.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private static ILog logger = LogManager.GetLogger(typeof(CatalogRepository));

        private readonly ISessionFactory sessionFactory;

        public CatalogRepository(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        private ISession OpenSessionIfRequired()
        {
            if (!CatalogSessionContext.HasBind(sessionFactory))
            {
                CatalogSessionContext.Bind(sessionFactory.OpenSession());
                logger.Info("CatalogSessionContext.OpenSession");
            }

            return this.sessionFactory.GetCurrentSession();
        }

        #region ICatalogRepository Members

        public void Save(SupplierCatalog catalog)
        {
            var session = OpenSessionIfRequired();
            //using (var session = this.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(catalog);
                    session.Transaction.Commit();
                }
            }
        }

        public IList<SupplierCatalog> FindAll()
        {
            var session = OpenSessionIfRequired();
            //using (var session = this.sessionFactory.OpenSession())
            {
                return session.Query<SupplierCatalog>().ToList();
            }
        }

        public SupplierCatalog FindById(int catalogId)
        {
            var session = OpenSessionIfRequired();
            //using (var session = this.sessionFactory.OpenSession())
            {
                return session.Query<SupplierCatalog>().Where(x => x.Id == catalogId).FirstOrDefault();
            }
        }

        public void Delete(SupplierCatalog catalog)
        {
            var session = OpenSessionIfRequired();
            using (var transaction = session.BeginTransaction())
            {
                foreach (Hardware h in catalog.Hardwares)
                {
                    foreach (HardwareSupply s in h.Components)
                    {
                        session.Delete(s);
                    }
                }

                session.Delete(catalog);
                session.Transaction.Commit();
            }
        }

        #endregion
    }
}