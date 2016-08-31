namespace BacnetLibrary.BACnetBase.BACnetEnum
{
    public enum BacnetSegmentations
    {
        SEGMENTATION_BOTH = 0,
        SEGMENTATION_TRANSMIT = 1,
        SEGMENTATION_RECEIVE = 2,
        SEGMENTATION_NONE = 3
    }

    public enum BacnetDeviceStatus : byte
    {
        OPERATIONAL = 0,
        OPERATIONAL_READONLY = 1,
        DOWNLOAD_REQUIRED = 2,
        DOWNLOAD_IN_PROGRESS = 3,
        NON_OPERATIONAL = 4,
        BACKUP_IN_PROGRESS = 5
    }

    public enum BacnetServicesSupported
    {
        /* Alarm and Event Services */
        SERVICE_SUPPORTED_ACKNOWLEDGE_ALARM = 0,
        SERVICE_SUPPORTED_CONFIRMED_COV_NOTIFICATION = 1,
        SERVICE_SUPPORTED_CONFIRMED_EVENT_NOTIFICATION = 2,
        SERVICE_SUPPORTED_GET_ALARM_SUMMARY = 3,
        SERVICE_SUPPORTED_GET_ENROLLMENT_SUMMARY = 4,
        SERVICE_SUPPORTED_GET_EVENT_INFORMATION = 39,
        SERVICE_SUPPORTED_SUBSCRIBE_COV = 5,
        SERVICE_SUPPORTED_SUBSCRIBE_COV_PROPERTY = 38,
        SERVICE_SUPPORTED_LIFE_SAFETY_OPERATION = 37,
        /* File Access Services */
        SERVICE_SUPPORTED_ATOMIC_READ_FILE = 6,
        SERVICE_SUPPORTED_ATOMIC_WRITE_FILE = 7,
        /* Object Access Services */
        SERVICE_SUPPORTED_ADD_LIST_ELEMENT = 8,
        SERVICE_SUPPORTED_REMOVE_LIST_ELEMENT = 9,
        SERVICE_SUPPORTED_CREATE_OBJECT = 10,
        SERVICE_SUPPORTED_DELETE_OBJECT = 11,
        SERVICE_SUPPORTED_READ_PROPERTY = 12,
        SERVICE_SUPPORTED_READ_PROP_CONDITIONAL = 13,
        SERVICE_SUPPORTED_READ_PROP_MULTIPLE = 14,
        SERVICE_SUPPORTED_READ_RANGE = 35,
        SERVICE_SUPPORTED_WRITE_PROPERTY = 15,
        SERVICE_SUPPORTED_WRITE_PROP_MULTIPLE = 16,
        SERVICE_SUPPORTED_WRITE_GROUP = 40,
        /* Remote Device Management Services */
        SERVICE_SUPPORTED_DEVICE_COMMUNICATION_CONTROL = 17,
        SERVICE_SUPPORTED_PRIVATE_TRANSFER = 18,
        SERVICE_SUPPORTED_TEXT_MESSAGE = 19,
        SERVICE_SUPPORTED_REINITIALIZE_DEVICE = 20,
        /* Virtual Terminal Services */
        SERVICE_SUPPORTED_VT_OPEN = 21,
        SERVICE_SUPPORTED_VT_CLOSE = 22,
        SERVICE_SUPPORTED_VT_DATA = 23,
        /* Security Services */
        SERVICE_SUPPORTED_AUTHENTICATE = 24,
        SERVICE_SUPPORTED_REQUEST_KEY = 25,
        SERVICE_SUPPORTED_I_AM = 26,
        SERVICE_SUPPORTED_I_HAVE = 27,
        SERVICE_SUPPORTED_UNCONFIRMED_COV_NOTIFICATION = 28,
        SERVICE_SUPPORTED_UNCONFIRMED_EVENT_NOTIFICATION = 29,
        SERVICE_SUPPORTED_UNCONFIRMED_PRIVATE_TRANSFER = 30,
        SERVICE_SUPPORTED_UNCONFIRMED_TEXT_MESSAGE = 31,
        SERVICE_SUPPORTED_TIME_SYNCHRONIZATION = 32,
        SERVICE_SUPPORTED_UTC_TIME_SYNCHRONIZATION = 36,
        SERVICE_SUPPORTED_WHO_HAS = 33,
        SERVICE_SUPPORTED_WHO_IS = 34,
        /* Other services to be added as they are defined. */
        /* All values in this production are reserved */
        /* for definition by ASHRAE. */
        MAX_BACNET_SERVICES_SUPPORTED = 41
    };

    public enum BacnetUnconfirmedServices : byte
    {
        SERVICE_UNCONFIRMED_I_AM = 0,
        SERVICE_UNCONFIRMED_I_HAVE = 1,
        SERVICE_UNCONFIRMED_COV_NOTIFICATION = 2,
        SERVICE_UNCONFIRMED_EVENT_NOTIFICATION = 3,
        SERVICE_UNCONFIRMED_PRIVATE_TRANSFER = 4,
        SERVICE_UNCONFIRMED_TEXT_MESSAGE = 5,
        SERVICE_UNCONFIRMED_TIME_SYNCHRONIZATION = 6,
        SERVICE_UNCONFIRMED_WHO_HAS = 7,
        SERVICE_UNCONFIRMED_WHO_IS = 8,
        SERVICE_UNCONFIRMED_UTC_TIME_SYNCHRONIZATION = 9,
        /* addendum 2010-aa */
        SERVICE_UNCONFIRMED_WRITE_GROUP = 10,
        /* Other services to be added as they are defined. */
        /* All choice values in this production are reserved */
        /* for definition by ASHRAE. */
        /* Proprietary extensions are made by using the */
        /* UnconfirmedPrivateTransfer service. See Clause 23. */
        MAX_BACNET_UNCONFIRMED_SERVICE = 11
    }
    public enum BacnetConfirmedServices : byte
    {
        /* Alarm and Event Services */
        SERVICE_CONFIRMED_ACKNOWLEDGE_ALARM = 0,
        SERVICE_CONFIRMED_COV_NOTIFICATION = 1,
        SERVICE_CONFIRMED_EVENT_NOTIFICATION = 2,
        SERVICE_CONFIRMED_GET_ALARM_SUMMARY = 3,
        SERVICE_CONFIRMED_GET_ENROLLMENT_SUMMARY = 4,
        SERVICE_CONFIRMED_GET_EVENT_INFORMATION = 29,
        SERVICE_CONFIRMED_SUBSCRIBE_COV = 5,
        SERVICE_CONFIRMED_SUBSCRIBE_COV_PROPERTY = 28,
        SERVICE_CONFIRMED_LIFE_SAFETY_OPERATION = 27,
        /* File Access Services */
        SERVICE_CONFIRMED_ATOMIC_READ_FILE = 6,
        SERVICE_CONFIRMED_ATOMIC_WRITE_FILE = 7,
        /* Object Access Services */
        SERVICE_CONFIRMED_ADD_LIST_ELEMENT = 8,
        SERVICE_CONFIRMED_REMOVE_LIST_ELEMENT = 9,
        SERVICE_CONFIRMED_CREATE_OBJECT = 10,
        SERVICE_CONFIRMED_DELETE_OBJECT = 11,
        SERVICE_CONFIRMED_READ_PROPERTY = 12,
        SERVICE_CONFIRMED_READ_PROP_CONDITIONAL = 13,
        SERVICE_CONFIRMED_READ_PROP_MULTIPLE = 14,
        SERVICE_CONFIRMED_READ_RANGE = 26,
        SERVICE_CONFIRMED_WRITE_PROPERTY = 15,
        SERVICE_CONFIRMED_WRITE_PROP_MULTIPLE = 16,
        /* Remote Device Management Services */
        SERVICE_CONFIRMED_DEVICE_COMMUNICATION_CONTROL = 17,
        SERVICE_CONFIRMED_PRIVATE_TRANSFER = 18,
        SERVICE_CONFIRMED_TEXT_MESSAGE = 19,
        SERVICE_CONFIRMED_REINITIALIZE_DEVICE = 20,
        /* Virtual Terminal Services */
        SERVICE_CONFIRMED_VT_OPEN = 21,
        SERVICE_CONFIRMED_VT_CLOSE = 22,
        SERVICE_CONFIRMED_VT_DATA = 23,
        /* Security Services */
        SERVICE_CONFIRMED_AUTHENTICATE = 24,
        SERVICE_CONFIRMED_REQUEST_KEY = 25,
        /* Services added after 1995 */
        /* readRange (26) see Object Access Services */
        /* lifeSafetyOperation (27) see Alarm and Event Services */
        /* subscribeCOVProperty (28) see Alarm and Event Services */
        /* getEventInformation (29) see Alarm and Event Services */
        MAX_BACNET_CONFIRMED_SERVICE = 30
    };

    public enum BacnetPolarity : byte
    {
        POLARITY_NORMAL = 0,
        POLARITY_REVERSE = 1
    }

    public enum BacnetReliability : uint
    {

        RELIABILITY_NO_FAULT_DETECTED = 0,
        RELIABILITY_NO_SENSOR = 1,
        RELIABILITY_OVER_RANGE = 2,
        RELIABILITY_UNDER_RANGE = 3,
        RELIABILITY_OPEN_LOOP = 4,
        RELIABILITY_SHORTED_LOOP = 5,
        RELIABILITY_NO_OUTPUT = 6,
        RELIABILITY_UNRELIABLE_OTHER = 7,
        RELIABILITY_PROCESS_ERROR = 8,
        RELIABILITY_MULTI_STATE_FAULT = 9,
        RELIABILITY_CONFIGURATION_ERROR = 10,
        RELIABILITY_MEMBER_FAULT = 11,
        RELIABILITY_COMMUNICATION_FAILURE = 12,
        RELIABILITY_TRIPPED = 13
        /* Enumerated values 0-63 are reserved for definition by ASHRAE.  */
        /* Enumerated values 64-65535 may be used by others subject to  */
        /* the procedures and constraints described in Clause 23. */
        /* do the max range inside of enum so that
           compilers will allocate adequate sized datatype for enum
           which is used to store decoding */
    }

    public enum BacnetMaxSegments : byte
    {

        MAX_SEG0 = 0,
        MAX_SEG2 = 0x10,
        MAX_SEG4 = 0x20,
        MAX_SEG8 = 0x30,
        MAX_SEG16 = 0x40,
        MAX_SEG32 = 0x50,
        MAX_SEG64 = 0x60,
        MAX_SEG65 = 0x70
    }

    public enum BacnetMaxApdu : byte //Application Protocol Data Unit --- https://de.wikipedia.org/wiki/Application_Protocol_Data_Unit
    {
        MAX_APDU50 = 0,
        MAX_APDU128 = 1,
        MAX_APDU206 = 2,
        MAX_APDU480 = 3,
        MAX_APDU1024 = 4,
        MAX_APDU1476 = 5
    }

    public enum BacnetWritePriority
    {
        NO_PRIORITY = 0,
        MANUAL_LIFE_SAFETY = 1,
        AUTOMATIC_LIFE_SAFETY = 2,
        UNSPECIFIED_LEVEL_3 = 3,
        UNSPECIFIED_LEVEL_4 = 4,
        CRITICAL_EQUIPMENT_CONTROL = 5,
        MINIMUM_ON_OFF = 6,
        UNSPECIFIED_LEVEL_7 = 7,
        MANUAL_OPERATOR = 8,
        UNSPECIFIED_LEVEL_9 = 9,
        UNSPECIFIED_LEVEL_10 = 10,
        UNSPECIFIED_LEVEL_11 = 11,
        UNSPECIFIED_LEVEL_12 = 12,
        UNSPECIFIED_LEVEL_13 = 13,
        UNSPECIFIED_LEVEL_14 = 14,
        UNSPECIFIED_LEVEL_15 = 15,
        LOWEST_AND_DEFAULT = 16
    }

    public enum BacnetCharacterStringEncodings
    {
        CHARACTER_ANSI_X34 = 0,  /* deprecated : Addendum 135-2008k  */
        CHARACTER_UTF8 = 0,
        CHARACTER_MS_DBCS = 1,
        CHARACTER_JISC_6226 = 2, /* deprecated : Addendum 135-2008k  */
        CHARACTER_JISX_0208 = 2,
        CHARACTER_UCS4 = 3,
        CHARACTER_UCS2 = 4,
        CHARACTER_ISO8859 = 5,
    }

    public enum BacnetReinitializedStates
    {
        BACNET_REINIT_COLDSTART = 0,
        BACNET_REINIT_WARMSTART = 1,
        BACNET_REINIT_STARTBACKUP = 2,
        BACNET_REINIT_ENDBACKUP = 3,
        BACNET_REINIT_STARTRESTORE = 4,
        BACNET_REINIT_ENDRESTORE = 5,
        BACNET_REINIT_ABORTRESTORE = 6,
        BACNET_REINIT_IDLE = 255
    }



}
