using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections;

namespace Chiffrage.Mvc
{
    public class ListItemDescriptor : PropertyDescriptor
    {
        private static readonly Attribute[] nix = new Attribute[0];
        private readonly PropertyDescriptor tail;
        private readonly Type type;
        private readonly int index;

        public ListItemDescriptor(PropertyDescriptor tail, int index, Type type)
            : base(tail.Name + "[" + index + "]", nix)
        {
            this.tail = tail;
            this.type = type;
            this.index = index;
        }

        public override object GetValue(object component)
        {
            IList list = tail.GetValue(component) as IList;
            return (list == null || list.Count <= index) ? null : list[index];
        }

        public override Type PropertyType
        {
            get { return type; }
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
            get { return tail.ComponentType; }
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
}
