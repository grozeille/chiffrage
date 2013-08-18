using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Projects.Domain;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.Projects.Module.ViewModel
{
    public static class CostSummaryItemViewModelBuilder
    {
        public static IEnumerable<ProjectCostSummaryViewModel> BuildProjectCostSummaryItems(this Project project, IEnumerable<Task> catalogTasks)
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
            var rates = new Dictionary<int, Dictionary<ProjectHardwareTaskType, double>>();
            foreach (var item in project.Tasks)
            {
                var taskRates = new Dictionary<ProjectHardwareTaskType, double>();
                taskRates.Add(ProjectHardwareTaskType.DAY, item.DayRate);
                if (item.TaskType == TaskType.DAYS_NIGHT)
                {
                    taskRates.Add(ProjectHardwareTaskType.NIGHT, item.NightRate);
                }
                else if (item.TaskType == TaskType.DAYS_LONGNIGHT_SHORTNIGHT)
                {
                    taskRates.Add(ProjectHardwareTaskType.LONG_NIGHT, item.LongNightRate);
                    taskRates.Add(ProjectHardwareTaskType.SHORT_NIGHT, item.ShortNightRate);
                }
                rates.Add(item.TaskId, taskRates);
            }


            foreach (var item in catalogTasks)
            {
                var taskRates = new Dictionary<ProjectHardwareTaskType, ProjectCostSummaryViewModel>();
                taskItems.Add(item.Id, taskRates);

                Dictionary<ProjectHardwareTaskType, double> projectTaskRates;
                double rate;
                rates.TryGetValue(item.Id, out projectTaskRates);

                string name = new String(new char[] { item.Name[0] }).ToUpper() + item.Name.Substring(1);
                var dayCost = new ProjectCostSummaryViewModel
                {
                    ProjectCostSummaryType = ProjectCostSummaryType.Simple,
                    Name = name+" (jour)",
                };
                
                if (projectTaskRates != null && projectTaskRates.TryGetValue(ProjectHardwareTaskType.DAY, out rate))
                {
                    dayCost.Rate = rate;
                }
                summaryItems.Add(dayCost);
                taskRates.Add(ProjectHardwareTaskType.DAY, dayCost);

                if (item.Type == Catalogs.Domain.TaskType.DAYS_NIGHT)
                {
                    var nightCost = new ProjectCostSummaryViewModel
                    {
                        ProjectCostSummaryType = ProjectCostSummaryType.Simple,
                        Name = name + " (nuit)",
                    };
                    if (projectTaskRates != null && projectTaskRates.TryGetValue(ProjectHardwareTaskType.NIGHT, out rate))
                    {
                        nightCost.Rate = rate;
                    }
                    summaryItems.Add(nightCost);
                    taskRates.Add(ProjectHardwareTaskType.NIGHT, nightCost);
                }
                else if (item.Type == Catalogs.Domain.TaskType.DAYS_LONGNIGHT_SHORTNIGHT)
                {
                    var longNightCost = new ProjectCostSummaryViewModel
                    {
                        ProjectCostSummaryType = ProjectCostSummaryType.Simple,
                        Name = name + " (nuit longue)",
                    };
                    if (projectTaskRates != null && projectTaskRates.TryGetValue(ProjectHardwareTaskType.LONG_NIGHT, out rate))
                    {
                        longNightCost.Rate = rate;
                    }
                    summaryItems.Add(longNightCost);
                    taskRates.Add(ProjectHardwareTaskType.LONG_NIGHT, longNightCost);

                    var shortNightCost = new ProjectCostSummaryViewModel
                    {
                        ProjectCostSummaryType = ProjectCostSummaryType.Simple,
                        Name = name + " (nuit courte)",
                    };
                    if (projectTaskRates != null && projectTaskRates.TryGetValue(ProjectHardwareTaskType.SHORT_NIGHT, out rate))
                    {
                        shortNightCost.Rate = rate;
                    }
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
                        else
                        {
                            Console.WriteLine("EEE");
                        }
                    }
                    else
                    {
                        Console.WriteLine("EEE");
                    }
                }
            }

            bigTotalCost.TotalTime = totalOtherCost.TotalTime + totalWorkCost.TotalTime;
            bigTotalCost.TotalCost = totalOtherCost.TotalCost + totalWorkCost.TotalCost + supplyCost.TotalCost;

            // how costs the frames?

            return summaryItems;
        }

        public static IEnumerable<DealProjectCostSummaryViewModel> BuildDealProjectCostSummaryItems(this Deal deal, IEnumerable<Task> catalogTasks)
        {
            foreach(var item in deal.Projects)
            {
                var summary = item.BuildProjectCostSummaryItems(catalogTasks);
                
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
