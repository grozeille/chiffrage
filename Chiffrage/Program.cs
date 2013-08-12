using System;
using System.Collections;
using System.Windows.Forms;
using Chiffrage.Catalogs.Dal.Repositories;
using Chiffrage.Catalogs.Domain;
using Chiffrage.App.Ioc;
using Chiffrage.Mvc.Events;
using Common.Logging;
using Settings = Chiffrage.App.Properties.Settings;
using System.Threading;
using System.Linq;
using Chiffrage.Mvc.Views;
using Chiffrage.Mvc.Controllers;
using Chiffrage.Mvc.Services;
using Chiffrage.Projects.Dal.Repositories;
using System.IO;
using System.Reflection;
using Chiffrage.Common.Module.Actions;
using Autofac;
using Chiffrage.App.Views;
using Chiffrage.Catalogs.Module;
using Chiffrage.Projects.Module;

namespace Chiffrage.App
{
    internal class Program
    {
        private static ILog logger = LogManager.GetLogger(typeof(Program));

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

                var builder = new ContainerBuilder();
                builder.RegisterModule(new NHibernateModule());
                builder.RegisterModule(new ProjectModule());
                builder.RegisterModule(new CatalogModule());
                builder.RegisterModule(new ChiffrageModule());

                var container = builder.Build();


                this.eventBroker = container.Resolve<IEventBroker>();
                this.eventBroker.Start();
                

                loadingForm.Stop();

                var applicationForm = container.Resolve<IApplicationView>();

                this.eventBroker.Publish(new ApplicationStartAction());

                Application.Run((ApplicationForm)applicationForm);
                this.eventBroker.Stop();
            }
            catch (Exception ex)
            {
                logger.Fatal("Fatal error", ex);
                Application.OnThreadException(ex);
                if (this.eventBroker != null)
                {
                    this.eventBroker.Stop();
                }
            }
        }

        [Subscribe]
        public void ProcessAction(ApplicationEndAction eventObject)
        {
            this.eventBroker.Stop();
        }
    }
}