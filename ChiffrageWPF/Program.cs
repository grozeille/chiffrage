using System;
using System.Collections;
using Chiffrage.Catalogs.Dal.Repositories;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Mvc.Events;
using Common.Logging;
using Settings=ChiffrageWPF.Properties.Settings;
using System.Threading;
using ChiffrageWPF;
using Autofac;
using ChiffrageWPF.Ioc;
using Chiffrage.Projects.Module;
using Chiffrage.Catalogs.Module;
using ChiffrageWPF.Views;
using ChiffrageWPF.Views.Impl;

namespace Chiffrage
{
    internal class Program
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

                var builder = new ContainerBuilder();
                builder.RegisterModule(new NHibernateModule());
                builder.RegisterModule(new ProjectModule());
                builder.RegisterModule(new CatalogModule());
                builder.RegisterModule(new ChiffrageModule());

                var container = builder.Build();


                this.eventBroker = container.Resolve<IEventBroker>();
                this.eventBroker.Start();

                app.MainWindow.Close();

                app.MainWindow = container.Resolve<IApplicationView>() as ApplicationWindow;
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
    }
}