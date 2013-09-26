using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Dal.Repositories;
using Chiffrage.Mvc.Events;
using Chiffrage.Projects.Dal.Repositories;
using Common.Logging;
using NHibernate;
using NHibernate.Context;

namespace Chiffrage.App.Ioc
{
    public class ProjectSessionManagerService
    {
        private static ILog logger = LogManager.GetLogger(typeof(ProjectSessionManagerService));

        private readonly ISessionFactory sessionFactory;

        private readonly IEventBroker eventBroker;

        private static readonly object _syncRoot = new object();

        public ProjectSessionManagerService(ISessionFactory sessionFactory, IEventBroker eventBroker)
        {
            eventBroker.OnAfterSend += (msg) =>
                                           {
                                               logger.Debug("Close Project Session");
                                               var session = ProjectSessionContext.Unbind(sessionFactory);
                                               session.Clear();
                                           };

            eventBroker.OnBeforeSend += (msg) =>
                                            {
                                                logger.Debug("Open Project Session");
                                                OpenSessionIfRequired(sessionFactory);
                                            };
        }

        public ISession OpenSessionIfRequired(ISessionFactory sessionFactory)
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
                    }
                    return sessionFactory.GetCurrentSession();
                }
            }
        }
    }
}
