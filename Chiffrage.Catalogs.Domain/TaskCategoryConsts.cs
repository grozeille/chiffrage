using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.Catalogs.Domain
{
    public static class TaskCategoryConsts
    {
        public const String STUDY = "Etudes";

        public const String WORK = "Travaux";

        public const String TEST = "Essais";

        public static String ToString(TaskCategory taskCategory)
        {
            switch (taskCategory)
            {
                case TaskCategory.STUDY:
                    return STUDY;
                case TaskCategory.WORK:
                    return WORK;
                case TaskCategory.TEST:
                    return TEST;
                default:
                    throw new ArgumentOutOfRangeException("taskCategory");
            }
        }

        public static TaskCategory ParseString(String taskCategory)
        {
            switch (taskCategory)
            {
                case STUDY:
                    return TaskCategory.STUDY;
                case WORK:
                    return TaskCategory.WORK;
                case TEST:
                    return TaskCategory.TEST;
                default:
                    throw new ArgumentOutOfRangeException("taskCategory");
            }
        }
    }
}
