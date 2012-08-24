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
        public static IEnumerable<ProjectSummaryItemViewModel> BuildSummaryItems(this ProjectHardware hardware, int projectId)
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

        public static IEnumerable<ProjectSummaryItemViewModel> BuildSummaryItems(this ProjectSupply supply, int projectId)
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

        public static ProjectSummaryItemViewModel BuildSummaryItem(this ProjectFrame frame, int projectId)
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
                summaryItems.AddRange(BuildSummaryItems(item, project.Id));
            }

            foreach (var item in project.Hardwares)
            {
                summaryItems.AddRange(BuildSummaryItems(item, project.Id));
            }

            foreach (var item in project.Frames)
            {
                summaryItems.Add(BuildSummaryItem(item, project.Id));
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

        public static IEnumerable<ProjectSummaryItemViewModel> BuildSummaryItems(this Deal deal)
        {
            return deal.Projects
                .SelectMany(x => x.BuildSummaryItems())
                .GroupBy(x => string.Format("{0}#{1}", x.ItemType, x.Name))
                .Select(x => new ProjectSummaryItemViewModel
                {
                    Name = x.First().Name,
                    ItemType = x.First().ItemType,
                    Quantity = x.Sum(y => y.Quantity)
                });
        }        
    }
}
