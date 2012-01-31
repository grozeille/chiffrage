using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.App.ViewModel;
using Chiffrage.Mvc.Views;

namespace Chiffrage.App.Views
{
    public interface IProjectView : IView
    {
        void Display(ProjectViewModel viewModel, IList<ProjectSupplyViewModel> supplies, IList<ProjectHardwareViewModel> hardwares);

        ProjectViewModel GetViewModel();

        void AddSupply(ProjectSupplyViewModel viewModel);

        void RemoveAllSupplies();

        void AddSupplies(IList<ProjectSupplyViewModel> supplies);

        void RemoveSupply(ProjectSupplyViewModel supply);

        void AddHardware(ProjectHardwareViewModel viewModel);
    }
}
