using System.Linq;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Catalogs.Domain.Repositories;
using Chiffrage.Core;
using NHibernate;

namespace Chiffrage.Catalogs.Dal.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        public ISessionFactory SessionFactory { get; set; }

        public void Save(Catalog catalog)
        {
            using (var session = this.SessionFactory.OpenSession())
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
            using (var session = this.SessionFactory.OpenSession())
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
            using (var session = this.SessionFactory.OpenSession())
            {
                return session.Query<SupplierCatalog>().ToList();
            }            
        }

        public SupplierCatalog FindById(int catalogId)
        {
            using (var session = this.SessionFactory.OpenSession())
            {
                return session.Query<SupplierCatalog>().Where(x => x.Id == catalogId).FirstOrDefault();
            }  
        }
    }
}