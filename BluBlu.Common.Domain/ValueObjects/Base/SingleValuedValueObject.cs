using System;
using System.Collections.Generic;

namespace BluBlu.Common.Domain.ValueObjects.Base;

public abstract class SingleValuedValueObject<TValue> : ValueObject, ISingleValuedValueObject
{
    public TValue? Value { get; protected set; }

    protected SingleValuedValueObject()
    {
    }
    
    protected SingleValuedValueObject(TValue? value)
    {
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}