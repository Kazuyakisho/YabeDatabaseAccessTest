namespace BacnetLibrary.BACnetBase.BACnetEnum
{
    public enum BacnetRestartReason
    {
        UNKNOWN = 0,
        COLD_START = 1,
        WARM_START = 2,
        DETECTED_POWER_LOST = 3,
        DETECTED_POWER_OFF = 4,
        HARDWARE_WATCHDOG = 5,
        SOFTWARE_WATCHDOG = 6,
        SUSPENDED = 7
    }



    //http://www.bacnetwiki.com/wiki/index.php?title=BACnet_Reject_Reason
    public enum BacnetRejectReasons
    {
        REJECT_REASON_OTHER = 0,
        REJECT_REASON_BUFFER_OVERFLOW = 1,
        REJECT_REASON_INCONSISTENT_PARAMETERS = 2,
        REJECT_REASON_INVALID_PARAMETER_DATA_TYPE = 3,
        REJECT_REASON_INVALID_TAG = 4,
        REJECT_REASON_MISSING_REQUIRED_PARAMETER = 5,
        REJECT_REASON_PARAMETER_OUT_OF_RANGE = 6,
        REJECT_REASON_TOO_MANY_ARGUMENTS = 7,
        REJECT_REASON_UNDEFINED_ENUMERATION = 8,
        REJECT_REASON_UNRECOGNIZED_SERVICE = 9,
        /* Enumerated values 0-63 are reserved for definition by ASHRAE. */
        /* Enumerated values 64-65535 may be used by others subject to */
        /* the procedures and constraints described in Clause 23. */
        MAX_BACNET_REJECT_REASON = 10,
        /* do the MAX here instead of outside of enum so that
           compilers will allocate adequate sized datatype for enum */
        REJECT_REASON_PROPRIETARY_FIRST = 64,
        REJECT_REASON_PROPRIETARY_LAST = 65535
    }
}
