using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grozeille.Chiffrage.Core
{
    public class OtherBenefit
    {
        public string Name { get; set; }

        public double Days { get; set; }

        public double CostRate { get; set; }

        public double TotalCost
        {
            get
            {
                return this.Days*this.CostRate;
            }
        }
    }
}
