using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Appender;
using System.IO;
using System.Diagnostics;

namespace Chiffrage.Excel.Appender
{
    public class ExcelDnaAppender : AppenderSkeleton
    {
        protected override void Append(log4net.Core.LoggingEvent loggingEvent)
        {
            var stringBuilder = new StringBuilder();
            var stringWriter = new StringWriter(stringBuilder);
            this.Layout.Format(stringWriter, loggingEvent);
            if (loggingEvent.ExceptionObject != null)
            {
                stringBuilder.AppendLine(loggingEvent.ExceptionObject.ToString());
            }

            ExcelDna.Logging.LogDisplay.WriteLine(stringBuilder.ToString());
        }
    }
}
