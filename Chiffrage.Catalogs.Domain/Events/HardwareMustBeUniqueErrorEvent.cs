﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.Catalogs.Domain.Events
{
    public class HardwareMustBeUniqueErrorEvent
    {
        private readonly int catalogId;
        private readonly int hardwareId;

        public HardwareMustBeUniqueErrorEvent(int catalogId, int hardwareId)
        {
            this.catalogId = catalogId;
            this.hardwareId = hardwareId;
        }

        public int HardwareId
        {
            get { return this.hardwareId; }
        }

        public int CatalogId
        {
            get { return this.catalogId; }
        }
    }
}
