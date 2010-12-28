using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Chiffrage.App.Controllers;
using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using NUnit.Framework;
using Chiffrage.Catalogs.Domain;
using Rhino.Mocks;
using Chiffrage.Catalogs.Domain.Repositories;
using Rhino.Mocks.Constraints;

namespace Chiffrage.Tests
{
    [TestFixture]
    public class CatalogControllerTests
    {
        private SupplierCatalog catalog;
        private Hardware hardware;
        private Supply supply;
        private HardwareSupply hardwareSupply;

        [SetUp]
        public void Setup()
        {
            this.catalog = new SupplierCatalog()
                          {
                              Id = 3,
                              Comment = "no comment",
                              SupplierName = "Catalog"
                          };

            this.hardware = new Hardware
                           {
                               Id = 1,
                               Name = "Roullette de tape",
                               Category = "Fourniture",
                               Reference = "RDT"
                           };
            this.supply = new Supply
                         {
                             Id = 1,
                             Name = "Cable",
                             Reference = "CB1",
                             ModuleSize = 1,
                             Category = "Cables",
                             CatalogPrice = 100.0,
                             CatalogExecutiveWorkDays = 1,
                             CatalogTestsDays = 1,
                             CatalogWorkDays = 1,
                             ReferenceDays = 1,
                             StudyDays = 2
                         };
            this.hardwareSupply = new HardwareSupply
                                 {
                                     Id = 0,
                                     Quantity = 2,
                                     Supply = this.supply
                                 };
            this.hardware.Components.Add(this.hardwareSupply);

            this.catalog.Hardwares = new List<Hardware>();
            this.catalog.Hardwares.Add(this.hardware);
        }

        [Test]
        public void CanDisplayCatalog()
        {
            var catalogView = MockRepository.GenerateStub<ICatalogView>();
            var catalogRepository = MockRepository.GenerateStub<ICatalogRepository>();
            catalogRepository.Stub(x => x.FindById(3))
                .Return(this.catalog);

            var controller = new CatalogController(catalogView, catalogRepository);

            // load the catalog
            controller.DisplayCatalog(3);

            var expectedViewModel = new CatalogViewModel();
            expectedViewModel.Id = 3;
            expectedViewModel.Comment = "no comment";
            expectedViewModel.SupplierName = "Catalog";

            catalogRepository.AssertWasCalled(x => x.FindById(3));
            catalogView.AssertWasCalled(x => x.Display(Arg<CatalogViewModel>.Is.Equal(expectedViewModel)));

            // simulate a "save"
            expectedViewModel.Comment = "new comment";
            controller.SaveCatalog(expectedViewModel);

            catalogRepository.AssertWasCalled(x => x.Save(Arg<SupplierCatalog>.Matches(c => c.Comment.Equals("new comment"))));
        }
    }
}
