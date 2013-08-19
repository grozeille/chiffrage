using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using NHibernate;

namespace Chiffrage.Catalogs.Dal.Repositories
{
    public class SessionManager
    {
        private static ILog logger = LogManager.GetLogger(typeof(SessionManager));
        private static readonly object _syncRoot = new object();

        public static ISession OpenSessionIfRequired(ISessionFactory sessionFactory)
        {
            if (CatalogSessionContext.HasBind(sessionFactory))
            {
                return sessionFactory.GetCurrentSession();
            }
            else
            {
                lock (_syncRoot)
                {
                    if (!CatalogSessionContext.HasBind(sessionFactory))
                    {
                        CatalogSessionContext.Bind(sessionFactory.OpenSession());
                        logger.Info("CatalogSessionContext.OpenSession");
                    }
                    return sessionFactory.GetCurrentSession();
                }
            }
        }
    }
}
