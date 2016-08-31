using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BacnetLibrary.BACnetUtilities;

namespace BacnetLibrary.BACnetConverter
{
    public class BacnetEnumValueConverter : TypeConverter
    {
        Enum currentPropertyEnum;

        // the corresponding Enum is given in parameter
        public BacnetEnumValueConverter(Enum e)
        {
            currentPropertyEnum = e;
        }

        public override object ConvertTo(ITypeDescriptorContext context,
                        CultureInfo culture,
                        object value,
                        System.Type destinationType)
        {
            if (destinationType == typeof(System.String) &&
                value is uint)
            {
                int i = (int)(uint)value;
                return i.ToString() + " : " + BacnetEnumValueDisplay.GetNiceName(Enum.GetName(currentPropertyEnum.GetType(), (uint)i));
            }
            else
                return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
