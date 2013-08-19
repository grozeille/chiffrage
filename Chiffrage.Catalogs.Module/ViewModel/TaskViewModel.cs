using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Chiffrage.Catalogs.Module.ViewModel
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private String name;

        private String category;

        private String type;

        private int orderId;

        public String Name
        {
            get { return name; }
            set
            {
                this.name = value;
                this.FirePropertyChanged("Name");
            }
        }

        public String Category
        {
            get { return category; }
            set
            {
                this.category = value;
                this.FirePropertyChanged("Category");
            }
        }

        public String Type
        {
            get { return type; }
            set
            {
                this.type = value;
                this.FirePropertyChanged("Type");
            }
        }

        public int OrderId
        {
            get { return orderId; }
            set
            {
                this.orderId = value;
                this.FirePropertyChanged("OrderId");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void FirePropertyChanged(String propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
