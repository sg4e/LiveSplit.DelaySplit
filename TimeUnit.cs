using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveSplit.DelaySplit
{
    public class TimeUnit
    {
        private const string StringMilliseconds = "milliseconds";
        private const string StringSeconds = "seconds";
        private const string StringMinutes = "minutes";
        private const string StringHours = "hours";

        public static readonly TimeUnit Milliseconds = new TimeUnit(StringMilliseconds, TimeSpan.FromMilliseconds);
        public static readonly TimeUnit Seconds = new TimeUnit(StringSeconds, TimeSpan.FromSeconds);
        public static readonly TimeUnit Minutes = new TimeUnit(StringMinutes, TimeSpan.FromMinutes);
        public static readonly TimeUnit Hours = new TimeUnit(StringHours, TimeSpan.FromHours);

        public string Name { get; private set; }
        private Func<double, TimeSpan> TimespanMethod;

        private TimeUnit(string name, Func<double, TimeSpan> timespanMethod)
        {
            this.Name = name;
            this.TimespanMethod = timespanMethod;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString() => Name;

        public static TimeUnit FromString(string name)
        {
            name = name.ToLowerInvariant();
            switch(name)
            {
                case StringMilliseconds:
                    return Milliseconds;
                case StringMinutes:
                    return Minutes;
                case StringHours:
                    return Hours;
                default:
                    return Seconds;
            }
        }

        public TimeSpan CreateTimespan(double quantity)
        {
            return TimespanMethod(quantity);
        }

        public TimeSpan CreateTimespan(string stringParseableAsDouble)
        {
            return CreateTimespan(Convert.ToDouble(stringParseableAsDouble));
        }

        public static TimeUnit[] enumerate()
        {
            return new[] { Milliseconds, Seconds, Minutes, Hours };
        }
    }
}
