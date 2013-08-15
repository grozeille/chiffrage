using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Commands
{
    public class DeleteCatalogCommand
    {
        public int CatalogId { get; private set; }

        public DeleteCatalogCommand(int catalogId)
        {
            this.CatalogId = catalogId;
        }
    }
}
