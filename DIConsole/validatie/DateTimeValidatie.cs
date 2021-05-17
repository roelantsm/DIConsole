using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GanzenBoardGame.Application.validatie
{
    public class DateTimeValidatie : IDateTimeValidatie
    {
        public DateTime ParseStringToDatetime(string StringToParseToDateTime)
        {
            //DateTime.TryParse(StringToParseToDateTime, out DateTime parsedDateTime);
            //return parsedDateTime;

            string format;
            CultureInfo provider = CultureInfo.InvariantCulture;

            // Parse date-only value with invariant culture.
            // dateString = "06/15/2008";
            format = "d";
            try
            {
                return DateTime.ParseExact(StringToParseToDateTime, format, provider);
            }
            catch (FormatException)
            {
                return DateTime.Now;
            }
        }
    }
}
