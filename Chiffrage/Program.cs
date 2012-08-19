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
using Spring.Context;
using Spring.Context.Support;
using Settings = Chiffrage.Properties.Settings;
using System.Threading;
using System.Linq;
using Chiffrage.Mvc.Views;
using Chiffrage.Mvc.Controllers;
using Chiffrage.Mvc.Services;
using Spring.Objects.Factory.Config;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using Chiffrage.Projects.Dal.Repositories;
using NHibernate.Cfg.MappingSchema;
using System.IO;
using System.Reflection;
using Strongshell.Recoil.Core.Integration;
using Chiffrage.Common.Module.Actions;

namespace Chiffrage
{
    public static class AplicationContextExtension
    {
        public static T GetObject<T>(this IApplicationContext applicationContext)
        {
            foreach (DictionaryEntry item in applicationContext.GetObjectsOfType(typeof(T)))
            {
                return (T)item.Value;
            }

            return default(T);
        }
    }

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

                var myContext = new GenericApplicationContext();
                myContext.Configure()
                    .With<CatalogContainer>()
                    .With<DealContainer>()
                    .With<MvcContainer>();


                myContext.Refresh();

                this.eventBroker = myContext.GetObject<IEventBroker>();
                this.eventBroker.Start();
                this.eventBroker.Publish(new ApplicationStartAction());

                loadingForm.Stop();

                var applicationForm = myContext.GetObject<ApplicationForm>();
                Application.Run(applicationForm);
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