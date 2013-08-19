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
        public static IEnumerable<ProjectCostSummaryViewModel> BuildProjectCostSummaryItems(this Project project)
        {
            var summaryItems = new List<ProjectCostSummaryViewModel>();

            // construction du total du matériel
            var supplyCost = new ProjectCostSummaryViewModel
            {
                ProjectCostSummaryType = ProjectCostSummaryType.TotalSupply,
                Name = "Fournitures/Matériels",
            };
            supplyCost.TotalCost = project.Supplies.Sum(x => x.Price * x.Quantity);
            supplyCost.TotalCost += project.Hardwares.Sum(x => x.Components.Sum(y => y.Supply.Price * y.Quantity));
            summaryItems.Add(supplyCost);

            // conserve les taux des différentes tâches
            var rates = new Dictionary<int, Dictionary<ProjectHardwareTaskType, double>>();
            foreach (var item in project.Tasks)
            {
                var taskRates = new Dictionary<ProjectHardwareTaskType, double>();
                taskRates.Add(ProjectHardwareTaskType.DAY, item.DayRate);
                if (item.Type == TaskType.DAYS_NIGHT)
                {
                    taskRates.Add(ProjectHardwareTaskType.NIGHT, item.NightRate);
                }
                else if (item.Type == TaskType.DAYS_LONGNIGHT_SHORTNIGHT)
                {
                    taskRates.Add(ProjectHardwareTaskType.LONG_NIGHT, item.LongNightRate);
                    taskRates.Add(ProjectHardwareTaskType.SHORT_NIGHT, item.ShortNightRate);
                }
                rates.Add(item.TaskId, taskRates);
            }

            // conserve les lignes correspondantes aux tâches
            var taskItems = new Dictionary<int, Dictionary<ProjectHardwareTaskType, ProjectCostSummaryViewModel>>();
            var taskGroupItems = new Dictionary<TaskCategory, ProjectCostSummaryViewModel>();
            
            // création des lignes pour les tâches
            var projectTasksByCategory = project.Tasks.GroupBy(x => x.Category);
            foreach (var group in projectTasksByCategory)
            {
                foreach (var item in group)
                {
                    var taskRates = new Dictionary<ProjectHardwareTaskType, ProjectCostSummaryViewModel>();
                    taskItems.Add(item.Id, taskRates);

                    Dictionary<ProjectHardwareTaskType, double> projectTaskRates;
                    double rate;
                    rates.TryGetValue(item.Id, out projectTaskRates);

                    string name = new String(new char[] {item.Name[0]}).ToUpper() + item.Name.Substring(1);
                    var dayCost = new ProjectCostSummaryViewModel
                                      {
                                          ProjectCostSummaryType = ProjectCostSummaryType.Simple,
                                          Name = name + " (jour)",
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
                        if (projectTaskRates != null &&
                            projectTaskRates.TryGetValue(ProjectHardwareTaskType.NIGHT, out rate))
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
                        if (projectTaskRates != null &&
                            projectTaskRates.TryGetValue(ProjectHardwareTaskType.LONG_NIGHT, out rate))
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
                        if (projectTaskRates != null &&
                            projectTaskRates.TryGetValue(ProjectHardwareTaskType.SHORT_NIGHT, out rate))
                        {
                            shortNightCost.Rate = rate;
                        }
                        summaryItems.Add(shortNightCost);
                        taskRates.Add(ProjectHardwareTaskType.SHORT_NIGHT, shortNightCost);
                    }
                }

                // création de la ligne du total de cette catégorie
                var taskCategorySummary = new ProjectCostSummaryViewModel
                {
                    Name = TaskCategoryConsts.ToString(group.Key),
                };
                switch (group.Key)
                {
                    case TaskCategory.STUDY:
                        taskCategorySummary.ProjectCostSummaryType = ProjectCostSummaryType.TotalStudy;
                        break;
                    case TaskCategory.WORK:
                        taskCategorySummary.ProjectCostSummaryType = ProjectCostSummaryType.TotalWork;
                        break;
                    case TaskCategory.TEST:
                        taskCategorySummary.ProjectCostSummaryType = ProjectCostSummaryType.TotalTests;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                taskGroupItems.Add(group.Key, taskCategorySummary);
                summaryItems.Add(taskCategorySummary);
            }

            // ligne des autres frais
            var totalOtherCost = new ProjectCostSummaryViewModel
            {
                ProjectCostSummaryType = ProjectCostSummaryType.TotalOther,
                Name = "Total Divers",
            };
            summaryItems.Add(totalOtherCost);

            // ligne du total
            var bigTotalCost = new ProjectCostSummaryViewModel
            {
                ProjectCostSummaryType = ProjectCostSummaryType.BigTotal,
                Name = "Total",
            };
            summaryItems.Add(bigTotalCost);

            // calcul du coût des tâches
            foreach (var item in project.Hardwares)
            {
                foreach (var task in item.Tasks)
                {
                    Dictionary<ProjectHardwareTaskType, ProjectCostSummaryViewModel> taskSummaryItem;
                    if (taskItems.TryGetValue(task.Task.Id, out taskSummaryItem))
                    {
                        ProjectCostSummaryViewModel summaryItem;
                        if (taskSummaryItem.TryGetValue(task.HardwareTaskType, out summaryItem))
                        {
                            summaryItem.TotalTime += task.Value;
                            summaryItem.TotalCost += task.Value * summaryItem.Rate;

                            taskGroupItems[task.Task.Category].TotalTime += task.Value;
                            taskGroupItems[task.Task.Category].TotalCost += task.Value * summaryItem.Rate;
                        }
                    }
                }
            }

            bigTotalCost.TotalTime = totalOtherCost.TotalTime + taskGroupItems.Sum(x => x.Value.TotalTime);
            bigTotalCost.TotalCost = totalOtherCost.TotalCost + taskGroupItems.Sum(x => x.Value.TotalCost) + supplyCost.TotalCost;

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
