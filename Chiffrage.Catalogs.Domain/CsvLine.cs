using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvHelper.Configuration;
using System.ComponentModel;

namespace Chiffrage.Catalogs.Domain
{
    public class CsvLine
    {
        [CsvField(Index = 0)]
        public string Hardware { get; set; }

        [CsvField(Index = 1)]
        public string Supply { get; set; }

        [CsvField(Index = 2)]
        public string Reference { get; set; }

        [CsvField(Index = 3)]
        [TypeConverter(typeof(EmptyInt32TypeConverter))]
        public int Module { get; set; }

        [CsvField(Index = 4)]
        [TypeConverter(typeof(EmptyInt32TypeConverter))]
        public int Quantity { get; set; }

        [CsvField(Index = 5)]
        public string Comment { get; set; }
    }
}
