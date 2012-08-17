using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Chiffrage.Catalogs.Domain.Services;
using Moq;
using Chiffrage.Mvc.Events;
using Chiffrage.Catalogs.Domain.Repositories;
using Chiffrage.Catalogs.Domain.Commands;
using System.Reflection;
using System.IO;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Catalogs.Domain.Events;

namespace Chiffrage.Catalogs.Tests
{
    [TestFixture]
    public class CatalogServiceTest
    {
        [Test]
        public void TestReadCsv()
        {
            var catalogReposityMock = new Mock<ICatalogRepository>();
            var eventBrokerMock = new Mock<IEventBroker>();

            var catalog = new SupplierCatalog();
            catalog.Id = 1;

            catalogReposityMock.Setup(x => x.FindById(1))
                .Returns(catalog);

            var catalogService = new CatalogService(eventBrokerMock.Object, catalogReposityMock.Object);

            var filePath = @"Resources\Hardware.csv";
            
            catalogService.ProcessAction(new ImportHardwareCommand(1, filePath));

            catalogReposityMock.Verify(x => x.Save(catalog));

            Assert.AreEqual(2, catalog.Hardwares.Count);
            Assert.AreEqual(2, catalog.Hardwares[0].Components.Count);
            Assert.AreEqual(4, catalog.Supplies.Count);

            eventBrokerMock.Verify(x => x.Publish(It.IsAny<HardwareCreatedEvent>()), Times.Exactly(2));
            eventBrokerMock.Verify(x => x.Publish(It.IsAny<SupplyCreatedEvent>()), Times.Exactly(4));
        }
    }
}
