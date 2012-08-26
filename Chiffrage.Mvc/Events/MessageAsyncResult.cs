using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Chiffrage.Mvc.Events
{
    public class MessageAsyncResult : IAsyncResult
    {
        public MessageAsyncResult()
        {
            this.ManualResetEvent = new ManualResetEvent(false);
        }

        public object AsyncState
        {
            get { return null; }
        }

        public WaitHandle AsyncWaitHandle
        {
            get { return this.ManualResetEvent; }
        }

        public bool CompletedSynchronously
        {
            get { return false; }
        }

        public bool IsCompleted
        {
            get { return ManualResetEvent.WaitOne(0); }
        }

        public ManualResetEvent ManualResetEvent { get; private set; }
    }
}
