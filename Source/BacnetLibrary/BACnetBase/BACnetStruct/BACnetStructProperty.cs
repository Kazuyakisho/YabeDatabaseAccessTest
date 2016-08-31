using BacnetLibrary.BACnetBase.BACnetEnum;
using System;
using System.Collections.Generic;

namespace BacnetLibrary.BACnetBase.BACnetStruct
{
    public struct BacnetPropetyState
    {
        public enum BacnetPropertyStateTypes
        {
            BOOLEAN_VALUE,
            BINARY_VALUE,
            EVENT_TYPE,
            POLARITY,
            PROGRAM_CHANGE,
            PROGRAM_STATE,
            REASON_FOR_HALT,
            RELIABILITY,
            STATE,
            SYSTEM_STATUS,
            UNITS,
            UNSIGNED_VALUE,
            LIFE_SAFETY_MODE,
            LIFE_SAFETY_STATE
        };

        public BacnetPropertyStateTypes tag;
        public uint state;
    }

    public struct BacnetPropertyReference
    {
        public UInt32 propertyIdentifier;
        public UInt32 propertyArrayIndex;        /* optional */
        public BacnetPropertyReference(uint id, uint array_index)
        {
            propertyIdentifier = id;
            propertyArrayIndex = array_index;
        }
        public override string ToString()
        {
            return ((BacnetPropertyIds)propertyIdentifier).ToString();
        }
    };

    public struct BacnetPropertyValue
    {
        public BacnetPropertyReference property;
        public IList<BacnetValue> value;
        public byte priority;

        public override string ToString()
        {
            return property.ToString();
        }
    }

}
