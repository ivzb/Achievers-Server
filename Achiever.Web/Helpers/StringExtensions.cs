using Achiever.Common;
using System;
using System.Globalization;

namespace Achiever.Web.Helpers
{
    public static class StringExtensions
    {
        public static DateTime? ToDateTime(this string date)
        {
            DateTime result;

            bool parsed = DateTime.TryParse(date, out result);

            if (parsed)
            {
                return result;
            }

            parsed = DateTime.TryParse(date, new CultureInfo(Settings.DateTimeCulture), DateTimeStyles.None, out result);

            if (parsed)
            {
                return result;
            }

            return null;
        }
    }
}