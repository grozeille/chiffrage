using System.Collections.Generic;
using System.Linq;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Catalogs.Domain.Repositories;
using NHibernate;
using NHibernate.Linq;

namespace Chiffrage.Catalogs.Dal.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly ISessionFactory sessionFactory;

        public CatalogRepository(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        #region ICatalogRepository Members

        public void Save(Catalog catalog)
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    foreach (var item in catalog.SupplierCatalogs)
                        session.SaveOrUpdate(item);
                    session.Transaction.Commit();
                }
            }
        }

        public void Save(SupplierCatalog catalog)
        {
            using (var session = this.sessionFactory.OpenSession())
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
            using (var session = this.sessionFactory.OpenSession())
            {
                return session.Query<SupplierCatalog>().ToList();
            }
        }

        public SupplierCatalog FindById(int catalogId)
        {
            using (var session = this.sessionFactory.OpenSession())
            {
                return session.Query<SupplierCatalog>().Where(x => x.Id == catalogId).FirstOrDefault();
            }
        }

        #endregion
    }
}