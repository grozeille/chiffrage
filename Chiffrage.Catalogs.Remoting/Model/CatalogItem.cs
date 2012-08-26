using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Catalogs.Remoting.Model
{
    [Serializable]
    public class CatalogItem
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
