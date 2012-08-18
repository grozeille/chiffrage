using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
    public class UpdateProjectSupplyCommand: IEvent
    {
        private readonly int projectId;

        private readonly int id;

        private readonly int quantity;

        private readonly string name;

        private readonly string reference;

        private readonly string category;

        private readonly int moduleSize;

        private readonly double price;

        private readonly int pfc0;

        private readonly int pfc12;

        private readonly int cap;

        public UpdateProjectSupplyCommand(
            int projectId,
            int id,
            int quantity,
            string name,
            string reference,
            string category,
            int moduleSize,
            double price,
            int pfc12,
            int pfc0,
            int cap)
        {
            this.projectId = projectId;
            this.id = id;
            this.quantity = quantity;
            this.name = name;
            this.reference = reference;
            this.category = category;
            this.moduleSize = moduleSize;
            this.price = price;
            this.pfc0 = pfc0;
            this.pfc12 = pfc12;
            this.cap = cap;       
        }


        public int ProjectId { get { return this.projectId; } }

        public int Id { get { return this.id; } }

        public int Quantity{ get { return this.quantity; } }

        public string Name { get { return this.name; } }

        public string Reference { get { return this.reference; } }

        public string Category { get { return this.category; } }

        public int ModuleSize { get { return this.moduleSize; } }

        public double Price { get { return this.price; } }

        public int PFC12 { get { return this.pfc12; } }

        public int PFC0 { get { return this.pfc0; } }

        public int Cap { get { return this.cap; } }

    }
}
