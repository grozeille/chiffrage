
namespace Chiffrage.Catalogs.Domain
{
    public class Cable
    {
        public virtual long Length { get; set; }

        public virtual double PricePerMeter { get; set; }


        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Reference { get; set; }
        public virtual string Category { get; set; }
        public virtual int ModuleSize { get; set; }


        public virtual double StudyDays { get; set; }
        public virtual double ReferenceDays { get; set; }
        public virtual double CatalogTechnicianWorkDays { get; set; }
        public virtual double CatalogWorkerWorkDays { get; set; }

        public virtual double CatalogTestsDays { get; set; }
    }
}