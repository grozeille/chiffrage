using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Commands
{
    public class UpdateCatalogCommand : IEvent
    {
        private readonly int catalogId;

        private readonly string name;

        private readonly string comment;

        public UpdateCatalogCommand(int catalogId, string name, string comment)
        {
            this.catalogId = catalogId;
            this.name = name;
            this.comment = comment;
        }

        public int CatalogId { get { return this.catalogId; } }

        public string Name { get { return this.name; } }

        public string Comment { get { return this.comment; } }
    }
}
