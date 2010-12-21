using System;
using System.Windows.Forms;
using Chiffrage.Catalogs.Dal.Repositories;
using Chiffrage.Catalogs.Domain;
using Common.Logging;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using Settings = Chiffrage.Properties.Settings;

namespace Chiffrage
{
    static class Program
    {
        private static ILog logger = LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Catalog catalog = new Catalog();

                if (string.IsNullOrEmpty(Settings.Default.CatalogPath))
                {
                    MessageBox.Show(
                        "Pas de catalogue détecté.\n\r Veuillez sélectionner un chemin de fichier pour un nouveau catalogue ou un catalogue existant.",
                        "Catalogue inexistant.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.CheckFileExists = false;
                    openFileDialog.Filter = "Catalogue (*.ctb)|*.ctb";
                    if (openFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    Settings.Default.CatalogPath = openFileDialog.FileName;
                    Settings.Default.Save();
                }

                Configuration configurationCatalog = Fluently.Configure()
                    .Database(SQLiteConfiguration.Standard
                        .UsingFile(Settings.Default.CatalogPath)
                        .ProxyFactoryFactory(typeof(NHibernate.ByteCode.Spring.ProxyFactoryFactory)))
                    .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(CatalogRepository).Assembly))
                    .BuildConfiguration();

                configurationCatalog.Properties["hbm2ddl.auto"] = "update";

                using (ISessionFactory sf = configurationCatalog.BuildSessionFactory())
                {
                    var catalogRepository = new CatalogRepository();
                    catalogRepository.SessionFactory = sf;

                    var formLoading = new LoadingForm();
                    var formMain = new FormMain();
                    formLoading.OnLoadingApplication =
                        new EventHandler<LoadingEventArgs>(delegate(object sender, LoadingEventArgs args)
                                                           {
                                                               args.ReportProgress(10);
                                                               catalog.SupplierCatalogs = catalogRepository.FindAll();
                                                               args.ReportProgress(60);
                                                               formMain.Catalog = catalog;
                                                               formMain.CatalogRepository = catalogRepository;
                                                               formMain.LoadLastDealFile();
                                                               args.ReportProgress(100);
                                                           });


                    Application.Run(formLoading);

                    Application.Run(formMain);
                }                
            }
            catch (Exception ex)
            {
                logger.Fatal("Unexpected error during program execution", ex);
                throw;
            }
        }
    }
}
