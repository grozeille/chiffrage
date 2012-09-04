﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Chiffrage.Projects.Module.Actions;
using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Projects.Module.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.Projects.Domain;
using Chiffrage.Projects.Domain.Repositories;
using Chiffrage.Mvc.Controllers;
using Chiffrage.Projects.Domain.Commands;
using Chiffrage.Catalogs.Domain.Repositories;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Projects.Domain.Events;
using Chiffrage.Mvc;
using Chiffrage.Mvc.Views;
using Chiffrage.Common.Module.Actions;
using Chiffrage.Catalogs.Module.ViewModel;

namespace Chiffrage.Projects.Module.Controllers
{
    public class ProjectController : IController
    {
        private readonly IProjectView projectView;

        private readonly INewProjectView newProjectView;

        private readonly IProjectRepository projectRepository;

        private readonly IDealRepository dealRepository;

        private readonly ICatalogRepository catalogRepository;

        private readonly INewProjectSupplyView newProjectSupplyView;

        private readonly INewProjectHardwareView newProjectHardwareView;

        private readonly IEditProjectSupplyView editProjectSupplyView;

        private readonly IEditProjectHardwareView editProjectHardwareView;

        private readonly INewProjectFrameView newProjectFrameView;

        private readonly IEditProjectHardwareSupplyView editProjectHardwareSupplyView;

        private readonly IEditProjectHardwareWorkView editProjectHardwareWorkView;

        private readonly IEditProjectHardwareEecutiveWorkView editProjectHardwareExecutiveWorkView;

        private readonly IEditProjectHardwareStudyReferenceTestsView editProjectHardwareStudyReferenceTestsView;

        // no better way...
        private readonly System.Windows.Forms.RichTextBox rtBox = new System.Windows.Forms.RichTextBox();
        
        public ProjectController(
            IProjectView projectView, 
            INewProjectView newProjectView, 
            IProjectRepository projectRepository, 
            IDealRepository dealRepository,
            INewProjectSupplyView newProjectSupplyView,
            INewProjectHardwareView newProjectHardwareView,
            IEditProjectSupplyView editProjectSupplyView,
            IEditProjectHardwareView editProjectHardwareView,
            INewProjectFrameView newProjectFrameView,
            IEditProjectHardwareSupplyView editProjectHardwareSupplyView,
            IEditProjectHardwareWorkView editProjectHardwareWorkView,
            IEditProjectHardwareEecutiveWorkView editProjectHardwareExecutiveWorkView,
            IEditProjectHardwareStudyReferenceTestsView editProjectHardwareStudyReferenceTestsView,
            ICatalogRepository catalogRepository)
        {
            this.projectView = projectView;
            this.newProjectView = newProjectView;
            this.projectRepository = projectRepository;
            this.dealRepository = dealRepository;
            this.newProjectSupplyView = newProjectSupplyView;
            this.newProjectHardwareView = newProjectHardwareView;
            this.editProjectHardwareView = editProjectHardwareView;
            this.editProjectSupplyView = editProjectSupplyView;
            this.newProjectFrameView = newProjectFrameView;
            this.editProjectHardwareSupplyView = editProjectHardwareSupplyView;
            this.editProjectHardwareWorkView = editProjectHardwareWorkView;
            this.editProjectHardwareExecutiveWorkView = editProjectHardwareExecutiveWorkView;
            this.editProjectHardwareStudyReferenceTestsView = editProjectHardwareStudyReferenceTestsView;
            this.catalogRepository = catalogRepository;
        }


        private ProjectHardwareViewModel MapToHardwareViewModel(ProjectHardware hardware, int projectId)
        {
            Mapper.CreateMap<ProjectHardware, ProjectHardwareViewModel>();
            Mapper.CreateMap<ProjectHardwareSupply, ProjectHardwareSupplyViewModel>();
            var viewModel = Mapper.Map<ProjectHardware, ProjectHardwareViewModel>(hardware);
            viewModel.ProjectId = projectId;

            foreach (var subItem in viewModel.Components)
            {
                subItem.ProjectId = projectId;
                subItem.HardwareId = viewModel.Id;
                subItem.CatalogId = viewModel.CatalogId;
                if (subItem.Comment.StartsWith("{\\rtf"))
                {
                    rtBox.Rtf = string.IsNullOrEmpty(subItem.Comment) ? "{\\rtf}" : subItem.Comment;
                    subItem.Comment = rtBox.Text;
                }
            }

            viewModel.TotalModuleSize = hardware.Components.Sum(x => x.Supply.ModuleSize * x.Quantity);
            viewModel.TotalCatalogPrice = hardware.Components.Sum(x => x.Supply.CatalogPrice * x.Quantity);
            viewModel.TotalPrice = hardware.Components.Sum(x => x.Supply.Price * x.Quantity);

            return viewModel;
        }

        private ProjectHardwareStudyReferenceTestViewModel MapToHardwareStudyReferenceTestViewModel(ProjectHardware hardware, int projectId)
        {
            Mapper.CreateMap<ProjectHardware, ProjectHardwareStudyReferenceTestViewModel>();
            var viewModel = Mapper.Map<ProjectHardware, ProjectHardwareStudyReferenceTestViewModel>(hardware);
            viewModel.ProjectId = projectId;
            
            return viewModel;
        }

        private ProjectHardwareExecutiveWorkViewModel MapToHardwareExecutiveWorkViewModel(ProjectHardware hardware, int projectId)
        {
            Mapper.CreateMap<ProjectHardware, ProjectHardwareExecutiveWorkViewModel>();
            var viewModel = Mapper.Map<ProjectHardware, ProjectHardwareExecutiveWorkViewModel>(hardware);
            viewModel.ProjectId = projectId;
            
            return viewModel;
        }

        private ProjectHardwareWorkViewModel MapToHardwareWorkViewModel(ProjectHardware hardware, int projectId)
        {
            Mapper.CreateMap<ProjectHardware, ProjectHardwareWorkViewModel>();
            var viewModel = Mapper.Map<ProjectHardware, ProjectHardwareWorkViewModel>(hardware);
            viewModel.ProjectId = projectId;

            return viewModel;
        }

        private ProjectSupplyViewModel Map(ProjectSupply supply, int projectId)
        {
            Mapper.CreateMap<ProjectSupply, ProjectSupplyViewModel>();

            var viewModel = Mapper.Map<ProjectSupply, ProjectSupplyViewModel>(supply);
            viewModel.ProjectId = projectId;

            viewModel.TotalModuleSize = viewModel.ModuleSize * viewModel.Quantity;
            viewModel.TotalPrice = viewModel.Price * viewModel.Quantity;
            viewModel.TotalCatalogPrice = viewModel.CatalogPrice * viewModel.Quantity;
            viewModel.TotalPFC12 = viewModel.PFC12 * viewModel.Quantity;
            viewModel.TotalPFC0 = viewModel.PFC0 * viewModel.Quantity;
            viewModel.TotalCap = viewModel.Cap * viewModel.Quantity;

            return viewModel;
        }

        private ProjectFrameViewModel Map(ProjectFrame frame, int projectId)
        {
            Mapper.CreateMap<ProjectFrame, ProjectFrameViewModel>();

            var viewModel = Mapper.Map<ProjectFrame, ProjectFrameViewModel>(frame);
            viewModel.ProjectId = projectId;

            return viewModel;
        }

        private ProjectViewModel Map(Project project)
        {
            Mapper.CreateMap<Project, ProjectViewModel>();
            var viewModel = Mapper.Map<Project, ProjectViewModel>(project);

            if (viewModel.StartDate == DateTime.MinValue)
            {
                viewModel.StartDate = DateTime.Now;
            }

            if (viewModel.EndDate == DateTime.MinValue)
            {
                viewModel.EndDate = DateTime.Now;
            }

            if (viewModel.Comment == null || !(viewModel.Comment.StartsWith("{\\rtf") && viewModel.Comment.EndsWith("}")))
                viewModel.Comment = "{\\rtf" + viewModel.Comment + "}";

            viewModel.TotalModules = project.Hardwares.Sum(x => x.Components.Sum(y => y.Quantity * y.Supply.ModuleSize)) +
                project.Supplies.Sum(x => x.Quantity * x.ModuleSize);

            viewModel.ModulesNotInFrame = viewModel.TotalModules - project.Frames.Sum(x => x.Count * x.Size);
            if (viewModel.ModulesNotInFrame < 0)
            {
                viewModel.ModulesNotInFrame = 0;
            }

            viewModel.TotalPrice = 0;
            foreach (var item in project.Supplies)
            {
                viewModel.TotalPrice += item.Quantity * item.Price;
            }

            foreach (var item in project.Hardwares)
            {
                // total price of components
                viewModel.TotalPrice += item.Components.Sum(x => x.Supply.Price * x.Quantity);

                // tota price of time*rate
                viewModel.TotalPrice += item.StudyDays * project.StudyRate +
                    item.ReferenceDays * project.ReferenceRate +
                    item.WorkDays * project.TechnicianWorkDayRate +
                    item.WorkShortNights * project.TechnicianWorkShortNightsRate +
                    item.WorkLongNights * project.TechnicianWorkLongNightsRate +
                    item.ExecutiveWorkDays * project.WorkerWorkDayRate +
                    item.ExecutiveWorkShortNights * project.WorkerWorkShortNightsRate +
                    item.ExecutiveWorkLongNights * project.WorkerWorkLongNightsRate +
                    item.TestsDays * project.TestDayRate +
                    item.TestsNights * project.TestNightRate;

                // total time
                viewModel.TotalDays += item.StudyDays +
                    item.ReferenceDays +
                    item.WorkDays +
                    item.WorkShortNights +
                    item.WorkLongNights +
                    item.ExecutiveWorkDays +
                    item.ExecutiveWorkShortNights +
                    item.ExecutiveWorkLongNights +
                    item.TestsDays +
                    item.TestsNights;
            }

            return viewModel;
        }

        private void RefreshProject(int projectId)
        {
            var project = this.projectRepository.FindById(projectId);
            var projectViewModel = Map(project);

            this.projectView.SetProjectViewModel(projectViewModel);
        }

        private void RefreshSummary(int projectId)
        {
            var project = this.projectRepository.FindById(projectId);

            this.projectView.SetSummaryItems(project.BuildSummaryItems());
        }

        private void RefreshCostSummary(int projectId)
        {
            var project = this.projectRepository.FindById(projectId);

            this.projectView.SetCostSummaryItems(project.BuildProjectCostSummaryItems());
        }

        [Subscribe]
        public void ProcessAction(ApplicationStartAction eventObject)
        {
            this.projectView.HideView();
        }

        [Subscribe]
        public void ProcessAction(ProjectSelectedAction eventObject)
        {
            var project = this.projectRepository.FindById(eventObject.Id);

            var viewModel = Map(project);
            
            var supplies = new List<ProjectSupplyViewModel>();
            foreach (var item in project.Supplies)
            {
                supplies.Add(Map(item, project.Id));
            }

            var works = new List<ProjectHardwareWorkViewModel>();
            var executiveWorks = new List<ProjectHardwareExecutiveWorkViewModel>();
            var studyReferenceTests = new List<ProjectHardwareStudyReferenceTestViewModel>();
            var hardwares = new List<ProjectHardwareViewModel>();
            foreach (var item in project.Hardwares)
            {
                hardwares.Add(MapToHardwareViewModel(item, project.Id));
                works.Add(MapToHardwareWorkViewModel(item, project.Id));
                executiveWorks.Add(MapToHardwareExecutiveWorkViewModel(item, project.Id));
                studyReferenceTests.Add(MapToHardwareStudyReferenceTestViewModel(item, project.Id));
            }

            var frames = new List<ProjectFrameViewModel>();
            foreach (var item in project.Frames)
            {
                frames.Add(Map(item, project.Id));
            }

            this.projectView.SetProjectViewModel(viewModel);
            this.projectView.SetSupplies(supplies);
            this.projectView.SetHardwares(hardwares);
            this.projectView.SetFrames(frames);
            this.projectView.SetHardwareWorks(works);
            this.projectView.SetHardwareExecutiveWorks(executiveWorks);
            this.projectView.SetHardwareStudyReferenceTests(studyReferenceTests);

            this.RefreshSummary(project.Id);
            this.RefreshCostSummary(project.Id);

            this.projectView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(ProjectUnselectedAction eventObject)
        {
            this.projectView.HideView();

            this.projectView.SetProjectViewModel(null);
            this.projectView.SetSupplies(null);
            this.projectView.SetHardwares(null);
            this.projectView.SetFrames(null);
            this.projectView.SetSummaryItems(null);
        }

        [Subscribe]
        public void ProcessAction(ProjectUpdatedEvent eventObject)
        {
            this.RefreshProject(eventObject.NewProject.Id);
            this.RefreshCostSummary(eventObject.NewProject.Id);
        }

        [Subscribe]
        public void ProcessAction(SaveAction eventObject)
        {
            this.projectView.Save();
        }

        [Subscribe]
        public void ProcessAction(RequestNewProjectAction eventObject)
        {
            this.newProjectView.ParentDealId = eventObject.DealId;
            this.newProjectView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(RequestNewProjectSupplyAction eventObject)
        {
            var catalogs = this.catalogRepository.FindAll();
            List<CatalogSupplyViewModel> suppliesViewModel = new List<CatalogSupplyViewModel>();
            Mapper.CreateMap<Supply, CatalogSupplyViewModel>();

            foreach(var catalog in catalogs)
            {
                var supplies = Mapper.Map<IList<Supply>, IList<CatalogSupplyViewModel>>(catalog.Supplies);
                foreach (var item in supplies)
                {
                    item.CatalogId = catalog.Id;
                }
                suppliesViewModel.AddRange(supplies);
            }

            this.newProjectSupplyView.Supplies = suppliesViewModel;
            this.newProjectSupplyView.ProjectId = eventObject.ProjectId;
            this.newProjectSupplyView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(ProjectSupplyCreatedEvent eventObject)
        {
            var viewModel = Map(eventObject.ProjectSupply, eventObject.ProjectId);
            this.projectView.AddSupply(viewModel);

            this.RefreshSummary(eventObject.ProjectId);
            this.RefreshCostSummary(eventObject.ProjectId);

            this.RefreshProject(eventObject.ProjectId);
        }

        [Subscribe]
        public void ProcessAction(ProjectSupplyDeletedEvent eventObject)
        {
            var supply = Map(eventObject.ProjectSupply, eventObject.ProjectId);
            this.projectView.RemoveSupply(supply);

            this.RefreshSummary(eventObject.ProjectId);
            this.RefreshCostSummary(eventObject.ProjectId);

            this.RefreshProject(eventObject.ProjectId);
        }

        [Subscribe]
        public void ProcessAction(RequestEditProjectSupplyAction eventObject)
        {
            this.editProjectSupplyView.Supply = eventObject.Supply;
            this.editProjectSupplyView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(RequestNewProjectHardwareAction eventObject)
        {
            var catalogs = this.catalogRepository.FindAll();
            List<CatalogHardwareViewModel> hardwaresViewModel = new List<CatalogHardwareViewModel>();
            Mapper.CreateMap<Hardware, CatalogHardwareViewModel>();
            Mapper.CreateMap<HardwareSupply, CatalogHardwareSupplyViewModel>();

            foreach (var catalog in catalogs)
            {
                var hardwares = Mapper.Map<IList<Hardware>, IList<CatalogHardwareViewModel>>(catalog.Hardwares);
                foreach (var item in hardwares)
                {
                    item.CatalogId = catalog.Id;
                    item.ModuleSize = item.Components.Sum(x => x.SupplyModuleSize * x.Quantity);
                    item.CatalogPrice = item.Components.Sum(x => x.SupplyCatalogPrice * x.Quantity);
                    foreach (var subItem in item.Components)
                    {
                        subItem.HardwareId = item.Id;
                        subItem.CatalogId = catalog.Id;
                        if (subItem.Comment.StartsWith("{\\rtf"))
                        {
                            rtBox.Rtf = string.IsNullOrEmpty(subItem.Comment) ? "{\\rtf}" : subItem.Comment;
                            subItem.Comment = rtBox.Text;
                        }
                    }
                }
                hardwaresViewModel.AddRange(hardwares);
            }

            this.newProjectHardwareView.ProjectId = eventObject.ProjectId;
            this.newProjectHardwareView.Hardwares = hardwaresViewModel;
            this.newProjectHardwareView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(ProjectHardwareCreatedEvent eventObject)
        {
            var viewModel = MapToHardwareViewModel(eventObject.ProjectHardware, eventObject.ProjectId);
            
            this.projectView.AddHardware(viewModel);

            var workViewModel = MapToHardwareWorkViewModel(eventObject.ProjectHardware, eventObject.ProjectId);

            this.projectView.AddHardwareWork(workViewModel);

            var executiveWorkViewModel = MapToHardwareExecutiveWorkViewModel(eventObject.ProjectHardware, eventObject.ProjectId);

            this.projectView.AddHardwareExecutiveWork(executiveWorkViewModel);

            var studyReferenceTestViewModel = MapToHardwareStudyReferenceTestViewModel(eventObject.ProjectHardware, eventObject.ProjectId);

            this.projectView.AddHardwareStudyReferenceTest(studyReferenceTestViewModel);

            this.RefreshSummary(eventObject.ProjectId);
            this.RefreshCostSummary(eventObject.ProjectId);

            this.RefreshProject(eventObject.ProjectId);
        }

        [Subscribe]
        public void ProcessAction(ProjectHardwareDeletedEvent eventObject)
        {
            var hardware = MapToHardwareViewModel(eventObject.Hardware, eventObject.ProjectId);
            this.projectView.RemoveHardware(hardware);

            var workViewModel = MapToHardwareWorkViewModel(eventObject.Hardware, eventObject.ProjectId);
            this.projectView.RemoveHardwareWork(workViewModel);

            var executiveWorkViewModel = MapToHardwareExecutiveWorkViewModel(eventObject.Hardware, eventObject.ProjectId);
            this.projectView.RemoveHardwareExecutiveWork(executiveWorkViewModel);

            var studyReferenceTestViewModel = MapToHardwareStudyReferenceTestViewModel(eventObject.Hardware, eventObject.ProjectId);
            this.projectView.RemoveHardwareStudyReferenceTest(studyReferenceTestViewModel);


            this.RefreshSummary(eventObject.ProjectId);
            this.RefreshCostSummary(eventObject.ProjectId);

            this.RefreshProject(eventObject.ProjectId);
        }

        [Subscribe]
        public void ProcessAction(RequestEditProjectHardwareAction eventObject)
        {
            this.editProjectHardwareView.Hardware = eventObject.Hardware;
            this.editProjectHardwareView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(RequestNewProjectFrameAction eventObject)
        {
            this.newProjectFrameView.ProjectId = eventObject.ProjectId;
            this.newProjectFrameView.ShowView();            
        }

        [Subscribe]
        public void ProcessAction(ProjectFrameCreatedEvent eventObject)
        {
            this.RefreshProject(eventObject.ProjectId);
            
            var projectFrameViewModel = Map(eventObject.ProjectFrame, eventObject.ProjectId);
            this.projectView.AddFrame(projectFrameViewModel);

            this.RefreshSummary(eventObject.ProjectId);
            this.RefreshCostSummary(eventObject.ProjectId);
        }

        [Subscribe]
        public void ProcessAction(ProjectFrameDeletedEvent eventObject)
        {
            var frame = Map(eventObject.Frame, eventObject.ProjectId);
            this.projectView.RemoveFrame(frame);

            this.RefreshProject(eventObject.ProjectId);

            this.RefreshSummary(eventObject.ProjectId);
            this.RefreshCostSummary(eventObject.ProjectId);
        }

        [Subscribe]
        public void ProcessAction(ProjectSupplyUpdatedEvent eventObject)
        {
            var viewModel = Map(eventObject.ProjectSupply, eventObject.ProjectId);
            this.projectView.UpdateSupply(viewModel);

            this.RefreshProject(eventObject.ProjectId);
        }

        [Subscribe]
        public void ProcessAction(ProjectHardwareUpdatedEvent eventObject)
        {
            var viewModel = MapToHardwareViewModel(eventObject.ProjectHardware, eventObject.ProjectId);
            this.projectView.UpdateHardware(viewModel);

            var workViewModel = MapToHardwareWorkViewModel(eventObject.ProjectHardware, eventObject.ProjectId);
            this.projectView.UpdateHardwareWork(workViewModel);

            var executiveWorkViewModel = MapToHardwareExecutiveWorkViewModel(eventObject.ProjectHardware, eventObject.ProjectId);
            this.projectView.UpdateHardwareExecutiveWork(executiveWorkViewModel);

            var studyReferenceTestViewModel = MapToHardwareStudyReferenceTestViewModel(eventObject.ProjectHardware, eventObject.ProjectId);
            this.projectView.UpdateHardwareStudyReferenceTest(studyReferenceTestViewModel);

            this.RefreshProject(eventObject.ProjectId);

            this.RefreshCostSummary(eventObject.ProjectId);
        }

        [Subscribe]
        public void ProcessAction(RequestEditProjectHardwareSupplyAction eventObject)
        {
            this.editProjectHardwareSupplyView.HardwareSupply = eventObject.HardwareSupply;
            this.editProjectHardwareSupplyView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(ProjectHardwareSupplyUpdatedEvent eventObject)
        {
            var viewModel = MapToHardwareViewModel(eventObject.ProjectHardware, eventObject.ProjectId);
            this.projectView.UpdateHardware(viewModel);

            this.RefreshProject(eventObject.ProjectId);
        }

        [Subscribe]
        public void ProcessAction(RequestEditProjectHardwareWorkAction eventObject)
        {
            this.editProjectHardwareWorkView.Hardware = eventObject.Hardware;
            this.editProjectHardwareWorkView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(RequestEditProjectHardwareExecutiveWorkAction eventObject)
        {
            this.editProjectHardwareExecutiveWorkView.Hardware = eventObject.Hardware;
            this.editProjectHardwareExecutiveWorkView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(RequestEditProjectHardwareStudyReferenceTestAction eventObject)
        {
            this.editProjectHardwareStudyReferenceTestsView.Hardware = eventObject.Hardware;
            this.editProjectHardwareStudyReferenceTestsView.ShowView();
        }
    }
}
