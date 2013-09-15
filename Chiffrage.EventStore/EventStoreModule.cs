using Autofac;
using Chiffrage.EventStore.Repositories;
using Chiffrage.EventStore.Services;
using Chiffrage.Mvc.Services;
using NHibernate;
using Chiffrage.Mvc.Events;

namespace Chiffrage.EventStore
{
    public class EventStoreModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<IEventRepository>(x => new EventRepository(x.ResolveNamed<ISessionFactory>("EventSessionFactory"))).SingleInstance();

            builder.RegisterAssemblyTypes(typeof(EventStoreService).Assembly)
                .Where(t => t.GetInterface(typeof(IService).Name) != null && !t.IsAbstract && t.IsPublic)
                .AsImplementedInterfaces()
                .SingleInstance()
                .OnActivated(x =>
                {
                    x.Context.Resolve<IEventBroker>().Subscribe(x.Instance);
                });

            base.Load(builder);
        }
    }
}
