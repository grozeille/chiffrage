using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using Chiffrage.Catalogs.Domain.Repositories;
using Chiffrage.Catalogs.Domain.Commands;
using Chiffrage.Catalogs.Domain.Events;
using Chiffrage.Mvc.Services;
using AutoMapper;

namespace Chiffrage.Catalogs.Domain.Services
{
    public class CatalogService : IService, 
        IGenericEventHandler<CreateNewCatalogCommand>,
        IGenericEventHandler<UpdateCatalogCommand>,
        IGenericEventHandler<CreateNewSupplyCommand>,
        IGenericEventHandler<UpdateSupplyCommand>,
        IGenericEventHandler<DeleteSupplyCommand>,
        IGenericEventHandler<CreateNewHardwareCommand>,
        IGenericEventHandler<UpdateHardwareCommand>,
        IGenericEventHandler<DeleteHardwareCommand>,
        IGenericEventHandler<CreateNewHardwareSupplyCommand>,
        IGenericEventHandler<DeleteHardwareSupplyCommand>,
        IGenericEventHandler<UpdateHardwareSupplyCommand>
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

            Mapper.CreateMap<CreateNewSupplyCommand, Supply>();

            var supply = Mapper.Map<CreateNewSupplyCommand, Supply>(eventObject);

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

        public void ProcessAction(UpdateSupplyCommand eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);

            var supply = catalog.Supplies.Where(s => s.Id == eventObject.SupplyId).First();

            Mapper.CreateMap<UpdateSupplyCommand, Supply>();

            Mapper.Map(eventObject, supply);

            this.repository.Save(catalog);

            this.eventBroker.Publish(new SupplyUpdatedEvent(catalog.Id, supply));
        }

        public void ProcessAction(DeleteSupplyCommand eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);

            var supply = catalog.Supplies.Where(x => x.Id == eventObject.SupplyId).FirstOrDefault();

            if (supply != null)
            {
                catalog.Supplies.Remove(supply);

                this.repository.Save(catalog);

                this.eventBroker.Publish(new SupplyDeletedEvent(catalog.Id, supply));
            }
        }

        public void ProcessAction(CreateNewHardwareCommand eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);

            Mapper.CreateMap<CreateNewHardwareCommand, Hardware>();

            var hardware = Mapper.Map<CreateNewHardwareCommand, Hardware>(eventObject);

            // hardware name must be unique
            if (catalog.Hardwares.Where(x => x.Name.Equals(hardware.Name, System.StringComparison.OrdinalIgnoreCase)).Any())
            {
                this.eventBroker.Publish(new HardwareMustBeUniqueErrorEvent(catalog.Id, hardware));
            }
            else
            {
                catalog.Hardwares.Add(hardware);

                this.repository.Save(catalog);

                this.eventBroker.Publish(new HardwareCreatedEvent(catalog.Id, hardware));
            }
        }

        public void ProcessAction(UpdateHardwareCommand eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);

            var hardware = catalog.Hardwares.Where(s => s.Id == eventObject.HardwareId).First();

            Mapper.CreateMap<UpdateHardwareCommand, Hardware>();

            Mapper.Map(eventObject, hardware);

            this.repository.Save(catalog);

            this.eventBroker.Publish(new HardwareUpdatedEvent(catalog.Id, hardware));
        }

        public void ProcessAction(DeleteHardwareCommand eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);

            var hardware = catalog.Hardwares.Where(x => x.Id == eventObject.HardwareId).FirstOrDefault();

            if (hardware != null)
            {
                catalog.Hardwares.Remove(hardware);

                this.repository.Save(catalog);

                this.eventBroker.Publish(new HardwareDeletedEvent(catalog.Id, hardware));
            }
        }
        public void ProcessAction(CreateNewHardwareSupplyCommand eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);
            var hardware = catalog.Hardwares.Where(x => x.Id == eventObject.HardwareId).First();
            var supply = catalog.Supplies.Where(x => x.Id == eventObject.SupplyId).First();

            var hardwareSupply = new HardwareSupply
            {
                Quantity = eventObject.Quantity,
                Supply = supply
            };

            // supply name must be unique in hardaware components
            if (hardware.Components.Where(x => x.Id == supply.Id).Any())
            {
                this.eventBroker.Publish(new HardwareSupplyMustBeUniqueErrorEvent(catalog.Id, hardware.Id, supply));
            }
            else
            {
                hardware.Components.Add(hardwareSupply);

                this.repository.Save(catalog);

                this.eventBroker.Publish(new HardwareSupplyCreatedEvent(catalog.Id, hardware, hardwareSupply));
            }
        }

        public void ProcessAction(DeleteHardwareSupplyCommand eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);
            var hardware = catalog.Hardwares.Where(x => x.Id == eventObject.HardwareId).First();
            var hardwareSupply = hardware.Components.Where(x => x.Id == eventObject.HardwareSupplyId).First();

            hardware.Components.Remove(hardwareSupply);

            this.repository.Save(catalog);

            this.eventBroker.Publish(new HardwareSupplyDeletedEvent(catalog.Id, hardware, hardwareSupply));
        }

        public void ProcessAction(UpdateHardwareSupplyCommand eventObject)
        {
            var catalog = this.repository.FindById(eventObject.CatalogId);
            var hardware = catalog.Hardwares.Where(x => x.Id == eventObject.HardwareId).First();
            var hardwareSupply = hardware.Components.Where(x => x.Id == eventObject.HardwareSupplyId).First();

            hardwareSupply.Quantity = eventObject.Quantity;

            this.repository.Save(catalog);

            this.eventBroker.Publish(new HardwareSupplyUpdatedEvent(catalog.Id, hardware, hardwareSupply));
        }
    }
}
