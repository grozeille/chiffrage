﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Commands
{
    public class CreateNewHardwareCommand : IEvent
    {
        private readonly int catalogId;

        private readonly string name;

        private readonly double studyDays;

        private readonly double referenceDays;

        private readonly double catalogWorkDays;

        private readonly double catalogExecutiveWorkDays;

        private readonly double catalogTestsDays;

        public CreateNewHardwareCommand(
            int catalogId,
            string name,
            double studyDays,
            double referenceDays,
            double catalogWorkDays,
            double catalogExecutiveWorkDays,
            double catalogTestsDays)
        {
            this.catalogId = catalogId;
            this.name = name;
            this.studyDays = studyDays;
            this.referenceDays = referenceDays;
            this.catalogWorkDays = catalogWorkDays;
            this.catalogExecutiveWorkDays = catalogExecutiveWorkDays;
            this.catalogTestsDays = catalogTestsDays;
        }

        public int CatalogId { get { return this.catalogId; } }

        public string Name { get { return this.name; } }

        public double StudyDays { get { return this.studyDays; } }

        public double ReferenceDays { get { return this.referenceDays; } }

        public double CatalogWorkDays { get { return this.catalogWorkDays; } }

        public double CatalogExecutiveWorkDays { get { return this.catalogExecutiveWorkDays; } }

        public double CatalogTestsDays { get { return this.catalogTestsDays; } }
    }
}