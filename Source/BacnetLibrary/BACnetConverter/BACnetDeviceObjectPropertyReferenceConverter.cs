using System;
using System.ComponentModel;
using System.Globalization;
using BacnetLibrary.BACnetBase.BACnetEnum;
using BacnetLibrary.BACnetBase.BACnetStruct;

namespace BacnetLibrary.BACnetConverter
{
    public class BACnetDeviceObjectPropertyReferenceConverter : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context,
                            System.Type destinationType)
        {
            if (destinationType == typeof(BacnetDeviceObjectPropertyReference))
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

        public override object ConvertTo(ITypeDescriptorContext context,
                        CultureInfo culture,
                        object value,
                        System.Type destinationType)
        {

            if (destinationType == typeof(System.String) &&
                 value is BacnetDeviceObjectPropertyReference)
            {
                BacnetDeviceObjectPropertyReference pr = (BacnetDeviceObjectPropertyReference)value;

                return "Reference to " + pr.objectIdentifier.ToString();
            }
            else
                return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
                      CultureInfo culture, object value)
        {
            if (value is string)
            {
                try
                {
                    // A realy hidden service !!!
                    // and remember that PRESENT_VALUE = 85
                    // entry like OBJECT_ANALOG_INPUT:0:85
                    //
                    string[] s = (value as String).Split(':');
                    return new BacnetDeviceObjectPropertyReference(
                            new BacnetObjectId((BacnetObjectTypes)Enum.Parse(typeof(BacnetObjectTypes), s[0]), Convert.ToUInt16(s[1])),
                            (BacnetPropertyIds)Convert.ToUInt16(s[2])
                    );
                }
                catch { return null; }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}
