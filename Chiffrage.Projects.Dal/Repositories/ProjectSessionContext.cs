using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Context;
using NHibernate;
using NHibernate.Engine;

namespace Chiffrage.Projects.Dal.Repositories
{
    public class ProjectSessionContext : CurrentSessionContext
    {
		private static ISession _session;

		protected override ISession Session
		{
			get
			{
                return ProjectSessionContext._session;
			}
			set
			{
                ProjectSessionContext._session = value;
			}
		}

        public ProjectSessionContext(ISessionFactoryImplementor factory)
		{
		}
    }
}
