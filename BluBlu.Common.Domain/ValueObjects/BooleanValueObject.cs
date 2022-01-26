using System;
using BluBlu.Common.Domain.ValueObjects.Base;

namespace BluBlu.Common.Domain.ValueObjects
{
    public abstract class BooleanValueObject : SingleValuedValueObject<bool>, IComparable, IComparable<BooleanValueObject>
    {
        protected BooleanValueObject()
        { }

        protected BooleanValueObject(bool value) : base(value)
        {
        }

        public static int Compare(BooleanValueObject? left, BooleanValueObject? right)
        {
            if (ReferenceEquals(left, right))
                return 0;

            return left?.CompareTo(right) ?? -1;
        }

        public virtual int CompareTo(object? obj)
        {
            if (obj == null)
                return 1;

            var other = obj as BooleanValueObject ?? throw new ArgumentException("A BooleanValueObject is required for comparison.", nameof(obj));

            return CompareTo(other);
        }

        public int CompareTo(BooleanValueObject? other)
        {
            return ReferenceEquals(other, null) ? 1 : Value.CompareTo(other.Value);
        }

        public override string ToString() => Value ? "True" : "False";
        
        public static implicit operator bool(BooleanValueObject boolean) => boolean.Value;
    }
}