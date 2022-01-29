using System;

namespace BluBlu.Common.Domain.ValueObjects
{
    public abstract class DateValueObject : DateTimeValueObject, IComparable<DateValueObject>
    {
        private static readonly DateTime MinDate = new DateTime(1899, 1, 1);
        public static readonly DateTime MaxDate = new DateTime(2100, 12, 31);

        protected DateValueObject()
        {
        }

        protected DateValueObject(DateTime value) : base(value)
        {
            if (!IsDateOnly(value))
                throw new ArgumentOutOfRangeException(nameof(value), "Argument should only contain date");

            if (value < MinDate || value > MaxDate)
                throw new ArgumentOutOfRangeException(nameof(value), "Date exceeds allowed range");
        }

        private bool IsDateOnly(DateTime value)
        {
            var date = value.Date;

            return value.Equals(date);
        }

        public bool IsWeekend() => Value.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;

        public bool IsSunday() => Value.DayOfWeek is DayOfWeek.Sunday;

        public bool IsSaturday() => Value.DayOfWeek is DayOfWeek.Saturday;

        public bool IsBetween(DateValueObject? previous, DateValueObject? next) => (previous == null || IsAfter(previous)) && (next == null || IsBefore(next));

        public bool IsSameAs(DateValueObject? other) => CompareTo(other) == 0;
        public bool IsBefore(DateValueObject? other) => CompareTo(other) < 0;
        public bool IsAfter(DateValueObject? other) => CompareTo(other) > 0;

        public bool IsSameYearAs(DateValueObject date) => Value.Year == date.Value.Year;

        public static int Compare(DateValueObject left, DateValueObject? right)
        {
            if (ReferenceEquals(left, right))
                return 0;

            return left?.CompareTo(right) ?? -1;
        }

        public override int CompareTo(object? obj)
        {
            if (obj == null)
                return 1;

            var other = obj as DateValueObject ?? throw new ArgumentException("A DateValueObject is required for comparison.", nameof(obj));

            return CompareTo(other);
        }

        public int CompareTo(DateValueObject? other) => ReferenceEquals(other, null) ? 1 : DateTime.Compare(Value, other.Value);

        public static bool operator <(DateValueObject left, DateValueObject? right) => Compare(left, right) < 0;
        public static bool operator >(DateValueObject left, DateValueObject? right) => Compare(left, right) > 0;

        public static bool operator <=(DateValueObject left, DateValueObject? right) => Compare(left, right) <= 0;
        public static bool operator >=(DateValueObject left, DateValueObject? right) => Compare(left, right) >= 0;


        public override string ToString() => Value.ToString("dd-MM-yyyy");
    }
}