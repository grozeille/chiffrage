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

        // no better way...
        private readonly System.Windows.Forms.RichTextBox rtBox = new System.Windows.Forms.RichTextBox();

        [Publish]
        public event Action<UpdateProjectCommand> OnUpdateProjectCommand;

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
            this.catalogRepository = catalogRepository;
        }


        private ProjectHardwareViewModel Map(ProjectHardware hardware, int projectId)
        {
            Mapper.CreateMap<ProjectHardware, ProjectHardwareViewModel>();
            Mapper.CreateMap<ProjectHardwareSupply, ProjectHardwareSupplyViewModel>();
            var viewModel = Mapper.Map<ProjectHardware, ProjectHardwareViewModel>(hardware);
            viewModel.ProjectId = projectId;

            foreach (var subItem in viewModel.Components)
            {
                subItem.HardwareId = viewModel.Id;
                subItem.CatalogId = viewModel.CatalogId;
                if (subItem.Comment.StartsWith("{\\rtf"))
                {
                    rtBox.Rtf = string.IsNullOrEmpty(subItem.Comment) ? "{\\rtf}" : subItem.Comment;
                    subItem.Comment = rtBox.Text;
                }
            }

            viewModel.ModuleSize = hardware.Components.Sum(x => x.Supply.ModuleSize * x.Quantity);
            viewModel.CatalogPrice = hardware.Components.Sum(x => x.Supply.CatalogPrice * x.Quantity);

            viewModel.TotalModuleSize = viewModel.ModuleSize * viewModel.Quantity;
            viewModel.TotalCatalogPrice = viewModel.CatalogPrice * viewModel.Quantity;

            viewModel.TotalCatalogStudyDays = viewModel.CatalogStudyDays * viewModel.Quantity;
            viewModel.TotalCatalogReferenceDays = viewModel.CatalogReferenceDays * viewModel.Quantity;
            viewModel.TotalCatalogWorkDays = viewModel.CatalogWorkDays * viewModel.Quantity; 
            viewModel.TotalCatalogExecutiveWorkDays = viewModel.CatalogExecutiveWorkDays * viewModel.Quantity;
            viewModel.TotalCatalogTestsDays = viewModel.CatalogTestsDays * viewModel.Quantity;

            viewModel.TotalStudyDays = viewModel.StudyDays * viewModel.Quantity;
            viewModel.TotalReferenceDays = viewModel.ReferenceDays * viewModel.Quantity;
            viewModel.TotalWorkDays = viewModel.WorkDays * viewModel.Quantity;
            viewModel.TotalExecutiveWorkDays = viewModel.ExecutiveWorkDays * viewModel.Quantity;
            viewModel.TotalTestsDays = viewModel.TestsDays * viewModel.Quantity;

            return viewModel;
        }

        private IList<ProjectSummaryItemViewModel> MapSummaryItem(ProjectHardware hardware, int projectId)
        {
            IList<ProjectSummaryItemViewModel> summaryItems = new List<ProjectSummaryItemViewModel>();
            summaryItems.Add(new ProjectSummaryItemViewModel
            {
                ProjectId = projectId,
                Id = hardware.Id,
                ItemType = ProjectSummaryItemType.Hardware,
                Name = hardware.Name,
                Quantity = hardware.Quantity
            });
            foreach (var component in hardware.Components)
            {
                summaryItems.Add(new ProjectSummaryItemViewModel
                {
                    ProjectId = projectId,
                    Id = component.Id,
                    ItemType = ProjectSummaryItemType.Supply,
                    Name = component.Supply.Name,
                    Quantity = component.Quantity
                });
            }

            return summaryItems;
        }

        private ProjectSummaryItemViewModel MapSummaryItem(ProjectSupply supply, int projectId)
        {
            return new ProjectSummaryItemViewModel
            {
                ProjectId = projectId,
                Id = supply.Id,
                ItemType = ProjectSummaryItemType.Supply,
                Name = supply.Name,
                Quantity = supply.Quantity
            };
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

            viewModel.TotalModules = project.Hardwares.Sum(x => x.Quantity * x.Components.Sum(y => y.Quantity * y.Supply.ModuleSize)) +
                project.Supplies.Sum(x => x.Quantity * x.ModuleSize);

            viewModel.ModulesNotInFrame = viewModel.TotalModules - project.Frames.Sum(x => x.Count * x.Size);
            if (viewModel.ModulesNotInFrame < 0)
            {
                viewModel.ModulesNotInFrame = 0;
            }

            return viewModel;
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
            var hardwares = new List<ProjectHardwareViewModel>();
            foreach (var item in project.Hardwares)
            {
                hardwares.Add(Map(item, project.Id));
            }
            var frames = new List<ProjectFrameViewModel>();
            foreach (var item in project.Frames)
            {
                frames.Add(Map(item, project.Id));
            }

            var summaryItems = new List<ProjectSummaryItemViewModel>();
            foreach (var item in project.Supplies)
            {
                summaryItems.Add(MapSummaryItem(item, project.Id));
            }
            foreach (var item in project.Hardwares)
            {
                summaryItems.AddRange(MapSummaryItem(item, project.Id));
            }

            this.projectView.SetProjectViewModel(viewModel);
            this.projectView.SetSupplies(supplies);
            this.projectView.SetHardwares(hardwares);
            this.projectView.SetFrames(frames);
            this.projectView.SetSummaryItems(summaryItems);

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
        public void ProcessAction(SaveAction eventObject)
        {
            var viewModel = this.projectView.GetProjectViewModel();

            if (viewModel == null)
            {
                return;
            }

            var command = new UpdateProjectCommand(
                viewModel.Id,
                viewModel.Name,
                viewModel.Comment,
                viewModel.Reference,
                viewModel.StartDate,
                viewModel.EndDate,
                viewModel.StudyRate,
                viewModel.ReferenceRate,
                viewModel.WorkDayRate,
                viewModel.WorkShortNightsRate,
                viewModel.WorkLongNightsRate,
                viewModel.TestDayRate,
                viewModel.TestNightRate);

            this.OnUpdateProjectCommand(command);
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

            var summaryItem = MapSummaryItem(eventObject.ProjectSupply, eventObject.ProjectId);

            this.projectView.AddSummaryItems(summaryItem);

            this.RefreshProject(eventObject.ProjectId);
        }

        [Subscribe]
        public void ProcessAction(ProjectSupplyDeletedEvent eventObject)
        {
            var supply = Map(eventObject.ProjectSupply, eventObject.ProjectId);
            this.projectView.RemoveSupply(supply);

            var summaryItems = MapSummaryItem(eventObject.ProjectSupply, eventObject.ProjectId);

            this.projectView.RemoveSummaryItems(summaryItems);

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
            var viewModel = Map(eventObject.ProjectHardware, eventObject.ProjectId);
            this.projectView.AddHardware(viewModel);

            var summaryItems = MapSummaryItem(eventObject.ProjectHardware, eventObject.ProjectId);
            this.projectView.AddSummaryItems(summaryItems.ToArray());

            this.RefreshProject(eventObject.ProjectId);
        }

        [Subscribe]
        public void ProcessAction(ProjectHardwareDeletedEvent eventObject)
        {
            var hardware = Map(eventObject.Hardware, eventObject.ProjectId);
            this.projectView.RemoveHardware(hardware);

            var summaryItems = MapSummaryItem(eventObject.Hardware, eventObject.ProjectId);

            this.projectView.RemoveSummaryItems(summaryItems.ToArray());

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
        }

        private void RefreshProject(int projectId)
        {
            var project = this.projectRepository.FindById(projectId);
            var projectViewModel = Map(project);
            this.projectView.SetProjectViewModel(projectViewModel);
        }

        [Subscribe]
        public void ProcessAction(ProjectFrameDeletedEvent eventObject)
        {
            var frame = Map(eventObject.Frame, eventObject.ProjectId);
            this.projectView.RemoveFrame(frame);

            this.RefreshProject(eventObject.ProjectId);
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
            var viewModel = Map(eventObject.ProjectHardware, eventObject.ProjectId);
            this.projectView.UpdateHardware(viewModel);

            this.RefreshProject(eventObject.ProjectId);
        }
    }
}
