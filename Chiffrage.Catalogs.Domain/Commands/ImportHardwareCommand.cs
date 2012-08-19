using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Commands
{
    public class ImportHardwareCommand
    {
        private readonly int catalogId;

        private readonly string filePath;

        public ImportHardwareCommand(int catalogId, string filePath)
        {
            this.catalogId = catalogId;
            this.filePath = filePath;
        }

        public int CatalogId
        {
            get
            {
                return this.catalogId;
            }
        }

        public string FilePath
        {
            get
            {
                return this.filePath;
            }
        }
    }
}
