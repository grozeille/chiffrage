using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using Chiffrage.Projects.Dal.Repositories;
using NHibernate.Cfg.MappingSchema;
using Chiffrage.Projects.Domain.Repositories;
using Chiffrage.Mvc.Views;
using Chiffrage.Mvc.Controllers;
using Chiffrage.Mvc.Services;
using NHibernate;

namespace Chiffrage.Projects.Module
{
    public class ProjectModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<IDealRepository>(x => new DealRepository(x.ResolveNamed<ISessionFactory>("ProjectSessionFactory"))).SingleInstance();
            builder.Register<IProjectRepository>(x => new ProjectRepository(x.ResolveNamed<ISessionFactory>("ProjectSessionFactory"))).SingleInstance();

            builder.RegisterAssemblyTypes(this.ThisAssembly)
               .Where(t => t.GetInterface(typeof(IView).Name) != null && !t.IsAbstract && t.IsPublic)
               .AsImplementedInterfaces()
               .SingleInstance();

            builder.RegisterAssemblyTypes(this.ThisAssembly)
                .Where(t => t.GetInterface(typeof(IController).Name) != null && !t.IsAbstract && t.IsPublic)
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterAssemblyTypes(this.ThisAssembly)
                .Where(t => t.GetInterface(typeof(IService).Name) != null && !t.IsAbstract && t.IsPublic)
                .AsImplementedInterfaces()
                .SingleInstance();

            base.Load(builder);
        }
    }
}
