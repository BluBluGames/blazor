using System;
using System.Text.RegularExpressions;

namespace BluBlu.Common.Domain.ValueObjects;

public class NumericStringValueObject : StringValueObject
{
    protected NumericStringValueObject()
    {
    }

    protected NumericStringValueObject(string value, int? maxLength = null, int minLength = 1)
        : base(value, maxLength, minLength)
    {
        if (Value != null && !Regex.IsMatch(Value, @"^\d*$")) 
            throw new FormatException("Value is not numeric");
    }
}