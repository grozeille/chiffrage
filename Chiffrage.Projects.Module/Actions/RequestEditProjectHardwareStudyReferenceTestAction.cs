using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Projects.Module.ViewModel;

namespace Chiffrage.Projects.Module.Actions
{
    public class RequestEditProjectHardwareStudyReferenceTestAction
    {
        private readonly ProjectHardwareStudyReferenceTestViewModel hardware;

        public RequestEditProjectHardwareStudyReferenceTestAction(ProjectHardwareStudyReferenceTestViewModel hardware)
        {
            this.hardware = hardware;
        }

        public ProjectHardwareStudyReferenceTestViewModel Hardware
        {
            get { return this.hardware; }
        }
    }
}
