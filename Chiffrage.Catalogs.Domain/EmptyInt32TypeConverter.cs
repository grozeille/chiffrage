using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Chiffrage.Catalogs.Domain
{
    public class EmptyInt32TypeConverter : Int32Converter 
    {
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string && string.IsNullOrEmpty((string)value))
            {
                return 0;
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}
