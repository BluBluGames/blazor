using System;
using System.Globalization;
using BluBlu.Common.Domain.ValueObjects.Base;

namespace BluBlu.Common.Domain.ValueObjects
{
    public abstract class DecimalValueObject : SingleValuedValueObject<decimal>, IComparable<DecimalValueObject>
    {
        private readonly int? _precision;

        private static readonly NumberFormatInfo NumberFormatInfo = new NumberFormatInfo
        {
            NumberDecimalSeparator = ",",
            NumberGroupSizes = Array.Empty<int>()
        };

        protected DecimalValueObject(int? precision)
        {
            _precision = precision;
        }

        protected DecimalValueObject(decimal value, int? precision, decimal? minValue, decimal? maxValue) : base(value)
        {
            if (minValue.HasValue && value < minValue.Value)
                throw new ArgumentOutOfRangeException(nameof(value), value, $"Value too small. Value must be greater or equal {minValue}");

            if (maxValue.HasValue && value > maxValue.Value)
                throw new ArgumentOutOfRangeException(nameof(value), value, $"Value too big. Value must be less or equal {maxValue}");

            if (precision.HasValue && value != Math.Round(value, precision.Value))
                throw new ArgumentException($"Too big precision. Value: {value}  Max allowed precision: {precision}", nameof(value));

            _precision = precision;
        }
        
        public override string ToString() => Value.ToString(Format(), NumberFormatInfo);

        private string Format() => _precision == null
                                        ? $"0.{new string('#', 28)}"
                                        : "0.".PadRight(_precision.Value + 2 /*"0."*/, '0');

        public int CompareTo(DecimalValueObject? other)
        {
            return ReferenceEquals(other, null) ? 1 : decimal.Compare(Value, other.Value);
        }

        public static int Compare(DecimalValueObject? left, DecimalValueObject? right)
        {
            if (ReferenceEquals(left, right))
                return 0;

            return left?.CompareTo(right) ?? -1;
        }

        public static bool operator <(DecimalValueObject? left, DecimalValueObject? right) => Compare(left, right) < 0;

        public static bool operator <=(DecimalValueObject? left, DecimalValueObject? right) => Compare(left, right) <= 0;

        public static bool operator >(DecimalValueObject? left, DecimalValueObject? right) => Compare(left, right) > 0;

        public static bool operator >=(DecimalValueObject? left, DecimalValueObject? right) => Compare(left, right) >= 0;
    }
}