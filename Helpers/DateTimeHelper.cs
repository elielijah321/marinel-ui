using System;
using System.Globalization;

namespace Marinel_ui.Helpers
{
    public static class DateTimeHelper
    {


        public static string ToYearMonthDay(DateTime? date)
        {
            return  date.HasValue ? date.Value.ToString("yyyy-MM-dd") : string.Empty;
        }

        public static string ToDayMonthYear(DateTime? date)
        {
            return date.HasValue ? date.Value.ToString("dd/MM/yyyy") : string.Empty;
        }

        public static DateTime ToDayMonthYear(string date)
        {
            var result = DateTime.Parse(date, new CultureInfo("en-GB"));

            return result;
        }
    }
}