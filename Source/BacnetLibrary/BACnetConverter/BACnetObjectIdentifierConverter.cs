using System;
using System.ComponentModel;
using System.Globalization;
using BacnetLibrary.BACnetBase.BACnetEnum;
using BacnetLibrary.BACnetBase.BACnetStruct;

namespace BacnetLibrary.BACnetConverter
{
    public class BacnetObjectIdentifierConverter : ExpandableObjectConverter
    {

        public override bool CanConvertTo(ITypeDescriptorContext context,
                                  System.Type destinationType)
        {
            if (destinationType == typeof(BacnetObjectId))
                return true;
            return base.CanConvertTo(context, destinationType);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context,
                              System.Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        // Call to change the display
        public override object ConvertTo(ITypeDescriptorContext context,
                               CultureInfo culture,
                               object value,
                               System.Type destinationType)
        {
            if (destinationType == typeof(System.String) &&
                 value is BacnetObjectId)
            {

                BacnetObjectId objId = (BacnetObjectId)value;

                return objId.type +
                       ":" + objId.instance;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
                              CultureInfo culture, object value)
        {
            if (value is string)
            {
                try
                {
                    string[] s = (value as String).Split(':');
                    return new BacnetObjectId((BacnetObjectTypes)Enum.Parse(typeof(BacnetObjectTypes), s[0]), Convert.ToUInt16(s[1]));
                }
                catch { return null; }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}
