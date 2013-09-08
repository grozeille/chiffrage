using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Services;
using Chiffrage.Mvc.Events;
using Chiffrage.Projects.Domain.Commands;
using Chiffrage.Projects.Domain.Repositories;
using Chiffrage.Catalogs.Domain.Repositories;
using Chiffrage.Projects.Domain.Events;
using AutoMapper;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.Projects.Domain.Services
{
    public class ProjectService : IService
    {
        private readonly IEventBroker eventBroker;
        private readonly ICatalogRepository catalogRepository;
        private readonly IDealRepository dealRepository;
        private readonly IProjectRepository projectRepository;
        private readonly ITaskRepository taskRepository;

        public ProjectService(
            IEventBroker eventBroker,
            ICatalogRepository catalogRepository,
            ITaskRepository taskRepository,
            IDealRepository dealRepository,
            IProjectRepository projectRepository)
        {
            this.dealRepository = dealRepository;
            this.catalogRepository = catalogRepository;
            this.taskRepository = taskRepository;
            this.projectRepository = projectRepository;
            this.eventBroker = eventBroker;
        }

        [Subscribe]
        public void ProcessAction(CreateNewDealCommand eventObject)
        {
            var newDeal = new Deal();
            newDeal.Name = eventObject.DealName;

            this.dealRepository.Save(newDeal);

            this.eventBroker.Publish(new DealCreatedEvent(newDeal));
        }

        [Subscribe]
        public void ProcessAction(UpdateDealCommand eventObject)
        {
            var deal = this.dealRepository.FindById(eventObject.DealId);

            Mapper.CreateMap<UpdateDealCommand, Deal>();

            Mapper.Map(eventObject, deal);

            this.dealRepository.Save(deal);

            this.eventBroker.Publish(new DealUpdatedEvent(deal));
        }

        [Subscribe]
        public void ProcessAction(UpdateProjectCommand eventObject)
        {
            var project = this.projectRepository.FindById(eventObject.ProjectId);

            Mapper.CreateMap<UpdateProjectCommand, Project>();

            Mapper.Map(eventObject, project);

            this.projectRepository.Save(project);

            this.eventBroker.Publish(new ProjectUpdatedEvent(project));
        }

        [Subscribe]
        public void ProcessAction(CreateNewProjectCommand eventObject)
        {
            var deal = this.dealRepository.FindById(eventObject.DealId);

            var newProject = new Project();
            newProject.Hardwares = new List<ProjectHardware>();
            newProject.Frames = new List<ProjectFrame>();
            newProject.OtherBenefits = new List<OtherBenefit>();
            newProject.Supplies = new List<ProjectSupply>();
            newProject.Tasks = this.taskRepository.FindAll().Select(x => new ProjectTask
            { 
                Name = x.Name, 
                TaskId = x.Id,
                Category = x.Category,
                Type = x.Type,
                OrderId = x.OrderId
            }).ToList();
            newProject.Name = eventObject.ProjectName;

            this.projectRepository.Save(newProject);
            deal.Projects.Add(newProject);
            this.dealRepository.Save(deal);

            this.eventBroker.Publish(new ProjectCreatedEvent(deal, newProject));
        }

        [Subscribe]
        public void ProcessAction(CreateNewProjectSupplyCommand eventObject)
        {
            var catalog = this.catalogRepository.FindById(eventObject.CatalogId);
            var supply = catalog.Supplies.Where(x => x.Id == eventObject.SupplyId).First();
            var project = this.projectRepository.FindById(eventObject.ProjectId);

            var projectSupply = MapProjectSupply(supply, new ProjectSupply(), eventObject.Quantity, catalog);
            project.Supplies.Add(projectSupply);

            this.projectRepository.Save(project);

            this.eventBroker.Publish(new ProjectSupplyCreatedEvent(project.Id, projectSupply));
        }

        private static ProjectSupply MapProjectSupply(Supply supply, ProjectSupply projectSupply, int quantity,
                                                      SupplierCatalog catalog)
        {
            Mapper.CreateMap<Supply, ProjectSupply>()
                .ForMember(x => x.SupplyId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Id, y => y.Ignore());

            Mapper.Map<Supply, ProjectSupply>(supply, projectSupply);
            projectSupply.CatalogId = catalog.Id;
            projectSupply.Quantity = quantity;
            projectSupply.Price = supply.CatalogPrice;
            return projectSupply;
        }

        [Subscribe]
        public void ProcessAction(DeleteProjectSupplyCommand eventObject)
        {
            var project = this.projectRepository.FindById(eventObject.ProjectId);
            var supply = project.Supplies.Where(x => x.Id == eventObject.ProjectSupplyId).First();

            project.Supplies.Remove(supply);

            this.projectRepository.Save(project);

            this.eventBroker.Publish(new ProjectSupplyDeletedEvent(project.Id, supply));
        }
        
        [Subscribe]
        public void ProcessAction(CreateNewProjectHardwareListCommand eventObject)
        {
            var projects = new List<Project>();
            var hardwares = new Dictionary<ProjectHardware, int>();
            foreach (var groupByProject in eventObject.Commands.GroupBy(x => x.ProjectId))
            {
                var project = this.projectRepository.FindById(groupByProject.Key);
                foreach(var groupByCatalog in groupByProject.GroupBy(x => x.CatalogId))
                {
                    var catalog = this.catalogRepository.FindById(groupByCatalog.Key);
                    foreach(var item in groupByCatalog)
                    {
                        var hardware = catalog.Hardwares.Where(x => x.Id == item.HardwareId).First();
                    
                        var projectHardware = MapProjectHardware(project, hardware, new ProjectHardware(), catalog);

                        project.Hardwares.Add(projectHardware);

                        projects.Add(project);
                        hardwares.Add(projectHardware, project.Id);
                    }
                }
            }

            foreach(var item in projects)
            {
                this.projectRepository.Save(item);
            }

            foreach(var item in hardwares)
            {
                this.eventBroker.Publish(new ProjectHardwareCreatedEvent(item.Value, item.Key));
            }
        }

        [Subscribe]
        public void ProcessAction(CreateNewProjectHardwareCommand eventObject)
        {
            var catalog = this.catalogRepository.FindById(eventObject.CatalogId);
            var hardware = catalog.Hardwares.Where(x => x.Id == eventObject.HardwareId).First();
            var project = this.projectRepository.FindById(eventObject.ProjectId);

            var projectHardware = MapProjectHardware(project, hardware, new ProjectHardware(),  catalog);

            project.Hardwares.Add(projectHardware);

            this.projectRepository.Save(project);

            this.eventBroker.Publish(new ProjectHardwareCreatedEvent(project.Id, projectHardware));
        }

        private ProjectHardware MapProjectHardware(Project project, Hardware hardware, ProjectHardware projectHardware, SupplierCatalog catalog)
        {
            Mapper.CreateMap<Supply, ProjectSupply>()
                .ForMember(x => x.SupplyId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Id, y => y.Ignore());
            Mapper.CreateMap<HardwareSupply, ProjectHardwareSupply>()
                .ForMember(x => x.HardwareSupplyId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Id, y => y.Ignore());
            Mapper.CreateMap<Hardware, ProjectHardware>()
                .ForMember(x => x.HardwareId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Tasks, y => y.Ignore())
                .ForMember(x => x.Id, y => y.Ignore());

            var projectTasksByOriginalId = new Dictionary<int, ProjectTask>();
            foreach (var item in project.Tasks)
            {
                projectTasksByOriginalId.Add(item.TaskId, item);
            }
            var hardwareTasksByOriginalId = new Dictionary<int, HardwareTask>();
            foreach (var item in hardware.Tasks)
            {
                hardwareTasksByOriginalId.Add(item.Id, item);
            }

            Mapper.Map<Hardware, ProjectHardware>(hardware, projectHardware);
            projectHardware.CatalogId = catalog.Id;

            if (projectHardware.Tasks == null)
            {
                projectHardware.Tasks = new List<ProjectHardwareTask>();
            }

            foreach(var item in projectHardware.Tasks)
            {
                HardwareTask hardwareTask;
                if (hardwareTasksByOriginalId.TryGetValue(item.HardwareTaskId, out hardwareTask))
                {
                    item.CatalogValue = hardwareTask.Value;
                    item.Value = hardwareTask.Value;
                    hardwareTasksByOriginalId.Remove(item.HardwareTaskId);
                }
            }

            foreach (var item in hardwareTasksByOriginalId.Values)
            {
                ProjectTask projectTask;
                if (projectTasksByOriginalId.TryGetValue(item.Task.Id, out projectTask))
                {
                    var projectHardwareTask = new ProjectHardwareTask
                                                  {
                                                      Value = item.Value,
                                                      CatalogValue = item.Value,
                                                      HardwareTaskId = item.Id,
                                                      HardwareTaskType = ProjectHardwareTaskType.DAY,
                                                      Task = projectTask
                                                  };
                    projectHardware.Tasks.Add(projectHardwareTask);
                }
            }

            foreach (var item in projectHardware.Components)
            {
                item.Supply.CatalogId = catalog.Id;
            }
            return projectHardware;
        }

        [Subscribe]
        public void ProcessAction(DeleteProjectHardwareCommand eventObject)
        {
            var project = this.projectRepository.FindById(eventObject.ProjectId);
            var hardware = project.Hardwares.Where(x => x.Id == eventObject.ProjectHardwareId).First();

            project.Hardwares.Remove(hardware);

            this.projectRepository.Save(project);

            this.eventBroker.Publish(new ProjectHardwareDeletedEvent(project.Id, hardware));
        }

        [Subscribe]
        public void ProcessAction(CreateNewProjectFrameCommand eventObject)
        {
            var project = this.projectRepository.FindById(eventObject.ProjectId);

            Mapper.CreateMap<CreateNewProjectFrameCommand, ProjectFrame>();
            var projectFrame = Mapper.Map<CreateNewProjectFrameCommand, ProjectFrame>(eventObject);

            project.Frames.Add(projectFrame);

            this.projectRepository.Save(project);

            this.eventBroker.Publish(new ProjectFrameCreatedEvent(project.Id, projectFrame));
        }

        [Subscribe]
        public void ProcessAction(DeleteProjectFrameCommand eventObject)
        {
            var project = this.projectRepository.FindById(eventObject.ProjectId);
            var frame = project.Frames.Where(x => x.Id == eventObject.ProjectFrameId).First();

            project.Frames.Remove(frame);

            this.projectRepository.Save(project);

            this.eventBroker.Publish(new ProjectFrameDeletedEvent(project.Id, frame));
        }

        [Subscribe]
        public void ProcessAction(UpdateProjectSupplyCommand eventObject)
        {
            var project = this.projectRepository.FindById(eventObject.ProjectId);
            var projectSupply = project.Supplies.Where(x => x.Id == eventObject.Id).First();

            Mapper.CreateMap<UpdateProjectSupplyCommand, ProjectSupply>();

            Mapper.Map(eventObject, projectSupply);

            this.projectRepository.Save(project);

            this.eventBroker.Publish(new ProjectSupplyUpdatedEvent(project.Id, projectSupply));
        }

        [Subscribe]
        public void ProcessAction(UpdateProjectHardwareCommand eventObject)
        {
            var project = this.projectRepository.FindById(eventObject.ProjectId);
            var projectHardware = project.Hardwares.Where(x => x.Id == eventObject.Id).First();

            Mapper.CreateMap<UpdateProjectHardwareCommand, ProjectHardware>();

            Mapper.Map(eventObject, projectHardware);

            this.projectRepository.Save(project);

            this.eventBroker.Publish(new ProjectHardwareUpdatedEvent(project.Id, projectHardware));
        }

        [Subscribe]
        public void ProcessAction(UpdateProjectHardwareSupplyCommand eventObject)
        {
            var project = this.projectRepository.FindById(eventObject.ProjectId);
            var projectHardware = project.Hardwares.Where(x => x.Id == eventObject.HardwareId).First();
            var projectHardwareSupply = projectHardware.Components.Where(x => x.Id == eventObject.HardwareSupplyId).First();

            // because it doesn't unflatten, do it manually
            projectHardwareSupply.Supply.Price = eventObject.SupplyPrice;


            this.projectRepository.Save(project);

            this.eventBroker.Publish(new ProjectHardwareSupplyUpdatedEvent(project.Id, projectHardware, projectHardwareSupply));
        }

        [Subscribe]
        public void ProcessAction(UpdateProjectHardwareTechnicianWorkCommand eventObject)
        {
            var project = this.projectRepository.FindById(eventObject.ProjectId);
            var projectHardware = project.Hardwares.Where(x => x.Id == eventObject.Id).First();

            Mapper.CreateMap<UpdateProjectHardwareTechnicianWorkCommand, ProjectHardware>();

            Mapper.Map(eventObject, projectHardware);

            this.projectRepository.Save(project);

            this.eventBroker.Publish(new ProjectHardwareUpdatedEvent(project.Id, projectHardware));
        }

        [Subscribe]
        public void ProcessAction(UpdateProjectHardwareWorkerWorkCommand eventObject)
        {
            var project = this.projectRepository.FindById(eventObject.ProjectId);
            var projectHardware = project.Hardwares.Where(x => x.Id == eventObject.Id).First();

            Mapper.CreateMap<UpdateProjectHardwareWorkerWorkCommand, ProjectHardware>();

            Mapper.Map(eventObject, projectHardware);

            this.projectRepository.Save(project);

            this.eventBroker.Publish(new ProjectHardwareUpdatedEvent(project.Id, projectHardware));
        }

        [Subscribe]
        public void ProcessAction(UpdateProjectHardwareStudyReferenceTestsCommand eventObject)
        {
            var project = this.projectRepository.FindById(eventObject.ProjectId);
            var projectHardware = project.Hardwares.Where(x => x.Id == eventObject.Id).First();

            Mapper.CreateMap<UpdateProjectHardwareStudyReferenceTestsCommand, ProjectHardware>();

            Mapper.Map(eventObject, projectHardware);

            this.projectRepository.Save(project);

            this.eventBroker.Publish(new ProjectHardwareUpdatedEvent(project.Id, projectHardware));
        }

        [Subscribe]
        public void ProcessAction(CloneDealCommand eventObject)
        {
            var deal = this.dealRepository.FindById(eventObject.DealId);
            Mapper.CreateMap<ProjectSupply, ProjectSupply>();
            Mapper.CreateMap<ProjectHardwareSupply, ProjectHardwareSupply>();
            Mapper.CreateMap<ProjectHardware, ProjectHardware>();
            Mapper.CreateMap<OtherBenefit, OtherBenefit>();
            Mapper.CreateMap<ProjectFrame, ProjectFrame>();
            Mapper.CreateMap<Project, Project>();
            Mapper.CreateMap<Deal, Deal>();

            var cloneDeal = Mapper.Map<Deal, Deal>(deal);
            cloneDeal.Name += " (copie)";
            cloneDeal.Id = 0;

            cloneDeal.Projects = new List<Project>();
            foreach (var p in deal.Projects)
            {
                Project cloneProject = cloneProject = CloneProject(p);
                cloneDeal.Projects.Add(cloneProject);
            }


            this.dealRepository.Save(cloneDeal);

            this.eventBroker.Publish(new DealCreatedEvent(cloneDeal));
        }


        [Subscribe]
        public void ProcessAction(DeleteDealCommand eventObject)
        {
            var deal = this.dealRepository.FindById(eventObject.DealId);

            this.dealRepository.Delete(deal);

            this.eventBroker.Publish(new DealDeletedEvent(deal.Id));
        }


        [Subscribe]
        public void ProcessAction(CloneProjectCommand eventObject)
        {
            var deal = this.dealRepository.FindById(eventObject.DealId);
            var project = this.projectRepository.FindById(eventObject.ProjectId);

            var cloneProject = CloneProject(project);

            deal.Projects.Add(cloneProject);

            this.dealRepository.Save(deal);

            this.eventBroker.Publish(new DealUpdatedEvent(deal));

            this.eventBroker.Publish(new ProjectCreatedEvent(deal, cloneProject));
        }

        private Project CloneProject(Project project)
        {
            Mapper.CreateMap<ProjectSupply, ProjectSupply>();
            Mapper.CreateMap<ProjectHardwareSupply, ProjectHardwareSupply>();
            Mapper.CreateMap<ProjectHardware, ProjectHardware>();
            Mapper.CreateMap<OtherBenefit, OtherBenefit>();
            Mapper.CreateMap<ProjectFrame, ProjectFrame>();
            Mapper.CreateMap<Project, Project>();
            Mapper.CreateMap<ProjectTask, ProjectTask>();
            Mapper.CreateMap<ProjectHardwareTask, ProjectHardwareTask>();


            Project cloneProject = Mapper.Map<Project, Project>(project);
            cloneProject.Name += " (copie)";
            cloneProject.Id = 0;

            var taskCache = new Dictionary<int, ProjectTask>();
            cloneProject.Tasks = new List<ProjectTask>();
            foreach (var s in project.Tasks)
            {
                ProjectTask cloneProjectTask = Mapper.Map<ProjectTask, ProjectTask>(s);
                cloneProjectTask.Id = 0;
                cloneProject.Tasks.Add(cloneProjectTask);
                taskCache.Add(s.Id, cloneProjectTask);
            }

            var supplyCache = new Dictionary<int, ProjectSupply>();
            cloneProject.Supplies = new List<ProjectSupply>();
            foreach (var s in project.Supplies)
            {
                ProjectSupply cloneProjectSupply = Mapper.Map<ProjectSupply, ProjectSupply>(s);
                cloneProjectSupply.Id = 0;
                cloneProject.Supplies.Add(cloneProjectSupply);
                supplyCache.Add(s.Id, cloneProjectSupply);
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
                    cloneSupply.Id = 0;

                    ProjectSupply cloneProjectSupply;
                    if (!supplyCache.TryGetValue(s.Supply.Id, out cloneProjectSupply))
                    {
                        cloneProjectSupply = Mapper.Map<ProjectSupply, ProjectSupply>(s.Supply);
                        cloneProjectSupply.Id = 0;
                    }
                    cloneSupply.Supply = cloneProjectSupply;

                    cloneHardware.Components.Add(cloneSupply);
                }

                cloneHardware.Tasks = new List<ProjectHardwareTask>();
                foreach (var s in h.Tasks)
                {
                    ProjectHardwareTask cloneTask = Mapper.Map<ProjectHardwareTask, ProjectHardwareTask>(s);
                    cloneTask.Id = 0;
                    cloneTask.Task = taskCache[s.Task.Id];
                    cloneHardware.Tasks.Add(cloneTask);
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

            return cloneProject;
        }

        [Subscribe]
        public void ProcessAction(DeleteProjectCommand eventObject)
        {
            var deal = this.dealRepository.FindById(eventObject.DealId);
            var project = this.projectRepository.FindById(eventObject.ProjectId);

            deal.Projects.Remove(project);

            this.dealRepository.Save(deal);

            this.projectRepository.Delete(project);

            this.eventBroker.Publish(new ProjectDeletedEvent(deal.Id, project.Id));
        }

        [Subscribe]
        public void ProcessAction(RefreshProjectTasksCommand eventObject)
        {
            var tasks = this.taskRepository.FindAll();

            var project = this.projectRepository.FindById(eventObject.ProjectId);

            var tasksByOriginalId = new Dictionary<int, ProjectTask>();
            foreach(var item in project.Tasks)
            {
                tasksByOriginalId.Add(item.TaskId, item);
            }

            // maj de l'existant
            var toAdd = new List<ProjectTask>();
            foreach(var item in tasks)
            {
                ProjectTask projectTask;
                if(tasksByOriginalId.TryGetValue(item.Id, out projectTask))
                {
                    projectTask.Name = item.Name;
                    projectTask.Category = item.Category;
                    projectTask.Type = item.Type;
                    projectTask.OrderId = item.OrderId;
                }
                else
                {
                    projectTask = new ProjectTask
                                      {
                                          Name = item.Name,
                                          TaskId = item.Id,
                                          Category = item.Category,
                                          Type = item.Type,
                                          OrderId = item.OrderId
                                      };
                    project.Tasks.Add(projectTask);
                    toAdd.Add(projectTask);
                }
            }

            // suppressions de ceux qui n'existent plus
            var toRemove = new List<ProjectTask>();
            foreach(var item in project.Tasks)
            {
                var task = tasks.Where(x => x.Id == item.TaskId).FirstOrDefault();
                if(task == null)
                {
                    toRemove.Add(item);
                }
            }
            foreach(var item in toRemove)
            {
                project.Tasks.Remove(item);
                foreach(var hardware in project.Hardwares)
                {
                    var existing = hardware.Tasks.Where(x => x.Task.TaskId == item.TaskId).FirstOrDefault();
                    if(existing != null)
                    {
                        hardware.Tasks.Remove(existing);
                    }
                }
            }

            this.projectRepository.Save(project);
            this.eventBroker.Publish(new ProjectUpdatedEvent(project));
        }

        [Subscribe]
        public void ProcessAction(ReloadProjectSupplyCommand eventObject)
        {
            var project = this.projectRepository.FindById(eventObject.ProjectId);
            var supply = project.Supplies.Where(x => x.Id == eventObject.ProjectSupplyId).First();

            var catalog = this.catalogRepository.FindById(supply.CatalogId);
            if (catalog == null)
            {
                // le catalogue n'existe plus
                return;
            }

            var catalogSupply = catalog.Supplies.Where(x => x.Id == supply.SupplyId).FirstOrDefault();
            if(catalogSupply == null)
            {
                // il n'existe plus
                return;
            }
            
            MapProjectSupply(catalogSupply, supply, supply.Quantity, catalog);

            this.projectRepository.Save(project);

            this.eventBroker.Publish(new ProjectSupplyUpdatedEvent(project.Id, supply));
        }

        [Subscribe]
        public void ProcessAction(ReloadProjectHardwareCommand eventObject)
        {
            var project = this.projectRepository.FindById(eventObject.ProjectId);
            var hardware = project.Hardwares.Where(x => x.Id == eventObject.ProjectHardwareId).First();

            var catalog = this.catalogRepository.FindById(hardware.CatalogId);
            if(catalog == null)
            {
                // le catalogue n'existe plus
                return;
            }

            var catalogHardware = catalog.Hardwares.Where(x => x.Id == hardware.HardwareId).FirstOrDefault();
            if (catalogHardware == null)
            {
                // il n'existe plus
                return;
            }

            MapProjectHardware(project, catalogHardware, hardware, catalog);

            this.projectRepository.Save(project);

            this.eventBroker.Publish(new ProjectHardwareUpdatedEvent(project.Id, hardware));
        }
    }
}
