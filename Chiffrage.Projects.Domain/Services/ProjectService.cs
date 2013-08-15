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

        public ProjectService(
            IEventBroker eventBroker,
            ICatalogRepository catalogRepository,
            IDealRepository dealRepository,
            IProjectRepository projectRepository)
        {
            this.dealRepository = dealRepository;
            this.catalogRepository = catalogRepository;
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

            Mapper.CreateMap<Supply, ProjectSupply>()
                .ForMember(x => x.SupplyId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Id, y => y.Ignore());

            var projectSupply = Mapper.Map<Supply, ProjectSupply>(supply);
            projectSupply.CatalogId = catalog.Id;
            projectSupply.Quantity = eventObject.Quantity;
            projectSupply.Price = supply.CatalogPrice;
            project.Supplies.Add(projectSupply);

            this.projectRepository.Save(project);

            this.eventBroker.Publish(new ProjectSupplyCreatedEvent(project.Id, projectSupply));
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
        public void ProcessAction(CreateNewProjectHardwareCommand eventObject)
        {
            var catalog = this.catalogRepository.FindById(eventObject.CatalogId);
            var hardware = catalog.Hardwares.Where(x => x.Id == eventObject.HardwareId).First();
            var project = this.projectRepository.FindById(eventObject.ProjectId);

            Mapper.CreateMap<Supply, ProjectSupply>()
                .ForMember(x => x.SupplyId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Id, y => y.Ignore());
            Mapper.CreateMap<HardwareSupply, ProjectHardwareSupply>()
                .ForMember(x => x.HardwareSupplyId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Id, y => y.Ignore());
            Mapper.CreateMap<Hardware, ProjectHardware>()
                .ForMember(x => x.HardwareId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Id, y => y.Ignore());

            var projectHardware = Mapper.Map<Hardware, ProjectHardware>(hardware);
            projectHardware.CatalogId = catalog.Id;

            projectHardware.StudyDays = hardware.CatalogStudyDays;
            projectHardware.ReferenceDays = hardware.CatalogReferenceDays;
            projectHardware.TechnicianWorkDays = hardware.CatalogTechnicianWorkDays;
            projectHardware.WorkerWorkDays = hardware.CatalogWorkerWorkDays;
            projectHardware.TestsDays = hardware.CatalogTestsDays;

            foreach (var item in projectHardware.Components)
            {
                item.Supply.CatalogId = catalog.Id;
            }

            project.Hardwares.Add(projectHardware);

            this.projectRepository.Save(project);

            this.eventBroker.Publish(new ProjectHardwareCreatedEvent(project.Id, projectHardware));
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
        public void ProcessAction(CopyDealCommand eventObject)
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
                Project cloneProject = Mapper.Map<Project, Project>(p);
                cloneProject.Id = 0;
                cloneDeal.Projects.Add(cloneProject);

                cloneProject.Supplies = new List<ProjectSupply>();
                foreach (var s in p.Supplies)
                {
                    ProjectSupply cloneProjectSupply = Mapper.Map<ProjectSupply, ProjectSupply>(s);
                    cloneProjectSupply.Id = 0;
                    cloneProject.Supplies.Add(cloneProjectSupply);
                }

                cloneProject.Hardwares = new List<ProjectHardware>();
                foreach (var h in p.Hardwares)
                {
                    ProjectHardware cloneHardware = Mapper.Map<ProjectHardware, ProjectHardware>(h);
                    cloneHardware.Id = 0;
                    cloneProject.Hardwares.Add(cloneHardware);

                    cloneHardware.Components = new List<ProjectHardwareSupply>();
                    foreach (var s in h.Components)
                    {
                        ProjectHardwareSupply cloneSupply = Mapper.Map<ProjectHardwareSupply, ProjectHardwareSupply>(s);
                        cloneSupply.Id = 0;
                        cloneHardware.Components.Add(s);
                    }
                }

                cloneProject.OtherBenefits = new List<OtherBenefit>();
                foreach (var o in p.OtherBenefits)
                {
                    OtherBenefit cloneOtherBenefits = Mapper.Map<OtherBenefit, OtherBenefit>(o);
                    cloneOtherBenefits.Id = 0;
                    cloneProject.OtherBenefits.Add(cloneOtherBenefits);
                }

                cloneProject.Frames = new List<ProjectFrame>();
                foreach (var f in p.Frames)
                {
                    ProjectFrame cloneFrame = Mapper.Map<ProjectFrame, ProjectFrame>(f);
                    cloneFrame.Id = 0;
                    cloneProject.Frames.Add(cloneFrame);
                }
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
        public void ProcessAction(CopyProjectCommand eventObject)
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
                    cloneSupply.Id = 0;
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
        public void ProcessAction(DeleteProjectCommand eventObject)
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
