﻿using System;
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

        private String type;

        public String Name
        {
            get { return name; }
            set
            {
                this.name = value;
                this.FirePropertyChanged("Name");
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