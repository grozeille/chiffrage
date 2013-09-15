using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Mvc.Events
{
    public class Message
    {
        public object Body { get; set; }

        public string Topic { get; set; }

        public MessageAsyncResult AsyncResult { get; set; }

        public AsyncCallback AsyncCallback { get; set; }
    }
}
