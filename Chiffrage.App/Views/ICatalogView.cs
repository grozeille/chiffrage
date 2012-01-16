﻿using Chiffrage.App.ViewModel;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Mvc.Views;
using System;

namespace Chiffrage.App.Views
{
    public interface ICatalogView : IView
    {
        void Display(CatalogViewModel viewModel);

        CatalogViewModel GetViewModel();

        void AddSupply(CatalogSupplyViewModel result);

        void UpdateSupply(CatalogSupplyViewModel result);

        void RemoveSupply(CatalogSupplyViewModel result);

        void AddHardware(CatalogHardwareViewModel result);

        void UpdateHardware(CatalogHardwareViewModel result);

        void RemoveHardware(CatalogHardwareViewModel result);

        void AddHardwareSupply(CatalogHardwareSupplyViewModel result);
    }
}