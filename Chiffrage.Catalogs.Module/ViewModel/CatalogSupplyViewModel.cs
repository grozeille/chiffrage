namespace Chiffrage.Catalogs.Module.ViewModel
{
    public class CatalogSupplyViewModel
    {
        public int Id { get; set; }

        public int CatalogId { get; set; }

        public string Name { get; set; }

        public string Reference { get; set; }

        public string Category { get; set; }

        public int ModuleSize { get; set; }

        public double CatalogPrice { get; set; }

        public virtual int PFC0 { get; set; }

        public virtual int PFC12 { get; set; }

        public virtual int Cap { get; set; }
    }
}