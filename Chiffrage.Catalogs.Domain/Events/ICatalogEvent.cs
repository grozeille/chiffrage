using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Catalogs.Domain.Events
{
    public interface ICatalogEvent
    {
        int CatalogId { get; }
    }
}
