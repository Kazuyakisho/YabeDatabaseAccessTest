using BacnetLibrary.BACnetBase.BACnetEnum;
using BacnetLibrary.BACnetBase.BACnetStruct;
using System;
using System.Collections.Generic;

namespace BacnetLibrary.BACnetDeviceStorage
{
    [Serializable]
    public class Property
    {
        [System.Xml.Serialization.XmlIgnore]
        public BacnetPropertyIds Id { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute("Id")]
        public string IdText
        {
            get
            {
                return Id.ToString();
            }
            set
            {
                Id = (BacnetPropertyIds)Enum.Parse((typeof(BacnetPropertyIds)), value);
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public BacnetApplicationTags Tag { get; set; }

        [System.Xml.Serialization.XmlElement]
        public string[] Value { get; set; }

        public static BacnetValue DeserializeValue(string value, BacnetApplicationTags type)
        {
            switch (type)
            {
                case BacnetApplicationTags.BACNET_APPLICATION_TAG_NULL:
                    if (value == "")
                        return new BacnetValue(type, null); // Modif FC
                    else
                        return new BacnetValue(value);
                case BacnetApplicationTags.BACNET_APPLICATION_TAG_BOOLEAN:
                    return new BacnetValue(type, bool.Parse(value));
                case BacnetApplicationTags.BACNET_APPLICATION_TAG_UNSIGNED_INT:
                    return new BacnetValue(type, uint.Parse(value));
                case BacnetApplicationTags.BACNET_APPLICATION_TAG_SIGNED_INT:
                    return new BacnetValue(type, int.Parse(value));
                case BacnetApplicationTags.BACNET_APPLICATION_TAG_REAL:
                    return new BacnetValue(type, float.Parse(value, System.Globalization.CultureInfo.InvariantCulture));
                case BacnetApplicationTags.BACNET_APPLICATION_TAG_DOUBLE:
                    return new BacnetValue(type, double.Parse(value, System.Globalization.CultureInfo.InvariantCulture));
                case BacnetApplicationTags.BACNET_APPLICATION_TAG_OCTET_STRING:
                    try
                    {
                        return new BacnetValue(type, Convert.FromBase64String(value));
                    }
                    catch
                    {
                        return new BacnetValue(type, value);
                    }
                case BacnetApplicationTags.BACNET_APPLICATION_TAG_CONTEXT_SPECIFIC_DECODED:
                    try
                    {
                        return new BacnetValue(type, Convert.FromBase64String(value));
                    }
                    catch
                    {
                        return new BacnetValue(type, value);
                    }
                case BacnetApplicationTags.BACNET_APPLICATION_TAG_CHARACTER_STRING:
                    return new BacnetValue(type, value);
                case BacnetApplicationTags.BACNET_APPLICATION_TAG_BIT_STRING:
                    return new BacnetValue(type, BacnetBitString.Parse(value));
                case BacnetApplicationTags.BACNET_APPLICATION_TAG_ENUMERATED:
                    return new BacnetValue(type, uint.Parse(value));
                case BacnetApplicationTags.BACNET_APPLICATION_TAG_DATE:
                    return new BacnetValue(type, DateTime.Parse(value));
                case BacnetApplicationTags.BACNET_APPLICATION_TAG_TIME:
                    return new BacnetValue(type, DateTime.Parse(value));
                case BacnetApplicationTags.BACNET_APPLICATION_TAG_OBJECT_ID:
                    return new BacnetValue(type, BacnetObjectId.Parse(value));
                case BacnetApplicationTags.BACNET_APPLICATION_TAG_READ_ACCESS_SPECIFICATION:
                    return new BacnetValue(type, BacnetReadAccessSpecification.Parse(value));
                default:
                    return new BacnetValue(type, null);
            }
        }

        public static string SerializeValue(BacnetValue value, BacnetApplicationTags type)
        {
            switch (type)
            {
                case BacnetApplicationTags.BACNET_APPLICATION_TAG_NULL:
                    return value.ToString(); // Modif FC
                case BacnetApplicationTags.BACNET_APPLICATION_TAG_REAL:
                    return ((float)value.Value).ToString(System.Globalization.CultureInfo.InvariantCulture);
                case BacnetApplicationTags.BACNET_APPLICATION_TAG_DOUBLE:
                    return ((double)value.Value).ToString(System.Globalization.CultureInfo.InvariantCulture);
                case BacnetApplicationTags.BACNET_APPLICATION_TAG_OCTET_STRING:
                    return Convert.ToBase64String((byte[])value.Value);
                case BacnetApplicationTags.BACNET_APPLICATION_TAG_CONTEXT_SPECIFIC_DECODED:
                    {
                        if (value.Value is byte[])
                        {
                            return Convert.ToBase64String((byte[])value.Value);
                        }
                        else
                        {
                            string ret = "";
                            BacnetValue[] arr = (BacnetValue[])value.Value;
                            foreach (BacnetValue v in arr)
                            {
                                ret += ";" + SerializeValue(v, v.Tag);
                            }
                            return ret.Length > 0 ? ret.Substring(1) : "";
                        }
                    }
                default:
                    return value.Value.ToString();
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public IList<BacnetValue> BacnetValue
        {
            get
            {
                if (Value == null) return new BacnetValue[0];
                BacnetValue[] ret = new BacnetValue[Value.Length];
                for (int i = 0; i < ret.Length; i++)
                {
                    ret[i] = DeserializeValue(Value[i], Tag);
                }
                return ret;
            }
            set
            {
                //count
                int count = 0;
                foreach (BacnetValue v in value)
                    count++;

                string[] str_values = new string[count];
                count = 0;
                foreach (BacnetValue v in value)
                {
                    str_values[count] = SerializeValue(v, Tag);
                    count++;
                }
                Value = str_values;
            }
        }
    }
}
