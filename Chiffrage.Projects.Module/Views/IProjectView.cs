using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Mvc.Views;

namespace Chiffrage.Projects.Module.Views
{
    public interface IProjectView : IView
    {
        void SetProjectViewModel(ProjectViewModel viewModel);

        void SetSupplies(IList<ProjectSupplyViewModel> supplies);

        void SetHardwares(IList<ProjectHardwareViewModel> hardwares);

        void SetFrames(IList<ProjectFrameViewModel> frames);

        void SetSummaryItems(IList<ProjectSummaryItemViewModel> summaryItems);

        ProjectViewModel GetProjectViewModel();

        void AddSupply(ProjectSupplyViewModel viewModel);

        void AddSupplies(IList<ProjectSupplyViewModel> supplies);

        void RemoveAllSupplies();

        void RemoveSupply(ProjectSupplyViewModel supply);

        void UpdateSupply(ProjectSupplyViewModel supply);

        void AddHardware(ProjectHardwareViewModel viewModel);

        void RemoveHardware(ProjectHardwareViewModel hardware);

        void UpdateHardware(ProjectHardwareViewModel hardware);
        
        void AddFrame(ProjectFrameViewModel frame);

        void AddFrames(IList<ProjectFrameViewModel> frames);

        void RemoveFrame(ProjectFrameViewModel frame);

        void AddSummaryItems(params ProjectSummaryItemViewModel[] summaryItems);

        void RemoveSummaryItems(params ProjectSummaryItemViewModel[] summaryItems);
    }
}
