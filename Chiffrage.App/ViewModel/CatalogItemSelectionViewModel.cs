using System.ComponentModel;
using Chiffrage.Core;

namespace Chiffrage.App.ViewModel
{
    public class CatalogItemSelectionViewModel<T> : ICatalogItemSelectionViewModel where T : ICatalogItem
    {
        private bool selected;
        public T Item { get; set; }

        #region ICatalogItemSelectionViewModel Members

        public bool Selected
        {
            get { return this.selected; }
            set
            {
                this.selected = value;
                this.FirePropertyChanged("Selected");
            }
        }

        public string Name
        {
            get { return Equals(this.Item, default(T)) ? null : this.Item.Name; }
        }

        public string Supplier { get; set; }

        public string Reference
        {
            get { return Equals(this.Item, default(T)) ? null : this.Item.Reference; }
        }

        public double Price
        {
            get { return Equals(this.Item, default(T)) ? 0 : this.Item.CatalogPrice; }
        }

        public int ModuleSize
        {
            get { return Equals(this.Item, default(T)) ? 0 : this.Item.ModuleSize; }
        }

        public ICatalogItem CatalogItem
        {
            get { return this.Item; }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected void FirePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}