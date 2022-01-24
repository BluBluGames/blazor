using System;
using BluBlu.Common.Domain.ValueObjects.Base;

namespace BluBlu.Common.Domain.ValueObjects;

public abstract class GuidValueObject : SingleValuedValueObject<Guid>
{
    protected GuidValueObject()
    {
    }
    
    protected GuidValueObject(Guid value) : base(value)
    {
    }

    public override string ToString() => Value.ToString();
}