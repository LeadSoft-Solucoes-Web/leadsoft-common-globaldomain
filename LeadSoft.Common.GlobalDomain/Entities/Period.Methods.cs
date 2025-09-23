using LeadSoft.Common.Library.Enumerators;
using LeadSoft.Common.Library.Exceptions;
using LeadSoft.Common.Library.Extensions;

using System.Net;

using static LeadSoft.Common.Library.Enumerators.Enums;

namespace LeadSoft.Common.GlobalDomain.Entities
{
    public partial class Period
    {
        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public Period()
        {
        }

        /// <summary>
        /// Initial Constructor
        /// </summary>
        /// <param name="aStart">Start Date</param>
        /// <param name="aEnd">End Date</param>
        public Period(DateTime? aStart, DateTime? aEnd)
        {
            if (DateTime.Compare(aStart.Value, aEnd.Value) > 0)
                throw new AppException(HttpStatusCode.BadRequest, "Start must be equal to or greater than End");

            Start = aStart;
            End = aEnd;
        }

        /// <summary>
        /// Constructor receives a month of start and a month of end and creates a corresponding Period
        /// If the specified month is less than the actual month, then the Period starts or ends in the
        /// next year.
        /// If Start Month is greater than End Month then the Period ends one year later than Start. 
        /// </summary>
        /// <param name="aMonthStart">Start Month</param>
        /// <param name="aMonthEnd">End Month</param>
        public Period(Month aMonthStart, Month aMonthEnd)
        {
            int currentMonth = DateTime.UtcNow.Month,
                currentYear = DateTime.UtcNow.Year;

            int startYear = currentMonth > aMonthStart.GetValue() ? currentYear + 1 : currentYear,
                endYear = currentMonth > aMonthEnd.GetValue() ? currentYear + 1 : currentYear;

            if (aMonthStart.GetValue() > aMonthEnd.GetValue()) endYear += 1;

            Start = new DateTime(startYear, aMonthStart.GetValue(), 1);
            End = new DateTime(endYear, aMonthEnd.GetValue(), 1).EndOfMonth();
        }

        /// <summary>
        /// Constructor receives an interval of days and creates a Period that Starts "now" and ends
        /// aDaysInterval laters 
        /// </summary>
        /// <param name="aDaysInterval">Start Month</param>
        public Period(int aDaysInterval)
        {
            if (aDaysInterval <= 0)
                throw new AppException(HttpStatusCode.BadRequest, "Interval must be at least 1");

            Start = DateTime.Today;
            End = Start.Value.AddDays(aDaysInterval);
        }

        /// <summary>
        /// Auxiliar method to verify if a Date Time is in between the Period
        /// </summary>
        /// <param name="aDateTime">DateTime</param>
        /// <returns>Bool</returns>
        public bool Contains(DateTime aDateTime)
        {
            if (Start.HasValue && End.HasValue)
                return Start <= aDateTime && aDateTime <= End;
            else if (Start.HasValue)
                return Start <= aDateTime;
            else
                return aDateTime <= End;
        }

        /// <summary>
        /// Determinies if current date time (UTC) is in it current period
        /// </summary>
        /// <returns><see langword="true"/> or <see langword="false"/></returns>
        public bool IsInIt()
            => Contains(DateTime.UtcNow);

        /// <summary>
        /// Method to assign the Start time from period and verify if is a valid assignment
        /// </summary>
        /// <param name="aStart">Start Date</param>
        public void SetStartTime(DateTime aStart)
        {
            if (End.HasValue && DateTime.Compare(aStart, End.Value) > 0)
                throw new InvalidOperationException("Start must be equal to or greater than End");

            Start = aStart;
        }

        /// <summary>
        /// Method to assign the End time from period and verify if is a valid assignment
        /// </summary>
        /// <param name="aEnd">End Date</param>
        public void SetEndTime(DateTime aEnd)
        {
            if (Start.HasValue && DateTime.Compare(Start.Value, aEnd) > 0)
                throw new InvalidOperationException("End must be equal to or less than Start");
            End = aEnd;
        }

        /// <summary>
        /// Method to get number of days between Start and End
        /// </summary>
        public int? DaysInterval() => Start.HasValue && End.HasValue
            ? (End.Value - Start.Value).Days
            : null;

        /// <summary>
        /// Get all seconds between dates
        /// </summary>
        /// <returns>List of seconds.</returns>
        public IEnumerable<int> GetSeconds()
        {
            IList<int> seconds = [];

            int begin = Start.HasValue ? Start.Value.Second : DateTime.MinValue.Second;
            int end = End.HasValue ? End.Value.Second : DateTime.UtcNow.Second;

            for (int second = begin; second <= end; second++)
                seconds.Add(second);

            return seconds.Order();
        }

        /// <summary>
        /// Get all minutes between dates
        /// </summary>
        /// <returns>List of minutes.</returns>
        public IEnumerable<int> GetMinutes()
        {
            IList<int> minutes = [];

            int begin = Start.HasValue ? Start.Value.Minute : DateTime.MinValue.Minute;
            int end = End.HasValue ? End.Value.Minute : DateTime.UtcNow.Minute;

            for (int minute = begin; minute <= end; minute++)
                minutes.Add(minute);

            return minutes.Order();
        }

        /// <summary>
        /// Get all hours between dates
        /// </summary>
        /// <returns>List of hours.</returns>
        public IEnumerable<int> GetHours()
        {
            IList<int> hours = [];

            int begin = Start.HasValue ? Start.Value.Hour : DateTime.MinValue.Hour;
            int end = End.HasValue ? End.Value.Hour : DateTime.UtcNow.Hour;

            for (int hour = begin; hour <= end; hour++)
                hours.Add(hour);

            return hours.Order();
        }

        /// <summary>
        /// Get all days between dates
        /// </summary>
        /// <returns>List of days.</returns>
        public IEnumerable<int> GetDays()
        {
            IList<int> days = [];

            int begin = Start.HasValue ? Start.Value.Day : DateTime.MinValue.Day;
            int end = End.HasValue ? End.Value.Day : DateTime.UtcNow.Day;

            for (int day = begin; day <= end; day++)
                days.Add(day);

            return days.Distinct().Order();
        }

        /// <summary>
        /// Get all months between dates
        /// </summary>
        /// <returns>List of Months.</returns>
        public IEnumerable<Month> GetMonths()
        {
            IList<int> months = [];

            int begin = Start.HasValue ? Start.Value.Month : DateTime.MinValue.Month;
            int end = End.HasValue ? End.Value.Month : DateTime.UtcNow.Month;

            for (int month = begin; month <= end; month++)
                months.Add(month);

            return months.Distinct().Order().Select(m => GetByValue<Month>(m));
        }

        /// <summary>
        /// Get all years between dates
        /// </summary>
        /// <returns>List of years.</returns>
        public IEnumerable<int> GetYears()
        {
            IList<int> years = [];

            int begin = Start.HasValue ? Start.Value.Year : DateTime.MinValue.Year;
            int end = End.HasValue ? End.Value.Year : DateTime.UtcNow.Year;

            for (int year = begin; year <= end; year++)
                years.Add(year);

            return years;
        }

        /// <summary>
        /// Check if <see langword="object"/> has date
        /// </summary>
        /// <returns>True or false.</returns>
        public bool IsEmpty()
            => !Start.HasValue && !End.HasValue;

        /// <summary>
        /// Clears Stard and end dates
        /// </summary>
        /// <returns>Self for chain calls.</returns>
        public Period Clear()
        {
            Start = null;
            End = null;

            return this;
        }
    }
}