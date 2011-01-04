using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.App.ViewModel
{
    public class LogItemViewModel
    {
        public string Message { get; set; }

        public DateTime Date { get; set; }

        public SeverityType Severity { get; set; }
    }
}
