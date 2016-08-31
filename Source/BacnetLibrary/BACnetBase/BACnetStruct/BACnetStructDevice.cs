using BacnetLibrary.BACnetBase.BACnetEnum;
using BacnetLibrary.BACnetBase.BACnetSerialize;
using System;

namespace BacnetLibrary.BACnetBase.BACnetStruct
{
    public struct BacnetDeviceObjectPropertyReference : ASN1.IASN1encode
    {
        public BacnetObjectId objectIdentifier;
        public BacnetPropertyIds propertyIdentifier;
        public UInt32 arrayIndex;
        public BacnetObjectId deviceIndentifier;

        public BacnetDeviceObjectPropertyReference(BacnetObjectId objectIdentifier, BacnetPropertyIds propertyIdentifier, BacnetObjectId? deviceIndentifier = null, UInt32 arrayIndex = ASN1.BACNET_ARRAY_ALL)
        {
            this.objectIdentifier = objectIdentifier;
            this.propertyIdentifier = propertyIdentifier;
            this.arrayIndex = arrayIndex;
            if (deviceIndentifier != null)
                this.deviceIndentifier = deviceIndentifier.Value;
            else
                this.deviceIndentifier = new BacnetObjectId(BacnetObjectTypes.MAX_BACNET_OBJECT_TYPE, 0);

        }
        public void ASN1encode(EncodeBuffer buffer)
        {
            ASN1.bacapp_encode_device_obj_property_ref(buffer, this);
        }

        public BacnetObjectId ObjectId
        {
            get { return objectIdentifier; }
            set { objectIdentifier = value; }
        }
        public Int32 ArrayIndex // shows -1 when it's ASN1.BACNET_ARRAY_ALL
        {
            get
            {
                if (arrayIndex == ASN1.BACNET_ARRAY_ALL)
                    return -1;
                return (Int32)arrayIndex;
            }
            set
            {
                if (value < 0)
                    arrayIndex = ASN1.BACNET_ARRAY_ALL;
                else
                    arrayIndex = (UInt32)value;
            }
        }
        public BacnetObjectId? DeviceId  // shows null when it's not OBJECT_DEVICE
        {
            get
            {
                if (deviceIndentifier.type == BacnetObjectTypes.OBJECT_DEVICE)
                    return deviceIndentifier;
                return null;
            }
            set
            {
                if (value == null)
                    deviceIndentifier = new BacnetObjectId();
                else
                    deviceIndentifier = value.Value;
            }
        }
        public BacnetPropertyIds PropertyId
        {
            get { return propertyIdentifier; }
            set { propertyIdentifier = value; }
        }

    };

    public struct DeviceReportingRecipient : ASN1.IASN1encode
    {
        public BacnetBitString WeekofDay;
        public DateTime toTime, fromTime;

        public BacnetObjectId Id;
        public BacnetAddress adr;

        public uint processIdentifier;
        public bool Ack_Required;
        public BacnetBitString evenType;

        public DeviceReportingRecipient(BacnetValue v0, BacnetValue v1, BacnetValue v2, BacnetValue v3, BacnetValue v4, BacnetValue v5, BacnetValue v6)
        {
            Id = new BacnetObjectId();
            adr = null;

            WeekofDay = (BacnetBitString)v0.Value;
            fromTime = (DateTime)v1.Value;
            toTime = (DateTime)v2.Value;
            if (v3.Value is BacnetObjectId)
                Id = (BacnetObjectId)v3.Value;
            else
            {
                BacnetValue[] netdescr = (BacnetValue[])v3.Value;
                ushort s = (ushort)(uint)netdescr[0].Value;
                byte[] b = (byte[])netdescr[1].Value;
                adr = new BacnetAddress(BacnetAddressTypes.IP, s, b);
            }
            processIdentifier = (uint)v4.Value;
            Ack_Required = (bool)v5.Value;
            evenType = (BacnetBitString)v6.Value;
        }

        public DeviceReportingRecipient(BacnetBitString WeekofDay, DateTime fromTime, DateTime toTime, BacnetObjectId Id, uint processIdentifier, bool Ack_Required, BacnetBitString evenType)
        {
            adr = null;

            this.WeekofDay = WeekofDay;
            this.toTime = toTime;
            this.fromTime = fromTime;
            this.Id = Id;
            this.processIdentifier = processIdentifier;
            this.Ack_Required = Ack_Required;
            this.evenType = evenType;
        }
        public DeviceReportingRecipient(BacnetBitString WeekofDay, DateTime fromTime, DateTime toTime, BacnetAddress adr, uint processIdentifier, bool Ack_Required, BacnetBitString evenType)
        {
            Id = new BacnetObjectId();

            this.WeekofDay = WeekofDay;
            this.toTime = toTime;
            this.fromTime = fromTime;
            this.adr = adr;
            this.processIdentifier = processIdentifier;
            this.Ack_Required = Ack_Required;
            this.evenType = evenType;
        }

        public void ASN1encode(EncodeBuffer buffer)
        {
            ASN1.bacapp_encode_application_data(buffer, new BacnetValue(WeekofDay));
            ASN1.bacapp_encode_application_data(buffer, new BacnetValue(BacnetApplicationTags.BACNET_APPLICATION_TAG_TIME, fromTime));
            ASN1.bacapp_encode_application_data(buffer, new BacnetValue(BacnetApplicationTags.BACNET_APPLICATION_TAG_TIME, toTime));
            if (adr != null)
                adr.ASN1encode(buffer);
            else
                ASN1.encode_context_object_id(buffer, 0, Id.type, Id.instance);         // BacnetObjectId is context specific encoded
            ASN1.bacapp_encode_application_data(buffer, new BacnetValue(processIdentifier));
            ASN1.bacapp_encode_application_data(buffer, new BacnetValue(Ack_Required));
            ASN1.bacapp_encode_application_data(buffer, new BacnetValue(evenType));
        }
    }
}
