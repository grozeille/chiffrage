using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using NHibernate;

namespace Chiffrage.EventStore.Repositories
{
    public class SessionManager
    {
        private static ILog logger = LogManager.GetLogger(typeof(SessionManager));
        private static readonly object _syncRoot = new object();

        public static ISession OpenSessionIfRequired(ISessionFactory sessionFactory)
        {
            if (EventStoreSessionContext.HasBind(sessionFactory))
            {
                return sessionFactory.GetCurrentSession();
            }
            else
            {
                lock (_syncRoot)
                {
                    if (!EventStoreSessionContext.HasBind(sessionFactory))
                    {
                        EventStoreSessionContext.Bind(sessionFactory.OpenSession());
                        logger.Info("EventStoreSessionContext.OpenSession");
                    }
                    return sessionFactory.GetCurrentSession();
                }
            }
        }
    }
}
