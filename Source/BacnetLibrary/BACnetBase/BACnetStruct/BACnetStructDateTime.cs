using BacnetLibrary.BACnetBase.BACnetEnum;
using BacnetLibrary.BACnetBase.BACnetSerialize;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace BacnetLibrary.BACnetBase.BACnetStruct
{
    public struct BacnetDate : ASN1.IASN1encode
    {
        public byte year;     /* 255 any */
        public byte month;      /* 1=Jan; 255 any, 13 Odd, 14 Even */
        public byte day;        /* 1..31; 32 last day of the month; 255 any */
        public byte wday;       /* 1=Monday-7=Sunday, 255 any */

        public BacnetDate(byte year, byte month, byte day, byte wday = 255)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.wday = wday;
        }

        public void ASN1encode(EncodeBuffer buffer)
        {

            buffer.Add(year);
            buffer.Add(month);
            buffer.Add(day);
            buffer.Add(wday);
        }

        public int ASN1decode(byte[] buffer, int offset, uint len_value)
        {
            year = buffer[offset];
            month = buffer[offset + 1];
            day = buffer[offset + 2];
            wday = buffer[offset + 3];

            return 4;
        }
        public bool IsPeriodic
        {
            get { return (year == 255) || (month > 12) || (day == 255); }
        }

        public bool IsAFittingDate(DateTime date)
        {
            if ((date.Year != (year + 1900)) && (year != 255))
                return false;

            if ((date.Month != month) && (month != 255) && (month != 13) && (month != 14))
                return false;
            if ((month == 13) && ((date.Month & 1) != 1))
                return false;
            if ((month == 14) && ((date.Month & 1) == 1))
                return false;

            if ((date.Day != day) && (day != 255))
                return false;
            // day 32 todo

            if (wday == 255)
                return true;
            if ((wday == 7) && (date.DayOfWeek == 0))  // Sunday 7 for Bacnet, 0 for .NET
                return true;
            if (wday == (int)date.DayOfWeek)
                return true;

            return false;
        }

        public DateTime toDateTime() // Not every time possible, too much complex (any month, any year ...)
        {
            try
            {
                if (IsPeriodic)
                    return new DateTime(1, 1, 1);
                return new DateTime(year + 1900, month, day);
            }
            catch { }

            return DateTime.Now; // or anything else why not !
        }

        string GetDayName(int day)
        {
            if (day == 7) day = 0;
            return CultureInfo.CurrentCulture.DateTimeFormat.DayNames[day];
        }

        public override string ToString()
        {
            String ret;

            if (wday != 255)
                ret = GetDayName(wday) + " ";
            else
                ret = "";

            if (day != 255)
                ret = ret + day + "/";
            else
                ret = ret + "**/";

            switch (month)
            {
                case 13:
                    ret = ret + "odd/";
                    break;
                case 14:
                    ret = ret + "even/";
                    break;
                case 255:
                    ret = ret + "**/";
                    break;
                default:
                    ret = ret + month + "/";
                    break;
            }


            if (year != 255)
                ret = ret + (year + 1900);
            else
                ret = ret + "****";

            return ret;
        }
    }

    public struct BacnetDateRange : ASN1.IASN1encode
    {
        public BacnetDate startDate;
        public BacnetDate endDate;

        public BacnetDateRange(BacnetDate start, BacnetDate end)
        {
            startDate = start;
            endDate = end;
        }
        public void ASN1encode(EncodeBuffer buffer)
        {

            ASN1.encode_tag(buffer, (byte)BacnetApplicationTags.BACNET_APPLICATION_TAG_DATE, false, 4);
            startDate.ASN1encode(buffer);
            ASN1.encode_tag(buffer, (byte)BacnetApplicationTags.BACNET_APPLICATION_TAG_DATE, false, 4);
            endDate.ASN1encode(buffer);

        }
        public int ASN1decode(byte[] buffer, int offset, uint len_value)
        {
            int len = 1; // opening tag
            len += startDate.ASN1decode(buffer, offset + len, len_value);
            len++;
            len += endDate.ASN1decode(buffer, offset + len, len_value);
            return len;
        }

        public bool IsAFittingDate(DateTime date)
        {
            date = new DateTime(date.Year, date.Month, date.Day);
            if ((date >= startDate.toDateTime()) && (date <= endDate.toDateTime()))
                return true;
            return false;
        }

        public override string ToString()
        {
            string ret;

            if (startDate.day != 255)
                ret = "From " + startDate;
            else
                ret = "From **/**/**";

            if (endDate.day != 255)
                ret = ret + " to " + endDate;
            else
                ret = ret + " to **/**/**";

            return ret;
        }
    };

    public struct BacnetweekNDay : ASN1.IASN1encode
    {
        public byte month;  /* 1 January, 13 Odd, 14 Even, 255 Any */
        public byte week;   /* Don't realy understand ??? 1 for day 1 to 7, 2 for ... what's the objective ?  boycott it*/
        public byte wday;   /* 1=Monday-7=Sunday, 255 any */

        public BacnetweekNDay(byte day, byte month, byte week = 255)
        {
            wday = day;
            this.month = month;
            this.week = week;
        }

        public void ASN1encode(EncodeBuffer buffer)
        {
            buffer.Add(month);
            buffer.Add(week);
            buffer.Add(wday);
        }

        public int ASN1decode(byte[] buffer, int offset, uint len_value)
        {
            month = buffer[offset++];
            week = buffer[offset++];
            wday = buffer[offset];

            return 3;
        }

        string GetDayName(int day)
        {
            if (day == 7) day = 0;
            return CultureInfo.CurrentCulture.DateTimeFormat.DayNames[day];
        }

        public override string ToString()
        {
            string ret;

            if (wday != 255)
                ret = GetDayName(wday);
            else
                ret = "Every days";

            if (month != 255)
                ret = ret + " on " + CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[month - 1];
            else
                ret = ret + " on every month";

            return ret;
        }

        public bool IsAFittingDate(DateTime date)
        {

            if ((date.Month != month) && (month != 255) && (month != 13) && (month != 14))
                return false;
            if ((month == 13) && ((date.Month & 1) != 1))
                return false;
            if ((month == 14) && ((date.Month & 1) == 1))
                return false;

            // What about week, too much stupid : boycott it !

            if (wday == 255)
                return true;
            if ((wday == 7) && (date.DayOfWeek == 0))  // Sunday 7 for Bacnet, 0 for .NET
                return true;
            if (wday == (int)date.DayOfWeek)
                return true;

            return false;
        }
    }

    public struct BACnetCalendarEntry : ASN1.IASN1encode
    {
        public List<object> Entries; // BacnetDate or BacnetDateRange or BacnetweekNDay

        public void ASN1encode(EncodeBuffer buffer)
        {
            if (Entries != null)
                foreach (ASN1.IASN1encode entry in Entries)
                {
                    if (entry is BacnetDate)
                    {
                        ASN1.encode_tag(buffer, 0, true, 4);
                        entry.ASN1encode(buffer);
                    }
                    if (entry is BacnetDateRange)
                    {
                        ASN1.encode_opening_tag(buffer, 1);
                        entry.ASN1encode(buffer);
                        ASN1.encode_closing_tag(buffer, 1);
                    }
                    if (entry is BacnetweekNDay)
                    {
                        ASN1.encode_tag(buffer, 2, true, 3);
                        entry.ASN1encode(buffer);
                    }
                }
        }


        public int ASN1decode(byte[] buffer, int offset, uint len_value)
        {
            int len = 0;
            byte tag_number;

            Entries = new List<object>();

            for (;;)
            {

                byte b = buffer[offset + len];
                len += ASN1.decode_tag_number(buffer, offset + len, out tag_number);

                switch (tag_number)
                {
                    case 0:
                        BacnetDate bdt = new BacnetDate();
                        len += bdt.ASN1decode(buffer, offset + len, len_value);
                        Entries.Add(bdt);
                        break;
                    case 1:
                        BacnetDateRange bdr = new BacnetDateRange();
                        len += bdr.ASN1decode(buffer, offset + len, len_value);
                        Entries.Add(bdr);
                        len++; // closing tag
                        break;
                    case 2:
                        BacnetweekNDay bwd = new BacnetweekNDay();
                        len += bwd.ASN1decode(buffer, offset + len, len_value);
                        Entries.Add(bwd);
                        break;
                    default:
                        return len - 1; // closing Tag
                }
            }

        }
    }

    public struct BacnetGenericTime
    {
        public BacnetTimestampTags Tag;
        public DateTime Time;
        public UInt16 Sequence;

        public BacnetGenericTime(DateTime Time, BacnetTimestampTags Tag, UInt16 Sequence = 0)
        {
            this.Time = Time;
            this.Tag = Tag;
            this.Sequence = Sequence;
        }
    }
}
