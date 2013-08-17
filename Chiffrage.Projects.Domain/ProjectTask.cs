using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.Projects.Domain
{
    public class ProjectTask
    {
        public virtual int Id { get; set; }

        public virtual int TaskId { get; set; }

        public virtual string Name { get; set; }

        public virtual double DayRate { get; set; }

        public virtual double NightRate { get; set; }

        public virtual double LongNightRate { get; set; }

        public virtual double ShortNightRate { get; set; }

        public virtual TaskType TaskType { get; set; }
    }
}
