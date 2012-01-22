using System;

namespace Chiffrage.Core
{
    public interface ICatalogItem : ICloneable
    {
        int Id { get; }
        string Name { get; }
        string Reference { get; }
        string Category { get; }
        int ModuleSize { get; }
        double CatalogPrice { get; }
        double StudyDays { get; }
        double ReferenceDays { get; }
        double CatalogWorkDays { get; }
        double CatalogExecutiveWorkDays { get; }
        double CatalogTestsDays { get; }
    }
}