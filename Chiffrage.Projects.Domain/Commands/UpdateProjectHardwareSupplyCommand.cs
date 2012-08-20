using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Domain.Commands
{
    public class UpdateProjectHardwareSupplyCommand
    {
        public int ProjectId { get; private set; }

        public int HardwareId { get; private set; }

        public int HardwareSupplyId { get; private set; }

        public double SupplyPrice { get; private set; }

        public UpdateProjectHardwareSupplyCommand(int projectId, int hardwareId, int hardwareSupplyId, double supplyPrice)
        {
            this.ProjectId = projectId;
            this.HardwareId = hardwareId;
            this.HardwareSupplyId = hardwareSupplyId;
            this.SupplyPrice = supplyPrice;
        }
    }
}
