using System;
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

        private readonly IEditProjectHardwareTechnicianWorkView editProjectHardwareTechnicianWorkView;

        private readonly IEditProjectHardwareWorkerWorkView editProjectHardwareWorkerWorkView;

        private readonly IEditProjectHardwareStudyReferenceTestsView editProjectHardwareStudyReferenceTestsView;

        private readonly IEventBroker eventBroker;

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
            IEditProjectHardwareTechnicianWorkView editProjectHardwareTechnicianWorkView,
            IEditProjectHardwareWorkerWorkView editProjectHardwareWorkerWorkView,
            IEditProjectHardwareStudyReferenceTestsView editProjectHardwareStudyReferenceTestsView,
            ICatalogRepository catalogRepository, 
            IEventBroker eventBroker)
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
            this.editProjectHardwareTechnicianWorkView = editProjectHardwareTechnicianWorkView;
            this.editProjectHardwareWorkerWorkView = editProjectHardwareWorkerWorkView;
            this.editProjectHardwareStudyReferenceTestsView = editProjectHardwareStudyReferenceTestsView;
            this.catalogRepository = catalogRepository;
            this.eventBroker = eventBroker;
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

        private ProjectHardwareWorkerWorkViewModel MapToHardwareWorkerWorkViewModel(ProjectHardware hardware, int projectId)
        {
            Mapper.CreateMap<ProjectHardware, ProjectHardwareWorkerWorkViewModel>();
            var viewModel = Mapper.Map<ProjectHardware, ProjectHardwareWorkerWorkViewModel>(hardware);
            viewModel.ProjectId = projectId;
            
            return viewModel;
        }

        private ProjectHardwareTechnicianWorkViewModel MapToHardwareTechnicianWorkViewModel(ProjectHardware hardware, int projectId)
        {
            Mapper.CreateMap<ProjectHardware, ProjectHardwareTechnicianWorkViewModel>();
            var viewModel = Mapper.Map<ProjectHardware, ProjectHardwareTechnicianWorkViewModel>(hardware);
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
                    item.TechnicianWorkDays * project.TechnicianWorkDayRate +
                    item.TechnicianWorkShortNights * project.TechnicianWorkShortNightsRate +
                    item.TechnicianWorkLongNights * project.TechnicianWorkLongNightsRate +
                    item.WorkerWorkDays * project.WorkerWorkDayRate +
                    item.WorkerWorkShortNights * project.WorkerWorkShortNightsRate +
                    item.WorkerWorkLongNights * project.WorkerWorkLongNightsRate +
                    item.TestsDays * project.TestDayRate +
                    item.TestsNights * project.TestNightRate;

                // total time
                viewModel.TotalDays += item.StudyDays +
                    item.ReferenceDays +
                    item.TechnicianWorkDays +
                    item.TechnicianWorkShortNights +
                    item.TechnicianWorkLongNights +
                    item.WorkerWorkDays +
                    item.WorkerWorkShortNights +
                    item.WorkerWorkLongNights +
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

            var technicianWorks = new List<ProjectHardwareTechnicianWorkViewModel>();
            var workerWorks = new List<ProjectHardwareWorkerWorkViewModel>();
            var studyReferenceTests = new List<ProjectHardwareStudyReferenceTestViewModel>();
            var hardwares = new List<ProjectHardwareViewModel>();
            foreach (var item in project.Hardwares)
            {
                hardwares.Add(MapToHardwareViewModel(item, project.Id));
                technicianWorks.Add(MapToHardwareTechnicianWorkViewModel(item, project.Id));
                workerWorks.Add(MapToHardwareWorkerWorkViewModel(item, project.Id));
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
            this.projectView.SetHardwareTechnicianWorks(technicianWorks);
            this.projectView.SetHardwareWorkerWorks(workerWorks);
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
                    //item.ModuleSize = item.Components.Sum(x => x.SupplyModuleSize * x.Quantity);
                    //item.CatalogPrice = item.Components.Sum(x => x.SupplyCatalogPrice * x.Quantity);
                    //foreach (var subItem in item.Components)
                    //{
                    //    subItem.HardwareId = item.Id;
                    //    subItem.CatalogId = catalog.Id;
                    //    if (subItem.Comment.StartsWith("{\\rtf"))
                    //    {
                    //        rtBox.Rtf = string.IsNullOrEmpty(subItem.Comment) ? "{\\rtf}" : subItem.Comment;
                    //        subItem.Comment = rtBox.Text;
                    //    }
                    //}
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

            var technicianWorkViewModel = MapToHardwareTechnicianWorkViewModel(eventObject.ProjectHardware, eventObject.ProjectId);

            this.projectView.AddHardwareTechnicianWork(technicianWorkViewModel);

            var workerWorkViewModel = MapToHardwareWorkerWorkViewModel(eventObject.ProjectHardware, eventObject.ProjectId);

            this.projectView.AddHardwareWorkerWork(workerWorkViewModel);

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

            var technicianWorkViewModel = MapToHardwareTechnicianWorkViewModel(eventObject.Hardware, eventObject.ProjectId);
            this.projectView.RemoveHardwareTechnicianWork(technicianWorkViewModel);

            var workerWorkViewModel = MapToHardwareWorkerWorkViewModel(eventObject.Hardware, eventObject.ProjectId);
            this.projectView.RemoveHardwareWorkerWork(workerWorkViewModel);

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

            var technicianWorkViewModel = MapToHardwareTechnicianWorkViewModel(eventObject.ProjectHardware, eventObject.ProjectId);
            this.projectView.UpdateHardwareTechnicianWork(technicianWorkViewModel);

            var workerWorkViewModel = MapToHardwareWorkerWorkViewModel(eventObject.ProjectHardware, eventObject.ProjectId);
            this.projectView.UpdateHardwareWorkerWork(workerWorkViewModel);

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
        public void ProcessAction(RequestEditProjectHardwareTechnicianWorkAction eventObject)
        {
            this.editProjectHardwareTechnicianWorkView.Hardware = eventObject.Hardware;
            this.editProjectHardwareTechnicianWorkView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(RequestEditProjectHardwareWorkerWorkAction eventObject)
        {
            this.editProjectHardwareWorkerWorkView.Hardware = eventObject.Hardware;
            this.editProjectHardwareWorkerWorkView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(RequestEditProjectHardwareStudyReferenceTestAction eventObject)
        {
            this.editProjectHardwareStudyReferenceTestsView.Hardware = eventObject.Hardware;
            this.editProjectHardwareStudyReferenceTestsView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(RequestCopyProjectAction eventObject)
        {
            var deal = this.dealRepository.FindById(eventObject.DealId);
            var project = this.projectRepository.FindById(eventObject.ProjectId);

            Mapper.CreateMap<ProjectSupply, ProjectSupply>();
            Mapper.CreateMap<ProjectHardwareSupply, ProjectHardwareSupply>();
            Mapper.CreateMap<ProjectHardware, ProjectHardware>();
            Mapper.CreateMap<OtherBenefit, OtherBenefit>();
            Mapper.CreateMap<ProjectFrame, ProjectFrame>();
            Mapper.CreateMap<Project, Project>();


            Project cloneProject = Mapper.Map<Project, Project>(project);
            cloneProject.Name += " (copie)";
            cloneProject.Id = 0;
            deal.Projects.Add(cloneProject);

            cloneProject.Supplies = new List<ProjectSupply>();
            foreach (var s in project.Supplies)
            {
                ProjectSupply cloneProjectSupply = Mapper.Map<ProjectSupply, ProjectSupply>(s);
                cloneProjectSupply.Id = 0;
                cloneProject.Supplies.Add(cloneProjectSupply);
            }

            cloneProject.Hardwares = new List<ProjectHardware>();
            foreach (var h in project.Hardwares)
            {
                ProjectHardware cloneHardware = Mapper.Map<ProjectHardware, ProjectHardware>(h);
                cloneHardware.Id = 0;
                cloneProject.Hardwares.Add(cloneHardware);

                cloneHardware.Components = new List<ProjectHardwareSupply>();
                foreach (var s in h.Components)
                {
                    ProjectHardwareSupply cloneSupply = Mapper.Map<ProjectHardwareSupply, ProjectHardwareSupply>(s);
                    s.Id = 0;
                    cloneHardware.Components.Add(s);
                }
            }

            cloneProject.OtherBenefits = new List<OtherBenefit>();
            foreach (var o in project.OtherBenefits)
            {
                OtherBenefit cloneOtherBenefits = Mapper.Map<OtherBenefit, OtherBenefit>(o);
                cloneOtherBenefits.Id = 0;
                cloneProject.OtherBenefits.Add(cloneOtherBenefits);
            }

            cloneProject.Frames = new List<ProjectFrame>();
            foreach (var f in project.Frames)
            {
                ProjectFrame cloneFrame = Mapper.Map<ProjectFrame, ProjectFrame>(f);
                cloneFrame.Id = 0;
                cloneProject.Frames.Add(cloneFrame);
            }


            this.dealRepository.Save(deal);

            this.eventBroker.Publish(new DealCreatedEvent(deal));

            this.eventBroker.Publish(new ProjectCreatedEvent(deal, cloneProject));
        }

        [Subscribe]
        public void ProcessAction(RequestDeleteProjectAction eventObject)
        {
            var deal = this.dealRepository.FindById(eventObject.DealId);
            var project = this.projectRepository.FindById(eventObject.ProjectId);

            deal.Projects.Remove(project);

            this.dealRepository.Save(deal);

            this.projectRepository.Delete(project);

            this.eventBroker.Publish(new ProjectDeletedEvent(deal.Id, project.Id));
        }
    }
}
