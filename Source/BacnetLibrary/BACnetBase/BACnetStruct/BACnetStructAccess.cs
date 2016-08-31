using BacnetLibrary.BACnetBase.BACnetEnum;
using System;
using System.Collections.Generic;

namespace BacnetLibrary.BACnetBase.BACnetStruct
{
    public struct BacnetReadAccessSpecification
    {
        public BacnetObjectId objectIdentifier;
        public IList<BacnetPropertyReference> propertyReferences;
        public BacnetReadAccessSpecification(BacnetObjectId objectIdentifier, IList<BacnetPropertyReference> propertyReferences)
        {
            this.objectIdentifier = objectIdentifier;
            this.propertyReferences = propertyReferences;
        }
        public static object Parse(string value)
        {
            BacnetReadAccessSpecification ret = new BacnetReadAccessSpecification();
            if (string.IsNullOrEmpty(value)) return ret;
            string[] tmp = value.Split(':');
            if (tmp == null || tmp.Length < 2) return ret;
            ret.objectIdentifier.type = (BacnetObjectTypes)Enum.Parse(typeof(BacnetObjectTypes), tmp[0]);
            ret.objectIdentifier.instance = uint.Parse(tmp[1]);
            List<BacnetPropertyReference> refs = new List<BacnetPropertyReference>();
            for (int i = 2; i < tmp.Length; i++)
            {
                BacnetPropertyReference n = new BacnetPropertyReference();
                n.propertyArrayIndex = BACnetSerialize.ASN1.BACNET_ARRAY_ALL;
                n.propertyIdentifier = (uint)(BacnetPropertyIds)Enum.Parse(typeof(BacnetPropertyIds), tmp[i]);
                refs.Add(n);
            }
            ret.propertyReferences = refs;
            return ret;
        }
        public override string ToString()
        {
            string ret = objectIdentifier.ToString();
            foreach (BacnetPropertyReference r in propertyReferences)
            {
                ret += ":" + ((BacnetPropertyIds)r.propertyIdentifier);
            }
            return ret;
        }
    }

    public struct BacnetReadAccessResult
    {
        public BacnetObjectId objectIdentifier;
        public IList<BacnetPropertyValue> values;
        public BacnetReadAccessResult(BacnetObjectId objectIdentifier, IList<BacnetPropertyValue> values)
        {
            this.objectIdentifier = objectIdentifier;
            this.values = values;
        }
    }
}
