using System;

namespace BacnetLibrary.BACnetBase.BACnetStruct
{
    public struct BacnetBitString
    {
        public byte bits_used;
        public byte[] value;

        public override string ToString()
        {
            string ret = "";
            for (int i = 0; i < bits_used; i++)
            {
                ret = ret + ((value[i / 8] & (1 << (i % 8))) > 0 ? "1" : "0");
            }
            return ret;
        }

        public void SetBit(byte bit_number, bool v)
        {
            byte byte_number = (byte)(bit_number / 8);
            byte bit_mask = 1;

            if (value == null) value = new byte[BACnetSerialize.ASN1.MAX_BITSTRING_BYTES];

            if (byte_number < BACnetSerialize.ASN1.MAX_BITSTRING_BYTES)
            {
                /* set max bits used */
                if (bits_used < (bit_number + 1))
                    bits_used = (byte)(bit_number + 1);
                bit_mask = (byte)(bit_mask << (bit_number - (byte_number * 8)));
                if (v)
                    value[byte_number] |= bit_mask;
                else
                    value[byte_number] &= (byte)(~(bit_mask));
            }
        }

        public static BacnetBitString Parse(string str)
        {
            BacnetBitString ret = new BacnetBitString();
            ret.value = new byte[BACnetSerialize.ASN1.MAX_BITSTRING_BYTES];

            if (!string.IsNullOrEmpty(str))
            {
                ret.bits_used = (byte)str.Length;
                for (int i = 0; i < ret.bits_used; i++)
                {
                    bool is_set = str[i] == '1';
                    if (is_set) ret.value[i / 8] |= (byte)(1 << (i % 8));
                }
            }

            return ret;
        }

        public uint ConvertToInt()
        {
            return value == null ? 0 : BitConverter.ToUInt32(value, 0);
        }

        public static BacnetBitString ConvertFromInt(uint value)
        {
            BacnetBitString ret = new BacnetBitString();
            ret.value = BitConverter.GetBytes(value);
            ret.bits_used = (byte)Math.Ceiling(Math.Log(value, 2));
            return ret;
        }
    };
}
