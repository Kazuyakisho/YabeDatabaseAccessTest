using System;
using System.ComponentModel;
using System.Globalization;
using BacnetLibrary.BACnetBase.BACnetStruct;

namespace BacnetLibrary.BACnetConverter
{
    public class BacnetBitStringConverter : TypeConverter
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
                    return BacnetBitString.Parse(value as String);
                }
                catch { return null; }
            }
            return base.ConvertFrom(context, culture, value);
        }

    }
}
