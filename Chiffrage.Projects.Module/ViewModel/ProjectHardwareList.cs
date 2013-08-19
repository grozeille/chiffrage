using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Mvc;
using System.Windows.Forms;
using Chiffrage.Projects.Domain;

namespace Chiffrage.Projects.Module.ViewModel
{
    public class ProjectHardwareList : SortableBindingList<ProjectHardwareViewModel>, ITypedList
    {
        public IList<ProjectTask> ProjectTasks { get; set; }

        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            PropertyDescriptorCollection origProps;

            if (listAccessors != null && listAccessors.Length > 0)
            {
                // Return child list shape.
                origProps = ListBindingHelper.GetListItemProperties(listAccessors[0].PropertyType);
            }
            else
            {
                // Return properties in sort order.
                origProps = TypeDescriptor.GetProperties(typeof(ProjectHardwareViewModel));
            }

            List<PropertyDescriptor> newProps = new List<PropertyDescriptor>(origProps.Count);
            foreach (PropertyDescriptor prop in origProps)
            {

                if (prop.Name != "Tasks")
                {
                    newProps.Add(prop);
                }
            }

            if (this.ProjectTasks != null)
            {
                foreach (var item in this.ProjectTasks)
                {
                    newProps.Add(new ProjectHardwareListItemDescriptor(item.Id));
                }
            }

            return new PropertyDescriptorCollection(newProps.ToArray());
        }

        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return "";
        }

        private class ProjectHardwareListItemDescriptor : PropertyDescriptor
        {
            private static readonly Attribute[] nix = new Attribute[0];
            private readonly int taskId;

            public ProjectHardwareListItemDescriptor(int taskId)
                : base("Tasks[" + taskId + "]", nix)
            {
                this.taskId = taskId;
            }

            public override object GetValue(object component)
            {
                var hardware = (ProjectHardwareViewModel)component;
                var item = hardware.Tasks.Where(x => x.Id == this.taskId).FirstOrDefault();
                if (item != null)
                {
                    string taskType = "";
                    switch (item.HardwareTaskType)
                    {
                        case ProjectHardwareTaskType.DAY:
                            taskType = "h (J)";
                            break;
                        case ProjectHardwareTaskType.SHORT_NIGHT:
                            taskType = "h (NC)";
                            break;
                        case ProjectHardwareTaskType.LONG_NIGHT:
                            taskType = "h (NL)";
                            break;
                        default:
                            break;
                    }
                    return item.Value +" "+taskType;
                }

                return "";
            }

            public override Type PropertyType
            {
                get { return typeof(double); }
            }

            public override bool IsReadOnly
            {
                get { return true; }
            }

            public override void SetValue(object component, object value)
            {
                throw new NotSupportedException();
            }

            public override void ResetValue(object component)
            {
                throw new NotSupportedException();
            }

            public override bool CanResetValue(object component)
            {
                return false;
            }

            public override Type ComponentType
            {
                get { return typeof(IList<ProjectHardwareTask>); }
            }

            public override bool ShouldSerializeValue(object component)
            {
                return false;
            }
        }
    }
}
