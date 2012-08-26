using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Common.Logging;
using System.Net;
using System.Threading;
using System.IO;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using Chiffrage.Catalogs.Domain.Repositories;
using System.Windows.Forms;
using Chiffrage.Catalogs.Remoting.Contracts.Services;
using Chiffrage.Catalogs.Remoting.Contracts;
using Chiffrage.Catalogs.Remoting.Contracts.Model;

namespace Chiffrage.Catalogs.Remoting.Services
{
    public class CatalogRemoteService : MarshalByRefObject, IStartable, ICatalogRemoteService
    {
        private ILog logger = LogManager.GetLogger<CatalogRemoteService>();

        public ICatalogRepository CatalogRepository { get; set; }

        private readonly RichTextBox richTextBox = new RichTextBox();

        public CatalogRemoteService()
        {
        }

        public void Start()
        {
            TcpChannel channel = new TcpChannel(Consts.Port);
            // Enregistrement du canal
            ChannelServices.RegisterChannel(channel, false);
            RemotingServices.Marshal(this, Consts.ServiceName, typeof(ICatalogRemoteService));
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

        public CatalogItem[] GetCatalogs()
        {
            return this.CatalogRepository.FindAll().Select(x => new CatalogItem { Id = x.Id, Name = x.SupplierName }).ToArray();
        }

        public object[,] GetCatalogData(int catalogId)
        {
            var catalog = this.CatalogRepository.FindById(catalogId);

            List<List<object>> rows = new List<List<object>>();

            foreach (var item in catalog.Hardwares)
            {
                foreach(var component in item.Components)
                {
                    List<object> columns = new List<object>();
                    columns.Add(item.Name);
                    columns.Add(component.Supply.Name);
                    columns.Add(component.Supply.Reference);
                    columns.Add(component.Quantity);
                    if (!string.IsNullOrEmpty(component.Comment) && component.Comment.StartsWith("{\\rtf"))
                    {
                        richTextBox.Rtf = component.Comment;
                        columns.Add(richTextBox.Text);
                    }
                    else
                    {
                        columns.Add(component.Comment);
                    }
                    
                    columns.Add(component.Supply.ModuleSize);

                    rows.Add(columns);
                }
            }

            foreach (var item in catalog.Supplies)
            {
                List<object> columns = new List<object>();
                columns.Add(string.Empty);
                columns.Add(item.Name);
                columns.Add(item.Reference);
                columns.Add(string.Empty);
                columns.Add(string.Empty);
                columns.Add(item.ModuleSize);

                rows.Add(columns);
            }

            var data = new object[rows.Count, 6];

            for (int cptRow = 0; cptRow < rows.Count; cptRow++)
            {
                for (int cptColumn = 0; cptColumn < 6; cptColumn++)
                {
                    data[cptRow, cptColumn] = rows[cptRow][cptColumn];
                }
            }

            return data;
        }


        public bool Ping()
        {
            return true;
        }
    }
}
