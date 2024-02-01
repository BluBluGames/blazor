using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;

[BsonSerializer(typeof(MongoStringValueObjectSerializer<AccountNumber>))]
public class AccountNumber : StringValueObject
{
    private static string EmptyValue => "0000000000";
    
    public AccountNumber()
    {
    }

    public AccountNumber(string value) : base(value, 100, 5)
    {
        if (Value != null && Value.Equals(EmptyValue))
            throw new ArgumentException("Account number cannot consist of only zeros", nameof(value));
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch (FormatException)
        {
            return false;
        }
    }
}