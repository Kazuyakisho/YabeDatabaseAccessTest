using BacnetLibrary.BACnetBase.BACnetEnum;
using System;

namespace BacnetLibrary.BACnetBase.BACnetStruct
{
    public struct BacnetLogRecord
    {
        public DateTime timestamp;

        /* logDatum: CHOICE { */
        public BacnetTrendLogValueTypes type;
        //private BacnetBitString log_status;
        //private bool boolean_value;
        //private float real_value;
        //private uint enum_value;
        //private uint unsigned_value;
        //private int signed_value;
        //private BacnetBitString bitstring_value;
        //private bool null_value;
        //private BacnetError failure;
        //private float time_change;
        private object any_value;
        /* } */

        public BacnetBitString statusFlags;

        public BacnetLogRecord(BacnetTrendLogValueTypes type, object value, DateTime stamp, uint status)
        {
            this.type = type;
            timestamp = stamp;
            statusFlags = BacnetBitString.ConvertFromInt(status);
            any_value = null;
            Value = value;
        }

        public object Value
        {
            get
            {
                switch (type)
                {
                    case BacnetTrendLogValueTypes.TL_TYPE_ANY:
                        return any_value;
                    case BacnetTrendLogValueTypes.TL_TYPE_BITS:
                        return (BacnetBitString)Convert.ChangeType(any_value, typeof(BacnetBitString));
                    case BacnetTrendLogValueTypes.TL_TYPE_BOOL:
                        return (bool)Convert.ChangeType(any_value, typeof(bool));
                    case BacnetTrendLogValueTypes.TL_TYPE_DELTA:
                        return (float)Convert.ChangeType(any_value, typeof(float));
                    case BacnetTrendLogValueTypes.TL_TYPE_ENUM:
                        return (uint)Convert.ChangeType(any_value, typeof(uint));
                    case BacnetTrendLogValueTypes.TL_TYPE_ERROR:
                        if (any_value != null)
                            return (BacnetError)Convert.ChangeType(any_value, typeof(BacnetError));
                        return new BacnetError(BacnetErrorClasses.ERROR_CLASS_DEVICE, BacnetErrorCodes.ERROR_CODE_ABORT_OTHER);
                    case BacnetTrendLogValueTypes.TL_TYPE_NULL:
                        return null;
                    case BacnetTrendLogValueTypes.TL_TYPE_REAL:
                        return (float)Convert.ChangeType(any_value, typeof(float));
                    case BacnetTrendLogValueTypes.TL_TYPE_SIGN:
                        return (int)Convert.ChangeType(any_value, typeof(int));
                    case BacnetTrendLogValueTypes.TL_TYPE_STATUS:
                        return (BacnetBitString)Convert.ChangeType(any_value, typeof(BacnetBitString));
                    case BacnetTrendLogValueTypes.TL_TYPE_UNSIGN:
                        return (uint)Convert.ChangeType(any_value, typeof(uint));
                    default:
                        throw new NotSupportedException();
                }
            }
            set
            {
                switch (type)
                {
                    case BacnetTrendLogValueTypes.TL_TYPE_ANY:
                        any_value = value;
                        break;
                    case BacnetTrendLogValueTypes.TL_TYPE_BITS:
                        if (value == null) value = new BacnetBitString();
                        if (value.GetType() != typeof(BacnetBitString))
                            value = BacnetBitString.ConvertFromInt((uint)Convert.ChangeType(value, typeof(uint)));
                        any_value = (BacnetBitString)value;
                        break;
                    case BacnetTrendLogValueTypes.TL_TYPE_BOOL:
                        if (value == null) value = false;
                        if (value.GetType() != typeof(bool))
                            value = (bool)Convert.ChangeType(value, typeof(bool));
                        any_value = (bool)value;
                        break;
                    case BacnetTrendLogValueTypes.TL_TYPE_DELTA:
                        if (value == null) value = (float)0;
                        if (value.GetType() != typeof(float))
                            value = (float)Convert.ChangeType(value, typeof(float));
                        any_value = (float)value;
                        break;
                    case BacnetTrendLogValueTypes.TL_TYPE_ENUM:
                        if (value == null) value = (uint)0;
                        if (value.GetType() != typeof(uint))
                            value = (uint)Convert.ChangeType(value, typeof(uint));
                        any_value = (uint)value;
                        break;
                    case BacnetTrendLogValueTypes.TL_TYPE_ERROR:
                        if (value == null) value = new BacnetError();
                        if (value.GetType() != typeof(BacnetError))
                            throw new ArgumentException();
                        any_value = (BacnetError)value;
                        break;
                    case BacnetTrendLogValueTypes.TL_TYPE_NULL:
                        if (value != null) throw new ArgumentException();
                        any_value = value;
                        break;
                    case BacnetTrendLogValueTypes.TL_TYPE_REAL:
                        if (value == null) value = (float)0;
                        if (value.GetType() != typeof(float))
                            value = (float)Convert.ChangeType(value, typeof(float));
                        any_value = (float)value;
                        break;
                    case BacnetTrendLogValueTypes.TL_TYPE_SIGN:
                        if (value == null) value = 0;
                        if (value.GetType() != typeof(Int32))
                            value = (Int32)Convert.ChangeType(value, typeof(Int32));
                        any_value = (Int32)value;
                        break;
                    case BacnetTrendLogValueTypes.TL_TYPE_STATUS:
                        if (value == null) value = new BacnetBitString();
                        if (value.GetType() != typeof(BacnetBitString))
                            value = BacnetBitString.ConvertFromInt((uint)Convert.ChangeType(value, typeof(uint)));
                        any_value = (BacnetBitString)value;
                        break;
                    case BacnetTrendLogValueTypes.TL_TYPE_UNSIGN:
                        if (value == null) value = (UInt32)0;
                        if (value.GetType() != typeof(UInt32))
                            value = (UInt32)Convert.ChangeType(value, typeof(UInt32));
                        any_value = (UInt32)value;
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        public T GetValue<T>()
        {
            return (T)Convert.ChangeType(Value, typeof(T));
        }
    }
}
