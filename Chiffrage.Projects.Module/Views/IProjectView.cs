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
        void SetProjectViewModel(ProjectViewModel viewModel);

        void SetSupplies(IList<ProjectSupplyViewModel> supplies);

        void SetHardwares(IList<ProjectHardwareViewModel> hardwares);

        void SetFrames(IList<ProjectFrameViewModel> frames);

        ProjectViewModel GetProjectViewModel();

        void AddSupply(ProjectSupplyViewModel viewModel);

        void RemoveAllSupplies();

        void AddSupplies(IList<ProjectSupplyViewModel> supplies);

        void RemoveSupply(ProjectSupplyViewModel supply);

        void AddHardware(ProjectHardwareViewModel viewModel);

        void RemoveHardware(ProjectHardwareViewModel hardware);
        
        void AddFrame(ProjectFrameViewModel frame);

        void AddFrames(IList<ProjectFrameViewModel> frames);

        void RemoveFrame(ProjectFrameViewModel frame);
    }
}
