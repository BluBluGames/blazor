using System;
using System.Globalization;
using BluBlu.Common.Domain.ValueObjects.Base;

namespace BluBlu.Common.Domain.ValueObjects
{
    public abstract class IntegerValueObject : SingleValuedValueObject<int>
    {
        private static readonly NumberFormatInfo NumberFormatInfo = new()
        {
            NumberGroupSizes = Array.Empty<int>()
        };

        protected IntegerValueObject()
        {
        }

        protected IntegerValueObject(int value, int? minValue = null, int? maxValue = null) : base(value)
        {
            if (value < minValue) throw new ArgumentOutOfRangeException(nameof(value), $"Value ({value}) is too low. Minimal accepted value ({minValue})");
            maxValue ??= int.MaxValue;
            minValue ??= int.MinValue;

            if (value < minValue) throw new ArgumentOutOfRangeException(nameof(value), $"Value ({value}) is too low. Minimal accepted value ({minValue})");
            if (value > maxValue) throw new ArgumentOutOfRangeException(nameof(value), $"Value ({value}) is too big. Maximal accepted value ({maxValue})");
        }

        public override string ToString() => Value.ToString(NumberFormatInfo);
    }
}