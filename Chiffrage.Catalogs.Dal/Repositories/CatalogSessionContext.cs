using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Context;
using NHibernate;
using NHibernate.Engine;

namespace Chiffrage.Catalogs.Dal.Repositories
{
    public class CatalogSessionContext : CurrentSessionContext
    {
        private static ISession _session;

		protected override ISession Session
		{
			get
			{
                return CatalogSessionContext._session;
			}
			set
			{
                CatalogSessionContext._session = value;
			}
		}

        public CatalogSessionContext(ISessionFactoryImplementor factory)
		{
		}
    }
}
