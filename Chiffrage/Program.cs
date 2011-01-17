using System;
using System.Collections;
using System.Windows.Forms;
using Chiffrage.Catalogs.Dal.Repositories;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Ioc;
using Chiffrage.Mvc.Events;
using Common.Logging;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.ByteCode.Spring;
using NHibernate.Cfg;
using Spring.Context;
using Spring.Context.Support;
using Strongshell.Recoil.Core.Integration;
using Settings=Chiffrage.Properties.Settings;
using System.Threading;

namespace Chiffrage
{
    public static class AplicationContextExtension
    {
        public static T GetObject<T>(this IApplicationContext applicationContext)
        {
            foreach (DictionaryEntry item in  applicationContext.GetObjectsOfType(typeof (T)))
            {
                return (T) item.Value;
            }

            return default(T);
        }
    }

    internal class Program : IGenericEventHandler<ApplicationEndEvent>
    {
        private static ILog logger = LogManager.GetLogger(typeof (Program));


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            new Program().Start();
        }

        private IEventBroker eventBroker;

        public void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            logger.InfoFormat("Start");

            try
            {
                var loadingForm = new LoadingForm();
                loadingForm.Start();

                var myContext = new GenericApplicationContext();
                myContext.Configure()
                    .With<CatalogContainer>()
                    .With<DealContainer>()
                    .With<MvcContainer>();


                myContext.Refresh();

                this.eventBroker = myContext.GetObject<IEventBroker>();
                this.eventBroker.Start();
                this.eventBroker.Publish(new ApplicationStartEvent());

                loadingForm.Stop();

                Application.Run(myContext.GetObject<ApplicationForm>());
                this.eventBroker.Stop();
            }
            catch (Exception ex)
            {
                logger.Fatal("Fatal error", ex);
                Application.OnThreadException(ex);
            }
        }

        public void ProcessAction(ApplicationEndEvent eventObject)
        {
            this.eventBroker.Stop();
        }
    }
}