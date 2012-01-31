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
    public class ProjectService : IService,
        IGenericEventHandler<CreateNewDealCommand>,
        IGenericEventHandler<CreateNewProjectCommand>,
        IGenericEventHandler<UpdateProjectCommand>,
        IGenericEventHandler<UpdateDealCommand>,
        IGenericEventHandler<CreateNewProjectSupplyCommand>,
        IGenericEventHandler<DeleteProjectSupplyCommand>,
        IGenericEventHandler<CreateNewProjectHardwareCommand>
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

        public void ProcessAction(CreateNewDealCommand eventObject)
        {
            var newDeal = new Deal();
            newDeal.Name = eventObject.DealName;

            this.dealRepository.Save(newDeal);

            this.eventBroker.Publish(new DealCreatedEvent(newDeal));
        }

        public void ProcessAction(UpdateDealCommand eventObject)
        {
            var deal = this.dealRepository.FindById(eventObject.DealId);

            Mapper.CreateMap<UpdateDealCommand, Deal>();

            Mapper.Map(eventObject, deal);

            this.dealRepository.Save(deal);

            this.eventBroker.Publish(new DealUpdatedEvent(deal));
        }

        public void ProcessAction(UpdateProjectCommand eventObject)
        {
            var project = this.projectRepository.FindById(eventObject.ProjectId);

            Mapper.CreateMap<UpdateProjectCommand, Project>();

            Mapper.Map(eventObject, project);

            this.projectRepository.Save(project);

            this.eventBroker.Publish(new ProjectUpdatedEvent(project));
        }

        public void ProcessAction(CreateNewProjectCommand eventObject)
        {
            var deal = this.dealRepository.FindById(eventObject.DealId);

            var newProject = new Project();
            newProject.Name = eventObject.ProjectName;

            this.projectRepository.Save(newProject);
            deal.Projects.Add(newProject);
            this.dealRepository.Save(deal);

            this.eventBroker.Publish(new ProjectCreatedEvent(deal, newProject));
        }

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
            project.Supplies.Add(projectSupply);

            this.projectRepository.Save(project);

            this.eventBroker.Publish(new ProjectSupplyCreatedEvent(project.Id, projectSupply));
        }

        public void ProcessAction(DeleteProjectSupplyCommand eventObject)
        {
            var project = this.projectRepository.FindById(eventObject.ProjectId);
            var supply = project.Supplies.Where(x => x.Id == eventObject.ProjectSupplyId).First();

            project.Supplies.Remove(supply);

            this.projectRepository.Save(project);

            this.eventBroker.Publish(new ProjectSupplyDeletedEvent(project.Id, supply));
        }

        public void ProcessAction(CreateNewProjectHardwareCommand eventObject)
        {
            var catalog = this.catalogRepository.FindById(eventObject.CatalogId);
            var hardware = catalog.Hardwares.Where(x => x.Id == eventObject.HardwareId).First();
            var project = this.projectRepository.FindById(eventObject.ProjectId);

            Mapper.CreateMap<Supply, ProjectSupply>()
                .ForMember(x => x.SupplyId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.CatalogId, y => y.UseValue(catalog.Id));
            Mapper.CreateMap<HardwareSupply, ProjectHardwareSupply>()
                .ForMember(x => x.HardwareSupplyId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Id, y => y.Ignore());
            Mapper.CreateMap<Hardware, ProjectHardware>()
                .ForMember(x => x.HardwareId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.CatalogId, y => y.UseValue(catalog.Id));

            var projectHardware = Mapper.Map<Hardware, ProjectHardware>(hardware);
            projectHardware.Quantity = eventObject.Quantity;
            project.Hardwares.Add(projectHardware);

            this.projectRepository.Save(project);

            this.eventBroker.Publish(new ProjectHardwareCreatedEvent(project.Id, projectHardware));
        }
    }
}
