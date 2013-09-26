using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Mvc.Views;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.Projects.Module.Views
{
    public interface IProjectView : IView
    {
        void SetProjectViewModel(ProjectViewModel viewModel);

        void SetSupplies(IEnumerable<ProjectSupplyViewModel> supplies);

        void SetHardwares(IEnumerable<ProjectHardwareViewModel> hardwares);

        void SetFrames(IEnumerable<ProjectFrameViewModel> frames);

        void SetSummaryItems(IEnumerable<ProjectSummaryItemViewModel> summaryItems);
        
        void AddSupply(ProjectSupplyViewModel viewModel);

        void AddSupplies(IEnumerable<ProjectSupplyViewModel> supplies);

        void RemoveAllSupplies();

        void RemoveSupply(int supplyId);

        void UpdateSupply(ProjectSupplyViewModel supply);

        void AddHardware(ProjectHardwareViewModel viewModel);

        void RemoveHardware(int hardwareId);

        void UpdateHardware(ProjectHardwareViewModel hardware);
        
        void AddFrame(ProjectFrameViewModel frame);

        void AddFrames(IEnumerable<ProjectFrameViewModel> frames);

        void RemoveFrame(int frameId);

        void SetCostSummaryItems(IEnumerable<ProjectCostSummaryViewModel> summaryItems);

        ProjectViewModel GetProjectViewModel();
    }
}
