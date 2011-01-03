using Chiffrage.App.Controllers;
using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Catalogs.Domain.Repositories;
using Chiffrage.Projects.Domain;
using Chiffrage.Projects.Domain.Repositories;
using NUnit.Framework;
using Rhino.Mocks;

namespace Chiffrage.Tests
{
    [TestFixture]
    public class ApplicationControllerTests
    {
        #region Setup/Teardown

        [SetUp]
        public void Setup()
        {
            this.catalogs = new SupplierCatalog[]
            {
                new SupplierCatalog
                {
                    Id = 1,
                    SupplierName = "Catalog",
                    Comment = "catalog comment"
                }
            };

            this.deals = new Deal[]
            {
                new Deal
                {
                    Id = 1,
                    Name = "Deal",
                    Comment = "no comment",
                    Projects = new Project[]
                    {
                        new Project
                        {
                            Id = 1,
                            Name = "My Project",
                            Comment = "my project"
                        }
                    }
                }
            };
        }

        #endregion

        private SupplierCatalog[] catalogs;

        private Deal[] deals;

        [Test]
        public void CanDisplayItems()
        {
            var catalogRepository = MockRepository.GenerateStub<ICatalogRepository>();
            catalogRepository.Stub(x => x.FindAll())
                .Return(this.catalogs);

            var dealRepository = MockRepository.GenerateStub<IDealRepository>();
            dealRepository.Stub(x => x.FindAll())
                .Return(this.deals);

            var applicationView = MockRepository.GenerateStub<IApplicationView>();

            var catalogController = MockRepository.GenerateStub<ICatalogController>();

            var controller = new ApplicationController(catalogRepository, dealRepository, applicationView,
                                                       catalogController);

            // display all items
            controller.Display();

            catalogRepository.AssertWasCalled(x => x.FindAll());

            dealRepository.AssertWasCalled(x => x.FindAll());

            var expectedApplicationItem = new ApplicationItemViewModel
            {
                Catalogs = new CatalogItemViewModel[]
                {
                    new CatalogItemViewModel
                    {
                        Id = 1,
                        SupplierName = "Catalog"
                    }
                },
                Deals = new DealItemViewModel[]
                {
                    new DealItemViewModel
                    {
                        Id = 1,
                        Name = "Deal",
                        Projects = new ProjectItemViewModel[]
                        {
                            new ProjectItemViewModel
                            {
                                Id = 1,
                                Name = "My Project"
                            }
                        }
                    }
                }
            };

            applicationView.AssertWasCalled(x => x.Display(expectedApplicationItem));

            // the user want to display a catalog
            controller.DisplayCatalog(1);

            catalogController.AssertWasCalled(x => x.DisplayCatalog(1));
        }
    }
}