﻿using AutoMapper;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.App.ViewModel
{
    public class CatalogComponentViewModel
    {
        public int Id { get; set; }

        public int SupplyId { get; set; }

        public int Quantity { get; set; }

        public string Name { get; set; }

        public string Reference { get; set; }

        public string Category { get; set; }

        public int ModuleSize { get; set; }

        public double CatalogPrice { get; set; }

        public double StudyDays { get; set; }

        public double ReferenceDays { get; set; }

        public double CatalogWorkDays { get; set; }

        public double CatalogExecutiveWorkDays { get; set; }

        public double CatalogTestsDays { get; set; }
    }
}