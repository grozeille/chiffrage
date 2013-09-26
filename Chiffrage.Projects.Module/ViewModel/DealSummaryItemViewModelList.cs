using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Mvc;
using Chiffrage.Projects.Domain;

namespace Chiffrage.Projects.Module.ViewModel
{
    public class DealSummaryItemViewModelList: SortableBindingList<DealSummaryItemViewModel>, ITypedList
    {
        public IEnumerable<Project> Projects { get; set; }

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
                origProps = TypeDescriptor.GetProperties(typeof(DealSummaryItemViewModel));
            }

            List<PropertyDescriptor> newProps = new List<PropertyDescriptor>(origProps.Count);
            foreach (PropertyDescriptor prop in origProps)
            {

                if (prop.Name != "ProjectItems")
                {
                    newProps.Add(prop);
                }
            }

            if (this.Projects != null)
            {
                foreach (var item in this.Projects)
                {
                    newProps.Add(new DealSummaryItemViewModelListItemDescriptor(item.Id));
                }

                newProps.Add(new DealTotalItemViewModelListItemDescriptor());
            }

            return new PropertyDescriptorCollection(newProps.ToArray());
        }

        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return "";
        }

        private class DealSummaryItemViewModelListItemDescriptor : PropertyDescriptor
        {
            private static readonly Attribute[] nix = new Attribute[0];
            private readonly int projectId;

            public DealSummaryItemViewModelListItemDescriptor(int projectId)
                : base("ProjectItems[" + projectId + "]", nix)
            {
                this.projectId = projectId;
            }

            public override object GetValue(object component)
            {
                var dealItem = (DealSummaryItemViewModel)component;
                var item = dealItem.ProjectItems.Where(x => x.ProjectId == this.projectId).FirstOrDefault();
                if (item != null)
                {
                    return item.Quantity;
                }

                return 0;
            }

            public override Type PropertyType
            {
                get { return typeof(int); }
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
                get { return typeof(IList<DealSummaryProjectItemViewModel>); }
            }

            public override bool ShouldSerializeValue(object component)
            {
                return false;
            }
        }

        private class DealTotalItemViewModelListItemDescriptor : PropertyDescriptor
        {
            private static readonly Attribute[] nix = new Attribute[0];
            
            public DealTotalItemViewModelListItemDescriptor()
                : base("TOTAL", nix)
            {
            }

            public override object GetValue(object component)
            {
                var dealItem = (DealSummaryItemViewModel)component;

                return dealItem.ProjectItems.Sum(x => x.Quantity);
            }

            public override Type PropertyType
            {
                get { return typeof(int); }
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
                get { return typeof(IList<DealTotalItemViewModelListItemDescriptor>); }
            }

            public override bool ShouldSerializeValue(object component)
            {
                return false;
            }
        }
    }
}
