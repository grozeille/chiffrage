using System;
using System.Collections.Generic;
using System.Text;

namespace Chiffrage.Core
{
    public class OtherBenefit
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual double Days { get; set; }

        public virtual double CostRate { get; set; }

        public virtual double TotalCost
        {
            get
            {
                return this.Days*this.CostRate;
            }
        }
    }
}
