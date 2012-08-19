using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Sample.Commands;

namespace Chiffrage.Mvc.Sample.Views
{
    public interface IChatView
    {
        void AddMessage(DateTime date, string value);

        event Action<MessageCommand> OnMessageCommand;

        void DisplayError(string errorMessage);
    }
}
