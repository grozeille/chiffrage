﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
{
    public class ProjectSelectedEvent : IEvent
    {
        public int Id { get; private set; }

        public ProjectSelectedEvent(int id)
        {
            this.Id = id;
        }
    }
}