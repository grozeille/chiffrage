using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
    public class UpdateProjectSupplyCommand
    {
        private readonly int projectId;

        private readonly int id;

        private readonly int quantity;

        private readonly double price;

        public UpdateProjectSupplyCommand(
            int projectId,
            int id,
            int quantity,
            double price)
        {
            this.projectId = projectId;
            this.id = id;
            this.quantity = quantity;
            this.price = price;     
        }

        public int ProjectId { get { return this.projectId; } }

        public int Id { get { return this.id; } }

        public int Quantity{ get { return this.quantity; } }

        public double Price { get { return this.price; } }

    }
}
