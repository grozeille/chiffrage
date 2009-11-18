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

        public SupplierCatalog()
        {
            supplies = new List<Supply>();
        }

        public virtual int Id
        {
            get { return id; }
            set
            {
                id = value;
                FirePropertyChanged("Id");
            }
        }

        public virtual string SupplierName
        {
            get { return supplierName; }
            set
            {
                supplierName = value;
                FirePropertyChanged("SupplierName");
            }
        }

        public virtual IList<Supply> Supplies
        {
            get { return supplies; }
            set
            {
                supplies = value;
                FirePropertyChanged("Supplies");
            }
        }

        public virtual string Comment
        {
            get { return comment; }
            set
            {
                comment = value;
                FirePropertyChanged("Comment");
            }
        }

        #region INotifyPropertyChanged Members

        public virtual event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}