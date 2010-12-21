using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Chiffrage.Core;

namespace Chiffrage.ViewModel
{
    public class CatalogItemSelectionViewModel<T> : ICatalogItemSelectionViewModel where T : ICatalogItem
    {
        public T Item { get; set; }

        private bool selected;
        public bool Selected
        {
            get { return this.selected; }
            set
            {
                this.selected = value;
                this.FirePropertyChanged("Selected");
            }
        }

        public string Name { get { return object.Equals(this.Item, default(T)) ? null : this.Item.Name; } }

        public string Supplier { get; set; }

        public string Reference { get { return object.Equals(this.Item, default(T)) ? null : this.Item.Reference; } }

        public double Price { get { return object.Equals(this.Item, default(T)) ? 0 : this.Item.CatalogPrice; } }

        public int ModuleSize { get { return object.Equals(this.Item, default(T)) ? 0 : this.Item.ModuleSize; } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void FirePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #region ICatalogItemSelectionDto Members

        public ICatalogItem CatalogItem
        {
            get { return this.Item; }
        }

        #endregion
    }
}