using System;
using BluBlu.Common.Domain.ValueObjects.Base;

namespace BluBlu.Common.Domain.ValueObjects
{
    public abstract class DateTimeValueObject : SingleValuedValueObject<DateTime>, IComparable, IComparable<DateTimeValueObject>
    {
        private static readonly DateTime MinDateTime = new DateTime(1899, 1, 1);
        private static readonly DateTime MaxDateTime = new DateTime(2101, 1, 1);

        protected DateTimeValueObject()
        {
        }

        protected DateTimeValueObject(DateTime value)
            : base(value)
        {
            if (value < MinDateTime || value > MaxDateTime)
                throw new ArgumentOutOfRangeException(nameof(value), "Date exceeds allowed range");
        }

        public bool IsBetween(DateTimeValueObject? previous, DateTimeValueObject? next) => (IsAfter(previous)) && (IsBefore(next));

        public bool IsBefore(DateTimeValueObject? other) => CompareTo(other) < 0;
        public bool IsAfter(DateTimeValueObject? other) => CompareTo(other) > 0;

        public bool IsSameDateAs(DateTimeValueObject other) => Value.Date == other.Value.Date;

        public static int Compare(DateTimeValueObject? left, DateTimeValueObject? right)
        {
            if (ReferenceEquals(left, right))
                return 0;

            return left?.CompareTo(right) ?? -1;
        }

        public virtual int CompareTo(object? obj)
        {
            if (obj is null)
                return 1;

            var other = obj as DateTimeValueObject ?? throw new ArgumentException("A DateValueObject is required for comparison.", nameof(obj));

            return CompareTo(other);
        }

        public int CompareTo(DateTimeValueObject? other) => ReferenceEquals(other, null) ? 1 : DateTime.Compare(Value, other.Value);

        public static bool operator <(DateTimeValueObject? left, DateTimeValueObject? right) => Compare(left, right) < 0;
        public static bool operator >(DateTimeValueObject? left, DateTimeValueObject? right) => Compare(left, right) > 0;

        public static bool operator <=(DateTimeValueObject? left, DateTimeValueObject? right) => Compare(left, right) <= 0;
        public static bool operator >=(DateTimeValueObject? left, DateTimeValueObject? right) => Compare(left, right) >= 0;
        
        public override string ToString() => Value.ToString("dd/MM/yyyy HH:mm:ss");
        
        public static implicit operator DateTime(DateTimeValueObject dateTimeValueObject) => dateTimeValueObject.Value;
    }
}
