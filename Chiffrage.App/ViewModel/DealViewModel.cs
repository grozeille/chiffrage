using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Projects.Domain;

namespace Chiffrage.App.ViewModel
{
    public class DealViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Reference { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Comment { get; set; }
    }
}