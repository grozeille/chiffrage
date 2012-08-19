using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Sample.Events;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Sample.Views;
using Chiffrage.Mvc.Sample.Commands;

namespace Chiffrage.Mvc.Sample.Controllers
{
    public class Controller:
        IGenericEventHandlerUI<MessageReceivedEvent>
    {
        public EventBroker EventBroker { get; set; }

        private IChatView chatView;

        public IChatView ChatView
        {
            get { return this.chatView; }
            set
            {
                this.chatView = value;
                this.chatView.OnMessageCommand += this.OnMessageCommand;
            }
        }

        public void OnMessageCommand(MessageCommand command)
        {
            if (command.Value.Length < 10)
            {
                EventBroker.Publish(command);
            }
            else
            {
                this.chatView.DisplayError("Message length >= 10: " + command.Value.Length);
            }
        }

        public void ProcessAction(MessageReceivedEvent eventObject)
        {
            this.chatView.AddMessage(eventObject.Date, eventObject.Value);
        }
    }
}
