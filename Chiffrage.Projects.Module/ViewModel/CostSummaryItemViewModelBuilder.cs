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
            supplyCost.TotalCost += project.Hardwares.Sum(x => x.Components.Sum(y => y.Supply.Price * y.Supply.Quantity));
            summaryItems.Add(supplyCost);

            var studyCost = new ProjectCostSummaryViewModel
            {
                ProjectCostSummaryType = ProjectCostSummaryType.Simple,
                Name = "Etudes",
                Rate = project.StudyRate,
            };
            summaryItems.Add(studyCost);

            var referenceCost = new ProjectCostSummaryViewModel
            {
                ProjectCostSummaryType = ProjectCostSummaryType.Simple,
                Name = "Saisie",
                Rate = project.ReferenceRate,
            };
            summaryItems.Add(referenceCost);

            var totalStudyReferenceCost = new ProjectCostSummaryViewModel
            {
                ProjectCostSummaryType = ProjectCostSummaryType.TotalStudyReference,
                Name = "Total Etude",
            };
            summaryItems.Add(totalStudyReferenceCost);

            var workDaysCost = new ProjectCostSummaryViewModel
            {
                ProjectCostSummaryType = ProjectCostSummaryType.Simple,
                Name = "Travaux jours (CNRO)",
                Rate = project.WorkDayRate,
            };
            summaryItems.Add(workDaysCost);

            var workShortNightsCost = new ProjectCostSummaryViewModel
            {
                ProjectCostSummaryType = ProjectCostSummaryType.Simple,
                Name = "Travaux nuits courtes (CNRO)",
                Rate = project.WorkShortNightsRate,
            };
            summaryItems.Add(workShortNightsCost);

            var workLongNightsCost = new ProjectCostSummaryViewModel
            {
                ProjectCostSummaryType = ProjectCostSummaryType.Simple,
                Name = "Travaux nuits longues (CNRO)",
                Rate = project.WorkLongNightsRate,
            };
            summaryItems.Add(workLongNightsCost);

            var executiveWorkDaysCost = new ProjectCostSummaryViewModel
            {
                ProjectCostSummaryType = ProjectCostSummaryType.Simple,
                Name = "Travaux jours (ETAM)",
                Rate = project.WorkDayRate,
            };
            summaryItems.Add(executiveWorkDaysCost);

            var executiveWorkShortNightsCost = new ProjectCostSummaryViewModel
            {
                ProjectCostSummaryType = ProjectCostSummaryType.Simple,
                Name = "Travaux nuits courtes (ETAM)",
                Rate = project.WorkShortNightsRate,
            };
            summaryItems.Add(executiveWorkShortNightsCost);

            var executiveWorkLongNightsCost = new ProjectCostSummaryViewModel
            {
                ProjectCostSummaryType = ProjectCostSummaryType.Simple,
                Name = "Travaux nuits longues (ETAM)",
                Rate = project.WorkLongNightsRate,
            };
            summaryItems.Add(executiveWorkLongNightsCost);

            var totalWorkCost = new ProjectCostSummaryViewModel
            {
                ProjectCostSummaryType = ProjectCostSummaryType.TotalWork,
                Name = "Total Travaux",
            };
            summaryItems.Add(totalWorkCost);

            var testDaysCost = new ProjectCostSummaryViewModel
            {
                ProjectCostSummaryType = ProjectCostSummaryType.Simple,
                Name = "Essais jours",
                Rate = project.TestDayRate,
            };
            summaryItems.Add(testDaysCost);

            var testNightsCost = new ProjectCostSummaryViewModel
            {
                ProjectCostSummaryType = ProjectCostSummaryType.Simple,
                Name = "Essais nuits",
                Rate = project.TestNightRate,
            };
            summaryItems.Add(testNightsCost);

            var totalTestsCost = new ProjectCostSummaryViewModel
            {
                ProjectCostSummaryType = ProjectCostSummaryType.TotalTests,
                Name = "Total Essais",
            };
            summaryItems.Add(totalTestsCost);

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
                studyCost.TotalTime += item.StudyDays;
                studyCost.TotalCost += item.StudyDays * studyCost.Rate;

                referenceCost.TotalTime += item.ReferenceDays;
                referenceCost.TotalCost += item.ReferenceDays * referenceCost.Rate;

                workDaysCost.TotalTime += item.WorkDays;
                workDaysCost.TotalCost += item.WorkDays * workDaysCost.Rate;

                workShortNightsCost.TotalTime += item.WorkShortNights;
                workShortNightsCost.TotalCost += item.WorkShortNights * workShortNightsCost.Rate;

                workLongNightsCost.TotalTime += item.WorkLongNights;
                workLongNightsCost.TotalCost += item.WorkLongNights * workLongNightsCost.Rate;

                executiveWorkDaysCost.TotalTime += item.ExecutiveWorkDays;
                executiveWorkDaysCost.TotalCost += item.ExecutiveWorkDays * executiveWorkDaysCost.Rate;

                executiveWorkShortNightsCost.TotalTime += item.ExecutiveWorkShortNights;
                executiveWorkShortNightsCost.TotalCost += item.ExecutiveWorkShortNights * executiveWorkShortNightsCost.Rate;

                executiveWorkLongNightsCost.TotalTime += item.ExecutiveWorkLongNights;
                executiveWorkLongNightsCost.TotalCost += item.ExecutiveWorkLongNights * executiveWorkLongNightsCost.Rate;

                testDaysCost.TotalTime += item.TestsDays;
                testDaysCost.TotalCost += item.TestsDays * testDaysCost.Rate;

                testNightsCost.TotalTime += item.TestsNights;
                testNightsCost.TotalCost += item.TestsNights * testNightsCost.Rate;
            }

            totalStudyReferenceCost.TotalTime = studyCost.TotalTime + referenceCost.TotalTime;
            totalStudyReferenceCost.TotalCost = studyCost.TotalCost + referenceCost.TotalCost;

            totalWorkCost.TotalTime = workDaysCost.TotalTime + workShortNightsCost.TotalTime + workLongNightsCost.TotalTime +
                executiveWorkDaysCost.TotalTime + executiveWorkShortNightsCost.TotalTime + executiveWorkLongNightsCost.TotalTime;
            totalWorkCost.TotalCost = workDaysCost.TotalCost + workShortNightsCost.TotalCost + workLongNightsCost.TotalTime +
                executiveWorkDaysCost.TotalCost + executiveWorkShortNightsCost.TotalCost + executiveWorkLongNightsCost.TotalCost;

            totalTestsCost.TotalTime = testDaysCost.TotalTime + testNightsCost.TotalTime;
            totalTestsCost.TotalCost = testDaysCost.TotalCost + testNightsCost.TotalCost;

            bigTotalCost.TotalTime = totalStudyReferenceCost.TotalTime + totalWorkCost.TotalTime + totalTestsCost.TotalTime;
            bigTotalCost.TotalCost = totalStudyReferenceCost.TotalCost + totalWorkCost.TotalCost + totalTestsCost.TotalCost;

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
