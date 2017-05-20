using System;
using System.Data.Entity;

namespace Achiever.Common.Utilities
{
    public static class TestableDbFunctions
    {
        [DbFunction("Edm", "DiffMinutes")]
        public static int? DiffMinutes(DateTime? first, DateTime? second)
        {
            if (!first.HasValue || !second.HasValue)
            {
                return null;
            }

            return (int)Math.Abs((second.Value - first.Value).TotalMinutes);
        }

        [DbFunction("Edm", "TruncateTime")]
        public static DateTime? TruncateTime(this DateTime? date)
        {
            return date.HasValue ? date.Value.Date : (DateTime?)null;
        }
    }
}
