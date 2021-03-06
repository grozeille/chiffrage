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
using System.Threading;
using Common.Logging;

namespace Chiffrage.Projects.Module.Controllers
{
    [Topic(Topics.UI)]
    public class ProjectController : IController
    {
        private static ILog logger = LogManager.GetLogger(typeof(ProjectController));

        private readonly IProjectView projectView;

        private readonly INewProjectView newProjectView;

        private readonly IProjectRepository projectRepository;

        private readonly IDealRepository dealRepository;

        private readonly ICatalogRepository catalogRepository;

        private readonly ITaskRepository taskRepository;

        private readonly INewProjectSupplyView newProjectSupplyView;

        private readonly INewProjectHardwareView newProjectHardwareView;

        private readonly IEditProjectSupplyView editProjectSupplyView;

        private readonly IEditProjectHardwareView editProjectHardwareView;

        private readonly INewProjectFrameView newProjectFrameView;

        private readonly IEditProjectHardwareSupplyView editProjectHardwareSupplyView;

        private readonly ILoadingView loadingView;

        private int? projectIdClipboard = null;

        private int? currentProjectId = null;

        private int? currentProjectHashcode = null;
        
        // no better way...
        private readonly System.Windows.Forms.RichTextBox rtBox = new System.Windows.Forms.RichTextBox();

        [Publish(Topic = Topics.COMMANDS)]
        public event Action<CloneProjectCommand> OnCloneProjectCommand;

        [Publish(Topic = Topics.COMMANDS)]
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
            IEditProjectHardwareSupplyView editProjectHardwareSupplyView,
            ILoadingView loadingView,
            ICatalogRepository catalogRepository,
            ITaskRepository taskRepository)
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
            this.loadingView = loadingView;
            this.catalogRepository = catalogRepository;
            this.taskRepository = taskRepository;
        }

        #region Actions
        [Subscribe]
        public void ProcessAction(ApplicationStartAction eventObject)
        {
            this.projectView.HideView();
        }

        [Subscribe]
        public void ProcessAction(ProjectSelectedAction eventObject)
        {
            this.loadingView.Continuous = true;
            this.loadingView.ShowView();

            var project = this.projectRepository.FindById(eventObject.Id);

            var viewModel = Map(project);

            this.currentProjectHashcode = this.ComputeHashcode(viewModel);

            var supplies = new List<ProjectSupplyViewModel>();
            foreach (var item in project.Supplies)
            {
                supplies.Add(Map(item, project.Id));
            }

            var hardwares = new List<ProjectHardwareViewModel>();
            foreach (var item in project.Hardwares)
            {
                hardwares.Add(MapToHardwareViewModel(item, project.Id));
            }

            var frames = new List<ProjectFrameViewModel>();
            foreach (var item in project.Frames)
            {
                frames.Add(Map(item, project.Id));
            }

            try
            {
                this.projectView.SetProjectViewModel(viewModel);
                this.projectView.SetSupplies(supplies);
                this.projectView.SetHardwares(hardwares);
                this.projectView.SetFrames(frames);

                this.RefreshSummary(project.Id);
                this.RefreshCostSummary(project.Id);

                this.loadingView.HideView();
                this.projectView.ShowView();
            }
            catch(Exception ex)
            {
                logger.Warn("Error while loading the project",ex);

                // a weird bug throw an exception the first time it loads a project, so try again
                this.projectView.SetProjectViewModel(viewModel);
                this.projectView.SetSupplies(supplies);
                this.projectView.SetHardwares(hardwares);
                this.projectView.SetFrames(frames);

                this.RefreshSummary(project.Id);
                this.RefreshCostSummary(project.Id);

                this.loadingView.HideView();
                this.projectView.ShowView();
            }

            this.currentProjectId = eventObject.Id;
        }

        [Subscribe]
        public void ProcessAction(ProjectUnselectedAction eventObject)
        {
            if (!this.currentProjectId.HasValue || currentProjectId.Value != eventObject.Id)
                return;

            var viewModel = this.projectView.GetProjectViewModel();

            var viewModelHash = this.ComputeHashcode(viewModel);
            if (viewModelHash != this.currentProjectHashcode)
            {
                this.ProcessAction(new SaveAction());
            }

            this.projectView.HideView();

            this.projectView.SetProjectViewModel(null);
            this.projectView.SetSupplies(null);
            this.projectView.SetHardwares(null);
            this.projectView.SetFrames(null);
            this.projectView.SetSummaryItems(null);

            this.currentProjectId = null;
        }

        [Subscribe]
        public void ProcessAction(SaveAction eventObject)
        {
            var viewModel = this.projectView.GetProjectViewModel();

            if (viewModel != null)
            {
                var command = new UpdateProjectCommand(
                    viewModel.Id,
                    viewModel.Name,
                    viewModel.Comment,
                    viewModel.Reference,
                    viewModel.StartDate,
                    viewModel.EndDate,
                    viewModel.Tasks,
                    viewModel.OtherBenefits);

                this.OnUpdateProjectCommand(command);
            }
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
            List<CatalogSupplySelectionViewModel> suppliesViewModel = new List<CatalogSupplySelectionViewModel>();
            Mapper.CreateMap<Supply, CatalogSupplySelectionViewModel>();

            foreach(var catalog in catalogs)
            {
                var supplies = Mapper.Map<IList<Supply>, IList<CatalogSupplySelectionViewModel>>(catalog.Supplies);
                foreach (var item in supplies)
                {
                    item.CatalogId = catalog.Id;
                    item.CatalogName = catalog.SupplierName;
                    item.Quantity = 1;
                }
                suppliesViewModel.AddRange(supplies);
            }

            suppliesViewModel.Sort((x, y) =>
            {
                int result = x.CatalogName.CompareTo(y.CatalogName);
                if (result != 0)
                {
                    return result;
                }

                return x.Name.CompareTo(y.Name);
            });

            this.newProjectSupplyView.Supplies = suppliesViewModel;
            this.newProjectSupplyView.ProjectId = eventObject.ProjectId;
            this.newProjectSupplyView.ShowView();
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
            List<CatalogHardwareSelectionViewModel> hardwaresViewModel = new List<CatalogHardwareSelectionViewModel>();
            Mapper.CreateMap<Hardware, CatalogHardwareSelectionViewModel>();
            Mapper.CreateMap<HardwareSupply, CatalogHardwareSupplyViewModel>();

            foreach (var catalog in catalogs)
            {
                var hardwares = Mapper.Map<IList<Hardware>, IList<CatalogHardwareSelectionViewModel>>(catalog.Hardwares);
                foreach (var item in hardwares)
                {
                    item.CatalogId = catalog.Id;
                    item.CatalogName = catalog.SupplierName;
                    item.Quantity = 1;
                }
                hardwaresViewModel.AddRange(hardwares);
            }

            hardwaresViewModel.Sort((x, y) =>
            {
                int result = x.CatalogName.CompareTo(y.CatalogName);
                if (result != 0)
                {
                    return result;
                }

                return x.Name.CompareTo(y.Name);
            });

            this.newProjectHardwareView.ProjectId = eventObject.ProjectId;
            this.newProjectHardwareView.Hardwares = hardwaresViewModel;
            this.newProjectHardwareView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(ProjectCopyAction eventObject)
        {
            this.projectIdClipboard = eventObject.Id;
        }

        [Subscribe]
        public void ProcessAction(ProjectPasteAction eventObject)
        {
            if (this.projectIdClipboard.HasValue)
            {
                OnCloneProjectCommand(new CloneProjectCommand(eventObject.DealId, this.projectIdClipboard.Value));
            }
        }

        [Subscribe]
        public void ProcessAction(RequestEditProjectHardwareSupplyAction eventObject)
        {
            this.editProjectHardwareSupplyView.HardwareSupply = eventObject.HardwareSupply;
            this.editProjectHardwareSupplyView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(RequestEditProjectHardwareAction eventObject)
        {
            Project project = this.projectRepository.FindById(eventObject.Hardware.ProjectId);
            ProjectHardware hardware = project.Hardwares.Where(x => x.Id == eventObject.Hardware.Id).FirstOrDefault();

            this.editProjectHardwareView.Hardware = eventObject.Hardware;
            this.editProjectHardwareView.ProjectTasks = project.Tasks;
            this.editProjectHardwareView.HardwareTask = hardware.Tasks;
            this.editProjectHardwareView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(RequestNewProjectFrameAction eventObject)
        {
            this.newProjectFrameView.ProjectId = eventObject.ProjectId;
            this.newProjectFrameView.ShowView();
        }
        #endregion

        #region events
        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(ProjectUpdatedEvent eventObject)
        {
            if (CheckIfCurrentProject(eventObject)) return;

            this.RefreshProject(eventObject.ProjectId);
            this.RefreshCostSummary(eventObject.ProjectId);
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(ProjectSupplyCreatedEvent eventObject)
        {
            if (CheckIfCurrentProject(eventObject)) return;

            var project = this.projectRepository.FindById(eventObject.ProjectId);
            var supply = project.Supplies.Where(x => x.Id == eventObject.ProjectSupplyId).FirstOrDefault();

            var viewModel = Map(supply, eventObject.ProjectId);
            this.projectView.AddSupply(viewModel);

            this.RefreshSummary(eventObject.ProjectId);
            this.RefreshCostSummary(eventObject.ProjectId);

            this.RefreshProject(eventObject.ProjectId);
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(ProjectSupplyListCreatedEvent eventObject)
        {
            if (this.currentProjectId != null)
            {
                foreach (var item in eventObject.Commands.Where(x => x.ProjectId == this.currentProjectId))
                {
                    var project = this.projectRepository.FindById(item.ProjectId);
                    var supply = project.Supplies.Where(x => x.Id == item.ProjectSupplyId).FirstOrDefault();
                    var viewModel = Map(supply, item.ProjectId);
                    this.projectView.AddSupply(viewModel);
                }

                this.RefreshSummary(this.currentProjectId.Value);
                this.RefreshCostSummary(this.currentProjectId.Value);

                this.RefreshProject(this.currentProjectId.Value);
            }
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(ProjectSupplyUpdatedEvent eventObject)
        {
            if (CheckIfCurrentProject(eventObject)) return;

            var project = this.projectRepository.FindById(eventObject.ProjectId);
            var supply = project.Supplies.Where(x => x.Id == eventObject.ProjectSupplyId).FirstOrDefault();

            var viewModel = Map(supply, eventObject.ProjectId);
            this.projectView.UpdateSupply(viewModel);

            this.RefreshProject(eventObject.ProjectId);
            this.RefreshSummary(eventObject.ProjectId);
            this.RefreshCostSummary(eventObject.ProjectId);
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(ProjectSupplyListUpdatedEvent eventObject)
        {
            if (this.currentProjectId != null)
            {
                foreach (var item in eventObject.Commands.Where(x => x.ProjectId == this.currentProjectId))
                {
                    var project = this.projectRepository.FindById(item.ProjectId);
                    var supply = project.Supplies.Where(x => x.Id == item.ProjectSupplyId).FirstOrDefault();
                    var viewModel = Map(supply, item.ProjectId);
                    this.projectView.UpdateSupply(viewModel);
                }

                this.RefreshProject(this.currentProjectId.Value);
                this.RefreshSummary(this.currentProjectId.Value);
                this.RefreshCostSummary(this.currentProjectId.Value);
            }
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(ProjectSupplyDeletedEvent eventObject)
        {
            if (CheckIfCurrentProject(eventObject)) return;

            this.projectView.RemoveSupply(eventObject.ProjectSupplyId);

            this.RefreshSummary(eventObject.ProjectId);
            this.RefreshCostSummary(eventObject.ProjectId);

            this.RefreshProject(eventObject.ProjectId);
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(ProjectHardwareCreatedEvent eventObject)
        {
            if (CheckIfCurrentProject(eventObject)) return;

            var project = this.projectRepository.FindById(eventObject.ProjectId);
            var hardware = project.Hardwares.Where(x => x.Id == eventObject.ProjectHardwareId).FirstOrDefault();

            var viewModel = MapToHardwareViewModel(hardware, eventObject.ProjectId);
            
            this.projectView.AddHardware(viewModel);

            this.RefreshSummary(eventObject.ProjectId);
            this.RefreshCostSummary(eventObject.ProjectId);

            this.RefreshProject(eventObject.ProjectId);
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(ProjectHardwareListCreatedEvent eventObject)
        {
            if (this.currentProjectId != null)
            {

                foreach (var item in eventObject.Commands.Where(x => x.ProjectId == this.currentProjectId))
                {
                    var project = this.projectRepository.FindById(item.ProjectId);
                    var hardware = project.Hardwares.Where(x => x.Id == item.ProjectHardwareId).FirstOrDefault();
                    var viewModel = MapToHardwareViewModel(hardware, item.ProjectId);

                    this.projectView.AddHardware(viewModel);

                }

                this.RefreshSummary(this.currentProjectId.Value);
                this.RefreshCostSummary(this.currentProjectId.Value);

                this.RefreshProject(this.currentProjectId.Value);
            }
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(ProjectHardwareUpdatedEvent eventObject)
        {
            if (CheckIfCurrentProject(eventObject)) return;

            var project = this.projectRepository.FindById(eventObject.ProjectId);
            var hardware = project.Hardwares.Where(x => x.Id == eventObject.ProjectHardwareId).FirstOrDefault();

            var viewModel = MapToHardwareViewModel(hardware, eventObject.ProjectId);
            this.projectView.UpdateHardware(viewModel);

            this.RefreshProject(eventObject.ProjectId);
            this.RefreshSummary(eventObject.ProjectId);
            this.RefreshCostSummary(eventObject.ProjectId);
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(ProjectHardwareListUpdatedEvent eventObject)
        {
            if (this.currentProjectId != null)
            {
                foreach (var item in eventObject.Commands.Where(x => x.ProjectId == this.currentProjectId))
                {
                    var project = this.projectRepository.FindById(item.ProjectId);
                    var hardware = project.Hardwares.Where(x => x.Id == item.ProjectHardwareId).FirstOrDefault();

                    var viewModel = MapToHardwareViewModel(hardware, item.ProjectId);
                    this.projectView.UpdateHardware(viewModel);
                }

                this.RefreshProject(this.currentProjectId.Value);
                this.RefreshSummary(this.currentProjectId.Value);
                this.RefreshCostSummary(this.currentProjectId.Value);
            }
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(ProjectHardwareSupplyUpdatedEvent eventObject)
        {
            if (CheckIfCurrentProject(eventObject)) return;

            var project = this.projectRepository.FindById(eventObject.ProjectId);
            var hardware = project.Hardwares.Where(x => x.Id == eventObject.ProjectHardwareId).FirstOrDefault();

            var viewModel = MapToHardwareViewModel(hardware, eventObject.ProjectId);
            this.projectView.UpdateHardware(viewModel);

            this.RefreshProject(eventObject.ProjectId);
            this.RefreshSummary(eventObject.ProjectId);
            this.RefreshCostSummary(eventObject.ProjectId);
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(ProjectHardwareDeletedEvent eventObject)
        {
            if (CheckIfCurrentProject(eventObject)) return;

            this.projectView.RemoveHardware(eventObject.ProjectHardwareId);

            this.RefreshSummary(eventObject.ProjectId);
            this.RefreshCostSummary(eventObject.ProjectId);

            this.RefreshProject(eventObject.ProjectId);
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(ProjectFrameCreatedEvent eventObject)
        {
            if (CheckIfCurrentProject(eventObject)) return;

            this.RefreshProject(eventObject.ProjectId);

            var project = this.projectRepository.FindById(eventObject.ProjectId);
            var frame = project.Frames.Where(x => x.Id == eventObject.ProjectFrameId).FirstOrDefault();

            var projectFrameViewModel = Map(frame, eventObject.ProjectId);
            this.projectView.AddFrame(projectFrameViewModel);

            this.RefreshSummary(eventObject.ProjectId);
            this.RefreshCostSummary(eventObject.ProjectId);
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(ProjectFrameDeletedEvent eventObject)
        {
            if (CheckIfCurrentProject(eventObject)) return;

            this.projectView.RemoveFrame(eventObject.ProjectFrameId);

            this.RefreshProject(eventObject.ProjectId);

            this.RefreshSummary(eventObject.ProjectId);
            this.RefreshCostSummary(eventObject.ProjectId);
        }
        #endregion




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

                foreach (var task in item.Tasks)
                {
                    double rate = 0.0;
                    if (task.Task != null)
                    {
                        switch (task.HardwareTaskType)
                        {
                            case ProjectHardwareTaskType.DAY:
                                rate = task.Task.DayRate;
                                break;
                            case ProjectHardwareTaskType.SHORT_NIGHT:
                                rate = task.Task.ShortNightRate;
                                break;
                            case ProjectHardwareTaskType.LONG_NIGHT:
                                rate = task.Task.LongNightRate;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                    viewModel.TotalPrice += rate * task.Value;
                    viewModel.TotalDays += task.Value;
                }
            }

            if (viewModel.OtherBenefits == null)
            {
                viewModel.OtherBenefits = new List<OtherBenefit>();
            }

            viewModel.TotalPrice += viewModel.OtherBenefits.Sum(x => x.Hours * x.CostRate);
            viewModel.TotalDays += viewModel.OtherBenefits.Sum(x => x.Hours);

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

        private bool CheckIfCurrentProject(IProjectEvent eventObject)
        {
            if (!this.currentProjectId.HasValue || currentProjectId.Value != eventObject.ProjectId)
            {
                return true;
            }
            return false;
        }


        private int ComputeHashcode(ProjectViewModel viewModel)
        {
            int hash = 23;
            hash = hash * 31 + viewModel.Id.GetHashCode();
            hash = hash * 31 + viewModel.Name.GetHashCode();
            hash = hash * 31 + (viewModel.Reference == null ? 0 : viewModel.Reference.GetHashCode());
            hash = hash * 31 + (viewModel.Comment == null ? 0 : viewModel.Comment.GetHashCode());
            hash = hash * 31 + viewModel.StartDate.GetHashCode();
            hash = hash * 31 + viewModel.EndDate.GetHashCode();

            foreach(var item in viewModel.Tasks.OrderBy(x => x.Id))
            {
                int tasksHash = 23;
                tasksHash = tasksHash * 31 + item.Id.GetHashCode();
                tasksHash = tasksHash * 31 + item.DayRate.GetHashCode();
                tasksHash = tasksHash * 31 + item.NightRate.GetHashCode();
                tasksHash = tasksHash * 31 + item.LongNightRate.GetHashCode();
                tasksHash = tasksHash * 31 + item.ShortNightRate.GetHashCode();

                hash = hash * 31 + tasksHash;
            }

            foreach (var item in viewModel.OtherBenefits.OrderBy(x => x.Id))
            {
                int otherBenefitsHash = 23;
                otherBenefitsHash = otherBenefitsHash * 31 + item.Id.GetHashCode();
                otherBenefitsHash = otherBenefitsHash * 31 + item.Name.GetHashCode();
                otherBenefitsHash = otherBenefitsHash * 31 + item.Hours.GetHashCode();
                otherBenefitsHash = otherBenefitsHash * 31 + item.CostRate.GetHashCode();

                hash = hash * 31 + otherBenefitsHash;
            }

            return hash;
        }
    }
}
