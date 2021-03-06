﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.EventStore
{
    public class EventObject
    {
        public virtual long Id { get; set; }

        public virtual string MessageType { get; set; }

        public virtual byte[] MessageBody { get; set; }

        public virtual DateTime Time { get; set; }

        public virtual string SessionId{ get; set; }

        public EventObject()
        {
            this.Time = DateTime.Now;
        }
    }
}
