namespace BacnetLibrary.BACnetBase.BACnetEnum
{

    public enum BacnetLifeSafetyOperations
    {
        LIFE_SAFETY_OP_NONE = 0,
        LIFE_SAFETY_OP_SILENCE = 1,
        LIFE_SAFETY_OP_SILENCE_AUDIBLE = 2,
        LIFE_SAFETY_OP_SILENCE_VISUAL = 3,
        LIFE_SAFETY_OP_RESET = 4,
        LIFE_SAFETY_OP_RESET_ALARM = 5,
        LIFE_SAFETY_OP_RESET_FAULT = 6,
        LIFE_SAFETY_OP_UNSILENCE = 7,
        LIFE_SAFETY_OP_UNSILENCE_AUDIBLE = 8,
        LIFE_SAFETY_OP_UNSILENCE_VISUAL = 9,
        /* Enumerated values 0-63 are reserved for definition by ASHRAE.  */
        /* Enumerated values 64-65535 may be used by others subject to  */
        /* procedures and constraints described in Clause 23. */
        /* do the max range inside of enum so that
           compilers will allocate adequate sized datatype for enum
           which is used to store decoding */
        LIFE_SAFETY_OP_PROPRIETARY_MIN = 64,
        LIFE_SAFETY_OP_PROPRIETARY_MAX = 65535
    }

    public enum BacnetLifeSafetyModes
    {
        MIN_LIFE_SAFETY_MODE = 0,
        LIFE_SAFETY_MODE_OFF = 0,
        LIFE_SAFETY_MODE_ON = 1,
        LIFE_SAFETY_MODE_TEST = 2,
        LIFE_SAFETY_MODE_MANNED = 3,
        LIFE_SAFETY_MODE_UNMANNED = 4,
        LIFE_SAFETY_MODE_ARMED = 5,
        LIFE_SAFETY_MODE_DISARMED = 6,
        LIFE_SAFETY_MODE_PREARMED = 7,
        LIFE_SAFETY_MODE_SLOW = 8,
        LIFE_SAFETY_MODE_FAST = 9,
        LIFE_SAFETY_MODE_DISCONNECTED = 10,
        LIFE_SAFETY_MODE_ENABLED = 11,
        LIFE_SAFETY_MODE_DISABLED = 12,
        LIFE_SAFETY_MODE_AUTOMATIC_RELEASE_DISABLED = 13,
        LIFE_SAFETY_MODE_DEFAULT = 14,
        MAX_LIFE_SAFETY_MODE = 15,
        /* Enumerated values 0-255 are reserved for definition by ASHRAE.  */
        /* Enumerated values 256-65535 may be used by others subject to  */
        /* procedures and constraints described in Clause 23. */
        /* do the max range inside of enum so that
           compilers will allocate adequate sized datatype for enum
           which is used to store decoding */
        LIFE_SAFETY_MODE_PROPRIETARY_MIN = 256,
        LIFE_SAFETY_MODE_PROPRIETARY_MAX = 65535
    }

    public enum BacnetLifeSafetyStates
    {
        MIN_LIFE_SAFETY_STATE = 0,
        LIFE_SAFETY_STATE_QUIET = 0,
        LIFE_SAFETY_STATE_PRE_ALARM = 1,
        LIFE_SAFETY_STATE_ALARM = 2,
        LIFE_SAFETY_STATE_FAULT = 3,
        LIFE_SAFETY_STATE_FAULT_PRE_ALARM = 4,
        LIFE_SAFETY_STATE_FAULT_ALARM = 5,
        LIFE_SAFETY_STATE_NOT_READY = 6,
        LIFE_SAFETY_STATE_ACTIVE = 7,
        LIFE_SAFETY_STATE_TAMPER = 8,
        LIFE_SAFETY_STATE_TEST_ALARM = 9,
        LIFE_SAFETY_STATE_TEST_ACTIVE = 10,
        LIFE_SAFETY_STATE_TEST_FAULT = 11,
        LIFE_SAFETY_STATE_TEST_FAULT_ALARM = 12,
        LIFE_SAFETY_STATE_HOLDUP = 13,
        LIFE_SAFETY_STATE_DURESS = 14,
        LIFE_SAFETY_STATE_TAMPER_ALARM = 15,
        LIFE_SAFETY_STATE_ABNORMAL = 16,
        LIFE_SAFETY_STATE_EMERGENCY_POWER = 17,
        LIFE_SAFETY_STATE_DELAYED = 18,
        LIFE_SAFETY_STATE_BLOCKED = 19,
        LIFE_SAFETY_STATE_LOCAL_ALARM = 20,
        LIFE_SAFETY_STATE_GENERAL_ALARM = 21,
        LIFE_SAFETY_STATE_SUPERVISORY = 22,
        LIFE_SAFETY_STATE_TEST_SUPERVISORY = 23,
        MAX_LIFE_SAFETY_STATE = 24,
        /* Enumerated values 0-255 are reserved for definition by ASHRAE.  */
        /* Enumerated values 256-65535 may be used by others subject to  */
        /* procedures and constraints described in Clause 23. */
        /* do the max range inside of enum so that
           compilers will allocate adequate sized datatype for enum
           which is used to store decoding */
        LIFE_SAFETY_STATE_PROPRIETARY_MIN = 256,
        LIFE_SAFETY_STATE_PROPRIETARY_MAX = 65535
    }
}
