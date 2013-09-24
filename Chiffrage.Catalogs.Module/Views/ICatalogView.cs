using Chiffrage.Catalogs.Module.ViewModel;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Mvc.Views;
using System;
using System.Collections.Generic;

namespace Chiffrage.Catalogs.Module.Views
{
    public interface ICatalogView : IView
    {
        void Display(CatalogViewModel viewModel, IList<Task> tasks);

        CatalogViewModel GetViewModel();

        void AddSupply(CatalogSupplyViewModel result);

        void AddSupplies(IList<CatalogSupplyViewModel> result);

        void UpdateSupply(CatalogSupplyViewModel result);

        void RemoveSupply(int supplyId);

        void AddHardware(CatalogHardwareViewModel result);

        void AddHardwares(IList<CatalogHardwareViewModel> result);

        void UpdateHardware(CatalogHardwareViewModel result);

        void RemoveHardware(int hardwareId);

        void AddHardwareSupply(CatalogHardwareSupplyViewModel result);

        void RemoveSupplies();

        void RemoveAllHardwares();

        void UpdateHardwares(IList<CatalogHardwareViewModel> result);
    }
}