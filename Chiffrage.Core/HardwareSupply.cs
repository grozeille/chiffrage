using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Core
{
    public class HardwareSupply : ICatalogItem
    {
        private Supply supply;

        public HardwareSupply()
        {
            this.Supply = new Supply();
            this.Quantity = 1;
        }

        public virtual int Id { get; set; }
        public virtual string Name
        {
            get { return this.Supply.Name; }
        }

        public virtual string Reference
        {
            get { return this.Supply.Reference; }
        }

        public virtual string Category
        {
            get { return this.Supply.Category; }
        }

        public virtual int ModuleSize
        {
            get { return this.Supply.ModuleSize; }
        }

        public virtual double CatalogPrice
        {
            get { return this.Supply.CatalogPrice; }
        }

        public virtual double StudyDays
        {
            get { return this.Supply.StudyDays; }
        }

        public virtual double ReferenceDays
        {
            get { return this.Supply.ReferenceDays; }
        }

        public virtual double CatalogWorkDays
        {
            get { return this.Supply.CatalogWorkDays; }
        }

        public virtual double CatalogExecutiveWorkDays
        {
            get { return this.Supply.CatalogExecutiveWorkDays; }
        }

        public virtual double CatalogTestsDays
        {
            get { return this.Supply.CatalogTestsDays; }
        }

        public virtual Supply Supply
        {
            get { return this.supply; }
            set
            {
                this.supply = value;
            }
        }

        public virtual int Quantity { get; set; }

        #region ICloneable Members

        public virtual object Clone()
        {
            var hardwareSupply =  (HardwareSupply)this.MemberwiseClone();
            hardwareSupply.supply = (Supply)this.supply.Clone();
            return hardwareSupply;
        }

        #endregion
    }
}
