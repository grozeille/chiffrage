using Chiffrage.Projects.Domain;
using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Mvc.Views;
using System.Collections.Generic;

namespace Chiffrage.Projects.Module.Views
{
    public interface IDealView : IView
    {
        void SetDealViewModel(DealViewModel viewModel);

        void SetCalendarItems(IEnumerable<DealProjectCalendarItemViewModel> calendarItems);

        void SetSummaryItems(IEnumerable<DealSummaryItemViewModel> summaryItems, IEnumerable<Project> projects);

        void SetProjectCostSummaryItems(IEnumerable<DealProjectCostSummaryViewModel> costSummaryItems);

        void SetCostSummaryItems(IEnumerable<ProjectCostSummaryViewModel> summaryItems);

        DealViewModel GetDealViewModel();
    }
}