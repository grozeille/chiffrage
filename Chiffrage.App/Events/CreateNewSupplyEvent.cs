﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.App.ViewModel;
using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
{
    public class CreateNewSupplyEvent : IEvent
    {
        private readonly CatalogSupplyViewModel viewModel;

        public CreateNewSupplyEvent(CatalogSupplyViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public CatalogSupplyViewModel ViewModel
        {
            get { return this.viewModel; }
        }
    }
}
