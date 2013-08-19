using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Projects.Domain;

namespace Chiffrage.Projects.Module.ViewModel
{
    public static class ProjectSummaryItemViewModelBuilder
    {
        public static IEnumerable<ProjectSummaryItemViewModel> BuildSummaryItems(this ProjectHardware hardware)
        {
            yield return new ProjectSummaryItemViewModel
            {
                ItemType = ProjectSummaryItemType.Hardware,
                Name = hardware.Name
            };

            foreach (var component in hardware.Components)
            {
                yield return new ProjectSummaryItemViewModel
                {
                    ItemType = ProjectSummaryItemType.Supply,
                    Name = component.Supply.Name,
                    Quantity = component.Quantity
                };

                yield return new ProjectSummaryItemViewModel
                {
                    ItemType = ProjectSummaryItemType.PFC,
                    Name = "PFC0",
                    Quantity = component.Supply.PFC0
                };

                yield return new ProjectSummaryItemViewModel
                {
                    ItemType = ProjectSummaryItemType.PFC,
                    Name = "PFC12",
                    Quantity = component.Supply.PFC12
                };

                yield return new ProjectSummaryItemViewModel
                {
                    ItemType = ProjectSummaryItemType.PFC,
                    Name = "Bouchon de codage",
                    Quantity = component.Supply.Cap
                };
            }
        }

        public static IEnumerable<ProjectSummaryItemViewModel> BuildSummaryItems(this ProjectSupply supply)
        {
            yield return new ProjectSummaryItemViewModel
            {
                ItemType = ProjectSummaryItemType.Supply,
                Name = supply.Name,
                Quantity = supply.Quantity
            };

            yield return new ProjectSummaryItemViewModel
            {
                ItemType = ProjectSummaryItemType.PFC,
                Name = "PFC0",
                Quantity = supply.PFC0
            };

            yield return new ProjectSummaryItemViewModel
            {
                ItemType = ProjectSummaryItemType.PFC,
                Name = "PFC12",
                Quantity = supply.PFC12
            };

            yield return new ProjectSummaryItemViewModel
            {
                ItemType = ProjectSummaryItemType.PFC,
                Name = "Bouchon de codage",
                Quantity = supply.Cap
            };
        }

        public static ProjectSummaryItemViewModel BuildSummaryItem(this ProjectFrame frame)
        {
            return new ProjectSummaryItemViewModel
            {
                ItemType = ProjectSummaryItemType.Frame,
                Name = string.Format("Chassis {0} modules", frame.Size),
                Quantity = frame.Count
            };
        }

        public static IEnumerable<ProjectSummaryItemViewModel> BuildSummaryItems(this Project project)
        {
            var summaryItems = new List<ProjectSummaryItemViewModel>();

            foreach (var item in project.Supplies)
            {
                summaryItems.AddRange(item.BuildSummaryItems());
            }

            foreach (var item in project.Hardwares)
            {
                summaryItems.AddRange(item.BuildSummaryItems());
            }

            foreach (var item in project.Frames)
            {
                summaryItems.Add(item.BuildSummaryItem());
            }

            // now do a "groupby"
            return summaryItems
                .Where(x => x.Quantity > 0)
                .GroupBy(x => string.Format("{0}#{1}", x.ItemType, x.Name))
                .Select(x => new ProjectSummaryItemViewModel
                {
                    Name = x.First().Name,
                    ItemType = x.First().ItemType,
                    Quantity = x.Sum(y => y.Quantity)
                });
        }

        public static IEnumerable<DealSummaryItemViewModel> BuildSummaryItems(this Deal deal)
        {
            var allItemsMap = new Dictionary<string, DealSummaryItemViewModel>();

            foreach(var item in deal.Projects)
            {
                foreach(var projectSummaryItem in item.BuildSummaryItems())
                {
                    var key = string.Format("{0}#{1}", projectSummaryItem.ItemType, projectSummaryItem.Name);
                    DealSummaryItemViewModel dealSummaryItem;
                    if(!allItemsMap.TryGetValue(key, out dealSummaryItem))
                    {
                        dealSummaryItem = new DealSummaryItemViewModel
                                              {
                                                  Name = projectSummaryItem.Name,
                                                  ItemType = projectSummaryItem.ItemType,
                                                  ProjectItems = new List<DealSummaryProjectItemViewModel>()
                                              };
                        allItemsMap.Add(key, dealSummaryItem);
                    }

                    var dealSummaryProjectItem = new DealSummaryProjectItemViewModel();
                    dealSummaryProjectItem.ProjectId = item.Id;
                    dealSummaryProjectItem.ProjectName = item.Name;
                    dealSummaryProjectItem.Quantity = projectSummaryItem.Quantity;

                    dealSummaryItem.ProjectItems.Add(dealSummaryProjectItem);
                }
            }

            return allItemsMap.Values;
        }        
    }
}
