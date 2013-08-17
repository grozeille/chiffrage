using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Projects.Domain;

namespace Chiffrage.Projects.Module.ViewModel
{
    public static class ProjectHardwareTaskTypeConsts
    {
        public const String DAY = "Jour";

        public const String NIGHT = "Nuit";

        public const String LONG_NIGHT = "Nuit longue";

        public const String SHORT_NIGHT = "Nuit courte";

        public static String ToString(ProjectHardwareTaskType taskType)
        {
            switch (taskType)
            {
                case ProjectHardwareTaskType.DAY:
                    return DAY;
                case ProjectHardwareTaskType.NIGHT:
                    return NIGHT;
                case ProjectHardwareTaskType.SHORT_NIGHT:
                    return SHORT_NIGHT;
                case ProjectHardwareTaskType.LONG_NIGHT:
                    return LONG_NIGHT;
                default:
                    return null;
            }
        }

        public static ProjectHardwareTaskType ParseString(String taskTypeString)
        {
            switch (taskTypeString)
            {
                case DAY:
                    return ProjectHardwareTaskType.DAY;
                case NIGHT:
                    return ProjectHardwareTaskType.NIGHT;
                case SHORT_NIGHT:
                    return ProjectHardwareTaskType.SHORT_NIGHT;
                case LONG_NIGHT:
                    return ProjectHardwareTaskType.LONG_NIGHT;
                default:
                    return ProjectHardwareTaskType.DAY;
            }
        }
    }
}
