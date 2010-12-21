using Chiffrage.Core;

namespace Chiffrage.Projects.Domain
{
    public interface IProjectItem : ICatalogItem
    {
        int Quantity { get; set; }
        double Price { get; set; }
        double TotalPrice { get; }
        double TotalStudyDays { get; }
        double TotalReferenceDays { get; }
        double WorkDays { get; set; }
        double WorkShortNights { get; set; }
        double WorkLongNights { get; set; }
        double TotalWorkDays { get; }
        double TotalWorkShortNights { get; }
        double TotalWorkLongNights { get; }
        double ExecutiveWorkDays { get; set; }
        double ExecutiveWorkShortNights { get; set; }
        double ExecutiveWorkLongNights { get; set; }
        double TotalExecutiveWorkDays { get; }
        double TotalExecutiveWorkShortNights { get; }
        double TotalExecutiveWorkLongNights { get; }
        double TestsDays { get; set; }
        double TestsNights { get; set; }
        double TotalTestsDays { get; }
        double TotalTestsNights { get; }
    }
}