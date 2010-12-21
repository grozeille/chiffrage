using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Projects.Domain;

namespace Chiffrage.ViewModel
{
    public class DealViewModel
    {
        public static DealViewModel Build(Deal deal)
        {
            if (deal == null)
                return null;

            return new DealViewModel
            {
                Id = deal.Id,
                Name = deal.Name,
                Reference = deal.Reference,
                StartDate = deal.StartDate,
                EndDate = deal.EndDate,
                Comment = deal.Comment
            };
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Reference { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Comment { get; set; }
    }
}
