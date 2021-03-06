﻿using Chiffrage.Catalogs.Domain;

namespace Chiffrage.Projects.Domain
{
    public class ProjectSupply
    {
        public virtual int Id { get; set; }

        public virtual int CatalogId { get; set; }

        public virtual int SupplyId { get; set; }

        public virtual int Quantity { get; set; }

        public virtual string Name { get; set; }

        public virtual string Reference { get; set; }

        public virtual string Category { get; set; }

        public virtual int ModuleSize { get; set; }

        public virtual int PFC0 { get; set; }

        public virtual int PFC12 { get; set; }

        public virtual int Cap { get; set; }

        public virtual double CatalogPrice { get; set; }

        public virtual double Price { get; set; }
    }
}