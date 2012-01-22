﻿using System;
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
        IGenericEventHandler<CreateNewProjectSupplyCommand>
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
            var project = this.projectRepository.FindById(eventObject.SupplyId);

            Mapper.CreateMap<Supply, ProjectSupply>()
                .ForMember(x => x.SupplyId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Id, y => y.Ignore());

            var projectSupply = Mapper.Map<Supply, ProjectSupply>(supply);
            projectSupply.CatalogId = catalog.Id;
            project.Supplies.Add(projectSupply);

            this.projectRepository.Save(project);

            this.eventBroker.Publish(new ProjectSupplyCreatedEvent(project.Id, projectSupply));
        }
    }
}
