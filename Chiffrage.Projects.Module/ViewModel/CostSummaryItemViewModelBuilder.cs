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

                    string name = new String(new char[] {item.Name[0]}).ToUpper() + item.Name.Substring(1);
                    var dayCost = new ProjectCostSummaryViewModel
                                      {
                                          ProjectCostSummaryType = ProjectCostSummaryType.Simple,
                                          Name = name + " (jour)",
                                          Rate = item.DayRate
                                      };

                    summaryItems.Add(dayCost);
                    taskRates.Add(ProjectHardwareTaskType.DAY, dayCost);

                    if (item.Type == Catalogs.Domain.TaskType.DAYS_NIGHT)
                    {
                        var longNightCost = new ProjectCostSummaryViewModel
                                                {
                                                    ProjectCostSummaryType = ProjectCostSummaryType.Simple,
                                                    Name = name + " (nuit longue)",
                                                    Rate = item.LongNightRate
                                                };
                        summaryItems.Add(longNightCost);
                        taskRates.Add(ProjectHardwareTaskType.LONG_NIGHT, longNightCost);

                        var shortNightCost = new ProjectCostSummaryViewModel
                                                 {
                                                     ProjectCostSummaryType = ProjectCostSummaryType.Simple,
                                                     Name = name + " (nuit courte)",
                                                     Rate = item.ShortNightRate
                                                 };
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
            totalOtherCost.TotalCost = project.OtherBenefits.Sum(x => x.CostRate*x.Hours);
            totalOtherCost.TotalTime = project.OtherBenefits.Sum(x => x.Hours);

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
                    if (task.Task != null)
                    {
                        Dictionary<ProjectHardwareTaskType, ProjectCostSummaryViewModel> taskSummaryItem;
                        if (taskItems.TryGetValue(task.Task.Id, out taskSummaryItem))
                        {
                            ProjectCostSummaryViewModel summaryItem;
                            if (taskSummaryItem.TryGetValue(task.HardwareTaskType, out summaryItem))
                            {
                                summaryItem.TotalTime += task.Value;
                                summaryItem.TotalCost += task.Value*summaryItem.Rate;

                                taskGroupItems[task.Task.Category].TotalTime += task.Value;
                                taskGroupItems[task.Task.Category].TotalCost += task.Value*summaryItem.Rate;
                            }
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
                    Cost = summary.Where(x => x.Name.Equals("Total")).First().TotalCost
                };
            }
        }

        public static IEnumerable<ProjectCostSummaryViewModel> BuildProjectCostSummaryItems(this Deal deal)
        {
            var totalItems = new Dictionary<String, ProjectCostSummaryViewModel>();

            foreach (var item in deal.Projects)
            {
                var summary = item.BuildProjectCostSummaryItems();

                foreach(var s in summary)
                {
                    ProjectCostSummaryViewModel costSummary;
                    if(!totalItems.TryGetValue(s.Name, out costSummary))
                    {
                        costSummary = s;
                        // not possible to compute rate in this case
                        costSummary.Rate = 0.0;
                        totalItems.Add(s.Name, s);
                    }
                    else
                    {
                        costSummary.TotalCost += s.TotalCost;
                        costSummary.TotalTime += s.TotalTime;
                    }
                }                
            }

            return totalItems.Values;
        }
    }
}
