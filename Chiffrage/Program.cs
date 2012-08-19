using System;
using System.Collections;
using System.Windows.Forms;
using Chiffrage.Catalogs.Dal.Repositories;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Ioc;
using Chiffrage.Mvc.Events;
using Common.Logging;
using NHibernate;
using NHibernate.Cfg;
using Settings = Chiffrage.Properties.Settings;
using System.Threading;
using System.Linq;
using Chiffrage.Mvc.Views;
using Chiffrage.Mvc.Controllers;
using Chiffrage.Mvc.Services;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using Chiffrage.Projects.Dal.Repositories;
using NHibernate.Cfg.MappingSchema;
using System.IO;
using System.Reflection;
using Strongshell.Recoil.Core.Integration;
using Chiffrage.Common.Module.Actions;
using Autofac;
using Chiffrage.App.Views;

namespace Chiffrage
{
    internal class Program : IGenericEventHandler<ApplicationEndAction>
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
                builder.RegisterModule(new DealModule());
                builder.RegisterModule(new CatalogModule());
                builder.RegisterModule(new MvcModule());

                var container = builder.Build();

                this.eventBroker = container.Resolve<IEventBroker>();
                this.eventBroker.Start();
                this.eventBroker.Publish(new ApplicationStartAction());

                loadingForm.Stop();

                var applicationForm = container.Resolve<IApplicationView>();
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

        public void ProcessAction(ApplicationEndAction eventObject)
        {
            this.eventBroker.Stop();
        }
    }
}