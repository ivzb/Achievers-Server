using System;

namespace Achiever.Common.Extenders
{
    public static class DateTimeExtenders
    {
        public static DateTime EndOfWeek(this DateTime date)
        {
            DateTime endOfLastWeek = date.StartOfWeek().AddDays(7).AddMilliseconds(-1);
            return endOfLastWeek;
        }
        public static DateTime EndOfWeek(this DateTime date, DayOfWeek firstDayOfWeek)
        {
            DateTime endOfLastWeek = date.StartOfWeek(firstDayOfWeek).AddDays(7).AddMilliseconds(-1);
            return endOfLastWeek;
        }

        public static DateTime StartOfWeek(this DateTime date)
        {
            return date.StartOfWeek(Settings.FirstDayOfWeek);
        }

        public static DateTime StartOfWeek(this DateTime date, DayOfWeek firstDayOfWeek)
        {
            DateTime firstDayInWeek = date.Date;

            while (firstDayInWeek.DayOfWeek != firstDayOfWeek)
            {
                firstDayInWeek = firstDayInWeek.AddDays(-1);
            }

            return firstDayInWeek;
        }
    }
}
