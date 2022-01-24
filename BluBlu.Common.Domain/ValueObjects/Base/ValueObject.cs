using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BluBlu.Common.Domain.ValueObjects.Comparers;

namespace BluBlu.Common.Domain.ValueObjects.Base;

public abstract class ValueObject : IEquatable<ValueObject>
{
    private static readonly ValueObjectEqualityComponentComparer Comparer = new();

    public override bool Equals(object? obj)
    {
        return Equals(obj as ValueObject);
    }

    public virtual bool Equals(ValueObject? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents(), Comparer!);
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Aggregate(1, (current, obj) =>
            {
                unchecked
                {
                    var hashCode = !(obj is string) && obj is IEnumerable enumerable
                        ? enumerable.Cast<object>().Aggregate(1, (sum, e) => sum + e.GetHashCode())
                        : obj?.GetHashCode() ?? 0;

                    return current * 23 + hashCode;
                }
            });
    }

    public static bool operator ==(ValueObject? a, ValueObject? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(ValueObject? a, ValueObject? b)
    {
        return !(a == b);
    }

    protected abstract IEnumerable<object?> GetEqualityComponents();
}