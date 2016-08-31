namespace BacnetLibrary.BACnetBase.BACnetEnum
{
    public enum BacnetMstpFrameTypes : byte
    {
        /* Frame Types 8 through 127 are reserved by ASHRAE. */
        FRAME_TYPE_TOKEN = 0,
        FRAME_TYPE_POLL_FOR_MASTER = 1,
        FRAME_TYPE_REPLY_TO_POLL_FOR_MASTER = 2,
        FRAME_TYPE_TEST_REQUEST = 3,
        FRAME_TYPE_TEST_RESPONSE = 4,
        FRAME_TYPE_BACNET_DATA_EXPECTING_REPLY = 5,
        FRAME_TYPE_BACNET_DATA_NOT_EXPECTING_REPLY = 6,
        FRAME_TYPE_REPLY_POSTPONED = 7,
        /* Frame Types 128 through 255: Proprietary Frames */
        /* These frames are available to vendors as proprietary (non-BACnet) frames. */
        /* The first two octets of the Data field shall specify the unique vendor */
        /* identification code, most significant octet first, for the type of */
        /* vendor-proprietary frame to be conveyed. The length of the data portion */
        /* of a Proprietary frame shall be in the range of 2 to 501 octets. */
        FRAME_TYPE_PROPRIETARY_MIN = 128,
        FRAME_TYPE_PROPRIETARY_MAX = 255,
    }
    public enum BacnetNodeTypes
    {
        NT_UNKNOWN,
        NT_SYSTEM,
        NT_NETWORK,
        NT_DEVICE,
        NT_ORGANIZATIONAL,
        NT_AREA,
        NT_EQUIPMENT,
        NT_POINT,
        NT_COLLECTION,
        NT_PROPERTY,
        NT_FUNCTIONAL,
        NT_OTHER,
    }
    /*Network Layer Message Type */
    /*If Bit 7 of the control octet described in 6.2.2 is 1, */
    /* a message type octet shall be present as shown in Figure 6-1. */
    /* The following message types are indicated: */
    public enum BacnetNetworkMessageTypes : byte
    {
        NETWORK_MESSAGE_WHO_IS_ROUTER_TO_NETWORK = 0,
        NETWORK_MESSAGE_I_AM_ROUTER_TO_NETWORK = 1,
        NETWORK_MESSAGE_I_COULD_BE_ROUTER_TO_NETWORK = 2,
        NETWORK_MESSAGE_REJECT_MESSAGE_TO_NETWORK = 3,
        NETWORK_MESSAGE_ROUTER_BUSY_TO_NETWORK = 4,
        NETWORK_MESSAGE_ROUTER_AVAILABLE_TO_NETWORK = 5,
        NETWORK_MESSAGE_INIT_RT_TABLE = 6,
        NETWORK_MESSAGE_INIT_RT_TABLE_ACK = 7,
        NETWORK_MESSAGE_ESTABLISH_CONNECTION_TO_NETWORK = 8,
        NETWORK_MESSAGE_DISCONNECT_CONNECTION_TO_NETWORK = 9,
        /* X'0A' to X'7F': Reserved for use by ASHRAE, */
        /* X'80' to X'FF': Available for vendor proprietary messages */
    }
    public enum BacnetEventTypes
    {
        EVENT_CHANGE_OF_BITSTRING = 0,
        EVENT_CHANGE_OF_STATE = 1,
        EVENT_CHANGE_OF_VALUE = 2,
        EVENT_COMMAND_FAILURE = 3,
        EVENT_FLOATING_LIMIT = 4,
        EVENT_OUT_OF_RANGE = 5,
        /*  complex-event-type        (6), -- see comment below */
        /*  event-buffer-ready   (7), -- context tag 7 is deprecated */
        EVENT_CHANGE_OF_LIFE_SAFETY = 8,
        EVENT_EXTENDED = 9,
        EVENT_BUFFER_READY = 10,
        EVENT_UNSIGNED_RANGE = 11,
        /* Enumerated values 0-63 are reserved for definition by ASHRAE.  */
        /* Enumerated values 64-65535 may be used by others subject to  */
        /* the procedures and constraints described in Clause 23.  */
        /* It is expected that these enumerated values will correspond to  */
        /* the use of the complex-event-type CHOICE [6] of the  */
        /* BACnetNotificationParameters production. */
        /* The last enumeration used in this version is 11. */
        /* do the max range inside of enum so that
           compilers will allocate adequate sized datatype for enum
           which is used to store decoding */
    }
    public enum BacnetCOVTypes
    {
        CHANGE_OF_VALUE_BITS,
        CHANGE_OF_VALUE_REAL
    }
    public enum BacnetAddressTypes
    {
        None,
        IP,
        MSTP,
        Ethernet,
        ArcNet,
        LonTalk,
        PTP,
        IPV6
    }
    public enum BacnetTrendLogValueTypes : byte
    {
        // Copyright (C) 2009 Peter Mc Shane in Steve Karg Stack, trendlog.h
        // Thank's to it's encoding sample, very usefull for this decoding work
        TL_TYPE_STATUS = 0,
        TL_TYPE_BOOL = 1,
        TL_TYPE_REAL = 2,
        TL_TYPE_ENUM = 3,
        TL_TYPE_UNSIGN = 4,
        TL_TYPE_SIGN = 5,
        TL_TYPE_BITS = 6,
        TL_TYPE_NULL = 7,
        TL_TYPE_ERROR = 8,
        TL_TYPE_DELTA = 9,
        TL_TYPE_ANY = 10
    }
    public enum BacnetObjectTypes
    {
        OBJECT_ANALOG_INPUT = 0,
        OBJECT_ANALOG_OUTPUT = 1,
        OBJECT_ANALOG_VALUE = 2,
        OBJECT_BINARY_INPUT = 3,
        OBJECT_BINARY_OUTPUT = 4,
        OBJECT_BINARY_VALUE = 5,
        OBJECT_CALENDAR = 6,
        OBJECT_COMMAND = 7,
        OBJECT_DEVICE = 8,
        OBJECT_EVENT_ENROLLMENT = 9,
        OBJECT_FILE = 10,
        OBJECT_GROUP = 11,
        OBJECT_LOOP = 12,
        OBJECT_MULTI_STATE_INPUT = 13,
        OBJECT_MULTI_STATE_OUTPUT = 14,
        OBJECT_NOTIFICATION_CLASS = 15,
        OBJECT_PROGRAM = 16,
        OBJECT_SCHEDULE = 17,
        OBJECT_AVERAGING = 18,
        OBJECT_MULTI_STATE_VALUE = 19,
        OBJECT_TRENDLOG = 20,
        OBJECT_LIFE_SAFETY_POINT = 21,
        OBJECT_LIFE_SAFETY_ZONE = 22,
        OBJECT_ACCUMULATOR = 23,
        OBJECT_PULSE_CONVERTER = 24,
        OBJECT_EVENT_LOG = 25,
        OBJECT_GLOBAL_GROUP = 26,
        OBJECT_TREND_LOG_MULTIPLE = 27,
        OBJECT_LOAD_CONTROL = 28,
        OBJECT_STRUCTURED_VIEW = 29,
        OBJECT_ACCESS_DOOR = 30,
        OBJECT_31 = 31,/* 31 was lighting output, but BACnet editor changed it... */
        OBJECT_ACCESS_CREDENTIAL = 32,      /* Addendum 2008-j */
        OBJECT_ACCESS_POINT = 33,
        OBJECT_ACCESS_RIGHTS = 34,
        OBJECT_ACCESS_USER = 35,
        OBJECT_ACCESS_ZONE = 36,
        OBJECT_CREDENTIAL_DATA_INPUT = 37,  /* authentication-factor-input */
        OBJECT_NETWORK_SECURITY = 38,       /* Addendum 2008-g */
        OBJECT_BITSTRING_VALUE = 39,        /* Addendum 2008-w */
        OBJECT_CHARACTERSTRING_VALUE = 40,  /* Addendum 2008-w */
        OBJECT_DATE_PATTERN_VALUE = 41,     /* Addendum 2008-w */
        OBJECT_DATE_VALUE = 42,     /* Addendum 2008-w */
        OBJECT_DATETIME_PATTERN_VALUE = 43, /* Addendum 2008-w */
        OBJECT_DATETIME_VALUE = 44, /* Addendum 2008-w */
        OBJECT_INTEGER_VALUE = 45,  /* Addendum 2008-w */
        OBJECT_LARGE_ANALOG_VALUE = 46,     /* Addendum 2008-w */
        OBJECT_OCTETSTRING_VALUE = 47,      /* Addendum 2008-w */
        OBJECT_POSITIVE_INTEGER_VALUE = 48, /* Addendum 2008-w */
        OBJECT_TIME_PATTERN_VALUE = 49,     /* Addendum 2008-w */
        OBJECT_TIME_VALUE = 50,     /* Addendum 2008-w */
        OBJECT_NOTIFICATION_FORWARDER = 51, /* Addendum 2010-af */
        OBJECT_ALERT_ENROLLMENT = 52,       /* Addendum 2010-af */
        OBJECT_CHANNEL = 53,        /* Addendum 2010-aa */
        OBJECT_LIGHTING_OUTPUT = 54,        /* Addendum 2010-i */
        /* Enumerated values 0-127 are reserved for definition by ASHRAE. */
        /* Enumerated values 128-1023 may be used by others subject to  */
        /* the procedures and constraints described in Clause 23. */
        /* do the max range inside of enum so that
           compilers will allocate adequate sized datatype for enum
           which is used to store decoding */
        OBJECT_PROPRIETARY_MIN = 128,
        OBJECT_PROPRIETARY_MAX = 1023,
        MAX_BACNET_OBJECT_TYPE = 1024,
        MAX_ASHRAE_OBJECT_TYPE = 55
    }
    public enum BacnetReadRangeRequestTypes
    {
        RR_BY_POSITION = 1,
        RR_BY_SEQUENCE = 2,
        RR_BY_TIME = 4,
        RR_READ_ALL = 8,
    }



}
