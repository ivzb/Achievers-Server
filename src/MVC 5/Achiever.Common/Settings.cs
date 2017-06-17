using System;

namespace Achiever.Common
{
    public static class Settings
    {
        public static string HttpParameterDateParseFormat
        {
            get
            {
                return "dd-MM-yyyy";
            }
        }
        public static string DateParseFormat
        {
            get
            {
                return "dd/MM/yyyy";
            }
        }

        public static string DateFormat
        {
            get
            {
                return "{0:" + DateParseFormat + "}";
            }
        }

        public static string DateYearMonthFormat
        {
            get
            {
                return "{0:MM/yyyy}";
            }
        }
        public static string TimeFormat
        {
            get
            {
                return "{0:" + TimeParseFormat + "}";
            }
        }
        public static string TimeParseFormat
        {
            get
            {
                return "HH:mm";
            }
        }
        public static string DateTimeParseFormat
        {
            get
            {
                return "dd/MM/yyyy HH:mm";
            }
        }

        public static string DateTimeFormat
        {
            get
            {
                return "{0:" + DateTimeParseFormat + "}";
            }
        }

        public static DayOfWeek FirstDayOfWeek
        {
            get
            {
                return DayOfWeek.Monday;
            }
        }
        public static int MaxDaysInWeek
        {
            get
            {
                return 7;
            }
        }
        public static int MaxDailyWorkingHours
        {
            get
            {
                return 24;
            }
        }
        public static int MaxWeeklyWorkingHours
        {
            get
            {
                return MaxDaysInWeek * MaxDailyWorkingHours;
            }
        }
        public static string DatePickerFormat { get { return "d"; } }
        public static string DateTimePickerFormat { get { return "g"; } }
        public static string DateTimeCulture { get { return "en-GB"; } }
        public static int IconsImageWidth { get { return 200; } }  // Pixels
        public static int IconsImageHeight { get { return 100; } }  // Pixels
        public static int SmallIconsImageWidth { get { return 100; } }  // Pixels
        public static int SmallIconsImageHeight { get { return 50; } }  // Pixels
    }
}
