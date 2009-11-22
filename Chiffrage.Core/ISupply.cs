using System;

namespace Chiffrage.Core
{
    public interface ISupply : ICloneable
    {
        int Id { get; }
        string Name { get; }
        string Reference { get; }
        string Category { get; }
        int ModuleSize { get; }
        double Price { get; }
        double StudyDays { get; }
        double ReferenceDays { get; }
        double WorkDays { get; }
        double ExecutiveWorkDays { get; }
        double TestsDays { get; }
    }
}