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
            Projects = new List<Project>();
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

        public virtual string Name
        {
            get { return name; }
            set
            {
                name = value;
                FirePropertyChanged("Name");
            }
        }

        public virtual string Reference
        {
            get { return reference; }
            set
            {
                reference = value;
                FirePropertyChanged("Reference");
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

        public virtual DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                FirePropertyChanged("StartDate");
            }
        }

        public virtual DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                FirePropertyChanged("EndDateId");
            }
        }

        public virtual IList<Project> Projects
        {
            get { return projects; }
            set
            {
                projects = value;
                FirePropertyChanged("Projects");
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