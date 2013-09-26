using System;

namespace Chiffrage.Projects.Module.ViewModel
{
    public class DealViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Reference { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Comment { get; set; }

        public double TotalDays { get; set; }

        public double TotalPrice { get; set; }
    }
}