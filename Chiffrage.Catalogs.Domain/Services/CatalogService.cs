using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using Chiffrage.Catalogs.Domain.Repositories;
using Chiffrage.Catalogs.Domain.Commands;
using Chiffrage.Catalogs.Domain.Events;
using Chiffrage.Mvc.Services;

namespace Chiffrage.Catalogs.Domain.Services
{
    public class CatalogService : IService, 
        IGenericEventHandler<CreateNewCatalogCommand>,
        IGenericEventHandler<UpdateCatalogCommand>,
        IGenericEventHandler<CreateNewSupplyCommand>
    {
        private readonly IEventBroker eventBroker;
        private readonly ICatalogRepository repository;
        
        public CatalogService(
            IEventBroker eventBroker,
            ICatalogRepository repository)
        {
            this.repository = repository;
            this.eventBroker = eventBroker;
        }

        public void ProcessAction(CreateNewCatalogCommand eventObject)
        {
            var catalog = new SupplierCatalog();
            catalog.SupplierName = eventObject.Name;

            this.repository.Save(catalog);

            this.eventBroker.Publish(new CatalogCreatedEvent(catalog));
        }

        public void ProcessAction(UpdateCatalogCommand eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);
            catalog.SupplierName = eventObject.Name;
            catalog.Comment = eventObject.Comment;

            this.repository.Save(catalog);

            this.eventBroker.Publish(new CatalogUpdatedEvent(catalog));
        }

        public void ProcessAction(CreateNewSupplyCommand eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);

            var supply = new Supply
            {
                Name = eventObject.Name,
                Reference = eventObject.Reference,
                ModuleSize = eventObject.ModuleSize,
                ReferenceDays = eventObject.ReferenceDays,
                StudyDays = eventObject.StudyDays,
                CatalogTestsDays = eventObject.CatalogTestsDays,
                CatalogWorkDays = eventObject.CatalogWorkDays,
                CatalogExecutiveWorkDays = eventObject.CatalogExecutiveWorkDays,
                CatalogPrice = eventObject.CatalogPrice,
                Category = eventObject.Category
            };

            // supply name must be unique
            if (catalog.Supplies.Where(x => x.Name.Equals(eventObject.Name, System.StringComparison.OrdinalIgnoreCase)).Any())
            {
                this.eventBroker.Publish(new SupplyMustBeUniqueErrorEvent(catalog.Id, supply));
            }
            else
            {
                catalog.Supplies.Add(supply);

                this.repository.Save(catalog);

                this.eventBroker.Publish(new SupplyCreatedEvent(catalog.Id, supply));
            }
        }
    }
}
