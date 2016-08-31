using BacnetLibrary.BACnetUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BacnetLibrary.BACnetConverter
{
    public class DynamicEnumConverter : TypeConverter
    {
        // Fields
        private DynamicEnum m_e;

        public DynamicEnumConverter(DynamicEnum e)
        {
            m_e = e;
        }

        private static bool is_number(string str)
        {
            if (string.IsNullOrWhiteSpace(str) || str.Length == 0) return false;
            for (int i = 0; i < str.Length; i++)
                if (!char.IsNumber(str, i)) return false;
            return true;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string && value != null)
            {
                string str = (string)value;
                str = str.Trim();

                if (m_e.Contains(str)) return m_e[str];
                else if (is_number(str))
                {
                    int int_val;
                    if (str.StartsWith("0x", StringComparison.InvariantCultureIgnoreCase))
                        int_val = int.Parse(str.Substring(2), System.Globalization.NumberStyles.HexNumber);
                    else
                        int_val = int.Parse(str);
                    return int_val;
                }
                else
                {
                    return m_e[str];
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return true;
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return true;
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
                throw new ArgumentNullException("destinationType");

            if ((destinationType == typeof(string)) && (value != null))
            {
                if (value is string)
                {
                    return value;
                }
                else if (value is KeyValuePair<string, int>)
                    return ((KeyValuePair<string, int>)value).Key;

                int val = (int)Convert.ChangeType(value, typeof(int));
                return m_e[val];
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new TypeConverter.StandardValuesCollection(m_e);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return !m_e.IsFlag;
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool IsValid(ITypeDescriptorContext context, object value)
        {
            if (value is string) return m_e.Contains((string)value);

            int val = (int)Convert.ChangeType(value, typeof(int));
            return m_e.Contains(val);
        }
    }
}
