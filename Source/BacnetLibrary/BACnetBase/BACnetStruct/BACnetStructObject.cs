using BacnetLibrary.BACnetBase.BACnetEnum;
using System;
using System.Collections.Generic;

namespace BacnetLibrary.BACnetBase.BACnetStruct
{
    public struct BacnetObjectDescription
    {
        public BacnetObjectTypes typeId;
        public List<BacnetPropertyIds> propsId;
    }

    [Serializable]
    public struct BacnetObjectId : IComparable<BacnetObjectId>
    {
        public BacnetObjectTypes type;
        public UInt32 instance;
        public BacnetObjectId(BacnetObjectTypes type, UInt32 instance)
        {
            this.type = type;
            this.instance = instance;
        }
        public BacnetObjectTypes Type
        {
            get { return type; }
            set { type = value; }
        }
        public UInt32 Instance
        {
            get { return instance; }
            set { instance = value; }
        }
        public override string ToString()
        {
            return type + ":" + instance;
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return obj.ToString().Equals(ToString());
        }

        public int CompareTo(BacnetObjectId other)
        {
            if (type == BacnetObjectTypes.OBJECT_DEVICE) return -1;
            if (other.type == BacnetObjectTypes.OBJECT_DEVICE) return 1;

            if (type == other.type)
                return instance.CompareTo(other.instance);
            return ((int)(type)).CompareTo((int)other.type);
        }
        public static BacnetObjectId Parse(string value)
        {
            BacnetObjectId ret = new BacnetObjectId();
            if (string.IsNullOrEmpty(value)) return ret;
            int p = value.IndexOf(":");
            if (p < 0) return ret;
            string str_type = value.Substring(0, p);
            string str_instance = value.Substring(p + 1);
            ret.type = (BacnetObjectTypes)Enum.Parse(typeof(BacnetObjectTypes), str_type);
            ret.instance = uint.Parse(str_instance);
            return ret;
        }

    };
}
