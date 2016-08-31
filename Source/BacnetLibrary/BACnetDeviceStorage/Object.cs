using BacnetLibrary.BACnetBase.BACnetEnum;
using System;

namespace BacnetLibrary.BACnetDeviceStorage
{
    [Serializable]
    public class Object
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public BacnetObjectTypes Type { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint Instance { get; set; }

        public Property[] Properties { get; set; }

        public Object()
        {
            Properties = new Property[0];
        }
    }
}
