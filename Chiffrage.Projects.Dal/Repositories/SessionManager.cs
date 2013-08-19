using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using NHibernate;

namespace Chiffrage.Projects.Dal.Repositories
{
    public class SessionManager
    {
        private static ILog logger = LogManager.GetLogger(typeof(SessionManager));
        private static readonly object _syncRoot = new object();

        public static ISession OpenSessionIfRequired(ISessionFactory sessionFactory)
        {
            if (ProjectSessionContext.HasBind(sessionFactory))
            {
                return sessionFactory.GetCurrentSession();
            }
            else
            {
                lock (_syncRoot)
                {
                    if (!ProjectSessionContext.HasBind(sessionFactory))
                    {
                        ProjectSessionContext.Bind(sessionFactory.OpenSession());
                        logger.Info("ProjectSessionContext.OpenSession");
                    }
                    return sessionFactory.GetCurrentSession();
                }
            }
        }
    }
}
