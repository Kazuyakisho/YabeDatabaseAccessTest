using System;

namespace BacnetLibrary.BACnetBase.BACnetEnum
{
    [Flags]
    public enum BacnetResultFlags
    {
        NONE = 0,
        FIRST_ITEM = 1,
        LAST_ITEM = 2,
        MORE_ITEMS = 4
    }

    [Flags]
    public enum BacnetStatusFlags
    {

        STATUS_FLAG_IN_ALARM = 1,
        STATUS_FLAG_FAULT = 2,
        STATUS_FLAG_OVERRIDDEN = 4,
        STATUS_FLAG_OUT_OF_SERVICE = 8
    }

    [Flags]
    public enum BacnetPduTypes : byte
    {
        PDU_TYPE_CONFIRMED_SERVICE_REQUEST = 0,
        SERVER = 1,
        NEGATIVE_ACK = 2,
        SEGMENTED_RESPONSE_ACCEPTED = 2,
        MORE_FOLLOWS = 4,
        SEGMENTED_MESSAGE = 8,
        PDU_TYPE_UNCONFIRMED_SERVICE_REQUEST = 0x10,
        PDU_TYPE_SIMPLE_ACK = 0x20,
        PDU_TYPE_COMPLEX_ACK = 0x30,
        PDU_TYPE_SEGMENT_ACK = 0x40,
        PDU_TYPE_ERROR = 0x50,
        PDU_TYPE_REJECT = 0x60,
        PDU_TYPE_ABORT = 0x70,
        PDU_TYPE_MASK = 0xF0
    }

    [Flags]
    public enum BacnetNpduControls : byte
    {
        PriorityNormalMessage = 0,
        PriorityUrgentMessage = 1,
        PriorityCriticalMessage = 2,
        PriorityLifeSafetyMessage = 3,
        ExpectingReply = 4,
        SourceSpecified = 8,
        DestinationSpecified = 32,
        NetworkLayerMessage = 128,
    };

    [Flags]
    public enum EncodeResult
    {
        Good = 0,
        NotEnoughBuffer = 1,
    }
}
