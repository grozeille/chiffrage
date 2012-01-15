﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.App.ViewModel;
using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
{
    public class CreateNewHardwareEvent : IEvent
    {
        private readonly CatalogHardwareViewModel viewModel;

        public CreateNewHardwareEvent(CatalogHardwareViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public CatalogHardwareViewModel ViewModel
        {
            get { return this.viewModel; }
        }
    }
}