using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
using Chiffrage.Repositories;
using Chiffrage.Core;
using System.Threading;
using NHibernate;
using NHibernate.Cfg;
using Settings=Chiffrage.Properties.Settings;
using System.Reflection;
using System.IO;
using Common.Logging;

namespace Chiffrage
{
    static class Program
    {
        private static ILog logger = LogManager.GetLogger(typeof (Program));

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Catalog catalog = new Catalog();

            System.Data.SQLite.SQLiteConnection connectionCatalog = null;

            if(string.IsNullOrEmpty(Settings.Default.CatalogPath))
            {
                MessageBox.Show(
                    "Pas de catalogue détecté.\n\r Veuillez sélectionner un chemin de fichier pour un nouveau catalogue ou un catalogue existant.",
                    "Catalogue inexistant.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.CheckFileExists = false;
                openFileDialog.Filter = "Catalogue (*.ctb)|*.ctb";
                if(openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;                    
                }
                Settings.Default.CatalogPath = openFileDialog.FileName;
                Settings.Default.Save();
            }

            connectionCatalog = new SQLiteConnection(string.Format("Data Source={0};FailIfMissing=false", Settings.Default.CatalogPath));
            try
            {
                connectionCatalog.Open();
            }
            catch (Exception ex)
            {
                File.Delete(Settings.Default.CatalogPath);
                connectionCatalog = new SQLiteConnection(string.Format("Data Source={0};FailIfMissing=false", Settings.Default.CatalogPath));
                logger.Fatal("Cannot open catalog file", ex);
                throw;
            }
            

            Configuration configurationCatalog = new Configuration();
            configurationCatalog.Configure();

            try
            {
                configurationCatalog.AddAssembly(Assembly.GetExecutingAssembly());
            }catch(Exception ex)
            {
                logger.Fatal("Cannot configure NHibernate", ex);
                throw;
            }

            CatalogRepository catalogRepository = new CatalogRepository();
            try
            {
                configurationCatalog.Properties.Add("connection.connection_string", connectionCatalog.ConnectionString);
                ISessionFactory sf = configurationCatalog.BuildSessionFactory();
                ISession sessionCatalog = sf.OpenSession(connectionCatalog);
                catalogRepository.Session = sessionCatalog;            

            }catch(Exception ex)
            {
                logger.Fatal("Cannot open NHibernate session", ex);
                throw;
            }


            var form = new LoadingForm();
            var formMain = new FormMain();
            form.OnLoadingApplication = new EventHandler<LoadingEventArgs>(delegate(object sender, LoadingEventArgs args)
                                            {
                                                args.ReportProgress(10);
                                                catalog.SupplierCatalogs = catalogRepository.FindAll();                                                
                                                args.ReportProgress(60);
                                                formMain.Catalog = catalog;
                                                formMain.CatalogRepository = catalogRepository;
                                                formMain.Configuration = configurationCatalog;
                                                formMain.LoadLastDealFile();
                                                args.ReportProgress(100);
                                            });
            try
            {

                Application.Run(form);

                Application.Run(formMain);
            }
            catch (Exception ex)
            {
                logger.Fatal("Unexpected error during program execution", ex);
                throw;
            }

            connectionCatalog.Close();
        }
    }
}
