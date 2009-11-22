using System.Collections.Generic;
using System.ComponentModel;

namespace Chiffrage.Core
{
    public class SupplierCatalog : INotifyPropertyChanged
    {
        private string comment;
        private int id;

        private string supplierName;

        private IList<Supply> supplies;

        private IList<Hardware> hardwares;

        private IList<Cable> cables;

        public SupplierCatalog()
        {
            this.supplies = new List<Supply>();
            this.hardwares = new List<Hardware>();
            this.cables = new List<Cable>();
        }

        public virtual int Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
                this.FirePropertyChanged("Id");
            }
        }

        public virtual string SupplierName
        {
            get { return this.supplierName; }
            set
            {
                this.supplierName = value;
                this.FirePropertyChanged("SupplierName");
            }
        }

        public virtual IList<Supply> Supplies
        {
            get { return this.supplies; }
            set
            {
                this.supplies = value;
                this.FirePropertyChanged("Supplies");
            }
        }

        public virtual IList<Hardware> Hardwares
        {
            get { return this.hardwares; }
            set
            {
                this.hardwares = value;
                this.FirePropertyChanged("Hardwares");
            }
        }

        public virtual IList<Cable> Cables
        {
            get { return this.cables; }
            set
            {
                this.cables = value;
                this.FirePropertyChanged("Cables");
            }
        }

        public virtual string Comment
        {
            get { return this.comment; }
            set
            {
                this.comment = value;
                this.FirePropertyChanged("Comment");
            }
        }

        #region INotifyPropertyChanged Members

        public virtual event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private void FirePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}