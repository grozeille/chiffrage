using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Core;
using Chiffrage.Core.Repositories;
using NHibernate;

namespace Chiffrage.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        public ISession Session { get; set; }

        public void Save(Catalog catalog)
        {
            Session.BeginTransaction();
            try
            {
                foreach (var item in catalog.SupplierCatalogs)
                    Session.SaveOrUpdateCopy(item);
                Session.Transaction.Commit();
            }
            catch
            {
                Session.Transaction.Rollback();
            }
        }

        public SupplierCatalog Save(SupplierCatalog catalog)
        {
            Session.BeginTransaction();
            try
            {
                Session.SaveOrUpdateCopy(catalog);
                Session.Transaction.Commit();
                return catalog;
            }
            catch(Exception ex)
            {
                Session.Transaction.Rollback();
                throw;
            }
        }

        public IList<SupplierCatalog> FindAll()
        {
            Session.Clear();
            return Session.CreateCriteria(typeof(SupplierCatalog)).List<SupplierCatalog>();
        }
    }
}
