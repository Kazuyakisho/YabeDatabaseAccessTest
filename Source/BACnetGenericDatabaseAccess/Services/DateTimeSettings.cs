using System;
using System.Globalization;

namespace BACnetGenericDatabaseAccess.Services
{

    public class DateTimeSettings
    {
        string[,] Weekdays = new string[7, 1];

        private DateTimeFormatInfo dateTimeFormat = new CultureInfo("de-DE").DateTimeFormat;

        public void SetWeekdays(string pweekdays)
        {
            string[] week = pweekdays.Split(new char[] { '_' });

            for (int i = 0; i < 7; i++)
            {
                string[] substring = week[i].Split(new char[] { '.' });

                Weekdays[i, 0] = substring[1];

            }

        }

        public bool CheckTodayIsValid()
        {

            DateTime dateValue = DateTime.Today;



            for (int i = 0; i < Weekdays.Length; i++)
            {
                int z = (int)dateValue.DayOfWeek;
                if ((int)dateValue.DayOfWeek == i)
                {
                    return Weekdays[i, 0] == "True";
                }
            }

            return false;
        }


    }
}
