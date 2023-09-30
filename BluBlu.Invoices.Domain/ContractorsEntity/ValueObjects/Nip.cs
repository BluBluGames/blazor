using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.ContractorsEntity.ValueObjects;

[BsonSerializer(typeof(MongoStringValueObjectSerializer<Nip>))]
public class Nip : NumericStringValueObject
{
    private static string EmptyValue => "0000000000";
    
    public Nip()
    {
    }

    public Nip(string value) : base(value, 10, 10)
    {
        if (Value != null && Value.Equals(EmptyValue))
            throw new ArgumentException("NIP cannot consist of only zeros", nameof(value));

        //if (!IsChecksumValid(Value))
            //throw new ArgumentException("Invalid NIP", nameof(value));
    }

    private bool IsChecksumValid(string? value)
    {
        var calculationDigits = value?.Substring(0, value.Length - 1);
        var controlDigit = int.Parse(value?.Substring(value.Length - 1, 1)!);

        var factors = new[] { 6, 5, 7, 2, 3, 4, 5, 6, 7 };

        var sum = calculationDigits!.Select((v, i) => factors[i] * (int)char.GetNumericValue(v)).Sum();

        return sum % 11 == controlDigit;
    }
}