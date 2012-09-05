using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Commands
{
    public class UpdateHardwareCommand
    {
        private readonly int catalogId;

        private readonly int hardwareId;

        private readonly string name;

        private readonly double catalogStudyDays;

        private readonly double catalogReferenceDays;

        private readonly double catalogExecutiveWorkDays;

        private readonly double catalogTechnicianWorkDays;

        private readonly double catalogWorkerWorkDays;

        private readonly double catalogTestsDays;

        public UpdateHardwareCommand(
            int catalogId, 
            int hardwareId,
            string name,
            double studyDays,
            double referenceDays,
            double catalogExecutiveWorkDays,
            double catalogTechnicianWorkDays,
            double catalogWorkerWorkDays,
            double catalogTestsDays)
        {
            this.catalogId = catalogId;
            this.hardwareId = hardwareId;
            this.name = name;
            this.catalogStudyDays = studyDays;
            this.catalogReferenceDays = referenceDays;
            this.catalogExecutiveWorkDays = catalogExecutiveWorkDays;
            this.catalogTechnicianWorkDays = catalogTechnicianWorkDays;
            this.catalogWorkerWorkDays = catalogWorkerWorkDays;
            this.catalogTestsDays = catalogTestsDays;
        }

        public int CatalogId { get { return this.catalogId; } }

        public int HardwareId { get { return this.hardwareId; } }

        public string Name { get { return this.name; } }

        public double CatalogStudyDays { get { return this.catalogStudyDays; } }

        public double CatalogReferenceDays { get { return this.catalogReferenceDays; } }

        public double CatalogExecutiveWorkDays { get { return this.catalogExecutiveWorkDays; } }

        public double CatalogTechnicianWorkDays { get { return this.catalogTechnicianWorkDays; } }

        public double CatalogWorkerWorkDays { get { return this.catalogWorkerWorkDays; } }

        public double CatalogTestsDays { get { return this.catalogTestsDays; } }
    }
}
