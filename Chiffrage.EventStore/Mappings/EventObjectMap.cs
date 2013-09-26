using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Chiffrage.EventStore.Mappings
{
    public class EventObjectMap : ClassMapping<EventObject>
    {
        public EventObjectMap()
        {
            Id(x => x.Id, y =>
                              {
                                  y.Generator(Generators.Identity);
                              });
            Property(x => x.MessageType);
            Property(x => x.MessageBody);
            Property(x => x.Time);
            Property(x => x.SessionId);
        }
    }
}
