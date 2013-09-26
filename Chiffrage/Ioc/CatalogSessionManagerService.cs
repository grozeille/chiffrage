using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Dal.Repositories;
using Chiffrage.Mvc.Events;
using Common.Logging;
using NHibernate;
using NHibernate.Context;

namespace Chiffrage.App.Ioc
{
    public class CatalogSessionManagerService
    {
        private static ILog logger = LogManager.GetLogger(typeof(CatalogSessionManagerService));

        private readonly ISessionFactory sessionFactory;

        private readonly IEventBroker eventBroker;

        private static readonly object _syncRoot = new object();

        public CatalogSessionManagerService(ISessionFactory sessionFactory, IEventBroker eventBroker)
        {
            eventBroker.OnAfterSend += (msg) =>
                                           {
                                               logger.Debug("Close Catalog Session");
                                               var session = CatalogSessionContext.Unbind(sessionFactory);
                                               session.Clear();
                                           };

            eventBroker.OnBeforeSend += (msg) =>
                                            {
                                                logger.Debug("Open Catalog Session");
                                                OpenSessionIfRequired(sessionFactory);
                                            };
        }

        public ISession OpenSessionIfRequired(ISessionFactory sessionFactory)
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
                    }
                    return sessionFactory.GetCurrentSession();
                }
            }
        }
    }
}
