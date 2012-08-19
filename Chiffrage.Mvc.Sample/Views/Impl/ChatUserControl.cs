using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Mvc.Sample.Commands;

namespace Chiffrage.Mvc.Sample.Views.Impl
{
    public partial class ChatUserControl : UserControl, IChatView
    {
        public ChatUserControl()
        {
            InitializeComponent();
        }

        public event Action<MessageCommand> OnMessageCommand;

        public void AddMessage(DateTime date, string value)
        {
            this.textBoxChat.AppendText(string.Format("{0} - {1} {2}", date, value, Environment.NewLine));
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            OnMessageCommand(new MessageCommand { Value = this.textBoxMessage.Text });
        }


        public void DisplayError(string errorMessage)
        {
            this.textBoxChat.AppendText("ERROR: " + errorMessage + Environment.NewLine);
        }
    }
}
