using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Mvc.Events
{
    public static class Topics
    {
        public const string UI = "topic://UI";

        public const string EVENTS = "topic://events";

        public const string COMMANDS = "topic://commands";

        public const string DEFAULT = "topic://default";
    }
}
