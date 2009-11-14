using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Grozeille.Chiffrage.Core;
using System.ComponentModel;

namespace Chiffrage.Dto
{
    public class CatalogSupplySelectionDto : INotifyPropertyChanged
    {
        public Supply Supply { get; set; }

        private bool selected;
        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                if(PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Selected"));
            }
        }

        public string Name { get { return this.Supply == null? null : this.Supply.Name; } }

        public string Supplier { get; set; }

        public string Reference { get { return this.Supply == null ? null : this.Supply.Reference; } }

        public double Price { get { return this.Supply == null ? 0 : this.Supply.Price; } }

        public int ModuleSize { get { return this.Supply == null ? 0 : this.Supply.ModuleSize; } }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
