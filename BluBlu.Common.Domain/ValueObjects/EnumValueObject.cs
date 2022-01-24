using System;
using BluBlu.Common.Domain.ValueObjects.Base;

namespace BluBlu.Common.Domain.ValueObjects;

public abstract class EnumValueObject<TEnum> : SingleValuedValueObject<TEnum>
    where TEnum : Enum
{
    public EnumValueObject()
    {
    }
    
    protected EnumValueObject(TEnum? value) : base(value)
    {
        if (value != null && !Enum.IsDefined(typeof(TEnum), value))
            throw new ArgumentOutOfRangeException(nameof(value), value, "Enum value is not defined");
    }

    public bool HasValue(TEnum value) => Value != null && Value.Equals(value);
    
    public override string? ToString() => Value?.ToString();
}