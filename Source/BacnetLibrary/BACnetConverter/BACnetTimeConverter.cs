using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacnetLibrary.BACnetConverter
{
    public class BacnetTimeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context,
                      System.Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
              CultureInfo culture, object value)
        {
            if (value is string)
            {
                try
                {
                    return DateTime.Parse("1/1/1 " + (string)value, System.Threading.Thread.CurrentThread.CurrentCulture);
                }
                catch { return null; }
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context,
                           System.Type destinationType)
        {
            if (destinationType == typeof(DateTime))
                return true;
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context,
                        CultureInfo culture,
                        object value,
                        System.Type destinationType)
        {
            if (destinationType == typeof(System.String) &&
                value is DateTime)
            {
                DateTime dt = (DateTime)value;

                return dt.ToLongTimeString();
            }
            else
                return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
