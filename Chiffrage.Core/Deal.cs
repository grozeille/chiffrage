using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Chiffrage.Core
{
    public class Deal : INotifyPropertyChanged
    {
        private string comment;
        private DateTime endDate;
        private int id;
        private string name;
        private IList<Project> projects;
        private string reference;
        private DateTime startDate;

        public Deal()
        {
            this.Projects = new List<Project>();
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

        public virtual string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                this.FirePropertyChanged("Name");
            }
        }

        public virtual string Reference
        {
            get { return this.reference; }
            set
            {
                this.reference = value;
                this.FirePropertyChanged("Reference");
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

        public virtual DateTime StartDate
        {
            get { return this.startDate; }
            set
            {
                this.startDate = value;
                this.FirePropertyChanged("StartDate");
            }
        }

        public virtual DateTime EndDate
        {
            get { return this.endDate; }
            set
            {
                this.endDate = value;
                this.FirePropertyChanged("EndDateId");
            }
        }

        public virtual IList<Project> Projects
        {
            get { return this.projects; }
            set
            {
                this.projects = value;
                this.FirePropertyChanged("Projects");
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