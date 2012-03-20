using System;
using System.Collections;
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
using Settings=ChiffrageWPF.Properties.Settings;
using System.Threading;
using ChiffrageWPF;

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
            logger.InfoFormat("Start");
            
            var app = new ChiffrageWPF.App();


            try
            {
                
                var loadingForm = new LoadingWindow();
                app.MainWindow = loadingForm;
                app.MainWindow.Show();
                //new Thread(() => app.Run()).Start();

                var myContext = new GenericApplicationContext();
                myContext.Configure()
                    .With<CatalogContainer>()
                    .With<DealContainer>()
                    .With<MvcContainer>();


                myContext.Refresh();

                this.eventBroker = myContext.GetObject<IEventBroker>();
                this.eventBroker.Start();
                this.eventBroker.Publish(new ApplicationStartEvent());

                app.MainWindow.Close();

                app.MainWindow = myContext.GetObject<ApplicationWindow>();
                app.MainWindow.Show();
                app.Run(app.MainWindow);
                this.eventBroker.Stop();
            }
            catch (Exception ex)
            {
                logger.Fatal("Fatal error", ex);
                app.DispatcherUnhandledException += (sender, e) =>
                    {
                        logger.Fatal("Unhandled exception", e.Exception);
                        this.eventBroker.Stop();
                    };
                if (this.eventBroker != null)
                {
                    this.eventBroker.Stop();
                }
            }
        }

        public void ProcessAction(ApplicationEndEvent eventObject)
        {
            this.eventBroker.Stop();
        }
    }
}