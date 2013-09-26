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
            SessionManager.OpenSessionIfRequired(this.sessionFactory);
        }

        #region ICatalogRepository Members

        public void Save(SupplierCatalog catalog)
        {
            var session = SessionManager.OpenSessionIfRequired(this.sessionFactory);
            using (var transaction = session.BeginTransaction())
            {
                foreach(var hardware in catalog.Hardwares)
                {
                    var tasks = new List<HardwareTask>(hardware.Tasks);
                    hardware.Tasks.Clear();
                    foreach (var item in tasks)
                    {
                        hardware.Tasks.Add(session.Merge(item));
                    }
                }

                session.SaveOrUpdate(catalog);
                session.Transaction.Commit();
            }
        }

        public IList<SupplierCatalog> FindAll()
        {
            var session = SessionManager.OpenSessionIfRequired(this.sessionFactory);
            return session.Query<SupplierCatalog>().ToList();
        }

        public SupplierCatalog FindById(int catalogId)
        {
            var session = SessionManager.OpenSessionIfRequired(this.sessionFactory);
            return session.Query<SupplierCatalog>().Where(x => x.Id == catalogId).FirstOrDefault();
        }

        public void Delete(SupplierCatalog catalog)
        {
            var session = SessionManager.OpenSessionIfRequired(this.sessionFactory);
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