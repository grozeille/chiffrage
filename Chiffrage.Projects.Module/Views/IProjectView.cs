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

        void AddHardwareWork(ProjectHardwareWorkViewModel workViewModel);

        void AddHardwareExecutiveWork(ProjectHardwareExecutiveWorkViewModel executiveWorkViewModel);

        void AddHardwareStudyReferenceTest(ProjectHardwareStudyReferenceTestViewModel studyReferenceTestViewModel);

        void SetHardwareWorks(List<ProjectHardwareWorkViewModel> works);

        void SetHardwareExecutiveWorks(List<ProjectHardwareExecutiveWorkViewModel> executiveWorks);

        void SetHardwareStudyReferenceTests(List<ProjectHardwareStudyReferenceTestViewModel> studyReferenceTests);

        void UpdateHardwareStudyReferenceTest(ProjectHardwareStudyReferenceTestViewModel studyReferenceTestViewModel);

        void UpdateHardwareExecutiveWork(ProjectHardwareExecutiveWorkViewModel executiveWorkViewModel);

        void UpdateHardwareWork(ProjectHardwareWorkViewModel workViewModel);

        void RemoveHardwareWork(ProjectHardwareWorkViewModel workViewModel);

        void RemoveHardwareExecutiveWork(ProjectHardwareExecutiveWorkViewModel executiveWorkViewModel);

        void RemoveHardwareStudyReferenceTest(ProjectHardwareStudyReferenceTestViewModel studyReferenceTestViewModel);

        void SetCostSummaryItems(IEnumerable<ProjectCostSummaryViewModel> summaryItems);
    }
}
