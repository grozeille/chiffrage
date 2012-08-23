using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Module.ViewModel
{
    public class ProjectHardwareStudyReferenceTestViewModel
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int CatalogId { get; set; }

        public string Name { get; set; }

        public double CatalogStudyDays { get; set; }

        public double CatalogReferenceDays { get; set; }

        public double CatalogTestsDays { get; set; }

        public double StudyDays { get; set; }

        public double ReferenceDays { get; set; }

        public double TestsDays { get; set; }

        public double TestsNights { get; set; }
    }
}
