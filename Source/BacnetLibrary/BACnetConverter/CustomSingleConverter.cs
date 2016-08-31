using System;
using System.ComponentModel;

namespace BacnetLibrary.BACnetConverter
{
    public class CustomSingleConverter : SingleConverter
    {
        public static bool DontDisplayExactFloats { get; set; }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if ((destinationType == typeof(string)) && (value.GetType() == typeof(float)) && !DontDisplayExactFloats)
            {
                return DoubleConverter.ToExactString((double)(float)value);
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

    }
}
