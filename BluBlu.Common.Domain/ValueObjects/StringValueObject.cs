using System;
using System.Collections.Generic;
using BluBlu.Common.Domain.ValueObjects.Base;

namespace BluBlu.Common.Domain.ValueObjects;

public abstract class StringValueObject : SingleValuedValueObject<string>
{
    public StringValueObject()
    {
    }
    
    protected StringValueObject(string value, int? maxLength = null, int minLength = 1) : base(value.Trim())
    {
        if (minLength < 1) 
            throw new ArgumentOutOfRangeException(nameof(minLength), minLength, "MinLength cannot be smaller than 1");

        if(maxLength < minLength)
            throw new ArgumentOutOfRangeException(nameof(maxLength), maxLength, "MaxLength cannot be smaller than MinLength");

        if (Value != null && Value.Length < minLength)
            throw new ArgumentOutOfRangeException(nameof(value), value, $"Value too short ({minLength})");

        if (Value != null && maxLength.HasValue && Value.Length > maxLength.Value)
            throw new ArgumentOutOfRangeException(nameof(value), value, $"Value too long ({maxLength})");
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value?.ToLower();
    }

    public override string? ToString() => Value;
}