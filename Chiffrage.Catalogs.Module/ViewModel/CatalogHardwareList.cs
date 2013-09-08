using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Mvc;
using System.Windows.Forms;
using Chiffrage.Catalogs.Module.ViewModel;

namespace Chiffrage.Catalogs.Module.ViewModel
{
    public class CatalogHardwareList : SortableBindingList<CatalogHardwareViewModel>, ITypedList
    {
        public IList<Task> CatalogTasks { get; set; }

        public CatalogHardwareList():base()
        {
            
        }

        public CatalogHardwareList(IEnumerable<CatalogHardwareViewModel> enumeration)
            : base(enumeration)
        {
            
        }

        public CatalogHardwareList(IEnumerable<CatalogHardwareViewModel> enumeration, CatalogHardwareList original)
            : base(enumeration, original)
        {
            this.CatalogTasks = original.CatalogTasks;
        }

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
                origProps = TypeDescriptor.GetProperties(typeof(CatalogHardwareViewModel));
            }

            List<PropertyDescriptor> newProps = new List<PropertyDescriptor>(origProps.Count);
            foreach (PropertyDescriptor prop in origProps)
            {

                if (prop.Name != "Tasks")
                {
                    newProps.Add(prop);
                }
            }

            if (this.CatalogTasks != null)
            {
                foreach (var item in this.CatalogTasks)
                {
                    newProps.Add(new CatalogHardwareListItemDescriptor(item.Id));
                }
            }

            return new PropertyDescriptorCollection(newProps.ToArray());
        }

        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return "";
        }

        private class CatalogHardwareListItemDescriptor : PropertyDescriptor
        {
            private static readonly Attribute[] nix = new Attribute[0];
            private readonly int taskId;

            public CatalogHardwareListItemDescriptor(int taskId)
                : base("Tasks[" + taskId + "]", nix)
            {
                this.taskId = taskId;
            }

            public override object GetValue(object component)
            {
                var hardware = (CatalogHardwareViewModel)component;
                var item = hardware.Tasks.Where(x => x.Task.Id == this.taskId).FirstOrDefault();
                if (item != null)
                {   
                    return item.Value;
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
                get { return typeof(IList<HardwareTask>); }
            }

            public override bool ShouldSerializeValue(object component)
            {
                return false;
            }
        }
    }
}
