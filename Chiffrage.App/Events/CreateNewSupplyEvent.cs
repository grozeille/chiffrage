using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.App.ViewModel;
using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
{
    public class CreateNewSupplyEvent : IEvent
    {
        private readonly int catalogId;

        private readonly CatalogSupplyViewModel viewModel;

        public CreateNewSupplyEvent(int catalogId, CatalogSupplyViewModel viewModel)
        {
            this.catalogId = catalogId;
            this.viewModel = viewModel;
        }

        public CatalogSupplyViewModel ViewModel
        {
            get { return this.viewModel; }
        }

        public int CatalogId
        {
            get { return this.catalogId; }
        }
    }
}
