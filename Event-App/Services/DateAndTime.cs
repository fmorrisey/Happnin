using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Event_App.Services
{
    public static class DateAndTime
    {
        public static DateTime dateValue { 
            get { return dateValue; }
            set { dateOffsetValue = new DateTimeOffset(dateValue, TimeZoneInfo.Local.GetUtcOffset(dateValue)); } 
        }
        static DateTimeOffset dateOffsetValue;
        static DateTimeFormatInfo dateTimeFormats;

        ////////////////////////////////////////////
        /// DROP ME INTO THE CONTORLLER
        /// private DayOfWeek Today = DateTime.Today.DayOfWeek;
        /////////////////////////////////////////////


        // Convert date representation to a date value
        // dateValue = DateTime.Parse(dateString, CultureInfo.InvariantCulture); 

    }
}
