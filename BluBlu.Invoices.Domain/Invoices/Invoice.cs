using BluBlu.Invoices.Domain.Invoices.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.Invoices;

public class Invoice
{
    [BsonId] [BsonRepresentation(BsonType.ObjectId)] [BsonIgnoreIfDefault] public string Id { get; set; }
    [BsonElement("InvoiceNumber")] public string InvoiceNumber { get; set; }
    [BsonElement("DateOfInvoice")] public DateTime DateOfInvoice { get; set; }
    [BsonElement("DateOfRelease")] public DateTime DateOfRelease { get; set; }
    [BsonElement("DateOfPayment")] public DateTime DateOfPayment { get; set; }
    [BsonElement("FormOfPayment")] public string FormOfPayment { get; set; }
    [BsonElement("AccountNumber")] public string AccountNumber { get; set; }
    [BsonElement("IsPaymentDivided")] public bool IsPaymentDivided { get; set; }
    [BsonElement("IsPaid")] public bool IsPaid { get; set; }
    [BsonElement("Remarks")] public string Remarks { get; set; }
    [BsonElement("Seller")] public Contractor Seller { get; set; }
    [BsonElement("Buyer")] public Contractor Buyer { get; set; }
    [BsonElement("Products")] public ICollection<Product> Products { get; set; }
}