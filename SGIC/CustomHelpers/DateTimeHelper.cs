using System;
using System.Collections.Generic;
using System.Globalization;


namespace SGIC.CustomHelpers
{
    public class DateTimeHelper
    {
        internal static DateTime FirstDateOfWeek(DateTime fecha)
        {
            DateTime jan1 = new DateTime(fecha.Year, 1, 1);
            int weekOfYear = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(fecha, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            int daysOffset = (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;

            DateTime firstMonday = jan1.AddDays(daysOffset);

            int firstWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(jan1, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, 
                CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);


            if (firstWeek <= 1)
            {
                weekOfYear -= 1;
            }

            return firstMonday.AddDays(weekOfYear * 7);
        }
    }
}