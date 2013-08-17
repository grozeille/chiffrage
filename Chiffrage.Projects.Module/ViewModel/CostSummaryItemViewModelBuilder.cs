using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Projects.Domain;

namespace Chiffrage.Projects.Module.ViewModel
{
    public static class CostSummaryItemViewModelBuilder
    {
        public static IEnumerable<ProjectCostSummaryViewModel> BuildProjectCostSummaryItems(this Project project)
        {
            var summaryItems = new List<ProjectCostSummaryViewModel>();

            var supplyCost = new ProjectCostSummaryViewModel
            {
                ProjectCostSummaryType = ProjectCostSummaryType.TotalSupply,
                Name = "Fournitures/Matériels",
            };
            supplyCost.TotalCost = project.Supplies.Sum(x => x.Price * x.Quantity);
            supplyCost.TotalCost += project.Hardwares.Sum(x => x.Components.Sum(y => y.Supply.Price * y.Quantity));
            summaryItems.Add(supplyCost);

            var taskItems = new Dictionary<int, Dictionary<ProjectHardwareTaskType, ProjectCostSummaryViewModel>>();

            foreach (var item in project.Tasks)
            {
                var taskRates = new Dictionary<ProjectHardwareTaskType, ProjectCostSummaryViewModel>();
                taskItems.Add(item.TaskId, taskRates);

                string name = new String(new char[] { item.Name[0] }).ToUpper() + item.Name.Substring(1);
                var dayCost = new ProjectCostSummaryViewModel
                {
                    ProjectCostSummaryType = ProjectCostSummaryType.Simple,
                    Name = name+" (jour)",
                    Rate = item.DayRate,
                };
                summaryItems.Add(dayCost);
                taskRates.Add(ProjectHardwareTaskType.DAY, dayCost);

                if (item.TaskType == Catalogs.Domain.TaskType.DAYS_NIGHT)
                {
                    var nightCost = new ProjectCostSummaryViewModel
                    {
                        ProjectCostSummaryType = ProjectCostSummaryType.Simple,
                        Name = name + " (nuit)",
                        Rate = item.NightRate,
                    };
                    summaryItems.Add(nightCost);
                    taskRates.Add(ProjectHardwareTaskType.NIGHT, nightCost);
                }
                else if (item.TaskType == Catalogs.Domain.TaskType.DAYS_LONGNIGHT_SHORTNIGHT)
                {
                    var longNightCost = new ProjectCostSummaryViewModel
                    {
                        ProjectCostSummaryType = ProjectCostSummaryType.Simple,
                        Name = name + " (nuit longue)",
                        Rate = item.LongNightRate,
                    };
                    summaryItems.Add(longNightCost);
                    taskRates.Add(ProjectHardwareTaskType.LONG_NIGHT, longNightCost);

                    var shortNightCost = new ProjectCostSummaryViewModel
                    {
                        ProjectCostSummaryType = ProjectCostSummaryType.Simple,
                        Name = name + " (nuit courte)",
                        Rate = item.ShortNightRate,
                    };
                    summaryItems.Add(shortNightCost);
                    taskRates.Add(ProjectHardwareTaskType.SHORT_NIGHT, shortNightCost);
                }
            }
            var totalWorkCost = new ProjectCostSummaryViewModel
            {
                ProjectCostSummaryType = ProjectCostSummaryType.TotalWork,
                Name = "Total temps de travail",
            };
            summaryItems.Add(totalWorkCost);

            var totalOtherCost = new ProjectCostSummaryViewModel
            {
                ProjectCostSummaryType = ProjectCostSummaryType.TotalOther,
                Name = "Total Divers",
            };
            summaryItems.Add(totalOtherCost);

            var bigTotalCost = new ProjectCostSummaryViewModel
            {
                ProjectCostSummaryType = ProjectCostSummaryType.BigTotal,
                Name = "Total",
            };
            summaryItems.Add(bigTotalCost);

            foreach (var item in project.Hardwares)
            {
                foreach (var task in item.Tasks)
                {
                    Dictionary<ProjectHardwareTaskType, ProjectCostSummaryViewModel> taskSummaryItem;
                    if (taskItems.TryGetValue(task.TaskId, out taskSummaryItem))
                    {
                        ProjectCostSummaryViewModel summaryItem;
                        if (taskSummaryItem.TryGetValue(task.HardwareTaskType, out summaryItem))
                        {
                            summaryItem.TotalTime += task.Value;
                            summaryItem.TotalCost += task.Value * summaryItem.Rate;
                            totalWorkCost.TotalCost += task.Value * summaryItem.Rate;
                        }
                    }
                }
            }

            bigTotalCost.TotalTime = totalOtherCost.TotalTime + totalWorkCost.TotalTime;
            bigTotalCost.TotalCost = totalOtherCost.TotalCost + totalWorkCost.TotalCost + supplyCost.TotalCost;

            // how costs the frames?

            return summaryItems;
        }

        public static IEnumerable<DealProjectCostSummaryViewModel> BuildDealProjectCostSummaryItems(this Deal deal)
        {
            foreach(var item in deal.Projects)
            {
                var summary = item.BuildProjectCostSummaryItems();
                
                yield return new DealProjectCostSummaryViewModel
                {
                    ProjectName = item.Name,
                    ProjectId = item.Id,
                    Cost = summary.Sum(x => x.TotalCost)
                };
            }
        }
    }
}
